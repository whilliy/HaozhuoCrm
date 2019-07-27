using Haozhuo.Crm.Service;
using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
using HaoZhuoCRM.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HaoZhuoCRM
{
    public partial class FormMyClients : Form
    {
        private Int32 CurrentPage = 1;
        private Int32 PageSize = 20;
        private Int64 Count;
        private Int32 PageCount = 1;
        private Boolean Queried = false;

        public FormMyClients()
        {
            InitializeComponent();
            InitialPager();
        }

        void InitialPager()
        {
            lblCurrentPage.Text = "1";
            lblPageCount.Text = "1";
            lblTotalCount.Text = "0";
            cmbPagesizes.Text = "20";
            txtJump.Text = "1";
            IntialPageButtons();
        }

        /// <summary>
        /// 指定“首页”上页，下页，尾页按钮的初始状态
        /// </summary>
        void IntialPageButtons()
        {
            btnFirstPage.Enabled = false;
            btnLastPage.Enabled = false;
            btnNextPage.Enabled = false;
            btnPrePage.Enabled = false;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            FormClient frmClient = new FormClient();
            DialogResult dialogResult = frmClient.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {

            }
            frmClient.Close();
        }

        private void FormMyClients_Load(object sender, EventArgs e)
        {
            //获取项目列表
            try
            {
                IList<ProjectDto> projects = ProjectService.ProjectsCopy;
                projects.Insert(0, new ProjectDto(-1, ""));
                cmbProjects.DisplayMember = "name";
                cmbProjects.ValueMember = "id";
                cmbProjects.DataSource = projects;
                cmbPagesizes.Text = PageSize.ToString();
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

        private void ButReset_Click(object sender, EventArgs e)
        {
            InitialPager();
            txtName.Text = txtMobile.Text = "";
            cmbCustomerSources.SelectedIndex = 0;
            cmbCustomerTypes.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            cmbProvinces.SelectedIndex = 0;

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
            //将每页数量改为下拉框内的值
            PageSize = Convert.ToInt32(cmbPagesizes.Text);
            ResultsWithCount<CustomerDto> customers = CustomerService.QueryCustomers(Global.USER_TOKEN, CurrentPage, PageSize, projectId,
                Global.USER_ID, status, source, type, txtName.Text, txtMobile.Text, provinceId, cityId, countyId);
            return customers;
        }

        private void bindingData(ListViewItem lvi, Int32 sequence, CustomerDto customer)
        {
            lvi.SubItems.Add(sequence.ToString());
            lvi.SubItems.Add(ProjectService.DicProjects[customer.projectId]);
            lvi.SubItems.Add(customer.name);
            lvi.SubItems.Add(Genders.DIC_GENDER[customer.gender]);
            lvi.SubItems.Add(customer.mobile);
            lvi.SubItems.Add(CustomerService.DicCustomerTypes[customer.type]);
            lvi.SubItems.Add(CustomerService.DicCustomerStatuses[customer.status]);
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
            int i = 1 + (CurrentPage - 1) * PageSize;//计算序号
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
            getCustomersAndBindingDatas();
        }

        /// <summary>
        /// 根据当前页码和总页数显示“首页”“下页”“前页”“尾页”状态
        /// </summary>
        private void SetPageButtons()
        {
            if (CurrentPage != 1)
            {
                btnPrePage.Enabled = true;
                btnFirstPage.Enabled = true;
            }
            if (CurrentPage < PageCount)
            {
                btnNextPage.Enabled = true;
                btnLastPage.Enabled = true;
            }
        }

        /// <summary>
        /// 获取符合条件的数据并绑定到ListView和Pager区
        /// </summary>
        private void getCustomersAndBindingDatas()
        {
            //初始化几个按钮的状态
            IntialPageButtons();
            try
            {
                //查询符合条件的记录
                ResultsWithCount<CustomerDto> customers = QueryCustomers();
                //将数据绑定到ListView
                BindingDatas(customers);
                //处理分页相关
                Assign(customers.getCount());
                Queried = true;
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Assign(long count)
        {
            Count = count;
            lblTotalCount.Text = count.ToString();
            //当前页Label修改
            lblCurrentPage.Text = CurrentPage.ToString();
            //跳转文本框内容修改
            txtJump.Text = CurrentPage.ToString();
            Int32 pageSize = Convert.ToInt32(cmbPagesizes.Text);
            if (count % pageSize == 0)
            {
                PageCount = Convert.ToInt32(count / pageSize);
                lblPageCount.Text = PageCount.ToString();
            }
            else
            {
                PageCount = Convert.ToInt32(count / pageSize + 1);
                lblPageCount.Text = PageCount.ToString();
            }
            SetPageButtons();
        }

        private void LvClients_DoubleClick(object sender, EventArgs e)
        {
            if (lvClients.SelectedItems.Count < 1)
            {
                return;
            }
            ListViewItem lviSelected = lvClients.SelectedItems[0];
            CustomerDto customer = (CustomerDto)(lviSelected.Tag);
            //this.Hide();
            FormUpateCustomer frmUpdateCustomer = new FormUpateCustomer(customer);
            DialogResult dialogResult = frmUpdateCustomer.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                CustomerDto currentCustomer = frmUpdateCustomer.CURRENT_CUSTOMER;
                lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "姓名").Value].Text = currentCustomer.name;
                lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "所属项目").Value].Text = ProjectService.DicProjects[currentCustomer.projectId];
                lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "性别").Value].Text = Genders.DIC_GENDER[currentCustomer.gender];
                lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "手机号码").Value].Text = currentCustomer.mobile;
                lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "客户类型").Value].Text = CustomerService.DicCustomerTypes[currentCustomer.type];
                lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "客户状态").Value].Text = CustomerService.DicCustomerStatuses[currentCustomer.status];
                lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "客户来源").Value].Text = CustomerService.DicCustomerSources[currentCustomer.source];
                lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "省").Value].Text = currentCustomer.provinceName;
                lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "市").Value].Text = currentCustomer.cityName;
                lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "区").Value].Text = currentCustomer.countyName;
                lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "录入时间").Value].Text = currentCustomer.createdTime.ToString("yyyy-MM-dd HH:mm:ss");
                lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "上次跟进时间").Value].Text = currentCustomer.previousFollowTime == null ? "" : currentCustomer.previousFollowTime.ToString("yyyy-MM-dd HH:mm:ss");
                lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "上次跟进人").Value].Text = currentCustomer.previousFollowUserName;
                lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "最后跟进时间").Value].Text = currentCustomer.lastFollowTime == null ? "" : currentCustomer.lastFollowTime.ToString("yyyy-MM-dd HH:mm:ss");
                lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "最后跟进人").Value].Text = frmUpdateCustomer.CURRENT_CUSTOMER.lastFollowUserName;
                lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "下次跟进时间").Value].Text = currentCustomer.nextFollowTime == null ? "" : currentCustomer.nextFollowTime.ToString("yyyy-MM-dd HH:mm:ss");
                lviSelected.Tag = currentCustomer;
            }
        }


        private void CmbPagesizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            PageSize = Convert.ToInt32(cmbPagesizes.Text);
            getCustomersAndBindingDatas();
        }

        private void BtnFirstPage_Click(object sender, EventArgs e)
        {
            CurrentPage = 1;
            getCustomersAndBindingDatas();
        }

        private void BtnPrePage_Click(object sender, EventArgs e)
        {
            CurrentPage = Math.Max(1, CurrentPage - 1);
            getCustomersAndBindingDatas();
        }

        private void BtnNextPage_Click(object sender, EventArgs e)
        {
            CurrentPage = Math.Min(CurrentPage + 1, PageCount);
            getCustomersAndBindingDatas();
        }

        private void BtnLastPage_Click(object sender, EventArgs e)
        {
            CurrentPage = PageCount;
            getCustomersAndBindingDatas();
        }

        private void BtnJump_Click(object sender, EventArgs e)
        {
            txtJump.Text = txtJump.Text.Trim();
            Int32 jumpPage = 1;
            if (!Int32.TryParse(txtJump.Text, out jumpPage) || jumpPage < 1)
            {
                MessageBox.Show("跳转页码只能为正整数！");
                txtJump.Focus();
                txtJump.SelectAll();
                return;
            }
            CurrentPage = Math.Min(PageCount, jumpPage);
            getCustomersAndBindingDatas();
            txtJump.Focus();
            txtJump.SelectAll();

        }
    }
}
