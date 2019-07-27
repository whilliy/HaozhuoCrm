using Haozhuo.Crm.Service;
using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
using Haozhuo.Crm.Service.vo;
using System;
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

        private void reset()
        {
            txtAccountNo.Text = "";
            txtName.Text = "";
            txtMobile.Text = "";
            cmbGenders.SelectedIndex = 0;
            txtAccountNo.Focus();
        }

        private void FormAddUser_Load(object sender, EventArgs e)
        {
            var genders = Genders.ALL_COPY;
            cmbGenders.ValueMember = "id";
            cmbGenders.DisplayMember = "name";
            cmbGenders.DataSource = genders;
        }
    }
}
