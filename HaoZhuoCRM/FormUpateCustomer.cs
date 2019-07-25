using Haozhuo.Crm.Service;
using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HaoZhuoCRM
{
    public partial class FormUpateCustomer : Form
    {
        private CustomerDto customer;
        public FormUpateCustomer()
        {
            InitializeComponent();
        }

        public FormUpateCustomer(CustomerDto customer) : this()
        {
            this.customer = customer;
        }

        private void FormUpateCustomer_Load(object sender, System.EventArgs e)
        {
            try
            {
                cmbCustomerTypes.DataSource = CustomerService.CustomerTypesCopy();
                cmbCustomerTypes.DisplayMember = "name";
                cmbCustomerTypes.ValueMember = "id";
                cmbCustomerTypes.SelectedValue = customer.type;
                cmbCustomerSources.DataSource = CustomerService.CustomerSources;
                cmbCustomerSources.DisplayMember = "name";
                cmbCustomerSources.ValueMember = "id";
                cmbCustomerSources.SelectedValue = customer.source;
                cmbCustomerStatus.DisplayMember = "name";
                cmbCustomerStatus.ValueMember = "id";
                cmbCustomerStatus.DataSource = CustomerService.CustomerStatusesCopy();
                cmbCustomerStatus.SelectedValue = customer.status;
                cmbGender.DataSource = Genders.ALL;
                cmbGender.ValueMember = "id";
                cmbGender.DisplayMember = "name";
                cmbGender.SelectedValue = customer.gender;
                txtName.Text = customer.name;
                txtMobile.Text = customer.mobile;
                cmbProvinces.DisplayMember = "provinceName";
                cmbProvinces.ValueMember = "provinceId";
                cmbProvinces.DataSource = RegionService.PROVINCES;
                if (customer.provinceId != null)
                {
                    cmbProvinces.SelectedValue = customer.provinceId;
                    if (customer.cityId != null)
                    {
                        cmbCities.SelectedValue = customer.cityId;
                        if (customer.countyId != null)
                        {
                            cmbCounties.SelectedValue = customer.countyId;
                        }
                    }
                }
                IList<CustomerFollowRecord> records = CustomerService.GetFollowerRecordsByCusotmerId(customer.id, Global.USER_TOKEN);
                foreach(CustomerFollowRecord record in records)
                {
                    ListViewItem lvi = new ListViewItem(record.communicationTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    lvi.SubItems.Add(record.followUserName);
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
            txtRemark.Text = txtRemark.Text.Trim();
            if (txtRemark.Text == String.Empty)
            {
                MessageBox.Show("必须输入沟通记录");
                return;
            }
            if(DateTime.Compare(dtpActuallyTime.Value, DateTime.Now) <= 0){
                MessageBox.Show("下次沟通时间必须晚于当前时间！");
                return;
            }
        }
    }
}
