using Haozhuo.Crm.Service;
using Haozhuo.Crm.Service.Dto;
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
            PermissionControl.Add("DISPATCH", miDispatch);
            PermissionControl.Add("IMPORT", miImport);
            PermissionControl.Add("ADD_CUSTOMER", miAddCustomer);
            PermissionControl.Add("ALL_CUSTOEMRS", miAllCustomers);
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
                frmLogin.Close();
                return;
            }
            frmLogin.Close();
            SelectProject();
            matchPermissions();
            labelCurrentName.Text = Global.USER_NAME;
            lableCurrentOrganization.Text = Global.ORGANIZAITON_NAME;
            labelCurrentProject.Text = Global.CURRENT_PROJECT_NAME;
        }

        private void SelectProject()
        {
            //选择项目
            try
            {
                IList<UserProjectDto> projects = UserService.GetProjectsByUserId(Global.USER_ID, Global.USER_TOKEN);
                if (projects.Count == 1)
                {
                    Global.CURRENT_PROJECT_ID = projects[0].projectId;
                    Global.CURRENT_PROJECT_NAME = projects[0].projectName;
                }
                else if (projects.Count >= 2)
                {
                    FormSelectProject formSelectProject = new FormSelectProject(projects);
                    DialogResult result = formSelectProject.ShowDialog();
                    formSelectProject.Close();
                    if (result == DialogResult.OK)
                    {
                        Global.CURRENT_PROJECT_ID = formSelectProject.CURRENT_PROJECT.projectId;
                        Global.CURRENT_PROJECT_NAME = formSelectProject.CURRENT_PROJECT.projectName;
                    }
                    else
                    {
                        MessageBox.Show("您没有选择任何项目，请重新登录并选择本次要操作的项目");
                        Application.Exit();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("您的账户未关联任何项目，如有需要请跟管理员取得联系!", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                    return;
                }
            }
            catch (BusinessException ex)
            {
                MessageBox.Show("获取用户关联项目列表失败:" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
                return;
            }

        }

        private void MiMyClients_Click(object sender, EventArgs e)
        {
            FormMyCustomers formMyClients = new FormMyCustomers();
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
            if (frmLogin.ShowDialog() != DialogResult.OK)
            {
                frmLogin.Close();
                return;
            }
            frmLogin.Close();
            SelectProject();
            matchPermissions();

            labelCurrentName.Text = Global.USER_NAME;
            lableCurrentOrganization.Text = Global.ORGANIZAITON_NAME;
            labelCurrentProject.Text = Global.CURRENT_PROJECT_NAME;
        }

        private void MiPublic_Click(object sender, EventArgs e)
        {
            FormPublic formPublic = new FormPublic();
            formPublic.MdiParent = this;
            formPublic.Show();
        }

        private void MiDispatch_Click(object sender, EventArgs e)
        {
            FormDispatch formDispatch = new FormDispatch();
            formDispatch.MdiParent = this;
            formDispatch.Show();
        }

        private void MiAddCustomer_Click(object sender, EventArgs e)
        {
            FormAddCustomer frmAddCustomer = new FormAddCustomer();
            frmAddCustomer.ShowDialog();
        }

        private void MiImport_Click(object sender, EventArgs e)
        {
            FormImportData frmImport = new FormImportData();
            frmImport.ShowDialog();
        }

        private void MiAbout_Click(object sender, EventArgs e)
        {
            FormAbout frmAbout = new FormAbout();
            frmAbout.ShowDialog();
        }

        private void MiAllCustomers_Click(object sender, EventArgs e)
        {
            FormAllCustomers formAllCustomers = new FormAllCustomers();
            formAllCustomers.MdiParent = this;
            formAllCustomers.Show();
        }
    }
}
