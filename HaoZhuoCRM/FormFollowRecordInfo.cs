using Haozhuo.Crm.Service;
using Haozhuo.Crm.Service.Dto;
using System;
using System.Windows.Forms;

namespace HaoZhuoCRM
{
    public partial class FormFollowRecordInfo : Form
    {
        CustomerFollowRecord record;
        public FormFollowRecordInfo(CustomerFollowRecord record)
        {
            InitializeComponent();
            this.record = record;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormFollowRecordInfo_Load(object sender, EventArgs e)
        {
            labelProjectName.Text = record.projectName;
            labelFollowUserName.Text = record.followUserName;
            labelNextFollowTime.Text = record.nextFollowTime.HasValue ? record.nextFollowTime.Value.ToString(GlobalConfig.DateTimeFormat) : "";
            labelCommunicationTime.Text = record.communicationTime.ToString(GlobalConfig.DateTimeFormat);
            txtRemark.Text = record.remark;
        }
    }
}
