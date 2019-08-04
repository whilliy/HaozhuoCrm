using Haozhuo.Crm.Service;
using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
using Haozhuo.Crm.Service.vo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace HaoZhuoCRM
{
    public partial class FormImportData : Form
    {
        private const string XLS = ".XLS";
        private const string XLSX = ".XLSX";
        private const string CVS = ".CVS";
        private const int indexSequence = 1;
        private const int indexName = 2;
        private const int indexMobile = 3;
        private const int indexLeaveWordsTime = 4;
        private const int indexRegion = 5;
        private const int indexSource = 6;
        private const int ColumnCount = 6;
        public FormImportData()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormImportData_Load(object sender, EventArgs e)
        {
            //获取项目列表
            try
            {
                IList<ProjectDto> projects = ProjectService.ProjectsCopy;
                cmbProjects.DisplayMember = "name";
                cmbProjects.ValueMember = "id";
                cmbProjects.DataSource = projects;
            }
            catch (BusinessException ex)
            {
                MessageBox.Show("获取项目列表发生错误：" + ex.Message);
                return;
            }
            //加载客户来源
            IList<CustomerSourceDto> sources = new List<CustomerSourceDto>();
            try
            {
                sources = CustomerService.CustomerSourcesCopy();
                cmbCustomerSources.ValueMember = "id";
                cmbCustomerSources.DisplayMember = "name";
                cmbCustomerSources.DataSource = sources;
            }
            catch (BusinessException ex)
            {
                MessageBox.Show("获取所有客户来源时发生错误:" + ex.Message);
                return;
            }
        }

        private void ParseRegion(String region, out ProvinceDto province, out CityDto city)
        {
            province = new ProvinceDto();
            city = new CityDto();
            var regions = region.Split(new char[] { '+', ',', '，' });
            if (regions.Length < 1)
            {
                throw new Exception("地区[" + region + "]格式错误，必须为 省+市");
            }
            province.provinceName = regions[0];
            var provinceId = RegionService.getProvinceIdByName(province.provinceName);
            if (provinceId == null)
            {
                throw new Exception("系统暂时不识别的省份名称:" + province.provinceName);
            }
            province.provinceId = provinceId;
            if (regions.Length > 1)
            {
                city.cityName = regions[1];
                var cityId = RegionService.getCityIdByName(provinceId, regions[1]);
                if (cityId == null)
                {
                    throw new Exception("系统暂时不识别的城市（地区）名称:" + regions[1]);
                }
                city.cityId = cityId;
            }
        }

        private void ButOpen_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                Cursor = Cursors.WaitCursor;
                txtFile.Text = openFileDialog.FileName;
                string fileExtension = Path.GetExtension(openFileDialog.FileName);
                String fileExtensionUpperCase = fileExtension.ToUpper();
                IList<CustomerData> datas = new List<CustomerData>();
                if (fileExtensionUpperCase == XLS || fileExtensionUpperCase == XLSX)
                {
                    #region 从文件中读取数据
                    Excel.Application App = null;
                    Excel.Workbook WorkBook = null;
                    Excel.Worksheet WorkSheeet = null;
                    try
                    {
                        App = new Excel.Application();
                        App.Visible = false;
                        App.UserControl = true;
                        WorkBook = App.Workbooks.Open(openFileDialog.FileName,
                           Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                           Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        WorkSheeet = (Excel.Worksheet)WorkBook.Worksheets[1];
                        int columnCount = WorkSheeet.UsedRange.Cells.Columns.Count;
                        if (columnCount < ColumnCount)
                        {
                            throw new Exception("数据表格式错误，列数不能少于6");
                        }
                        int rowCount = WorkSheeet.UsedRange.Cells.Rows.Count;
                        Excel.Range range = WorkSheeet.UsedRange;
                        for (int row = 1; row <= rowCount; row++)
                        {
                            var data = new CustomerData();
                            for (int column = 1; column < columnCount; column++)
                            {
                                //定义单元格对象
                                var value2 = ((Excel.Range)range.Cells[row, column]).Value2;
                                string strValue = (value2 == null) ? "" : value2.ToString();
                                if (column == indexSequence)
                                {
                                    data.Sequence = strValue;
                                }
                                else if (column == indexName)
                                {
                                    data.name = strValue;
                                }
                                else if (column == indexMobile)
                                {
                                    data.mobile = strValue;
                                }
                                else if (column == indexLeaveWordsTime)
                                {
                                    DateTime dt;
                                    if (!DateTime.TryParse(strValue, out dt))
                                    {
                                        throw new Exception("第 " + row + " 行留言时间格式错误，必须为 yyyy-MM-dd HH:mm:ss");
                                    }
                                    data.leaveWordsTime = dt;
                                }
                                else if (column == indexRegion)
                                {
                                    ProvinceDto province;
                                    CityDto city;
                                    try
                                    {
                                        ParseRegion(strValue, out province, out city);
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Exception("第 " + row + " 行地区有误：" + ex.Message);
                                    }
                                    data.Region = strValue;
                                    data.provinceName = province.provinceName;
                                    data.cityName = city.cityName;
                                    data.cityId = city.cityId;
                                    data.provinceId = province.provinceId;
                                }
                            }
                            datas.Add(data);
                        }
                    }
                    catch (Exception ex)
                    {
                        Cursor = Cursors.Default;
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    finally
                    {
                        if (WorkBook != null) { WorkBook.Close(true, null, null); }
                        if (App != null) { App.Quit(); }
                        if (WorkSheeet != null) { Marshal.ReleaseComObject(WorkSheeet); }
                        if (WorkBook != null) { Marshal.ReleaseComObject(WorkBook); }
                        if (App != null) { Marshal.ReleaseComObject(App); }
                        Cursor = Cursors.Default;
                    }
                    #endregion
                    Cursor = Cursors.Default;
                    lvCustomers.Items.Clear();
                    Cursor = Cursors.WaitCursor;
                    foreach (CustomerData data in datas)
                    {
                        ListViewItem lvi = new ListViewItem(data.Sequence);
                        lvi.SubItems.Add(data.name);
                        lvi.SubItems.Add(data.mobile);
                        lvi.SubItems.Add(data.leaveWordsTime.HasValue ? data.leaveWordsTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : "");
                        lvi.SubItems.Add(data.Region);
                        lvi.SubItems.Add(data.provinceName == null ? "" : data.provinceName);
                        lvi.SubItems.Add(data.cityName == null ? "" : data.cityName);
                        lvi.Tag = data;
                        lvCustomers.Items.Add(lvi);
                    }
                    Cursor = Cursors.Default;
                }
                else
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("暂不支持的文件格式！", "提示");
                }
                Cursor = Cursors.Default;
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (lvCustomers.Items.Count < 1)
            {
                MessageBox.Show("请先加载数据到列表中！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            ImportCustomerVo vo = new ImportCustomerVo();
            vo.projectId = Convert.ToInt32(cmbProjects.SelectedValue.ToString());
            vo.source = Convert.ToInt32(cmbCustomerSources.SelectedValue.ToString());
            vo.customers = new List<CustomerData>();
            foreach (ListViewItem lvi in lvCustomers.Items)
            {
                vo.customers.Add((CustomerData)lvi.Tag);
            }
            try
            {
                Cursor = Cursors.WaitCursor;
                CustomerService.ImportCustomerData(vo, Global.USER_TOKEN);
                Cursor = Cursors.Default;
                if (DialogResult.Yes != MessageBox.Show("导入数据成功！您是否需要继续导入新的数据？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    DialogResult = DialogResult.OK;
                    return;
                }
                lvCustomers.Items.Clear();
                txtFile.Text = String.Empty;
                butOpen.Focus();
            }
            catch (BusinessException ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("导入数据失败:" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lvCustomers.SelectedItems.Count < 1)
            {
                MessageBox.Show("请选择要删除的客户数据（不会影响数据文件）", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            foreach (ListViewItem lvi in lvCustomers.SelectedItems)
            {
                lvCustomers.Items.Remove(lvi);
            }
        }
    }
}
