using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
using Haozhuo.Crm.Service.vo;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace Haozhuo.Crm.Service
{
    public class CustomerService : BaseService
    {
        private static readonly object lockTypes = new object();
        private static readonly object lockSources = new object();

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

        /// <summary>
        /// 客户类型列表新拷贝
        /// </summary>
        /// <returns></returns>
        public static IList<CustomerTypeDto> CustomerTypesCopy()
        {
            IList<CustomerTypeDto> customerTypesCopy = new List<CustomerTypeDto>();
            foreach (CustomerTypeDto c in CustomerTypes)
            {
                customerTypesCopy.Add(new CustomerTypeDto(c.id, c.name));
            }
            return customerTypesCopy;
        }

        private static IList<CustomerSourceDto> customerSources;

        /// <summary>
        /// 客户来源列表
        /// </summary>
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

        /// <summary>
        /// 获取客户来源的列表拷贝
        /// </summary>
        /// <returns></returns>
        public static IList<CustomerSourceDto> CustomerSourcesCopy()
        {
            IList<CustomerSourceDto> cusotmerSourcesCopies = new List<CustomerSourceDto>();
            foreach (CustomerSourceDto s in CustomerSources)
            {
                cusotmerSourcesCopies.Add(new CustomerSourceDto(s.id, s.name));
            }
            return cusotmerSourcesCopies;
        }

        private static IDictionary<Int32, String> dicCustomerSources;
        /// <summary>
        /// 客户来源值与名称字典
        /// </summary>
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
        /// <summary>
        /// 客户类型值与名称字典
        /// </summary>
        public static IDictionary<Int32, String> DicCustomerTypes
        {
            get
            {
                if (dicCustomerTypes == null)
                {
                    dicCustomerTypes = new Dictionary<Int32, String>();
                    foreach (CustomerTypeDto type in CustomerTypes)
                    {
                        dicCustomerTypes.Add(type.id, type.name);
                    }
                }
                return dicCustomerTypes;
            }
        }



        private static readonly object objstatus = new object();
        private static IList<CustomerStatus> statuses;
        /// <summary>
        /// 客户状态列表
        /// </summary>
        public static IList<CustomerStatus> CustomerStatuses
        {
            get
            {
                if (statuses == null)
                {
                    lock (objstatus)
                    {
                        if (statuses == null)
                        {
                            statuses = getCustomerStatuses();
                        }
                    }
                }
                return statuses;
            }
        }

        /// <summary>
        /// 获取客户状态列表的副本
        /// </summary>
        /// <returns></returns>
        public static IList<CustomerStatus> CustomerStatusesCopy()
        {
            IList<CustomerStatus> customerStatusesCopies = new List<CustomerStatus>();
            foreach (CustomerStatus s in CustomerStatuses)
            {
                customerStatusesCopies.Add(new CustomerStatus(s.id, s.name));
            }
            return customerStatusesCopies;
        }

        private static IDictionary<Int32, String> dicCustomerStatuses;
        public static IDictionary<Int32, String> DicCustomerStatuses
        {
            get
            {
                if (dicCustomerStatuses == null)
                {
                    lock (objstatus)
                    {
                        if (dicCustomerStatuses == null)
                        {
                            dicCustomerStatuses = new Dictionary<Int32, String>();
                            foreach (CustomerStatus status in CustomerStatuses)
                            {
                                dicCustomerStatuses.Add(status.id, status.name);
                            }
                        }
                    }
                }
                return dicCustomerStatuses;
            }
        }


        private static IList<CustomerStatus> getCustomerStatuses()
        {
            RestClient rs = new RestClient();
            var request = new RestRequest(GlobalConfig.CUSTOMER_STATUSES);
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
                var statuses = rs.Deserialize<List<CustomerStatus>>(response);
                return statuses.Data;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

        /// <summary>
        /// 获取所有的客户类型
        /// </summary>
        /// <returns></returns>
        private static List<CustomerTypeDto> getAllCustomerTypes()
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
        /// 获取所有的客户来源
        /// </summary>
        /// <returns></returns>
        private static List<CustomerSourceDto> getAllCustomerSources()
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
        /// 根据顾客Id获取顾客的所有跟进记录列表
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static IList<CustomerFollowRecord> GetFollowerRecordsByCusotmerId(String customerId, String token)
        {
            RestClient rc = new RestClient();
            var request = new RestRequest(GlobalConfig.CUSTOER_FOLLOW_RECORDS);
            request.AddUrlSegment("customerId", customerId);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            IRestResponse response;
            try
            {
                response = rc.Execute(request, Method.GET);
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
                var res = rc.Deserialize<CustomException>(response);
                var customException = res.Data;
                throw new BusinessException(customException.message);
            }
            try
            {
                var types = rc.Deserialize<List<CustomerFollowRecord>>(response);
                return types.Data;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

        /// <summary>
        /// 添加客户跟进记录
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="token"></param>
        /// <param name="record"></param>
        /// <returns></returns>
        public static CustomerFollowRecord AddFllowRecord(String customerId, String token, AddFollowRecord record)
        {
            RestClient rc = new RestClient();
            var request = new RestRequest(GlobalConfig.CUSTOER_FOLLOW_RECORDS);
            request.AddUrlSegment("customerId", customerId);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            request.AddJsonBody(record);
            IRestResponse response;
            try
            {
                response = rc.Execute(request, Method.POST);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
            if (response.StatusCode == 0)
            {
                throw new BusinessException("请检查网络");
            }
            if (response.StatusCode != HttpStatusCode.Created)
            {
                var res = rc.Deserialize<CustomException>(response);
                var customException = res.Data;
                throw new BusinessException(customException.message);
            }
            try
            {
                var types = rc.Deserialize<CustomerFollowRecord>(response);
                return types.Data;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }


        /// <summary>
        /// 更新客户信息
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="token"></param>
        /// <param name="record"></param>
        /// <returns></returns>
        public static CustomerDto updateCustomer(String customerId, String token, CustomerVo vo)
        {
            RestClient rc = new RestClient();
            var request = new RestRequest(GlobalConfig.CUSTOER_SOMEONE);
            request.AddUrlSegment("customerId", customerId);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            request.AddJsonBody(vo);
            IRestResponse response;
            try
            {
                response = rc.Execute(request, Method.PUT);
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
                var res = rc.Deserialize<CustomException>(response);
                var customException = res.Data;
                throw new BusinessException(customException.message);
            }
            try
            {
                var types = rc.Deserialize<CustomerDto>(response);
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
        public static ResultsWithCount<CustomerDto> QueryCustomers(String token,
                                                        Int32? pageNum,
                                                        Int32? pageSize,
                                                        Int32? projectId,
                                                        Int64? userId,
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
            if (userId != null)
            {
                request.AddParameter("user_id", userId);
            }
            if (projectId != null)
            {
                request.AddParameter("project_id", projectId);
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
