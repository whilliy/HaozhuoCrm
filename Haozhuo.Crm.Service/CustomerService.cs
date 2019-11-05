using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
using Haozhuo.Crm.Service.vo;
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

        public static readonly Int32 CUSTOMER_SOURCE_DATABASE = 4;
        //客户状态未沟通
        public static readonly Int32 CUSTOMER_STATUS_INIT = 5;

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
                            cusomterTypes = GetAllCustomerTypes();
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
                            customerSources = GetAllCustomerSources();
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
        private static readonly object objAssignedStatus = new object();
        private static IList<CustomerStatus> statuses;
        private static IList<CustomerStatus> assignedStatuses;
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
                            statuses = GetCustomerStatuses();
                        }
                    }
                }
                return statuses;
            }
        } /// <summary>
          /// 客户状态列表（分派过后的）
          /// </summary>
        public static IList<CustomerStatus> AssignedCustomerStatuses
        {
            get
            {
                if (assignedStatuses == null)
                {
                    lock (objAssignedStatus)
                    {
                        if (assignedStatuses == null)
                        {
                            assignedStatuses = GetCustomerAssignedStatuses();
                        }
                    }
                }
                return assignedStatuses;
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

        /// <summary>
        /// 获取客户状态列表的副本
        /// </summary>
        /// <returns></returns>
        public static IList<CustomerStatus> CustomerAssignStatusesCopy()
        {
            IList<CustomerStatus> customerAssignedStatusesCopies = new List<CustomerStatus>();
            foreach (CustomerStatus s in AssignedCustomerStatuses)
            {
                customerAssignedStatusesCopies.Add(new CustomerStatus(s.id, s.name));
            }
            return customerAssignedStatusesCopies;
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

        /// <summary>
        /// 获取所有的客户状态列表
        /// </summary>
        /// <returns></returns>
        private static IList<CustomerStatus> GetCustomerStatuses()
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
        /// 获取所有分派之后的客户状态列表
        /// </summary>
        /// <returns></returns>
        private static IList<CustomerStatus> GetCustomerAssignedStatuses()
        {
            RestClient rs = new RestClient();
            var request = new RestRequest(GlobalConfig.CUSTOMER_ASSIGNED_STATUSES);
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
        private static List<CustomerTypeDto> GetAllCustomerTypes()
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
        private static List<CustomerSourceDto> GetAllCustomerSources()
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
        public static CustomerDto AddFllowRecord(String customerId, String token, AddFollowRecord record)
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
                var types = rc.Deserialize<CustomerDto>(response);
                return types.Data;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

        /// <summary>
        /// 批量添加客户
        /// </summary>
        /// <param name="customers">客户列表</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static IList<CustomerDto> AddCustomers(IList<AddCustomerVo> customers, String token)
        {
            RestClient rc = new RestClient();
            var request = new RestRequest(GlobalConfig.CUSTOMERS);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            request.AddJsonBody(customers);
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
                var types = rc.Deserialize<IList<CustomerDto>>(response);
                return types.Data;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

        /// <summary>
        /// 导入客户
        /// </summary>
        /// <param name="customers">客户列表</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static Int32 ImportCustomerData(ImportCustomerVo vo, String token)
        {
            RestClient rc = new RestClient();
            var request = new RestRequest(GlobalConfig.IMPORT_CUSTOMERS);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            request.AddJsonBody(vo);
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
            if (response.StatusCode != HttpStatusCode.OK)
            {
                var res = rc.Deserialize<CustomException>(response);
                var customException = res.Data;
                throw new BusinessException(customException.message);
            }
            try
            {
                var types = rc.Deserialize<Int32>(response);
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
        public static CustomerDto UpdateCustomer(String customerId, String token, CustomerVo vo)
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
        /// 根据条件查询客戶信息
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
                                                        Int32? status,
                                                        Int32? source,
                                                        Int32? type,
                                                        String name,
                                                        String mobile,
                                                        Int64? firstOwnerId,
                                                        Int64? currentUserId,
                                                        String provinceId,
                                                        String cityId,
                                                        String countyId,
                                                        String leaveWordsTimeBegin,
                                                        String leaveWordsTimeEnd)
        {
            RestClient rc = new RestClient();
            var request = new RestRequest(GlobalConfig.CUSTOMERS, Method.GET);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            if (pageNum != null)
            {
                request.AddParameter("page", pageNum);
            }
            if (projectId != null)
            {
                request.AddParameter("project_id", projectId);
            }
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
            if (firstOwnerId.HasValue)
            {
                request.AddParameter("first_owner_id", firstOwnerId);
            }
            if (currentUserId.HasValue)
            {
                request.AddParameter("user_id", currentUserId);
            }
            if (!String.IsNullOrEmpty(mobile))
            {
                request.AddParameter("mobile", mobile);
            }
            if (!String.IsNullOrEmpty(provinceId))
            {
                request.AddParameter("province_id", provinceId);
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
            if (!String.IsNullOrEmpty(leaveWordsTimeBegin))
            {
                request.AddParameter("leave_words_begin", leaveWordsTimeBegin);
            }
            if (!String.IsNullOrEmpty(leaveWordsTimeEnd))
            {
                request.AddParameter("leave_words_end", leaveWordsTimeEnd);
            }
            try
            {
                var response = rc.Get(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var customers = rc.Deserialize<List<CustomerDto>>(response);
                    return ResultsWithCount<CustomerDto>.of(customers.Data, GetTotalCountFromResponseHeaders(response));
                }
                else if (response.StatusCode == 0)
                {
                    throw new BusinessException("请检查网络");
                }
                else
                {
                    var res = rc.Deserialize<CustomException>(response);
                    var customException = res.Data;
                    throw new BusinessException(customException.message);
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

        /// <summary>
        /// 根据条件查询我的客戶信息
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
        public static ResultsWithCount<CustomerDto> QueryMyCustomers(String token,
                                                        Int32? pageNum,
                                                        Int32? pageSize,
                                                        Int32? projectId,
                                                        Int32? status,
                                                        Int32? source,
                                                        Int32? type,
                                                        String name,
                                                        String mobile,
                                                        String provinceId,
                                                        String cityId,
                                                        String countyId,
                                                        String leaveWordsTimeBegin,
                                                        String leaveWordsTimeEnd,
                                                        String nextFollowTimeStart,
                                                        String nextFollowTimeEnd)
        {
            RestClient rc = new RestClient();
            var request = new RestRequest(GlobalConfig.MY_CUSTOMERS, Method.GET);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            if (pageNum != null)
            {
                request.AddParameter("page", pageNum);
            }
            if (projectId != null)
            {
                request.AddParameter("project_id", projectId);
            }
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
            if (!String.IsNullOrEmpty(provinceId))
            {
                request.AddParameter("province_id", provinceId);
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
            if (!String.IsNullOrEmpty(leaveWordsTimeBegin))
            {
                request.AddParameter("leave_words_begin", leaveWordsTimeBegin);
            }
            if (!String.IsNullOrEmpty(nextFollowTimeStart))
            {
                request.AddParameter("next_follow_time_start", nextFollowTimeStart);
            }
            if (!String.IsNullOrEmpty(nextFollowTimeEnd))
            {
                request.AddParameter("next_follow_time_end", nextFollowTimeEnd);
            }
            if (!String.IsNullOrEmpty(leaveWordsTimeEnd))
            {
                request.AddParameter("leave_words_end", leaveWordsTimeEnd);
            }
            try
            {
                var response = rc.Get(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var customers = rc.Deserialize<List<CustomerDto>>(response);
                    return ResultsWithCount<CustomerDto>.of(customers.Data, GetTotalCountFromResponseHeaders(response));
                }
                else if (response.StatusCode == 0)
                {
                    throw new BusinessException("请检查网络");
                }
                else
                {
                    var res = rc.Deserialize<CustomException>(response);
                    var customException = res.Data;
                    throw new BusinessException(customException.message);
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
        /// <summary>
        /// 根據條件查詢客戶信息(公海）
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
        public static ResultsWithCount<CustomerDto> QueryCustomersFromPublic(String token,
                                                        Int32? pageNum,
                                                        Int32? pageSize,
                                                        Int32? projectId,
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
            var request = new RestRequest(GlobalConfig.CUSTOMERS_PUBLIC, Method.GET);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            if (pageNum != null)
            {
                request.AddParameter("page", pageNum);
            }
            if (projectId != null)
            {
                request.AddParameter("project_id", projectId);
            }
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
            if (!String.IsNullOrEmpty(provinceId))
            {
                request.AddParameter("province_id", provinceId);
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
                    return ResultsWithCount<CustomerDto>.of(customers.Data, GetTotalCountFromResponseHeaders(response));
                }
                else if (response.StatusCode == 0)
                {
                    throw new BusinessException("请检查网络");
                }
                else
                {
                    var res = rc.Deserialize<CustomException>(response);
                    var customException = res.Data;
                    throw new BusinessException(customException.message);
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

        /// <summary>
        /// 根據條件查詢客戶信息(公海）
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
        public static ResultsWithCount<CustomerDto> QueryUnAssignedCustomers(String token,
                                                        Int32? pageNum,
                                                        Int32? pageSize,
                                                        Int32? projectId,
                                                        Int32? source,
                                                        String name,
                                                        String mobile)
        {
            RestClient rc = new RestClient();
            var request = new RestRequest(GlobalConfig.CUSTOMERS_UNASSIGNED, Method.GET);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            if (pageNum != null)
            {
                request.AddParameter("page", pageNum);
            }
            if (projectId != null)
            {
                request.AddParameter("project_id", projectId);
            }
            if (pageSize != null)
            {
                request.AddParameter("page_size", pageSize);
            }
            if (source != null)
            {
                request.AddParameter("source", source);
            }
            if (!String.IsNullOrEmpty(mobile))
            {
                request.AddParameter("mobile", mobile);
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
                    return ResultsWithCount<CustomerDto>.of(customers.Data, GetTotalCountFromResponseHeaders(response));
                }
                else if (response.StatusCode == 0)
                {
                    throw new BusinessException("请检查网络");
                }
                else
                {
                    var res = rc.Deserialize<CustomException>(response);
                    var customException = res.Data;
                    throw new BusinessException(customException.message);
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
        /// <summary>
        /// 扔回公海
        /// </summary>
        /// <param name="vo"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static void ReturnCustomersToPublic(ReturnCustomersToPublic vo, String token)
        {
            RestClient rc = new RestClient();
            var request = new RestRequest(GlobalConfig.CUSTOER_RETURN_PUBLIC);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            request.AddJsonBody(vo);
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
        /// <summary>
        /// 将选定顾客转移给目标用户
        /// </summary>
        /// <param name="vo"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static void TransferCustomersToTargetUsers(TransterCustomerVo vo, String token)
        {
            RestClient rc = new RestClient();
            var request = new RestRequest(GlobalConfig.CUSTOMER_TRANSFER);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            request.AddJsonBody(vo);
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
        /// <summary>
        /// 将选定顾客转移给目标用户(管理员）
        /// </summary>
        /// <param name="vo"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static void AdminTransferCustomersToTargetUsers(TransterCustomerVo vo, String token)
        {
            RestClient rc = new RestClient();
            var request = new RestRequest(GlobalConfig.ADMIN_CUSTOMER_TRANSFER);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            request.AddJsonBody(vo);
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
        /// <summary>
        /// 将选定顾客分配给目标用户
        /// </summary>
        /// <param name="vo"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static void DispatchCustomersToTargetUsers(TransterCustomerVo vo, String token)
        {
            RestClient rc = new RestClient();
            var request = new RestRequest(GlobalConfig.CUSTOMER_DISPATCH);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            request.AddJsonBody(vo);
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
        /// <summary>
        /// 将选定顾客转移给目标用户
        /// </summary>
        /// <param name="vo"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static void GraspCustomersFromPublic(GraspCustomerVo vo, String token)
        {
            RestClient rc = new RestClient();
            var request = new RestRequest(GlobalConfig.GRASP_CUSTOMERS_FROM_PUBLIC);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            request.AddJsonBody(vo);
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


        /// <summary>
        /// 删除指定客户
        /// </summary>
        /// <param name="vo"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static void DeleteCustomer(String customerId, String token)
        {
            RestClient rc = new RestClient();
            var request = new RestRequest(GlobalConfig.CUSTOER_SOMEONE);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            request.AddUrlSegment("customerId", customerId);
            IRestResponse response;
            try
            {
                response = rc.Execute(request, Method.DELETE);
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
