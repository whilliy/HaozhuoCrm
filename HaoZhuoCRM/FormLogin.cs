using Haozhuo.Crm.Service;
using System;
using System.Windows.Forms;

namespace HaoZhuoCRM
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            txtAccountNo.Text = txtAccountNo.Text.Trim();
            txtPassword.Text = txtPassword.Text.Trim();
            if (txtAccountNo.Text.Length < 1)
            {
                MessageBox.Show("请输入您的账号");
                txtAccountNo.Focus();
                return;
            }
            if (txtPassword.Text == String.Empty)
            {
                MessageBox.Show("请输入密码");
                txtPassword.Focus();
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void ButExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
