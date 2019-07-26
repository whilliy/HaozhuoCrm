using Haozhuo.Crm.Service;
using Haozhuo.Crm.Service.Utils;
using System;
using System.Windows.Forms;

namespace HaoZhuoCRM
{
    public partial class FormModifyPassword : Form
    {
        public FormModifyPassword()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            txtOriginalPassword.Text = txtOriginalPassword.Text.Trim();
            txtNewPassword.Text = txtNewPassword.Text.Trim();
            if (String.IsNullOrEmpty(txtOriginalPassword.Text))
            {
                MessageBox.Show("请输入原密码");
                txtOriginalPassword.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtNewPassword.Text))
            {
                MessageBox.Show("请输入新密码");
                txtNewPassword.Focus();
                return;
            }
            if (txtNewPassword.Text.Length < 6)
            {
                MessageBox.Show("新密码长度不能小于6个字母和数字的组合");
                txtNewPassword.Focus();
                txtNewPassword.SelectAll();
                return;
            }
            try
            {
                UserService.ModifyPassword(Global.USER_TOKEN, txtOriginalPassword.Text, txtNewPassword.Text);
                DialogResult = DialogResult.OK;
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
