using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HaoZhuoCRM
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void MiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
    }
}
