using Haozhuo.Crm.Service;
using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
using Haozhuo.Crm.Service.vo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HaoZhuoCRM
{
    public partial class FormUpdateUser : Form
    {
        public UserDto CurrentUser { get; set; }
        public FormUpdateUser(UserDto user)
        {
            InitializeComponent();
            CurrentUser = user;
        }


        private IList<Int32> CollectionAllProjects()
        {
            IList<Int32> projectIds = new List<Int32>();
            foreach (TreeNode node in tvProjects.Nodes)
            {
                if (node.Checked)
                {
                    ProjectDto dto = (ProjectDto)node.Tag;
                    if (dto != null)
                    {
                        projectIds.Add(dto.id);
                    }
                }
            }
            return projectIds;
        }

        private void LoadProjects()
        {
            var projects = ProjectService.ProjectsCopy;
            foreach (ProjectDto dto in projects)
            {
                TreeNode node = new TreeNode(dto.name);
                node.Tag = dto;
                tvProjects.Nodes.Add(node);
            }
            var projectIds = new List<Int32>();
            try
            {
                IList<UserProjectDto> myProjects = UserService.GetProjectsByUserId(CurrentUser.id, Global.USER_TOKEN);
                if (myProjects.Count > 0)
                {
                    foreach (var pdto in myProjects)
                    {
                        projectIds.Add(pdto.projectId);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取用户关联部门失败：" + ex.Message);
                return;
            }
            foreach (TreeNode node in tvProjects.Nodes)
            {
                var project = (ProjectDto)node.Tag;
                if (projectIds.Contains(project.id))
                {
                    node.Checked = true;
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnYes_Click(object sender, EventArgs e)
        {
            txtName.Text = txtName.Text.Trim();
            txtMobile.Text = txtMobile.Text.Trim();
            if (String.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("必须输入姓名");
                txtName.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtMobile.Text))
            {
                MessageBox.Show("必须输入手机号码");
                txtMobile.Focus();
                return;
            }
            if (String.IsNullOrEmpty(cmbGenders.Text))
            {
                MessageBox.Show("必须指定性别");
                cmbGenders.Focus();
                return;
            }
            if (String.IsNullOrEmpty(cmbOrganizations.Text))
            {
                MessageBox.Show("必须指定部门");
                cmbOrganizations.Focus();
                return;
            }
            AddUserVo vo = new AddUserVo();
            vo.name = txtName.Text;
            vo.mobile = txtMobile.Text;
            vo.gender = Convert.ToInt32(cmbGenders.SelectedValue.ToString());
            vo.organizationId = cmbOrganizations.SelectedValue.ToString();
            vo.permissionIds = collectionUserAllPermissions();
            vo.projectIds = CollectionAllProjects();
            if (vo.projectIds.Count < 1 && MessageBox.Show("您确认该用户不关联任何一个项目？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {

                return;
            }
            try
            {
                CurrentUser = UserService.UpdateUser(CurrentUser.id, vo, Global.USER_TOKEN);
            }
            catch (BusinessException ex)
            {
                MessageBox.Show("修改用户发生错误：" + ex.Message, "提醒");
                txtName.Focus();
                return;
            }
            MessageBox.Show("修改成功！", "提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;

        }

        private void collectAllPermissions(IList<String> permissionIds, TreeNode node)
        {
            if (node != null && node.Nodes.Count > 0)
            {
                foreach (TreeNode leaf in node.Nodes)
                {
                    PermissionDto p = (PermissionDto)leaf.Tag;
                    if (leaf.Checked && p != null && !permissionIds.Contains(p.id))
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
                if (node.Checked && p != null && !permissionIds.Contains(p.id))
                {
                    permissionIds.Add(p.id);
                    collectAllPermissions(permissionIds, node);
                }
            }
            return permissionIds;
        }

        private void LoadInitalValues()
        {
            txtAccountNo.Text = CurrentUser.accountNo;
            txtName.Text = CurrentUser.name;
            txtMobile.Text = CurrentUser.mobile;
            cmbGenders.SelectedValue = CurrentUser.gender;
            if (!String.IsNullOrEmpty(CurrentUser.organizationId))
            {
                cmbOrganizations.SelectedValue = CurrentUser.organizationId;
            }
            txtName.Focus();
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
                return;
            }

            try
            {
                var permissionIds = UserService.getUserPermissionIds(CurrentUser.id, Global.USER_TOKEN);

                treeView1.AfterCheck -= TreeView1_AfterCheck;
                foreach (TreeNode node in treeView1.Nodes)
                {
                    match(node, permissionIds);
                }
                treeView1.AfterCheck += TreeView1_AfterCheck;

            }
            catch (BusinessException ex)
            {
                MessageBox.Show("获取该用户的权限信息失败：" + ex.Message);
            }

        }

        private void match(TreeNode node, IList<String> permissionIds)
        {
            PermissionDto p = (PermissionDto)node.Tag;
            node.Checked = permissionIds.Contains(p.id);
            foreach (TreeNode leaf in node.Nodes)
            {
                match(leaf, permissionIds);
            }
        }

        private void FormAddUser_Load(object sender, EventArgs e)
        {
            var genders = Genders.ALL_COPY;
            cmbGenders.ValueMember = "id";
            cmbGenders.DisplayMember = "name";
            cmbGenders.DataSource = genders;
            //cmbGenders.SelectedValue = CurrentUser.gender;
            var organizations = OrganizationService.OrganizationsCopy;
            cmbOrganizations.ValueMember = "id";
            cmbOrganizations.DisplayMember = "name";
            cmbOrganizations.DataSource = organizations;
            LoadInitalValues();
            LoadPermissionTrees();
            LoadProjects();
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
