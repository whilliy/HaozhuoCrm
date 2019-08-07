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
        public FormViewCustomer()
        {
            InitializeComponent();
        }

        public FormViewCustomer(CustomerDto customer) : this()
        {
            this.CURRENT_CUSTOMER = customer;
        }

        private void FormUpateCustomer_Load(object sender, System.EventArgs e)
        {
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
            txtCurrentUserName.Text = CURRENT_CUSTOMER.currentUserName;
            txtCity.Text = CURRENT_CUSTOMER.cityName;
            txtCounty.Text = CURRENT_CUSTOMER.countyName;
            txtNextFollowTime.Text = (CURRENT_CUSTOMER.nextFollowTime.HasValue ? CURRENT_CUSTOMER.nextFollowTime.Value.ToString(GlobalConfig.DateTimeFormat) : "");
            try
            {
                IList<CustomerFollowRecord> records = CustomerService.GetFollowerRecordsByCusotmerId(CURRENT_CUSTOMER.id, Global.USER_TOKEN);
                foreach (CustomerFollowRecord record in records)
                {
                    ListViewItem lvi = new ListViewItem(record.communicationTime.ToString("yyyy-MM-dd HH:mm:ss"));
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
    }
}
