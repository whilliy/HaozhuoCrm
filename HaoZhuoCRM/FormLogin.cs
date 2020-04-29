using Haozhuo.Crm.Service;
using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.vo;
using OAUS.Core;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace HaoZhuoCRM
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            //String oausServerIP = ConfigurationManager.AppSettings["oausServerIP"];
            //int oausServerPort = Convert.ToInt32(ConfigurationManager.AppSettings["oausServerPort"]);
            //if (VersionHelper.HasNewVersion(oausServerIP, oausServerPort))
            //{
            //    MessageBox.Show("发现新版本，让我们开始升级吧~~~", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    string updateExePath = AppDomain.CurrentDomain.BaseDirectory + "AutoUpdater\\AutoUpdater.exe";
            //    System.Diagnostics.Process myProcess = System.Diagnostics.Process.Start(updateExePath);
            //    Application.Exit();
            //}
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            txtAccountNo.Text = txtAccountNo.Text.Trim();
            txtPassword.Text = txtPassword.Text.Trim();
            if (txtAccountNo.Text.Length < 1)
            {
                MessageBox.Show("请输入您的账号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAccountNo.Focus();
                return;
            }
            if (txtPassword.Text == String.Empty)
            {
                MessageBox.Show("请输入密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
                return;
            }
            UserLoginVo vo = new UserLoginVo();
            vo.password = txtPassword.Text;
            vo.principalName = txtAccountNo.Text;
            try
            {
                UserLoginDto login = LoginService.Login(vo);
                Global.USER_TOKEN = login.Token;
                Global.USER_ID = login.Id;
                Global.USER_NAME = login.Name;
                Global.ORGANIZAITON_NAME = login.organizationName;
                Global.ORGANIZATION_ID = login.organizationId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("登录失败：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void TxtAccountNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtAccountNo.Text = txtAccountNo.Text.Trim();
                if (String.IsNullOrEmpty(txtAccountNo.Text))
                {
                    return;
                }
                txtPassword.Focus();
                txtPassword.SelectAll();
            }
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtAccountNo.Text = txtAccountNo.Text.Trim();
                txtPassword.Text = txtPassword.Text.Trim();
                if (String.IsNullOrEmpty(txtPassword.Text))
                {
                    return;
                }
                if (String.IsNullOrEmpty(txtAccountNo.Text))
                {
                    txtAccountNo.Focus();
                    return;
                }
                BtnLogin_Click(null, null);
            }
        }
    }
}
