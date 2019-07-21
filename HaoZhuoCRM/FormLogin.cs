﻿using Haozhuo.Crm.Service;
using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.vo;
using System;
using System.Windows.Forms;

namespace HaoZhuoCRM
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            txtAccountNo.Text = txtAccountNo.Text.Trim();
            txtPassword.Text = txtPassword.Text.Trim();
            if (txtAccountNo.Text.Length < 1)
            {
                MessageBox.Show("请输入您的账号");
                txtAccountNo.Focus();
                return;
            }
            if (txtPassword.Text == String.Empty)
            {
                MessageBox.Show("请输入密码");
                txtPassword.Focus();
                return;
            }
            UserLoginVo vo = new UserLoginVo();
            vo.password = txtPassword.Text;
            vo.principalName = txtAccountNo.Text;
            try
            {
                UserLoginDto login = LoginService.Login(vo);
                Global.USER_TOKEN = login.Token;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void ButExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
