using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Haozhuo.Crm.Service
{
    public class CustomerService
    {
        /// <summary>
        /// 根據條件查詢客戶信息
        /// </summary>
        /// <param name="token"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="status"></param>
        /// <param name="source"></param>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="mobile"></param>
        /// <param name="provinceId"></param>
        /// <param name="cityId"></param>
        /// <param name="countyId"></param>
        /// <returns></returns>
        public static List<CustomerDto> QueryCustomers(String token, Int32? pageNum,
                                                        Int32? pageSize,
                                                        Int32? status,
                                                        Int32? source,
                                                        Int32? type,
                                                        String name,
                                                        String mobile,
                                                        String provinceId,
                                                        String cityId,
                                                        String countyId)
        {
            RestClient rc = new RestClient();
            var request = new RestRequest(GlobalConfig.CUSTOMERS, Method.GET);
            //String json = JsonConvert.SerializeObject(vo);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            if (pageNum != null)
            {
                request.AddParameter("page", pageNum);
            }
            request.AddParameter("province_id", provinceId);
            if (pageSize != null)
            {
                request.AddParameter("page_size", pageSize);
            }
            if (status != null)
            {
                request.AddParameter("status", status);
            }
            if (source != null)
            {
                request.AddParameter("source", source);
            }
            if (type != null)
            {
                request.AddParameter("type", type);
            }
            request.AddParameter("mobile", mobile);
            request.AddParameter("city_id", cityId);
            request.AddParameter("county_id", countyId);
            request.AddParameter("name", name);
            try
            {
                var response = rc.Get(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var login = JsonConvert.DeserializeObject<List<CustomerDto>>(response.Content);
                    //var count = response.Headers[GlobalConfig.X_TOTAL_COUNT];
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
