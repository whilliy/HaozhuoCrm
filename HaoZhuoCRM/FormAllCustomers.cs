using Haozhuo.Crm.Service;
using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
using HaoZhuoCRM.Utils;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace HaoZhuoCRM
{
    public partial class FormAllCustomers : Form
    {
        private ResultsWithCount<CustomerDto> customers = new ResultsWithCount<CustomerDto>();
        public FormAllCustomers()
        {
            InitializeComponent();
        }

        private void FormPublic_Load(object sender, EventArgs e)
        {
            dtpLeaveWordsTimeEnd.Value = dtpLeaveWordsTimeBegin.Value = DateTime.Now;
            //获取所有的客户状态
            IList<CustomerStatus> customerStatuses = new List<CustomerStatus>();
            try
            {
                cmbStatus.DisplayMember = "name";
                cmbStatus.ValueMember = "id";
                customerStatuses = CustomerService.CustomerStatusesCopy();
                customerStatuses.Insert(0, new CustomerStatus(-1, ""));
                cmbStatus.DataSource = customerStatuses;
            }
            catch (BusinessException ex)
            {
                MessageBox.Show("加载客户状态发生错误：" + ex.Message);
                return;
            }
            //加载客户类型
            IList<CustomerTypeDto> types = new List<CustomerTypeDto>();
            try
            {
                types = CustomerService.CustomerTypesCopy();
                types.Insert(0, new CustomerTypeDto() { id = -1, name = "" });
                cmbCustomerTypes.ValueMember = "id";
                cmbCustomerTypes.DisplayMember = "name";
                cmbCustomerTypes.DataSource = types;
            }
            catch (BusinessException ex)
            {
                MessageBox.Show("获取所有客户类型时发生错误:" + ex.Message);
                return;
            }
            //获取项目列表
            try
            {
                IList<ProjectDto> projects = ProjectService.ProjectsCopy;
                projects.Insert(0, new ProjectDto(-1, ""));
                cmbProjects.DisplayMember = "name";
                cmbProjects.ValueMember = "id";
                cmbProjects.DataSource = projects;
                //cmbPagesizes.Text = PageSize.ToString();
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
                sources.Insert(0, new CustomerSourceDto() { id = -1, name = "" });
                cmbCustomerSources.ValueMember = "id";
                cmbCustomerSources.DisplayMember = "name";
                cmbCustomerSources.DataSource = sources;
            }
            catch (BusinessException ex)
            {
                MessageBox.Show("获取所有客户来源时发生错误:" + ex.Message);
                return;
            }

            //加载省
            IList<ProvinceDto> provinces = null;
            try
            {
                provinces = RegionService.PROVINCES_COPY;
            }
            catch (BusinessException ex)
            {
                MessageBox.Show("获取省/自治区/直辖市列表失败:" + ex.Message);
                return;
            }
            provinces.Insert(0, new ProvinceDto(string.Empty, String.Empty));
            //注意：一定先指定 ValueMember 和 DisplayMember 再设定 DataSource 否则提前触发 CmbProvinces_SelectedIndexChanged
            cmbProvinces.ValueMember = "provinceId";
            cmbProvinces.DisplayMember = "provinceName";
            cmbProvinces.DataSource = provinces;
            pager.Reset();
            //查询
            Query();
        }



        private ResultsWithCount<CustomerDto> QueryCustomers()
        {
            txtName.Text = txtName.Text.Trim();
            txtMobile.Text = txtMobile.Text.Trim();
            String provinceId = cmbProvinces.SelectedValue != null ? cmbProvinces.SelectedValue.ToString() : String.Empty;
            String cityId = cmbCities.SelectedValue != null ? cmbCities.SelectedValue.ToString() : String.Empty;
            String countyId = cmbCounties.SelectedValue != null ? cmbCounties.SelectedValue.ToString() : String.Empty;
            Int32? projectId = null;
            if (cmbProjects.SelectedValue != null)
            {
                projectId = Convert.ToInt32(cmbProjects.SelectedValue.ToString());
                if (projectId == -1)
                {
                    projectId = null;
                }
            }
            Int32? status = null;
            if (cmbStatus.SelectedValue != null)
            {
                status = Convert.ToInt32(cmbStatus.SelectedValue.ToString());
                if (status == -1)
                {
                    status = null;
                }
            }
            Int32? source = null;
            if (cmbCustomerSources.SelectedValue != null)
            {
                source = Convert.ToInt32(cmbCustomerSources.SelectedValue.ToString());
                if (source == -1)
                {
                    source = null;
                }
            }
            Int32? type = null;
            if (cmbCustomerTypes.SelectedValue != null)
            {
                type = Convert.ToInt32(cmbCustomerTypes.SelectedValue.ToString());
                if (type == -1)
                {
                    type = null;
                }
            }
            Int64? currentUserId = null;
            if (txtFollowUserName.Tag != null && !String.IsNullOrEmpty(txtFollowUserName.Text))
            {
                currentUserId = Convert.ToInt64(txtFollowUserName.Tag.ToString());
            }
            String leaveWordsTimeBegin = null, leaveWordsTimeEnd = null;
            if (cbLeaveWordsTime.Checked)
            {
                if (dtpLeaveWordsTimeBegin.Value.CompareTo(dtpLeaveWordsTimeEnd.Value) > 0)
                {
                    throw new BusinessException("留言范围的截至时间不能早于起始时间");
                }
                leaveWordsTimeBegin = dtpLeaveWordsTimeBegin.Value.ToString("yyyy-MM-dd");
                leaveWordsTimeEnd = dtpLeaveWordsTimeEnd.Value.ToString("yyyy-MM-dd");
            }
            ResultsWithCount<CustomerDto> customers = CustomerService.QueryCustomers(Global.USER_TOKEN, pager.PageIndex, pager.PageSize,
                projectId, status, source, type, txtName.Text, txtMobile.Text, currentUserId, provinceId, cityId, countyId, leaveWordsTimeBegin, leaveWordsTimeEnd);
            return customers;
        }

        private void BindingData(Int32 sequence, CustomerDto customer)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.UseItemStyleForSubItems = false;
            lvi.SubItems.Add(sequence.ToString());
            if (customer.projectId.HasValue && ProjectService.DicProjects.ContainsKey(customer.projectId.Value))
            {
                lvi.SubItems.Add(ProjectService.DicProjects[customer.projectId.Value]);
            }
            else
            {
                lvi.SubItems.Add("");
            }
            lvi.SubItems.Add(customer.name);
            lvi.SubItems.Add(Genders.DIC_GENDER[customer.gender]);
            lvi.SubItems.Add(customer.mobile);
            lvi.SubItems.Add(customer.type.HasValue ? CustomerService.DicCustomerTypes[customer.type.Value] : "");
            ListViewItem.ListViewSubItem lviType = lvi.SubItems.Add(customer.status.HasValue ? CustomerService.DicCustomerStatuses[customer.status.Value] : "");
            if (customer.status.HasValue && CustomerService.CUSTOMER_STATUS_INIT == customer.status.Value)
            {
                lviType.BackColor = Color.MistyRose;
            }
            lvi.SubItems.Add(customer.currentUserName);
            ListViewItem.ListViewSubItem lviSource = lvi.SubItems.Add(CustomerService.DicCustomerSources[customer.source]);
            if (CustomerService.CUSTOMER_SOURCE_DATABASE == customer.source)
            {
                lviSource.BackColor = Color.GreenYellow;
            }
            lvi.SubItems.Add(customer.provinceName);
            lvi.SubItems.Add(customer.cityName);
            lvi.SubItems.Add(customer.countyName);
            lvi.SubItems.Add(!customer.leaveWordsTime.HasValue ? "" : customer.leaveWordsTime.Value.ToString(GlobalConfig.DateTimeFormat));
            lvi.SubItems.Add(customer.createdTime == null ? "" : customer.createdTime.ToString(GlobalConfig.DateTimeFormat));
            lvi.SubItems.Add(!customer.previousFollowTime.HasValue ? "" : customer.previousFollowTime.Value.ToString(GlobalConfig.DateTimeFormat));
            lvi.SubItems.Add(customer.previousFollowUserName);
            lvi.SubItems.Add(!customer.lastFollowTime.HasValue ? "" : customer.lastFollowTime.Value.ToString(GlobalConfig.DateTimeFormat));
            lvi.SubItems.Add(customer.lastFollowUserName);
            lvi.SubItems.Add(!customer.nextFollowTime.HasValue ? "" : customer.nextFollowTime.Value.ToString(GlobalConfig.DateTimeFormat));
            lvi.Tag = customer;
            lvClients.Items.Add(lvi);
        }

        private void BindingDatas(ResultsWithCount<CustomerDto> customers)
        {
            if (lvClients.Items.Count > 0)
            {
                lvClients.Items.Clear();
            }
            lvClients.BeginUpdate();
            int i = 1 + (pager.PageSize) * (pager.PageIndex - 1);//计算序号
            foreach (CustomerDto customer in customers.getResults())
            {
                BindingData(i, customer);
                i++;
            }
            lvClients.EndUpdate();
        }

        private void Query()
        {
            try
            {
                //查询符合条件的记录
                customers = QueryCustomers();
                pager.PageIndex = 1;
                pager.DrawControl((int)customers.getCount());
                //将数据绑定到ListView
                BindingDatas(customers);
                pager.NeedExcuteQuery = true;
            }
            catch (BusinessException ex)
            {
                MessageBox.Show("查询失败：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ButQuery_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void Pager_OnPageChanged(object sender, EventArgs e)
        {
            try
            {
                ResultsWithCount<CustomerDto> customers = QueryCustomers();
                //将数据绑定到ListView
                BindingDatas(customers);
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButReset_Click(object sender, EventArgs e)
        {
            txtMobile.Text = txtName.Text = string.Empty;
            cmbProjects.SelectedIndex = 0;
            cmbCustomerTypes.SelectedIndex = 0;
            cmbCustomerSources.SelectedIndex = 0;
            cmbProvinces.SelectedIndex = 0;
            lvClients.Items.Clear();
            txtFollowUserName.Tag = null;
            txtFollowUserName.Text = "";
            cbLeaveWordsTime.Checked = false;
            pager.Reset();
            txtName.Focus();
            customers = new ResultsWithCount<CustomerDto>();

        }

        private void Modify()
        {
            if (lvClients.SelectedItems.Count < 1)
            {
                MessageBox.Show("请选择要修改的客户记录");
                return;
            }
            ListViewItem lviSelected = lvClients.SelectedItems[0];
            CustomerDto customer = (CustomerDto)lviSelected.Tag;
            FormModifyCustomer modifyCustomer = new FormModifyCustomer(customer);
            if (DialogResult.OK == modifyCustomer.ShowDialog())
            {
                if (modifyCustomer.InformationChanged)
                {
                    CustomerDto currentCustomer = modifyCustomer.CURRENT_CUSTOMER;
                    lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "姓名").Value].Text = currentCustomer.name;
                    if (currentCustomer.projectId.HasValue && ProjectService.DicProjects.ContainsKey(currentCustomer.projectId.Value))
                    {
                        lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "所属项目").Value].Text =
                            ProjectService.DicProjects[currentCustomer.projectId.Value];
                    }
                    else
                    {
                        lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "所属项目").Value].Text = "";
                    }
                    lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "性别").Value].Text = Genders.DIC_GENDER[currentCustomer.gender];
                    lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "手机号码").Value].Text = currentCustomer.mobile;
                    lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "当前跟进人").Value].Text = currentCustomer.currentUserName;
                    lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "客户类型").Value].Text = currentCustomer.type.HasValue ? CustomerService.DicCustomerTypes[currentCustomer.type.Value] : "";
                    lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "客户状态").Value].Text = currentCustomer.status.HasValue ? CustomerService.DicCustomerStatuses[currentCustomer.status.Value] : "";
                    lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "客户来源").Value].Text = CustomerService.DicCustomerSources[currentCustomer.source];
                    lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "省").Value].Text = currentCustomer.provinceName;
                    lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "市").Value].Text = currentCustomer.cityName;
                    lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "区").Value].Text = currentCustomer.countyName;
                    lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "留言时间").Value].Text = !currentCustomer.leaveWordsTime.HasValue ? "" : currentCustomer.leaveWordsTime.Value.ToString(GlobalConfig.DateTimeFormat);
                    lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "录入时间").Value].Text = currentCustomer.createdTime.ToString(GlobalConfig.DateTimeFormat);
                    lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "上次跟进时间").Value].Text = !currentCustomer.previousFollowTime.HasValue ? "" : currentCustomer.previousFollowTime.Value.ToString(GlobalConfig.DateTimeFormat);
                    lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "上次跟进人").Value].Text = currentCustomer.previousFollowUserName;
                    lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "最后跟进时间").Value].Text = !currentCustomer.lastFollowTime.HasValue ? "" : currentCustomer.lastFollowTime.Value.ToString(GlobalConfig.DateTimeFormat);
                    lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "最后跟进人").Value].Text = currentCustomer.lastFollowUserName;
                    lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "下次跟进时间").Value].Text = !currentCustomer.nextFollowTime.HasValue ? "" : currentCustomer.nextFollowTime.Value.ToString(GlobalConfig.DateTimeFormat);
                    lviSelected.Tag = currentCustomer;
                }

            }
            modifyCustomer.Close();

        }

        private void LvClients_DoubleClick(object sender, EventArgs e)
        {
            View();
        }

        private void MiModify_Click(object sender, EventArgs e)
        {
            Modify();
        }

        private void CmbProvinces_SelectedIndexChanged(object sender, EventArgs e)
        {
            var provinceIdObj = cmbProvinces.SelectedValue;
            if (provinceIdObj == null)
            {
                cmbCities.DataSource = null;
                cmbCities.Items.Clear();
                return;
            }
            var provinceId = provinceIdObj.ToString();
            if (String.IsNullOrEmpty(provinceId))
            {
                cmbCities.DataSource = null;
                cmbCities.Items.Clear();
                return;
            }
            IList<CityDto> cities = null;
            try
            {
                cities = RegionService.getCitiesByProviceId(provinceId);
            }
            catch (BusinessException ex)
            {
                MessageBox.Show("获取省/自治区/直辖市列表失败:" + ex.Message);
                return;

            }
            cities.Insert(0, new CityDto(String.Empty, String.Empty));
            cmbCities.ValueMember = "cityId";
            cmbCities.DisplayMember = "cityName";
            cmbCities.DataSource = cities;

        }

        private void CmbCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            object obj = cmbCities.SelectedValue;
            if (obj == null)
            {
                cmbCounties.DataSource = null;
                cmbCounties.Items.Clear();
                return;
            }
            var cityId = obj.ToString();
            if (String.IsNullOrEmpty(cityId))
            {
                cmbCounties.DataSource = null;
                cmbCounties.Items.Clear();
                return;
            }
            IList<CountyDto> counties = new List<CountyDto>();
            try
            {
                counties = RegionService.getCountiesByCityId(cityId);
            }
            catch (BusinessException ex)
            {
                MessageBox.Show("获取 县/市/区 列表失败:" + ex.Message);
            }
            counties.Insert(0, new CountyDto(String.Empty, String.Empty));
            cmbCounties.ValueMember = "countyId";
            cmbCounties.DisplayMember = "countyName";
            cmbCounties.DataSource = counties;
            return;
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            FormSelectUser frmSelectUser = new FormSelectUser();
            if (DialogResult.OK == frmSelectUser.ShowDialog())
            {
                txtFollowUserName.Text = frmSelectUser.SelectedUser.name;
                txtFollowUserName.Tag = frmSelectUser.SelectedUser.id;
            }
            frmSelectUser.Close();
        }

        private void View()
        {
            if (lvClients.SelectedItems.Count < 1)
            {
                MessageBox.Show("请选择要查看的客户记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            IList<CustomerDto> customers = new List<CustomerDto>();
            foreach (ListViewItem lvi in lvClients.Items)
            {
                customers.Add((CustomerDto)lvi.Tag);
            }
            var customer = (CustomerDto)lvClients.SelectedItems[0].Tag;
            FormViewCustomer formViewCustomer = new FormViewCustomer(customers, lvClients.SelectedItems[0].Index);
            formViewCustomer.ShowDialog();
            formViewCustomer.Close();
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            View();
        }

        private void BtnFollow_Click(object sender, EventArgs e)
        {
            Modify();
        }

        private void MiView_Click(object sender, EventArgs e)
        {
            View();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CbLeaveWordsTime_CheckedChanged(object sender, EventArgs e)
        {
            dtpLeaveWordsTimeBegin.Enabled = dtpLeaveWordsTimeEnd.Enabled = cbLeaveWordsTime.Checked;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (lvClients.CheckedItems.Count < 1)
            {
                MessageBox.Show("请在需要转移的客户记录前打勾✔", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            IList<String> customerIds = new List<String>();
            foreach (ListViewItem lvi in lvClients.CheckedItems)
            {
                CustomerDto customer = (CustomerDto)lvi.Tag;
                //if (!customer.projectId.HasValue)
                //{
                //    MessageBox.Show("姓名为【" + customer.name + "】，手机号码为【" + customer.mobile + "】的客户当前不属于任何项目，不能进行该操作"
                //        ,"提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                //    return;
                //}
                //if (customer.currentUserId <= 0 || customer.currentUserName == String.Empty)
                //{
                //如果当前不属于任何用户相当于分派了！
                //}
                customerIds.Add(customer.id);
            }
            IList<UserDto> userTargets = null;
            try
            {
                userTargets = UserService.GetUsersSameByOrganization(Global.USER_TOKEN, true);
            }
            catch (BusinessException ex)
            {
                MessageBox.Show("获取部门用户列表失败：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            FormAllCustomersTransferToOther frmTransfer = new FormAllCustomersTransferToOther(customerIds, userTargets);
            if (frmTransfer.ShowDialog() != DialogResult.OK)
            {
                frmTransfer.Close();
                return;
            }
            frmTransfer.Close();

            foreach (ListViewItem lvi in lvClients.CheckedItems)
            {
                lvClients.Items.Remove(lvi);
            }

        }

        private void CbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lvClients.Items)
            {
                lvi.Checked = cbSelectAll.Checked;
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            if (lvClients.Items.Count < 1)
            {
                MessageBox.Show("请先根据条件查询，再进行到处操作", "提示");
                return;
            }
            DialogResult dialogResult = saveFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                //MessageBox.Show(saveFileDialog.FileName);
                XSSFWorkbook workbook = new XSSFWorkbook();
                XSSFSheet sheet = (XSSFSheet)workbook.CreateSheet();
                IRow rowTitle = sheet.CreateRow(0);
                ICell cellSequence = rowTitle.CreateCell(0);
                cellSequence.SetCellValue("序号");
                ICellStyle style = workbook.CreateCellStyle();
                style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                style.VerticalAlignment = VerticalAlignment.Center;
                cellSequence.CellStyle = style;
                ICell cellCustomerName = rowTitle.CreateCell(1);
                cellCustomerName.SetCellValue("姓名");
                ICell cellLeaveWordsTime = rowTitle.CreateCell(2);
                sheet.SetColumnWidth(cellLeaveWordsTime.ColumnIndex, 20 * 256);//列宽
                cellLeaveWordsTime.SetCellValue("留言时间");
                cellLeaveWordsTime.CellStyle = style;
                ICell cellCurrentUserName = rowTitle.CreateCell(3);
                cellCurrentUserName.SetCellValue("当前跟进人");
                ICell cellRemark = rowTitle.CreateCell(4);
                cellRemark.SetCellValue("跟进信息");
                sheet.SetColumnWidth(cellRemark.ColumnIndex, 100 * 256);//指定列宽
                for (int i = 0; i < customers.getResults().Count; i++)
                {
                    CustomerDto customer = customers.getResults()[i];
                    IRow row = sheet.CreateRow(1 + i);
                    row.CreateCell(cellSequence.ColumnIndex).SetCellValue(i + 1);
                    row.CreateCell(cellCustomerName.ColumnIndex).SetCellValue(customer.name);
                    row.CreateCell(cellLeaveWordsTime.ColumnIndex).SetCellValue(customer.leaveWordsTime.HasValue ? customer.leaveWordsTime.Value.ToString(GlobalConfig.DateTimeFormat) : "");
                    row.CreateCell(cellCurrentUserName.ColumnIndex).SetCellValue(customer.currentUserName);
                    IList<CustomerFollowRecord> records = CustomerService.GetFollowerRecordsByCusotmerId(customer.id, Global.USER_TOKEN);
                    if (records != null)
                    {
                        StringBuilder sb = new StringBuilder();
                        for (int j = records.Count; j >= 1; j--)
                        {
                            sb.Append("第 ").Append(records.Count - j + 1).Append(" 次（").Append(records[j - 1].followUserName).Append("）去电时间：").Append(records[j - 1].communicationTime.ToString(GlobalConfig.DateTimeFormat)).Append("，备注：")
                                .Append(records[j - 1].remark);

                            if (j != 1)
                            {
                                sb.Append("\r\n");
                            }
                        }
                        row.CreateCell(cellRemark.ColumnIndex).SetCellValue(sb.ToString());
                    }
                    else
                    {
                        row.CreateCell(cellRemark.ColumnIndex).SetCellValue("");
                    }
                }
                try
                {
                    using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                    {
                        workbook.Write(fs);
                        workbook.Close();
                        MessageBox.Show("导出成功！", "提示");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出失败:" + ex.Message, "提示");
                }
                finally
                {
                    workbook.Close();
                }
            }
        }
    }
}
