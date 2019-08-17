using Haozhuo.Crm.Service;
using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HaoZhuoCRM
{
    public partial class FormViewCustomer : Form
    {
        public CustomerDto CURRENT_CUSTOMER { get; set; }
        private IList<CustomerDto> customers;
        private int CURRENT_INDEX;
        public FormViewCustomer()
        {
            InitializeComponent();
        }

        private void UpdateButtonStatus(int index)
        {
            btnNext.Enabled = btnPrevious.Enabled = true;
            if (index == 0)
            {
                btnPrevious.Enabled = false;
            }
            if (index == customers.Count - 1)
            {
                btnNext.Enabled = false;
            }

        }

        public FormViewCustomer(IList<CustomerDto> customers, int index) : this()
        {
            this.customers = customers;
            this.CURRENT_INDEX = index;
            if (customers.Count == 1)
            {
                btnPrevious.Enabled = btnNext.Enabled = false;
            }
            labelCount.Text = customers.Count.ToString();
            AssignCustomer(index);
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
            txtName.Text = CURRENT_CUSTOMER.name;
            txtMobile.Text = CURRENT_CUSTOMER.mobile;
            if (CURRENT_CUSTOMER.projectId.HasValue && ProjectService.DicProjects.ContainsKey(CURRENT_CUSTOMER.projectId.Value))
            {
                txtProjectName.Text = ProjectService.DicProjects[CURRENT_CUSTOMER.projectId.Value];
            }
            try
            {
                txtGender.Text = Genders.DIC_GENDER[CURRENT_CUSTOMER.gender];
            }
            catch { }
            try
            {
                txtSource.Text = CustomerService.DicCustomerSources[CURRENT_CUSTOMER.source];
            }
            catch { }
            txtStatus.Text = CURRENT_CUSTOMER.status.HasValue ? CustomerService.DicCustomerStatuses[CURRENT_CUSTOMER.status.Value] : "";
            txtType.Text = CURRENT_CUSTOMER.type.HasValue ? CustomerService.DicCustomerTypes[CURRENT_CUSTOMER.type.Value] : "";
            txtProvince.Text = CURRENT_CUSTOMER.provinceName;
            txtFirstOwnerName.Text = CURRENT_CUSTOMER.firstOwnerName;
            txtCity.Text = CURRENT_CUSTOMER.cityName;
            txtCounty.Text = CURRENT_CUSTOMER.countyName;
            txtRemark.Text = CURRENT_CUSTOMER.remark;
            txtNextFollowTime.Text = (CURRENT_CUSTOMER.nextFollowTime.HasValue ? CURRENT_CUSTOMER.nextFollowTime.Value.ToString(GlobalConfig.DateTimeFormat) : "");
            try
            {
                IList<CustomerFollowRecord> records = CustomerService.GetFollowerRecordsByCusotmerId(CURRENT_CUSTOMER.id, Global.USER_TOKEN);
                foreach (CustomerFollowRecord record in records)
                {
                    ListViewItem lvi = new ListViewItem(record.communicationTime.ToString("yyyy-MM-dd HH:mm:ss"));
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
                MessageBox.Show("加载客户沟通记录失败：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void FormUpateCustomer_Load(object sender, System.EventArgs e)
        {
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
