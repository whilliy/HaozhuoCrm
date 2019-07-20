using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
using Haozhuo.Crm.Service.vo;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;

namespace Haozhuo.Crm.Service
{
    public class LoginService
    {
        public static UserLoginDto Login(UserLoginVo vo)
        {
            RestClient rc = new RestClient();
            var request = new RestRequest(GlobalConfig.USER_LOGIN, Method.POST);
            //String json = JsonConvert.SerializeObject(vo);
            request.AddJsonBody(vo);
            try
            {
                var response = rc.Post(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var login = JsonConvert.DeserializeObject<UserLoginDto>(response.Content);
                    return login;
                }
                else if (response.StatusCode == 0)
                {
                    throw new BusinessException("请检查网络");
                }
                else
                {
                    var x = JsonConvert.DeserializeObject<CustomException>(response.Content);
                    throw new BusinessException(x.Message);
                }
            }
            catch (BusinessException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }
    }
}
