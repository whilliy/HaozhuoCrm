using Haozhuo.Crm.Service;
using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
using Haozhuo.Crm.Service.vo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HaoZhuoCRM
{
    public partial class FormModifyCustomer : Form
    {
        public CustomerDto CURRENT_CUSTOMER { get; set; }
        public Boolean InformationChanged = false;
        public FormModifyCustomer(CustomerDto customer)
        {
            InitializeComponent();
            CURRENT_CUSTOMER = customer;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormModifyCustomer_Load(object sender, EventArgs e)
        {

            //获取项目列表
            try
            {
                IList<ProjectDto> projects = ProjectService.ProjectsCopy;
                cmbProjects.DisplayMember = "name";
                cmbProjects.ValueMember = "id";
                cmbProjects.DataSource = projects;
                cmbProjects.SelectedValue = CURRENT_CUSTOMER.projectId;
            }
            catch (BusinessException ex)
            {
                MessageBox.Show("获取项目列表发生错误：" + ex.Message);
                return;
            }
            cmbGender.DataSource = Genders.ALL;
            cmbGender.ValueMember = "id";
            cmbGender.DisplayMember = "name";
            cmbGender.SelectedValue = CURRENT_CUSTOMER.gender;
            txtName.Text = CURRENT_CUSTOMER.name;
            txtMobile.Text = CURRENT_CUSTOMER.mobile;
            //加载客户来源
            IList<CustomerSourceDto> sources = new List<CustomerSourceDto>();
            try
            {
                sources = CustomerService.CustomerSourcesCopy();
                cmbCustomerSources.ValueMember = "id";
                cmbCustomerSources.DisplayMember = "name";
                cmbCustomerSources.DataSource = sources;
                cmbCustomerSources.SelectedValue = CURRENT_CUSTOMER.source;
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
            //注意：一定先指定 ValueMember 和 DisplayMember 再设定 DataSource 否则提前触发 CmbProvinces_SelectedIndexChanged
            cmbProvinces.ValueMember = "provinceId";
            cmbProvinces.DisplayMember = "provinceName";
            cmbProvinces.DataSource = provinces;
            cmbProvinces.SelectedValue = CURRENT_CUSTOMER.provinceId;
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
            if (!String.IsNullOrEmpty(CURRENT_CUSTOMER.cityId))
            {
                cmbCities.SelectedValue = CURRENT_CUSTOMER.cityId;
            }
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
            if (!String.IsNullOrEmpty(CURRENT_CUSTOMER.countyId))
            {
                cmbCounties.SelectedValue = CURRENT_CUSTOMER.countyId;
            }
            return;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {

            txtName.Text = txtName.Text.Trim();
            //txtMobile.Text = txtMobile.Text.Trim();
            if (cmbCustomerSources.Text == String.Empty)
            {
                MessageBox.Show("请指定客户数据来源");
                cmbCustomerSources.Focus();
                return;
            }
            if (cmbProvinces.Text == String.Empty)
            {
                MessageBox.Show("请指定客户所在区域");
                cmbProvinces.Focus();
                return;
            }
            if (cmbProjects.Text == String.Empty)
            {
                MessageBox.Show("请选择项目");
                cmbProjects.Focus();
                return;
            }
            try
            {
                CustomerVo vo = new CustomerVo();
                vo.cityId = cmbCities.SelectedValue != null ? cmbCities.SelectedValue.ToString() : null;
                vo.projectId = Convert.ToInt32(cmbProjects.SelectedValue.ToString());
                vo.countyId = cmbCounties.SelectedValue != null ? cmbCounties.SelectedValue.ToString() : null;
                vo.gender = cmbGender.SelectedValue == null ? 0 : Convert.ToInt32(cmbGender.SelectedValue.ToString());
                vo.provinceId = cmbProvinces.SelectedValue.ToString();
                vo.mobile = txtMobile.Text;
                vo.name = txtName.Text;
                vo.source = Convert.ToInt32(cmbCustomerSources.SelectedValue.ToString());
                //当前客户已经更新
                CURRENT_CUSTOMER = CustomerService.UpdateCustomer(CURRENT_CUSTOMER.id, Global.USER_TOKEN, vo);
                InformationChanged = true;
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
    }
}
