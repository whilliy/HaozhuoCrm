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
        private IList<CustomerDto> customers;
        private int CURRENT_INDEX;
        //数据是否做了修改
        public Boolean InformationChanged = false;
        //那些客户信息做了修改,key为数据在父页ListView中的index
        public IDictionary<int, CustomerDto> ModifiedCustomers = new Dictionary<int, CustomerDto>();
        public FormUpateCustomer()
        {
            InitializeComponent();
        }

        public FormUpateCustomer(IList<CustomerDto> customers, int index) : this()
        {
            this.customers = customers;
            this.CURRENT_INDEX = index;
            if (customers.Count == 1)
            {
                btnPre.Enabled = btnNext.Enabled = false;
            }
            labelCount.Text = customers.Count.ToString();
            AssignCustomer(index);
        }


        private void UpdateButtonStatus(int index)
        {
            btnNext.Enabled = btnPre.Enabled = true;
            if (index == 0)
            {
                btnPre.Enabled = false;
            }
            if (index == customers.Count - 1)
            {
                btnNext.Enabled = false;
            }

        }

        private void Clear()
        {
            listView1.Items.Clear();
        }

        private void AssignCustomer(int index)
        {
            Clear();
            UpdateButtonStatus(index);
            this.CURRENT_CUSTOMER = customers[index];
            labelCurrentSeq.Text = Convert.ToString(this.CURRENT_INDEX + 1);
            if (!Global.CURRENT_PROJECT_ID.HasValue)
            {
                btnAdd.Enabled = false;
            }
            try
            {
                dtpActuallyTime.Value = DateTime.Now;
                dtpNextFollowTime.Value = DateTime.Now.AddDays(1);
                if (CURRENT_CUSTOMER.projectId.HasValue && ProjectService.DicProjects.ContainsKey(CURRENT_CUSTOMER.projectId.Value))
                {
                    txtProjectName.Text = ProjectService.DicProjects[CURRENT_CUSTOMER.projectId.Value];
                }
                else
                {
                    txtProjectName.Text = Global.CURRENT_PROJECT_NAME;
                }
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
                txtRemark.Text = CURRENT_CUSTOMER.remark;
                txtFirstOwnerName.Text = CURRENT_CUSTOMER.firstOwnerName;
                cmbProvinces.DisplayMember = "provinceName";
                cmbProvinces.ValueMember = "provinceId";
                cmbProvinces.DataSource = RegionService.PROVINCES_COPY;
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
                    ListViewItem lvi = new ListViewItem(record.communicationTime.ToString(GlobalConfig.DateTimeFormat));
                    lvi.SubItems.Add(record.projectName);
                    lvi.SubItems.Add(record.customerStatus.HasValue ? CustomerService.DicCustomerStatuses[record.customerStatus.Value] : "");
                    lvi.SubItems.Add(record.customerType.HasValue ? CustomerService.DicCustomerTypes[record.customerType.Value] : "");
                    lvi.SubItems.Add(record.followUserName);
                    lvi.SubItems.Add(record.nextFollowTime.HasValue ? record.nextFollowTime.Value.ToString("MM-dd HH:mm") : "");
                    lvi.SubItems.Add(record.remark);
                    lvi.Tag = record;
                    listView1.Items.Add(lvi);
                }
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormUpateCustomer_Load(object sender, System.EventArgs e)
        {
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
            if (!Global.CURRENT_PROJECT_ID.HasValue)
            {
                MessageBox.Show("您登录时未选择当前操作项目，所以添加跟进记录，请重新登录选择项目或者跟管理员确认您可以操作的项目");
                return;

            }
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
            txtFollowRemark.Text = txtFollowRemark.Text.Trim();
            if (txtFollowRemark.Text == String.Empty)
            {
                MessageBox.Show("必须输入沟通记录");
                txtFollowRemark.Focus();
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
                vo.remark = txtFollowRemark.Text;
                vo.cityId = cmbCities.SelectedValue != null ? cmbCities.SelectedValue.ToString() : null;
                vo.countyId = cmbCounties.SelectedValue != null ? cmbCounties.SelectedValue.ToString() : null;
                vo.gender = cmbGender.SelectedValue == null ? 0 : Convert.ToInt32(cmbGender.SelectedValue.ToString());
                vo.provinceId = cmbProvinces.SelectedValue.ToString();
                //vo.mobile = txtMobile.Text;
                vo.name = txtName.Text;
                vo.nextFollowTime = dtpNextFollowTime.Value;
                //vo.source = Convert.ToInt32(cmbCustomerSources.SelectedValue.ToString());
                vo.type = Convert.ToInt32(cmbCustomerTypes.SelectedValue.ToString());
                vo.projectId = Global.CURRENT_PROJECT_ID.Value;
                vo.status = Convert.ToInt32(cmbCustomerStatus.SelectedValue.ToString());
                CustomerDto thisCustomer = CustomerService.AddFllowRecord(CURRENT_CUSTOMER.id, Global.USER_TOKEN, vo);
                ListViewItem lvi = new ListViewItem(vo.communicationTime.ToString("yyyy-MM-dd HH:mm:ss"));
                lvi.SubItems.Add(Global.CURRENT_PROJECT_NAME);
                lvi.SubItems.Add(cmbCustomerStatus.Text);
                lvi.SubItems.Add(cmbCustomerTypes.Text);
                lvi.SubItems.Add(CURRENT_CUSTOMER.lastFollowUserName);
                lvi.SubItems.Add(dtpNextFollowTime.Value.ToString("MM-dd HH:mm"));
                lvi.SubItems.Add(txtFollowRemark.Text);
                CustomerFollowRecord record = new CustomerFollowRecord();//供查看详细信息时使用
                record.projectName = Global.CURRENT_PROJECT_NAME;
                record.communicationTime = dtpActuallyTime.Value;
                record.followUserName = Global.USER_NAME;
                record.nextFollowTime = dtpNextFollowTime.Value;
                record.remark = txtFollowRemark.Text;
                lvi.Tag = record;
                listView1.Items.Insert(0, lvi);
                txtFollowRemark.Text = String.Empty;
                InformationChanged = true;
                ModifiedCustomers[CURRENT_INDEX] = thisCustomer;
                CURRENT_CUSTOMER = this.CURRENT_CUSTOMER;
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
                CURRENT_CUSTOMER = CustomerService.UpdateCustomer(CURRENT_CUSTOMER.id, Global.USER_TOKEN, vo);
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

        private void ListView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count < 1)
            {
                return;
            }
            FormFollowRecordInfo frmFollowRecordInfo = new FormFollowRecordInfo((CustomerFollowRecord)listView1.SelectedItems[0].Tag);
            frmFollowRecordInfo.ShowDialog();
            frmFollowRecordInfo.Close();
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            if (CURRENT_INDEX == 0)
            {
                return;
            }
            CURRENT_INDEX--;
            AssignCustomer(CURRENT_INDEX);
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (CURRENT_INDEX >= customers.Count - 1)
            {
                return;
            }
            CURRENT_INDEX++;
            AssignCustomer(CURRENT_INDEX);

        }
    }
}
