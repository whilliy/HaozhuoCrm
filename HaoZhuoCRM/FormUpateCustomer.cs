using Haozhuo.Crm.Service;
using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
using Haozhuo.Crm.Service.vo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HaoZhuoCRM
{
    public partial class FormUpateCustomer : Form
    {
        public CustomerDto CURRENT_CUSTOMER { get; set; }
        public Boolean InformationChanged = false;
        public FormUpateCustomer()
        {
            InitializeComponent();
        }

        public FormUpateCustomer(CustomerDto customer) : this()
        {
            this.CURRENT_CUSTOMER = customer;
        }

        private void FormUpateCustomer_Load(object sender, System.EventArgs e)
        {
            try
            {
                dtpActuallyTime.Value = DateTime.Now;
                dtpNextFollowTime.Value = DateTime.Now.AddDays(1);
                txtProjectName.Text = CURRENT_CUSTOMER.projectId == 0 ? "" : ProjectService.DicProjects[CURRENT_CUSTOMER.projectId];
                cmbCustomerTypes.DataSource = CustomerService.CustomerTypesCopy();
                cmbCustomerTypes.DisplayMember = "name";
                cmbCustomerTypes.ValueMember = "id";
                if (CURRENT_CUSTOMER.type.HasValue)
                {
                    cmbCustomerTypes.SelectedValue = CURRENT_CUSTOMER.type;
                }
                cmbCustomerSources.DataSource = CustomerService.CustomerSources;
                cmbCustomerSources.DisplayMember = "name";
                cmbCustomerSources.ValueMember = "id";
                cmbCustomerSources.SelectedValue = CURRENT_CUSTOMER.source;
                cmbCustomerStatus.DisplayMember = "name";
                cmbCustomerStatus.ValueMember = "id";
                cmbCustomerStatus.DataSource = CustomerService.CustomerAssignStatusesCopy();
                if (CURRENT_CUSTOMER.status.HasValue)
                {
                    cmbCustomerStatus.SelectedValue = CURRENT_CUSTOMER.status;
                }
                cmbGender.DataSource = Genders.ALL;
                cmbGender.ValueMember = "id";
                cmbGender.DisplayMember = "name";
                cmbGender.SelectedValue = CURRENT_CUSTOMER.gender;
                txtName.Text = CURRENT_CUSTOMER.name;
                txtMobile.Text = CURRENT_CUSTOMER.mobile;
                cmbProvinces.DisplayMember = "provinceName";
                cmbProvinces.ValueMember = "provinceId";
                cmbProvinces.DataSource = RegionService.PROVINCES;
                if (CURRENT_CUSTOMER.provinceId != null)
                {
                    cmbProvinces.SelectedValue = CURRENT_CUSTOMER.provinceId;
                    if (CURRENT_CUSTOMER.cityId != null)
                    {
                        cmbCities.SelectedValue = CURRENT_CUSTOMER.cityId;
                        if (CURRENT_CUSTOMER.countyId != null)
                        {
                            cmbCounties.SelectedValue = CURRENT_CUSTOMER.countyId;
                        }
                    }
                }
                IList<CustomerFollowRecord> records = CustomerService.GetFollowerRecordsByCusotmerId(CURRENT_CUSTOMER.id, Global.USER_TOKEN);
                foreach (CustomerFollowRecord record in records)
                {
                    ListViewItem lvi = new ListViewItem(record.communicationTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    lvi.SubItems.Add(record.customerStatus.HasValue ? CustomerService.DicCustomerStatuses[record.customerStatus.Value] : "");
                    lvi.SubItems.Add(record.customerType.HasValue ? CustomerService.DicCustomerTypes[record.customerType.Value] : "");
                    lvi.SubItems.Add(record.followUserName);
                    lvi.SubItems.Add(record.nextFollowTime.HasValue ? record.nextFollowTime.Value.ToString("MM-dd HH:mm") : "");
                    lvi.SubItems.Add(record.remark);
                    listView1.Items.Add(lvi);
                }
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CmbProvinces_SelectedIndexChanged(object sender, System.EventArgs e)
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
            cmbCities.ValueMember = "CityId";
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
            IList<CountyDto> counties = null;
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            txtName.Text = txtName.Text.Trim();
            if (String.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("客户姓名不能为空");
                txtName.Focus();
                return;
            }
            //txtMobile.Text = txtMobile.Text.Trim();
            if (cmbCustomerTypes.Text == String.Empty)
            {
                MessageBox.Show("请指定客户类型");
                cmbCustomerTypes.Focus();
                return;
            }
            //if (cmbCustomerSources.Text == String.Empty)
            //{
            //    MessageBox.Show("请指定客户数据来源");
            //    cmbCustomerSources.Focus();
            //    return;
            //}
            if (cmbCustomerStatus.Text == String.Empty)
            {
                MessageBox.Show("请指定客户状态");
                cmbCustomerTypes.Focus();
                return;
            }
            if (cmbProvinces.Text == String.Empty)
            {
                MessageBox.Show("请指定客户所在区域");
                cmbProvinces.Focus();
                return;
            }
            DateTime nextCommTime = dtpNextFollowTime.Value;
            if (DateTime.Compare(nextCommTime, DateTime.Now) < 0)
            {
                MessageBox.Show("下次跟进时间不能早于当前时间！");
                dtpNextFollowTime.Focus();
                return;
            }
            txtRemark.Text = txtRemark.Text.Trim();
            if (txtRemark.Text == String.Empty)
            {
                MessageBox.Show("必须输入沟通记录");
                txtRemark.Focus();
                return;
            }
            if (DateTime.Compare(dtpActuallyTime.Value, DateTime.Now) > 0)
            {
                MessageBox.Show("实际跟进时间不能晚于当前时间！");
                dtpActuallyTime.Focus();
                return;
            }
            try
            {
                AddFollowRecord vo = new AddFollowRecord();
                vo.communicationTime = dtpActuallyTime.Value;
                vo.remark = txtRemark.Text;
                vo.cityId = cmbCities.SelectedValue.ToString();
                vo.countyId = cmbCounties.SelectedValue.ToString();
                vo.gender = cmbGender.SelectedValue == null ? 0 : Convert.ToInt32(cmbGender.SelectedValue.ToString());
                vo.provinceId = cmbProvinces.SelectedValue.ToString();
                //vo.mobile = txtMobile.Text;
                vo.name = txtName.Text;
                vo.nextFollowTime = dtpNextFollowTime.Value;
                //vo.source = Convert.ToInt32(cmbCustomerSources.SelectedValue.ToString());
                vo.type = Convert.ToInt32(cmbCustomerTypes.SelectedValue.ToString());
                vo.status = Convert.ToInt32(cmbCustomerStatus.SelectedValue.ToString());
                CURRENT_CUSTOMER = CustomerService.AddFllowRecord(CURRENT_CUSTOMER.id, Global.USER_TOKEN, vo);
                ListViewItem lvi = new ListViewItem(vo.communicationTime.ToString("yyyy-MM-dd HH:mm:ss"));
                lvi.SubItems.Add(cmbCustomerStatus.Text);
                lvi.SubItems.Add(cmbCustomerTypes.Text);
                lvi.SubItems.Add(CURRENT_CUSTOMER.lastFollowUserName);
                lvi.SubItems.Add(dtpNextFollowTime.Value.ToString("MM-dd HH:mm"));
                lvi.SubItems.Add(txtRemark.Text);
                listView1.Items.Insert(0, lvi);
                txtRemark.Text = String.Empty;
                InformationChanged = true;
                MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (BusinessException ex)
            {
                MessageBox.Show("添加跟进记录发生错误:" + ex.Message);
                return;
            }
        }

        private void ButConfirm_Click(object sender, EventArgs e)
        {
            txtName.Text = txtName.Text.Trim();
            //txtMobile.Text = txtMobile.Text.Trim();
            if (cmbCustomerTypes.Text == String.Empty)
            {
                MessageBox.Show("请指定客户类型");
                cmbCustomerTypes.Focus();
                return;
            }
            if (cmbCustomerSources.Text == String.Empty)
            {
                MessageBox.Show("请指定客户数据来源");
                cmbCustomerSources.Focus();
                return;
            }
            if (cmbCustomerStatus.Text == String.Empty)
            {
                MessageBox.Show("请指定客户状态");
                cmbCustomerTypes.Focus();
                return;
            }
            if (cmbProvinces.Text == String.Empty)
            {
                MessageBox.Show("请指定客户所在区域");
                cmbProvinces.Focus();
                return;
            }
            DateTime nextCommTime = dtpNextFollowTime.Value;
            if (DateTime.Compare(nextCommTime, DateTime.Now) < 0)
            {
                MessageBox.Show("下次跟进时间不能早于当前时间！");
                dtpNextFollowTime.Focus();
                return;
            }
            try
            {
                CustomerVo vo = new CustomerVo();
                vo.cityId = cmbCities.SelectedValue.ToString();
                vo.countyId = cmbCounties.SelectedValue.ToString();
                vo.gender = cmbGender.SelectedValue == null ? 0 : Convert.ToInt32(cmbGender.SelectedValue.ToString());
                vo.provinceId = cmbProvinces.SelectedValue.ToString();
                vo.mobile = txtMobile.Text;
                vo.name = txtName.Text;
                vo.nextFollowTime = dtpNextFollowTime.Value;
                vo.source = Convert.ToInt32(cmbCustomerSources.SelectedValue.ToString());
                vo.type = Convert.ToInt32(cmbCustomerTypes.SelectedValue.ToString());
                vo.status = Convert.ToInt32(cmbCustomerStatus.SelectedValue.ToString());
                //当前客户已经更新
                CURRENT_CUSTOMER = CustomerService.updateCustomer(CURRENT_CUSTOMER.id, Global.USER_TOKEN, vo);
                DialogResult = DialogResult.OK;
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
