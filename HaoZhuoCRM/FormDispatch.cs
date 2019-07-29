using Haozhuo.Crm.Service;
using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HaoZhuoCRM
{
    public partial class FormDispatch : Form
    {
        public FormDispatch()
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
            pager.Reset();

        }



        private ResultsWithCount<CustomerDto> QueryCustomers()
        {
            txtName.Text = txtName.Text.Trim();
            txtMobile.Text = txtMobile.Text.Trim();
            Int32? projectId = null;
            if (cmbProjects.SelectedValue != null)
            {
                projectId = Convert.ToInt32(cmbProjects.SelectedValue.ToString());
                if (projectId == -1)
                {
                    projectId = null;
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
            ResultsWithCount<CustomerDto> customers = CustomerService.QueryUnAssignedCustomers(Global.USER_TOKEN,
                pager.PageIndex, pager.PageSize, projectId,
                  source, txtName.Text, txtMobile.Text);
            return customers;
        }

        private void bindingData(ListViewItem lvi, Int32 sequence, CustomerDto customer)
        {
            lvi.SubItems.Add(sequence.ToString());
            lvi.SubItems.Add(ProjectService.DicProjects[customer.projectId]);
            lvi.SubItems.Add(customer.name);
            lvi.SubItems.Add(Genders.DIC_GENDER[customer.gender]);
            lvi.SubItems.Add(customer.mobile);
            lvi.SubItems.Add(CustomerService.DicCustomerSources[customer.source]);
            lvi.SubItems.Add(customer.provinceName);
            lvi.SubItems.Add(customer.cityName);
            lvi.SubItems.Add(customer.countyName);
            lvi.SubItems.Add(customer.createdTime == null ? "" : customer.createdTime.ToString("yyyy-MM-dd HH:mm:ss"));
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

        private void ButReset_Click(object sender, EventArgs e)
        {
            txtMobile.Text = txtName.Text = string.Empty;
            lvClients.Items.Clear();
            pager.Reset();
            txtName.Focus();

        }

        private void BtnDispatch_Click(object sender, EventArgs e)
        {
            dispatch();
        }

        private void MiDispatch_Click(object sender, EventArgs e)
        {
            dispatch();
        }

        private void dispatch()
        {
            if (lvClients.CheckedItems.Count < 1)
            {
                MessageBox.Show("请在需要分配的客户记录前打勾✔", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            IList<String> customerIds = new List<String>();
            foreach (ListViewItem lvi in lvClients.CheckedItems)
            {
                CustomerDto customer = (CustomerDto)lvi.Tag;
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
            FormDispatchTo formTransfer = new FormDispatchTo(customerIds, userTargets);
            if (formTransfer.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            foreach (ListViewItem lvi in lvClients.CheckedItems)
            {
                lvClients.Items.Remove(lvi);
            }

        }
    }
}
