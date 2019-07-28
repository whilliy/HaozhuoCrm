using Haozhuo.Crm.Service;
using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
using Haozhuo.Crm.Service.vo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HaoZhuoCRM
{
    public partial class FormAddUser : Form
    {
        public FormAddUser()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnYes_Click(object sender, EventArgs e)
        {
            txtAccountNo.Text = txtAccountNo.Text.Trim();
            txtName.Text = txtName.Text.Trim();
            txtMobile.Text = txtMobile.Text.Trim();
            if (String.IsNullOrEmpty(txtAccountNo.Text))
            {
                MessageBox.Show("必须输入账号");
                txtAccountNo.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("必须输入姓名");
                txtName.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtMobile.Text))
            {
                MessageBox.Show("必须输入姓名");
                txtMobile.Focus();
                return;
            }
            if (String.IsNullOrEmpty(cmbGenders.Text))
            {
                MessageBox.Show("必须制定性别");
                cmbGenders.Focus();
                return;
            }
            AddUserVo vo = new AddUserVo();
            vo.accountNo = txtAccountNo.Text;
            vo.name = txtName.Text;
            vo.mobile = txtMobile.Text;
            vo.gender = Convert.ToInt32(cmbGenders.SelectedValue.ToString());
            vo.organizationId = cmbOrganizations.SelectedValue.ToString();
            vo.permissionIds = collectionUserAllPermissions();
            try
            {
                UserDto user = UserService.AddUser(vo, Global.USER_TOKEN);
            }
            catch (BusinessException ex)
            {
                MessageBox.Show("添加用户发生错误：" + ex.Message, "提醒");
                txtAccountNo.Focus();
                return;
            }
            if (MessageBox.Show("用户添加成功！是否需要继续添加新的用户？", "提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                reset();
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void collectAllPermissions(IList<String> permissionIds, TreeNode node)
        {
            if (node != null && node.Nodes.Count > 0)
            {
                foreach (TreeNode leaf in node.Nodes)
                {
                    PermissionDto p = (PermissionDto)leaf.Tag;
                    if (p != null && !permissionIds.Contains(p.id))
                    {
                        permissionIds.Add(p.id);
                        collectAllPermissions(permissionIds, leaf);
                    }
                }
            }
        }

        private IList<string> collectionUserAllPermissions()
        {
            IList<String> permissionIds = new List<String>();
            foreach (TreeNode node in treeView1.Nodes)
            {
                PermissionDto p = (PermissionDto)node.Tag;
                if (p != null && !permissionIds.Contains(p.id))
                {
                    permissionIds.Add(p.id);
                    collectAllPermissions(permissionIds, node);
                }
            }
            return permissionIds;
        }

        private void assignUserPermissions(long userid)
        {
            IList<String> permissionIds = collectionUserAllPermissions();
            UserService.modifyUserPermissions(userid, permissionIds, Global.USER_TOKEN);
        }

        private void reset()
        {
            txtAccountNo.Text = "";
            txtName.Text = "";
            txtMobile.Text = "";
            cmbGenders.SelectedIndex = 0;
            cmbOrganizations.SelectedIndex = 0;
            txtAccountNo.Focus();
        }

        private void AssignTreeNode(TreeNode node)
        {
            PermissionDto p = (PermissionDto)node.Tag;
            {
                if (p.children != null)
                {
                    foreach (PermissionDto child in p.children)
                    {
                        TreeNode leaf = new TreeNode(child.name);
                        node.Nodes.Add(leaf);
                        leaf.Tag = child;
                        AssignTreeNode(leaf);
                    }
                }
            }
        }

        private void LoadPermissionTrees()
        {
            try
            {
                var permissions = PermissionService.PERMISSION_TREES;
                treeView1.Nodes.Clear();
                foreach (PermissionDto p in permissions)
                {
                    TreeNode node = new TreeNode(p.name);
                    node.Tag = p;
                    if (p.children != null)
                    {
                        AssignTreeNode(node);
                    }
                    treeView1.Nodes.Add(node);
                }
                treeView1.ExpandAll();
            }
            catch (BusinessException ex)
            {
                MessageBox.Show("加载权限列表失败：" + ex.Message);
            }
        }

        private void FormAddUser_Load(object sender, EventArgs e)
        {
            var genders = Genders.ALL_COPY;
            cmbGenders.ValueMember = "id";
            cmbGenders.DisplayMember = "name";
            cmbGenders.DataSource = genders;
            var organizations = OrganizationService.OrganizationsCopy;
            cmbOrganizations.ValueMember = "id";
            cmbOrganizations.DisplayMember = "name";
            cmbOrganizations.DataSource = organizations;
            LoadPermissionTrees();
        }

        private void ChildrenCheck(TreeNode node)
        {
            if (node.Nodes.Count > 0)
            {
                foreach (TreeNode leaf in node.Nodes)
                {
                    leaf.Checked = node.Checked;
                    ChildrenCheck(leaf);
                }
            }
        }

        private void ParentCheck(TreeNode node)
        {
            if (node.Checked && node.Parent != null)
            {
                node.Parent.Checked = true;
                ParentCheck(node.Parent);
            }
        }

        private void TreeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            if (node != null)
            {
                //不加上这个死循环，内存溢出
                treeView1.AfterCheck -= TreeView1_AfterCheck;
                ParentCheck(node);
                ChildrenCheck(node);
                treeView1.AfterCheck += TreeView1_AfterCheck;
            }
        }
    }
}
