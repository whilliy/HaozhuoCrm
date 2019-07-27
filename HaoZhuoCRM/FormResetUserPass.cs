using Haozhuo.Crm.Service;
using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
using Haozhuo.Crm.Service.vo;
using System;
using System.Windows.Forms;

namespace HaoZhuoCRM
{
    public partial class FormResetUserPass : Form
    {
        public FormResetUserPass()
        {
            InitializeComponent();
        }

        private UserDto user;
        public FormResetUserPass(UserDto user) : this()
        {
            this.user = user;
        }

        private void FormResetUserPass_Load(object sender, EventArgs e)
        {
            labelName.Text = user.name;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            txtPassword.Text = txtPassword.Text.Trim();
            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("请给用户指定一个新的密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
                return;
            }
            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("密码为长度不少于6个数字或者字母的组合！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
                txtPassword.SelectAll();
                return;
            }
            try
            {
                UserService.ResetUserPassword(new ResetUserPassword { userId = user.id, password = txtPassword.Text }, Global.USER_TOKEN);
                MessageBox.Show("重置密码成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (BusinessException ex)
            {
                MessageBox.Show("重置密码失败:" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
