using Haozhuo.Crm.Service;
using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HaoZhuoCRM
{
    public partial class FormOrganization : Form
    {
        public FormOrganization()
        {
            InitializeComponent();
        }

        private void FormOrganizationManagement_Load(object sender, EventArgs e)
        {
            IList<OrganizationDto> organizations = OrganizationService.OrganizationsCopy;
            foreach (OrganizationDto dto in organizations)
            {
                ListViewItem lvi = new ListViewItem(dto.name);
                lvi.SubItems.Add(dto.createdTime.ToString("yyyy-MM-dd HH:mm:ss"));
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
                txtOrganizationName.Text = listView1.SelectedItems[0].Text;
                txtOrganizationName.Focus();
                txtOrganizationName.SelectAll();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            txtOrganizationName.Text = txtOrganizationName.Text.Trim();
            if (String.IsNullOrEmpty(txtOrganizationName.Text))
            {
                MessageBox.Show("必须输入组织名称");
                txtOrganizationName.Focus();
                return;
            }
            try
            {
                OrganizationDto organization = OrganizationService.AddOrganization(txtOrganizationName.Text, Global.USER_TOKEN);
                ListViewItem lvi = new ListViewItem(organization.name);
                lvi.SubItems.Add(organization.createdTime.ToString("yyyy-MM-dd HH:mm:ss"));
                lvi.Tag = organization;
                txtOrganizationName.Text = string.Empty;
                listView1.Items.Add(lvi).Selected = true;
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            txtOrganizationName.Text = txtOrganizationName.Text.Trim();
            if (String.IsNullOrEmpty(txtOrganizationName.Text))
            {
                MessageBox.Show("必须输入组织名称");
                txtOrganizationName.Focus();
                return;
            }
            if (listView1.SelectedIndices.Count < 1)
            {
                MessageBox.Show("请选择要修改的组织记录");
                return;
            }
            ListViewItem lvi = listView1.SelectedItems[0];
            OrganizationDto p = (OrganizationDto)lvi.Tag;
            try
            {
                OrganizationDto organization = OrganizationService.UpdateOrganization(p.id, txtOrganizationName.Text, Global.USER_TOKEN);
                lvi.Text = organization.name;
                lvi.Tag = organization;
                txtOrganizationName.Text = "";
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
                MessageBox.Show("请选择要删除的组织");
                return;
            }
            ListViewItem lvi = listView1.SelectedItems[0];
            OrganizationDto p = (OrganizationDto)lvi.Tag;
            if (DialogResult.No == MessageBox.Show("您确认要删除[" + p.name + "]组织吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1))
            {
                return;
            }
            try
            {
                OrganizationService.DeleteOrganizationt(p.id, Global.USER_TOKEN);
                listView1.Items.Remove(lvi);
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
