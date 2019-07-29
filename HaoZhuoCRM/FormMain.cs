using Haozhuo.Crm.Service;
using Haozhuo.Crm.Service.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HaoZhuoCRM
{
    public partial class FormMain : Form
    {
        private Dictionary<String, ToolStripItem> PermissionControl = new Dictionary<string, ToolStripItem>();
        public FormMain()
        {
            InitializeComponent();
            PermissionControl.Add("CUSTOMER", miClients);
            PermissionControl.Add("EXIT", miExit);
            PermissionControl.Add("FILE", miFile);
            PermissionControl.Add("MANAGEMENT", miManagement);
            PermissionControl.Add("MODIFY_PASWORD", miModifyPassword);
            PermissionControl.Add("MY_CLIENTS", miMyClients);
            PermissionControl.Add("ORGANIZATION_MANAGEMENT", miOrganizationManagement);
            PermissionControl.Add("PROJECT_MANAGEMENT", miProjectManagement);
            PermissionControl.Add("PUBLIC", miPublic);
            PermissionControl.Add("USER_MANAGEMENT", miUserManagement);
            PermissionControl.Add("CHANGE_USER", miChangeUser);
        }

        private void MiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void matchPermissions()
        {
            try
            {
                Global.PERMISSION_IDS = UserService.GetMyPermissionIds(Global.USER_TOKEN);
                foreach (var item in PermissionControl)
                {
                    if (Global.PERMISSION_IDS.Contains(item.Key))
                    {
                        item.Value.Visible = true;
                    }
                    else
                    {
                        item.Value.Visible = false;
                    }
                }
            }
            catch (BusinessException ex)
            {
                MessageBox.Show("获取用户权限失败：" + ex.Message);
                Application.Exit();
                return;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            FormLogin frmLogin = new FormLogin();
            DialogResult dialogResult = frmLogin.ShowDialog();
            if (frmLogin.DialogResult != DialogResult.OK)
            {
                return;
            }
            frmLogin.Close();
            matchPermissions();
        }

        private void MiMyClients_Click(object sender, EventArgs e)
        {
            FormMyClients formMyClients = new FormMyClients();
            formMyClients.MdiParent = this;
            formMyClients.Show();
        }

        private void MenuItemProjectManagement_Click(object sender, EventArgs e)
        {
            FormProjectManagement formProjectManagement = new FormProjectManagement();
            formProjectManagement.ShowDialog();
        }

        private void MenuModifyPassword_Click(object sender, EventArgs e)
        {
            FormModifyPassword formModifyPassword = new FormModifyPassword();
            formModifyPassword.ShowDialog();
        }

        private void MenuItemUser_Click(object sender, EventArgs e)
        {
            FormUser frmUser = new FormUser();
            frmUser.ShowDialog();
        }

        private void 组织架构OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOrganization frmOrganizaiton = new FormOrganization();
            frmOrganizaiton.ShowDialog();
        }

        private void MiChangeUser_Click(object sender, EventArgs e)
        {
            FormLogin frmLogin = new FormLogin();
            if (frmLogin.ShowDialog() == DialogResult.OK)
            {
                matchPermissions();
            }
        }

        private void MiPublic_Click(object sender, EventArgs e)
        {
            FormPublic formPublic = new FormPublic();
            formPublic.MdiParent = this;
            formPublic.Show();
        }
    }
}
