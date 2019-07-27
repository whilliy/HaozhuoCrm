using Haozhuo.Crm.Service;
using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
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
            return UserService.QueryCustomers(Global.USER_TOKEN, pager.PageIndex, pager.PageSize, txtName.Text,
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
                lvUsers.Items.Add(lvi);
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
    }
}
