using Haozhuo.Crm.Service;
using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
using Haozhuo.Crm.Service.vo;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HaoZhuoCRM
{
    public partial class FormAllCustomersTransferToOther : Form
    {
        private IList<string> customerIds;
        private IList<UserDto> targetUsers;
        public FormAllCustomersTransferToOther(IList<string> customerIds, IList<UserDto> targetUsers)
        {
            InitializeComponent();
            this.customerIds = customerIds;
            this.targetUsers = targetUsers;
        }

        private void FormTransferToOther_Load(object sender, System.EventArgs e)
        {
            try
            {
                foreach (UserDto user in targetUsers)
                {
                    ListViewItem lvi = new ListViewItem(user.name);
                    lvi.SubItems.Add(user.mobile);
                    lvi.Tag = user;
                    lvUsers.Items.Add(lvi);
                }
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LvUsers_DoubleClick(object sender, System.EventArgs e)
        {
            tranfer();
        }

        private void ButtonOK_Click(object sender, System.EventArgs e)
        {
            tranfer();
        }

        private void tranfer()
        {
            if (lvUsers.SelectedItems.Count < 1)
            {
                MessageBox.Show("请选择一个用户", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ListViewItem lviSelected = lvUsers.SelectedItems[0];
            UserDto target = (UserDto)lviSelected.Tag;
            try
            {
                TransterCustomerVo vo = new TransterCustomerVo();
                vo.customerIds = customerIds;
                vo.targetUserId = target.id;
                CustomerService.AdminTransferCustomersToTargetUsers(vo, Global.USER_TOKEN);
                DialogResult = DialogResult.OK;
            }
            catch (BusinessException ex)
            {
                MessageBox.Show("客户转移发生错误" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
