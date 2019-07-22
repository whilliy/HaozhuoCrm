using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace Haozhuo.Crm.Service
{
    public class CustomerService : BaseService
    {
        private static readonly object lockTypes= new object();
        private static readonly object lockSources= new object();

        private static IList<CustomerTypeDto> cusomterTypes;

        public static IList<CustomerTypeDto> CustomerTypes
        {
            get
            {
                if (cusomterTypes == null)
                {
                    lock (lockTypes)
                    {
                        if (cusomterTypes == null)
                        {
                            cusomterTypes = getAllCustomerTypes();
                        }
                    }
                }
                return cusomterTypes;
            }
        }

        private static IList<CustomerSourceDto> customerSources;

        public static IList<CustomerSourceDto> CustomerSources
        {
            get
            {
                if (customerSources == null)
                {
                    lock (lockSources)
                    {
                        if (customerSources == null)
                        {
                            customerSources = getAllCustomerSources();
                        }
                    }
                }
                return customerSources;
            }
        }

        private static IDictionary<Int32, String> dicCustomerSources;

        public static IDictionary<Int32, String> DicCustomerSources
        {
            get
            {
                if (dicCustomerSources == null)
                {
                    dicCustomerSources = new Dictionary<Int32, String>();
                    foreach (CustomerSourceDto source in CustomerSources)
                    {
                        dicCustomerSources.Add(source.id, source.name);
                    }
                }
                return dicCustomerSources;
            }
        }
        private static IDictionary<Int32, String> dicCustomerTypes;

        public static IDictionary<Int32, String> DicCustomerTypes
        {
            get
            {
                if (dicCustomerTypes == null)
                {
                    dicCustomerTypes = new Dictionary<Int32, String>();
                    foreach (CustomerTypeDto type in cusomterTypes)
                    {
                        dicCustomerTypes.Add(type.id, type.name);
                    }
                }
                return dicCustomerTypes;
            }
        }


        /// <summary>
        /// 获取所有的客户类型
        /// </summary>
        /// <returns></returns>
        public static List<CustomerTypeDto> getAllCustomerTypes()
        {
            RestClient rs = new RestClient();
            var request = new RestRequest(GlobalConfig.CUSTOMER_TYPES);
            //request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            IRestResponse response;
            try
            {
                response = rs.Execute(request, Method.GET);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
            if (response.StatusCode == 0)
            {
                throw new BusinessException("请检查网络");
            }
            if (response.StatusCode != HttpStatusCode.OK)
            {
                var res = rs.Deserialize<CustomException>(response);
                var customException = res.Data;
                throw new BusinessException(customException.message);
            }
            try
            {
                var types = rs.Deserialize<List<CustomerTypeDto>>(response);
                return types.Data;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }



        /// <summary>
        /// 获取所有的客户
        /// </summary>
        /// <returns></returns>
        public static List<CustomerSourceDto> getAllCustomerSources()
        {
            RestClient rs = new RestClient();
            var request = new RestRequest(GlobalConfig.CUSTOMER_SOURCES);
            //request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            IRestResponse response;
            try
            {
                response = rs.Execute(request, Method.GET);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
            if (response.StatusCode == 0)
            {
                throw new BusinessException("请检查网络");
            }
            if (response.StatusCode != HttpStatusCode.OK)
            {
                var res = rs.Deserialize<CustomException>(response);
                var customException = res.Data;
                throw new BusinessException(customException.message);
            }
            try
            {
                var types = rs.Deserialize<List<CustomerSourceDto>>(response);
                return types.Data;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

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
        public static ResultsWithCount<CustomerDto> QueryCustomers(String token, Int32? pageNum,
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
            if (!String.IsNullOrEmpty(mobile))
            {
                request.AddParameter("mobile", mobile);
            }
            if (!String.IsNullOrEmpty(cityId))
            {
                request.AddParameter("city_id", cityId);
            }
            if (!String.IsNullOrEmpty(countyId))
            {
                request.AddParameter("county_id", countyId);
            }
            if (!String.IsNullOrEmpty(name))
            {
                request.AddParameter("name", name);
            }
            try
            {
                var response = rc.Get(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var customers = rc.Deserialize<List<CustomerDto>>(response);
                    //var count = response.Headers[GlobalConfig.X_TOTAL_COUNT];
                    return ResultsWithCount<CustomerDto>.of(customers.Data, GetTotalCountFromResponseHeaders(response));
                }
                else if (response.StatusCode == 0)
                {
                    throw new BusinessException("请检查网络");
                }
                else
                {
                    var x = JsonConvert.DeserializeObject<CustomException>(response.Content);
                    throw new BusinessException(x.message);
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
