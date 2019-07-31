using Haozhuo.Crm.Service;
using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
using System;
using System.Windows.Forms;

namespace HaoZhuoCRM
{
    public partial class FormSelectUser : Form
    {
        public  UserDto SelectedUser;
        public FormSelectUser()
        {
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            SelectUser();
        }

        private void FormSelectUser_Load(object sender, EventArgs e)
        {
            ResultsWithCount<UserDto> users = UserService.QueryUsers(Global.USER_TOKEN, 1, Int32.MaxValue, null, null, null, null);
            foreach (UserDto user in users.getResults())
            {
                ListViewItem lvi = new ListViewItem(user.name);
                lvi.SubItems.Add(user.mobile);
                lvi.Tag = user;
                lvUsers.Items.Add(lvi);
            }
        }

        private void LvUsers_DoubleClick(object sender, EventArgs e)
        {
            SelectUser();
        }

        private void SelectUser()
        {
            if (lvUsers.SelectedItems.Count < 1)
            {
                MessageBox.Show("请在列表中选择一个用户", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SelectedUser = (UserDto)lvUsers.SelectedItems[0].Tag;
            DialogResult = DialogResult.OK;
        }
    }
}
