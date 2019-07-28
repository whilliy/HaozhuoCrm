using Haozhuo.Crm.Service;
using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
using HaoZhuoCRM.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HaoZhuoCRM
{
    public partial class FormUser : Form
    {
        public FormUser()
        {
            InitializeComponent();
        }


        private void FormUser_Load(object sender, EventArgs e)
        {
            IList<Gender> genders = Genders.ALL_COPY;
            genders.Insert(0, new Gender(-1, ""));
            cmbGenders.DataSource = genders;
            cmbGenders.DisplayMember = "name";
            cmbGenders.ValueMember = "id";
            cmbStatuses.Items.Add("");
            cmbStatuses.Items.Add("可用");
            cmbStatuses.Items.Add("禁用");
            //初始化控件
            pager.Reset();
            //pager.RemovePageSizeSelectedIndexChanged();
        }

        private ResultsWithCount<UserDto> QueryUsers()
        {
            txtMobile.Text = txtMobile.Text.Trim();
            txtName.Text = txtName.Text.Trim();
            int? gender = null;
            if (!String.IsNullOrEmpty(cmbGenders.Text))
            {
                gender = Convert.ToInt32(cmbGenders.SelectedValue.ToString());
                if (gender == -1)
                {
                    gender = null;
                }
            }
            Boolean? active = null;
            if (cmbStatuses.SelectedIndex == 1)
            {
                active = true;
            }
            else if (cmbStatuses.SelectedIndex == 2)
            {
                active = false;
            }
            return UserService.QueryUsers(Global.USER_TOKEN, pager.PageIndex, pager.PageSize, txtName.Text,
                txtMobile.Text, gender, active);
        }

        void refresh(IList<UserDto> users)
        {
            lvUsers.Items.Clear();
            Int32 index = 1 + (pager.PageSize) * (pager.PageIndex - 1);
            foreach (UserDto user in users)
            {
                ListViewItem lvi = new ListViewItem(index.ToString());
                lvi.SubItems.Add(user.name);
                lvi.SubItems.Add(user.accountNo);
                if (user.gender == null)
                {
                    lvi.SubItems.Add("未知");
                }
                else if (user.gender == 1)
                {
                    lvi.SubItems.Add("男");
                }
                else if (user.gender == 2)
                {
                    lvi.SubItems.Add("女");
                }
                else
                {
                    lvi.SubItems.Add("未知");
                }
                lvi.SubItems.Add(user.mobile);
                if (user.active)
                {
                    lvi.SubItems.Add("可用");
                }
                else
                {
                    lvi.SubItems.Add("禁用");
                }
                lvi.Tag = user;
                lvUsers.Items.Add(lvi);
                index++;
            }
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                //根据条件查询用户
                ResultsWithCount<UserDto> users = QueryUsers();
                //获取符合条件的用户总数量后修改Pager的相关属性
                pager.PageIndex = 1;
                pager.DrawControl((int)users.getCount());
                //更新用户列表
                refresh(users.getResults());
                pager.NeedExcuteQuery = true;
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Pager_OnPageChanged(object sender, EventArgs e)
        {
            try
            {
                ResultsWithCount<UserDto> users = QueryUsers();
                refresh(users.getResults());
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            txtMobile.Text = txtName.Text = string.Empty;
            cmbGenders.SelectedIndex = cmbStatuses.SelectedIndex = 0;
            lvUsers.Items.Clear();
            pager.Reset();
            txtName.Focus();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FormAddUser frmAddUser = new FormAddUser();
            frmAddUser.ShowDialog();
        }

        private void BtnResetPassword_Click(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count < 1)
            {
                MessageBox.Show("请在列表中选择要重置密码的用户！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ListViewItem lvi = lvUsers.SelectedItems[0];
            UserDto user = (UserDto)lvi.Tag;
            FormResetUserPass frmResetPass = new FormResetUserPass(user);
            frmResetPass.ShowDialog();
            lvUsers.Focus();
            lvi.Selected = true;
        }

        private void LvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count < 1)
            {
                return;
            }
            ListViewItem lvi = lvUsers.SelectedItems[0];
            UserDto user = (UserDto)lvi.Tag;
            if (user.active)
            {
                btnDisable.Enabled = true;
                btnEnable.Enabled = false;
            }
            else
            {
                btnDisable.Enabled = false;
                btnEnable.Enabled = true;
            }
        }

        private void BtnDisable_Click(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count < 1)
            {
                MessageBox.Show("请在列表中选择用户！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ListViewItem lvi = lvUsers.SelectedItems[0];
            UserDto user = (UserDto)lvi.Tag;
            if (!user.active)
            {
                btnDisable.Enabled = false;
                btnEnable.Enabled = true;
                lvi.SubItems[ListViewHelper.getIndexByText(lvUsers, "状态").Value].Text = "禁用";
                lvUsers.Focus();
                lvi.Selected = true;
                return;
            }
            try
            {
                UserService.DisableUser(user.id, Global.USER_TOKEN);
                btnDisable.Enabled = false;
                btnEnable.Enabled = true;
                user.active = false;
                lvi.SubItems[ListViewHelper.getIndexByText(lvUsers, "状态").Value].Text = "禁用";
            }
            catch (BusinessException ex)
            {
                MessageBox.Show("禁用用户失败：" + ex.Message);
                return;
            }
            finally
            {
                lvUsers.Focus();
                lvi.Selected = true;
            }
        }

        private void BtnEnable_Click(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count < 1)
            {
                MessageBox.Show("请在列表中选择用户！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ListViewItem lvi = lvUsers.SelectedItems[0];
            UserDto user = (UserDto)lvi.Tag;
            if (user.active)
            {
                btnDisable.Enabled = true;
                btnEnable.Enabled = false;
                lvi.SubItems[ListViewHelper.getIndexByText(lvUsers, "状态").Value].Text = "启用";
                lvUsers.Focus();
                lvi.Selected = true;
                return;
            }
            try
            {
                UserService.EnableUser(user.id, Global.USER_TOKEN);
                btnDisable.Enabled = true;
                btnEnable.Enabled = false;
                lvi.SubItems[ListViewHelper.getIndexByText(lvUsers, "状态").Value].Text = "启用";
                user.active = true;
            }
            catch (BusinessException ex)
            {
                MessageBox.Show("启用用户失败：" + ex.Message);
                return;
            }
            finally
            {
                lvUsers.Focus();
                lvi.Selected = true;
            }
        }

        private void ModifyUser()
        {
            ListViewItem lvi = lvUsers.SelectedItems[0];
            UserDto user = (UserDto)lvi.Tag;
            FormUpdateUser formUpdateUser = new FormUpdateUser(user);
            if (DialogResult.OK == formUpdateUser.ShowDialog())
            {
                lvi.Tag = formUpdateUser.CurrentUser;
                UserDto currentUser = formUpdateUser.CurrentUser;
                lvi.SubItems[ListViewHelper.getIndexByText(lvUsers, "姓名").Value].Text = currentUser.name;
                String gender = "";
                if (currentUser.gender.HasValue)
                {
                    gender = Genders.DIC_GENDER[currentUser.gender.Value];
                }
                lvi.SubItems[ListViewHelper.getIndexByText(lvUsers, "性别").Value].Text = gender;
                lvi.SubItems[ListViewHelper.getIndexByText(lvUsers, "手机号码").Value].Text = currentUser.mobile;
                string status = user.active ? "可用" : "禁用";
                lvi.SubItems[ListViewHelper.getIndexByText(lvUsers, "状态").Value].Text = status;
            }

        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count < 1)
            {
                MessageBox.Show("请在列表中选择用户！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ModifyUser();
        }

        private void LvUsers_DoubleClick(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count < 1)
            {
                return;
            }
            ModifyUser();
        }
    }
}
