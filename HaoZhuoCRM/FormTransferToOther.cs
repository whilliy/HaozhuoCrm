using Haozhuo.Crm.Service;
using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
using Haozhuo.Crm.Service.vo;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HaoZhuoCRM
{
    public partial class FormTransferToOther : Form
    {
        private IList<string> customerIds;
        private IList<UserDto> targetUsers;
        public FormTransferToOther(IList<string> customerIds, IList<UserDto> targetUsers)
        {
            InitializeComponent();
            this.customerIds = customerIds;
            this.targetUsers = targetUsers;
        }

        private void FormTransferToOther_Load(object sender, System.EventArgs e)
        {
            try
            {
                var users = UserService.GetUsersSameByOrganization(Global.USER_TOKEN);
                foreach (UserDto user in users)
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
                MessageBox.Show("请选择一个数据转移目标用户", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ListViewItem lviSelected = lvUsers.SelectedItems[0];
            UserDto target = (UserDto)lviSelected.Tag;
            try
            {
                TransterCustomerVo vo = new TransterCustomerVo();
                vo.customerIds = customerIds;
                vo.targetUserId = target.id;
                CustomerService.TransferCustomersToTargetUsers(vo, Global.USER_TOKEN);
                DialogResult = DialogResult.OK;
            }
            catch (BusinessException ex)
            {
                MessageBox.Show("" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
