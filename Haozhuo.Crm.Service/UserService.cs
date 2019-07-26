using Haozhuo.Crm.Service.Utils;
using Haozhuo.Crm.Service.vo;
using RestSharp;
using System;
using System.Net;

namespace Haozhuo.Crm.Service
{
    public class UserService
    {  /// <summary>
       /// 修改用户密码
       /// </summary>
       /// <param name="customerId"></param>
       /// <param name="token"></param>
       /// <returns></returns>
        public static void ModifyPassword(String token, String oldPassword, String newPassword)
        {
            RestClient rc = new RestClient();
            var request = new RestRequest(GlobalConfig.USER_MODIFY_PASSWORD);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            request.AddJsonBody(new ModifyPassword(oldPassword, newPassword));
            IRestResponse response;
            try
            {
                response = rc.Execute(request, Method.PATCH);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
            if (response.StatusCode == 0)
            {
                throw new BusinessException("请检查网络");
            }
            if (response.StatusCode != HttpStatusCode.NoContent)
            {
                var res = rc.Deserialize<CustomException>(response);
                var customException = res.Data;
                throw new BusinessException(customException.message);
            }
        }
    }
}
