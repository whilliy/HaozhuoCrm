﻿using Haozhuo.Crm.Service;
using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HaoZhuoCRM
{
    public partial class FormPublic : Form
    {
        public FormPublic()
        {
            InitializeComponent();
        }

        private void FormPublic_Load(object sender, EventArgs e)
        {
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
            //获取所有的客户类型
            IList<CustomerStatus> customerStatuses = new List<CustomerStatus>();
            try
            {
                cmbStatus.DisplayMember = "name";
                cmbStatus.ValueMember = "id";
                customerStatuses = CustomerService.CustomerAssignStatusesCopy();
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
                provinces = RegionService.PROVINCES;
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
            ResultsWithCount<CustomerDto> customers = CustomerService.QueryCustomersFromPublic(Global.USER_TOKEN, pager.PageIndex, pager.PageSize, projectId,
                 status, source, type, txtName.Text, txtMobile.Text, provinceId, cityId, countyId);
            return customers;
        }

        private void bindingData(ListViewItem lvi, Int32 sequence, CustomerDto customer)
        {
            lvi.SubItems.Add(sequence.ToString());
            lvi.SubItems.Add(ProjectService.DicProjects[customer.projectId]);
            lvi.SubItems.Add(customer.name);
            lvi.SubItems.Add(Genders.DIC_GENDER[customer.gender]);
            lvi.SubItems.Add(customer.mobile);
            lvi.SubItems.Add(customer.type.HasValue ? CustomerService.DicCustomerTypes[customer.type.Value] : "");
            lvi.SubItems.Add(customer.status.HasValue ? CustomerService.DicCustomerStatuses[customer.status.Value] : "");
            lvi.SubItems.Add(CustomerService.DicCustomerSources[customer.source]);
            lvi.SubItems.Add(customer.provinceName);
            lvi.SubItems.Add(customer.cityName);
            lvi.SubItems.Add(customer.countyName);
            lvi.SubItems.Add(customer.createdTime == null ? "" : customer.createdTime.ToString("yyyy-MM-dd HH:mm:ss"));
            lvi.SubItems.Add(customer.previousFollowTime == null ? "" : customer.previousFollowTime.ToString("yyyy-MM-dd HH:mm:ss"));
            lvi.SubItems.Add(customer.previousFollowUserName);
            lvi.SubItems.Add(customer.lastFollowTime == null ? "" : customer.lastFollowTime.ToString("yyyy-MM-dd HH:mm:ss"));
            lvi.SubItems.Add(customer.lastFollowUserName);
            lvi.SubItems.Add(customer.nextFollowTime == null ? "" : customer.nextFollowTime.ToString("yyyy-MM-dd HH:mm:ss"));
            lvi.Tag = customer;
        }

        private void BindingDatas(ResultsWithCount<CustomerDto> customers)
        {
            lvClients.BeginUpdate();
            lvClients.Items.Clear();
            int i = 1 + (pager.PageSize) * (pager.PageIndex - 1);//计算序号
            foreach (CustomerDto customer in customers.getResults())
            {
                ListViewItem lvi = new ListViewItem();
                bindingData(lvi, i, customer);
                lvClients.Items.Add(lvi);
                i++;
            }
            lvClients.EndUpdate();
        }

        private void ButQuery_Click(object sender, EventArgs e)
        {
            try
            {
                //查询符合条件的记录
                ResultsWithCount<CustomerDto> customers = QueryCustomers();
                pager.PageIndex = 1;
                pager.DrawControl((int)customers.getCount());
                //将数据绑定到ListView
                BindingDatas(customers);
                pager.NeedExcuteQuery = true;
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void BtnGrab_Click(object sender, EventArgs e)
        {
            Grasp();
        }

        private void Grasp()
        {
            if (lvClients.CheckedIndices.Count < 1)
            {
                MessageBox.Show("请选择要抓取的记录然后在其前面打勾✔", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lvClients.Focus();
                return;
            }
            IList<String> customerIds = new List<String>();
            foreach (ListViewItem lvi in lvClients.Items)
            {
                customerIds.Add(((CustomerDto)lvi.Tag).id);
            }
            try
            {
                CustomerService.GraspCustomersFromPublic(customerIds, Global.USER_TOKEN);
                foreach (ListViewItem lvi in lvClients.Items)
                {
                    lvClients.Items.Remove(lvi);
                }
            }
            catch (BusinessException ex)
            {
                MessageBox.Show("抓取数据失败：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lvClients.Focus();
                return;
            }
        }

        private void MenuItemTransfer_Click(object sender, EventArgs e)
        {
            Grasp();
        }

        private void ButReset_Click(object sender, EventArgs e)
        {
            txtName.Text = txtMobile.Text = "";
            cmbCustomerSources.SelectedIndex = 0;
            cmbCustomerTypes.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            cmbProvinces.SelectedIndex = 0;
            lvClients.Items.Clear();
            pager.Reset();
            txtName.Focus();

        }
    }
}