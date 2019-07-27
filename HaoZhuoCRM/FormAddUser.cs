using Haozhuo.Crm.Service.Dto;
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
