using System;

namespace Haozhuo.Crm.Service.vo
{
    public class ModifyPassword
    {
        public String oldPassword { get; set; }
        public String newPassword { get; set; }

        public ModifyPassword()
        {

        }

        public ModifyPassword(String old, String newPass)
        {
            this.oldPassword = old;
            this.newPassword = newPass;
        }
    }
}
