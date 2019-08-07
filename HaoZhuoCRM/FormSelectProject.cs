using Haozhuo.Crm.Service.Dto;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HaoZhuoCRM
{
    public partial class FormSelectProject : Form
    {
        private IList<UserProjectDto> projects;
        public UserProjectDto CURRENT_PROJECT;
        public FormSelectProject(IList<UserProjectDto> projects)
        {
            InitializeComponent();
            this.projects = projects;

        }

        private void FormSelectProject_Load(object sender, EventArgs e)
        {
            cmbProjects.DataSource = projects;
            cmbProjects.DisplayMember = "projectName";
            cmbProjects.ValueMember = "projectId";
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (cmbProjects.SelectedValue == null)
            {
                MessageBox.Show("请选择一个项目!");
                return;
            }
            foreach (UserProjectDto up in projects)
            {
                if (up.projectId == Convert.ToInt32(cmbProjects.SelectedValue.ToString()))
                {
                    CURRENT_PROJECT = up;
                    break;
                }
            }
            if (CURRENT_PROJECT == null)
            {
                MessageBox.Show("请选择一个项目!");
                return;
            }
            DialogResult = DialogResult.OK;
        }
    }
}
