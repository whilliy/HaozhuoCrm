using Haozhuo.Crm.Service;
using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HaoZhuoCRM
{
    public partial class FormProjectManagement : Form
    {
        public FormProjectManagement()
        {
            InitializeComponent();
        }

        private void FormProjectManagement_Load(object sender, EventArgs e)
        {
            IList<ProjectDto> projects = ProjectService.ProjectsCopy;
            foreach (ProjectDto dto in projects)
            {
                ListViewItem lvi = new ListViewItem(dto.name);
                lvi.Tag = dto;
                listView1.Items.Add(lvi);
            }
        }

        private void ButClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                txtProjectName.Text = listView1.SelectedItems[0].Text;
                txtProjectName.Focus();
                txtProjectName.SelectAll();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            txtProjectName.Text = txtProjectName.Text.Trim();
            if (String.IsNullOrEmpty(txtProjectName.Text))
            {
                MessageBox.Show("必须输入项目名称");
                txtProjectName.Focus();
                return;
            }
            try
            {
                ProjectDto project = ProjectService.AddProject(txtProjectName.Text, Global.USER_TOKEN);
                ListViewItem lvi = new ListViewItem(project.name);
                lvi.Tag = project;
                listView1.Focus();
                listView1.Items.Add(lvi).Selected = true;
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            txtProjectName.Text = txtProjectName.Text.Trim();
            if (String.IsNullOrEmpty(txtProjectName.Text))
            {
                MessageBox.Show("必须输入项目名称");
                txtProjectName.Focus();
                return;
            }
            if (listView1.SelectedIndices.Count < 1)
            {
                MessageBox.Show("请选择要修改的项目记录");
                return;
            }
            ListViewItem lvi = listView1.SelectedItems[0];
            ProjectDto p = (ProjectDto)lvi.Tag;
            try
            {
                ProjectDto project = ProjectService.UpdateProject(p.id, txtProjectName.Text, Global.USER_TOKEN);
                lvi.Text = project.name;
                lvi.Tag = project;
                txtProjectName.Text = string.Empty;
                listView1.Focus();
                lvi.Selected = true;
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count < 1)
            {
                MessageBox.Show("请选择要删除的项目");
                return;
            }
            ListViewItem lvi = listView1.SelectedItems[0];
            ProjectDto p = (ProjectDto)lvi.Tag;
            if (DialogResult.No == MessageBox.Show("您确认要删除[" + p.name + "]项目吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1))
            {
                return;
            }
            try
            {
                ProjectService.DeleteProject(p.id, Global.USER_TOKEN);
                listView1.Items.Remove(lvi);
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
