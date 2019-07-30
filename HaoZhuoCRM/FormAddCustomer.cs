using Haozhuo.Crm.Service;
using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
using Haozhuo.Crm.Service.vo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HaoZhuoCRM
{
    public partial class FormAddCustomer : Form
    {
        public FormAddCustomer()
        {
            InitializeComponent();
        }

        private void FormCustomer_Load(object sender, System.EventArgs e)
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
            IList<Gender> genders = Genders.ALL_COPY;
            cmbGenders.DataSource = genders;
            cmbGenders.DisplayMember = "name";
            cmbGenders.ValueMember = "id";
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

            //加载省
            IList<ProvinceDto> provinces = null;
            try
            {
                provinces = RegionService.PROVINCES;
            }
            catch (BusinessException ex)
            {
                MessageBox.Show("获取省/自治区/直辖市列表失败:" + ex.Message);
                return;
            }
            //provinces.Insert(0, new ProvinceDto(string.Empty, String.Empty));
            //注意：一定先指定 ValueMember 和 DisplayMember 再设定 DataSource 否则提前触发 CmbProvinces_SelectedIndexChanged
            cmbProvinces.ValueMember = "provinceId";
            cmbProvinces.DisplayMember = "provinceName";
            cmbProvinces.DataSource = provinces;
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddCustomerVo vo = new AddCustomerVo();
            txtName.Text = txtName.Text.Trim();
            if (txtName.Text == String.Empty)
            {
                MessageBox.Show("请输入客户姓名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return;
            }
            vo.name = txtName.Text;
            txtMobile.Text = txtMobile.Text.Trim();
            if (String.IsNullOrEmpty(txtMobile.Text))
            {
                MessageBox.Show("请输入客户手机", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMobile.Focus();
                return;
            }
            vo.mobile = txtMobile.Text;
            if (cmbProjects.Text == string.Empty)
            {
                MessageBox.Show("请指定客户项目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbProjects.Focus();
                return;
            }
            if (cmbGenders.Text == String.Empty)
            {
                MessageBox.Show("请指定客户性别", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbGenders.Focus();
                return;
            }
            if (cmbCustomerSources.Text == String.Empty)
            {
                MessageBox.Show("请指定客户来源", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbCustomerSources.Focus();
                return;
            }
            vo.source = Convert.ToInt32(cmbCustomerSources.SelectedValue.ToString());
            vo.gender = Convert.ToInt32(cmbGenders.SelectedValue.ToString());
            vo.projectId = Convert.ToInt32(cmbProjects.SelectedValue.ToString());
            if (cmbProvinces.Text == String.Empty)
            {
                MessageBox.Show("请指定客户所在省", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbProvinces.Focus();
                return;
            }
            vo.provinceId = cmbProvinces.SelectedValue.ToString();
            if (!String.IsNullOrEmpty(cmbCities.Text))
            {
                vo.cityId = cmbCities.SelectedValue.ToString();
            }
            if (!String.IsNullOrEmpty(cmbCounties.Text))
            {
                vo.countyId = cmbCounties.SelectedValue.ToString();
            }
            ListViewItem lvi = new ListViewItem(vo.name);
            lvi.SubItems.Add(vo.mobile);
            lvi.SubItems.Add(cmbProjects.Text);
            lvi.SubItems.Add(cmbGenders.Text);
            lvi.SubItems.Add(cmbCustomerSources.Text);
            lvi.SubItems.Add(cmbProvinces.Text);
            lvi.SubItems.Add(cmbCities.Text);
            lvi.SubItems.Add(cmbCounties.Text);
            lvi.Tag = vo;
            lvCustomers.Items.Add(lvi);
            reset();
        }

        private void reset()
        {
            txtMobile.Text = txtName.Text = "";
            cmbProjects.SelectedIndex = 0;
            cmbProvinces.SelectedIndex = 0;
            cmbGenders.SelectedIndex = 0;
            cmbCustomerSources.SelectedIndex = 0;
            txtName.Focus();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lvCustomers.SelectedItems.Count < 1)
            {
                return;
            }
            if (MessageBox.Show("您确认要将选定用户移除吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            foreach (ListViewItem lvi in lvCustomers.SelectedItems)
            {
                lvCustomers.Items.Remove(lvi);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (lvCustomers.Items.Count < 1)
            {
                MessageBox.Show("请先将新增客户添加到列表中", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAdd.Focus();
                return;
            }
            IList<AddCustomerVo> customers = new List<AddCustomerVo>();
            foreach (ListViewItem lvi in lvCustomers.Items)
            {
                customers.Add((AddCustomerVo)lvi.Tag);
            }
            try
            {
                CustomerService.AddCustomers(customers, Global.USER_TOKEN);
                MessageBox.Show("添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (BusinessException ex)
            {
                MessageBox.Show("添加客户失败:" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOK.Focus();
                return;
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
        }
    }
}
