﻿using Haozhuo.Crm.Service;
using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
using Haozhuo.Crm.Service.vo;
using HaoZhuoCRM.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HaoZhuoCRM
{
    public partial class FormMyCustomers : Form
    {

        public FormMyCustomers()
        {
            InitializeComponent();
        }



        private void BtnNew_Click(object sender, EventArgs e)
        {
            FormAddCustomer frmClient = new FormAddCustomer();
            DialogResult dialogResult = frmClient.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {

            }
            frmClient.Close();
        }

        private void FormMyClients_Load(object sender, EventArgs e)
        {
            dtpLeaveWordsTimeEnd.Value = dtpLeaveWordsTimeBegin.Value = DateTime.Now;
            dtpNextFollowTimeStart.Value = dtpNextFollowTimeEnd.Value = DateTime.Now;
            //获取项目列表
            try
            {
                IList<ProjectDto> projects = ProjectService.ProjectsCopy;
                //projects.Insert(0, new ProjectDto(-1, ""));
                cmbProjects.DisplayMember = "name";
                cmbProjects.ValueMember = "id";
                cmbProjects.DataSource = projects;
                cmbProjects.SelectedValue = Global.CURRENT_PROJECT_ID;
                
            }
            catch (BusinessException ex)
            {
                MessageBox.Show("获取项目列表发生错误：" + ex.Message);
                return;
            }
            //获取所有的客户状态
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
            Query();
        }

        private void Query()
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
                MessageBox.Show("查询失败：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
                MessageBox.Show("获取市列表失败:" + ex.Message);
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
            txtName.Text = txtMobile.Text = "";
            cmbCustomerSources.SelectedIndex = 0;
            cmbCustomerTypes.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            cmbProvinces.SelectedIndex = 0;
            lvClients.Items.Clear();
            cbLeaveWordsTime.Checked = false;
            cbNextFollowTime.Checked = false;
            pager.Reset();
            txtName.Focus();

        }

        private ResultsWithCount<CustomerDto> QueryCustomers()
        {
            txtName.Text = txtName.Text.Trim();
            txtMobile.Text = txtMobile.Text.Trim();
            String provinceId = cmbProvinces.SelectedValue != null ? cmbProvinces.SelectedValue.ToString() : String.Empty;
            String cityId = cmbCities.SelectedValue != null ? cmbCities.SelectedValue.ToString() : String.Empty;
            String countyId = cmbCounties.SelectedValue != null ? cmbCounties.SelectedValue.ToString() : String.Empty;
            //Int32? projectId = null;
            //if (cmbProjects.SelectedValue != null)
            //{
            //    projectId = Convert.ToInt32(cmbProjects.SelectedValue.ToString());
            //    if (projectId == -1)
            //    {
            //        projectId = null;
            //    }
            //}
            Int32? projectId = Global.CURRENT_PROJECT_ID;
            if (projectId.HasValue)
            {
                cmbProjects.SelectedValue = projectId;
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
            String nextFollowTimeBegin = null, nextFollowTimeEnd = null;
            if (cbNextFollowTime.Checked)
            {
                if (dtpNextFollowTimeStart.Value.CompareTo(dtpNextFollowTimeEnd.Value) > 0)
                {
                    throw new BusinessException("下次跟进时间范围截至时间不能早于起始时间");
                }
                nextFollowTimeBegin = dtpNextFollowTimeStart.Value.ToString("yyyy-MM-dd HH:mm");
                nextFollowTimeEnd = dtpNextFollowTimeEnd.Value.ToString("yyyy-MM-dd HH:mm");
            }
            ResultsWithCount<CustomerDto> customers = CustomerService.QueryMyCustomers(Global.USER_TOKEN, pager.PageIndex, pager.PageSize, projectId,
                 status, source, type, txtName.Text, txtMobile.Text, provinceId, cityId, countyId, leaveWordsTimeBegin, leaveWordsTimeEnd,
                 nextFollowTimeBegin, nextFollowTimeEnd);
            return customers;
        }

        private void BindingData(ListViewItem lvi, Int32 sequence, CustomerDto customer)
        {
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
            ListViewItem.ListViewSubItem lviStatus = lvi.SubItems.Add(customer.status.HasValue ? CustomerService.DicCustomerStatuses[customer.status.Value] : "");
            if (customer.status.HasValue && CustomerService.CUSTOMER_STATUS_INIT == customer.status.Value)
            {
                lviStatus.BackColor = Color.MistyRose;//.Red;
            }
            ListViewItem.ListViewSubItem lviSource = lvi.SubItems.Add(CustomerService.DicCustomerSources[customer.source]);
            if (CustomerService.CUSTOMER_SOURCE_DATABASE == customer.source)
            {
                lviSource.BackColor = Color.GreenYellow;
            }
            lvi.SubItems.Add(customer.provinceName);
            lvi.SubItems.Add(customer.cityName);
            lvi.SubItems.Add(customer.countyName);
            lvi.SubItems.Add(customer.leaveWordsTime.HasValue ? customer.leaveWordsTime.Value.ToString(GlobalConfig.DateTimeFormat) : "");
            lvi.SubItems.Add(!customer.nextFollowTime.HasValue ? "" : customer.nextFollowTime.Value.ToString(GlobalConfig.DateTimeFormat));
            lvi.SubItems.Add(customer.createdTime == null ? "" : customer.createdTime.ToString(GlobalConfig.DateTimeFormat));
            lvi.SubItems.Add(customer.lastFollowUserName);
            lvi.SubItems.Add(!customer.lastFollowTime.HasValue ? "" : customer.lastFollowTime.Value.ToString(GlobalConfig.DateTimeFormat));
            lvi.SubItems.Add(customer.previousFollowUserName);
            lvi.SubItems.Add(!customer.previousFollowTime.HasValue ? "" : customer.previousFollowTime.Value.ToString(GlobalConfig.DateTimeFormat));
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
                BindingData(lvi, i, customer);
                lvClients.Items.Add(lvi);
                i++;
            }
            lvClients.EndUpdate();
        }

        private void ButQuery_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void LvClients_DoubleClick(object sender, EventArgs e)
        {
            if (lvClients.SelectedItems.Count < 1)
            {
                return;
            }
            ListViewItem lviSelected = lvClients.SelectedItems[0];
            IList<CustomerDto> customers = new List<CustomerDto>();
            foreach (ListViewItem lvi in lvClients.Items)
            {
                customers.Add((CustomerDto)lvi.Tag);
            }
            var customer = (CustomerDto)lvClients.SelectedItems[0].Tag;
            //this.Hide();
            FormUpateCustomer frmUpdateCustomer = new FormUpateCustomer(customers, lvClients.SelectedItems[0].Index);
            DialogResult dialogResult = frmUpdateCustomer.ShowDialog();
            if (frmUpdateCustomer.InformationChanged)
            {
                foreach (KeyValuePair<int, CustomerDto> item in frmUpdateCustomer.ModifiedCustomers)
                {
                    lviSelected = lvClients.Items[item.Key];
                    CustomerDto currentCustomer = item.Value;
                    lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "姓名").Value].Text = currentCustomer.name;
                    if (currentCustomer.projectId.HasValue && ProjectService.DicProjects.ContainsKey(currentCustomer.projectId.Value))
                    {
                        lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "所属项目").Value].Text = ProjectService.DicProjects[currentCustomer.projectId.Value];
                    }
                    else
                    {
                        lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "所属项目").Value].Text = string.Empty;
                    }
                    lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "性别").Value].Text = Genders.DIC_GENDER[currentCustomer.gender];
                    lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "手机号码").Value].Text = currentCustomer.mobile;
                    lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "客户类型").Value].Text = currentCustomer.type.HasValue ? CustomerService.DicCustomerTypes[currentCustomer.type.Value] : "";
                    var lviStatus = lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "客户状态").Value];
                    lviStatus.Text = currentCustomer.status.HasValue ? CustomerService.DicCustomerStatuses[currentCustomer.status.Value] : "";
                    if (currentCustomer.status.HasValue && CustomerService.CUSTOMER_STATUS_INIT == currentCustomer.status.Value)
                    {
                        lviStatus.BackColor = Color.MistyRose;//.Red;
                    }
                    else
                    {
                        lviStatus.BackColor = Color.White;
                    }
                    lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "客户来源").Value].Text = CustomerService.DicCustomerSources[currentCustomer.source];
                    lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "省").Value].Text = currentCustomer.provinceName;
                    lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "市").Value].Text = currentCustomer.cityName;
                    lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "区").Value].Text = currentCustomer.countyName;
                    lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "留言时间").Value].Text = !currentCustomer.leaveWordsTime.HasValue ? "" : currentCustomer.leaveWordsTime.Value.ToString(GlobalConfig.DateTimeFormat);
                    lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "下次跟进时间").Value].Text = !currentCustomer.nextFollowTime.HasValue ? "" : currentCustomer.nextFollowTime.Value.ToString(GlobalConfig.DateTimeFormat);
                    lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "录入时间").Value].Text = currentCustomer.createdTime.ToString(GlobalConfig.DateTimeFormat);
                    lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "上次跟进时间").Value].Text = !currentCustomer.previousFollowTime.HasValue ? "" : currentCustomer.previousFollowTime.Value.ToString(GlobalConfig.DateTimeFormat);
                    lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "上次跟进人").Value].Text = currentCustomer.previousFollowUserName;
                    lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "最后跟进时间").Value].Text = !currentCustomer.lastFollowTime.HasValue ? "" : currentCustomer.lastFollowTime.Value.ToString(GlobalConfig.DateTimeFormat);
                    lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "最后跟进人").Value].Text = frmUpdateCustomer.CURRENT_CUSTOMER.lastFollowUserName;
                    lviSelected.Tag = currentCustomer;
                }
                frmUpdateCustomer.Close();

            }
        }

        private void MenuItemFollow_Click(object sender, EventArgs e)
        {
            LvClients_DoubleClick(null, null);
        }

        private void ReturnCustomersToPublic()
        {
            if (lvClients.CheckedIndices.Count < 1)
            {
                MessageBox.Show("请先选择用户,在用户记录前面打勾✔", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("您确认要将选中的用户放回公海吗？数据数量：" + lvClients.CheckedItems.Count, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            ReturnCustomersToPublic vo = new ReturnCustomersToPublic
            {
                customerIds = new List<String>()
            };
            foreach (ListViewItem lvi in lvClients.CheckedItems)
            {
                CustomerDto customer = (CustomerDto)lvi.Tag;
                vo.customerIds.Add(customer.id);
            }
            try
            {
                CustomerService.ReturnCustomersToPublic(vo, Global.USER_TOKEN);
                Query();
            }
            catch (BusinessException ex)
            {
                MessageBox.Show("将选定客户扔回公海时发生错误：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                lvClients.Focus();
            }
            foreach (ListViewItem lvi in lvClients.CheckedItems)
            {
                lvClients.Items.Remove(lvi);
            }

        }

        private void MenuItemReturnToPublic_Click(object sender, EventArgs e)
        {
            ReturnCustomersToPublic();
        }

        private void BtnReturnToPublic_Click(object sender, EventArgs e)
        {
            ReturnCustomersToPublic();
        }

        private void MenuItemTransfer_Click(object sender, EventArgs e)
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
                customerIds.Add(customer.id);
            }
            if (MessageBox.Show("您确认要将选中的[ " + customerIds.Count + " ]条数据转移给他人吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
            {
                return;
            }
            IList<UserDto> userTargets = null;
            try
            {
                userTargets = UserService.GetUsersSameByOrganization(Global.USER_TOKEN, false);
            }
            catch (BusinessException ex)
            {
                MessageBox.Show("获取目标用户列表失败：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            FormTransferToOther formTransfer = new FormTransferToOther(customerIds, userTargets);
            if (formTransfer.ShowDialog() != DialogResult.OK)
            {
                formTransfer.Close();
                return;
            }
            formTransfer.Close();

            foreach (ListViewItem lvi in lvClients.CheckedItems)
            {
                lvClients.Items.Remove(lvi);
            }
        }

        private void CheckBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lvClients.Items)
            {
                lvi.Checked = checkBoxAll.Checked;
            }
        }

        private void CbLeaveWordsTime_CheckedChanged(object sender, EventArgs e)
        {
            dtpLeaveWordsTimeBegin.Enabled = dtpLeaveWordsTimeEnd.Enabled = cbLeaveWordsTime.Checked;
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

        private void MiModify_Click(object sender, EventArgs e)
        {
            Modify();
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
                    // lviSelected.SubItems[ListViewHelper.getIndexByText(lvClients, "当前跟进人").Value].Text = currentCustomer.currentUserName;
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

        private void CbNextFollowTime_CheckedChanged(object sender, EventArgs e)
        {
            dtpNextFollowTimeStart.Enabled = dtpNextFollowTimeEnd.Enabled = cbNextFollowTime.Checked;
        }
    }
}
