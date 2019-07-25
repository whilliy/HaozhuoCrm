using Haozhuo.Crm.Service;
using Haozhuo.Crm.Service.Dto;
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
        }
    }
}
