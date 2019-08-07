using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
using Haozhuo.Crm.Service.vo;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace Haozhuo.Crm.Service
{
    public class UserService : BaseService
    {
        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="oldPassword"></param>
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

        public static ResultsWithCount<UserDto> QueryUsers(String token,
                                                        Int32? pageNum,
                                                        Int32? pageSize,
                                                        String name,
                                                        String mobile,
                                                        Int32? gender,
                                                        Boolean? active)
        {
            RestClient rc = new RestClient();
            var request = new RestRequest(GlobalConfig.USERS, Method.GET);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            if (pageNum != null)
            {
                request.AddParameter("page", pageNum);
            }
            if (pageSize != null)
            {
                request.AddParameter("page_size", pageSize);
            }
            if (gender != null)
            {
                request.AddParameter("gender", gender);
            }
            if (active != null)
            {
                request.AddParameter("active", active);
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
                    var customers = rc.Deserialize<List<UserDto>>(response);
                    return ResultsWithCount<UserDto>.of(customers.Data, GetTotalCountFromResponseHeaders(response));
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
        /// 添加用户
        /// </summary>
        /// <param name="vo"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static UserDto AddUser(AddUserVo vo, String token)
        {
            RestClient rs = new RestClient();
            var request = new RestRequest(GlobalConfig.USERS);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            request.AddJsonBody(vo);
            IRestResponse response;
            try
            {
                response = rs.Execute(request, Method.POST);
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
                var res = rs.Deserialize<CustomException>(response);
                var customException = res.Data;
                throw new BusinessException(customException.message);
            }
            try
            {
                var types = rs.Deserialize<UserDto>(response);
                return types.Data;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }
        /// <summary>
        /// 跟新用户
        /// </summary>
        /// <param name="vo"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static UserDto UpdateUser(long userId, AddUserVo vo, String token)
        {
            RestClient rs = new RestClient();
            var request = new RestRequest(GlobalConfig.USERS_SOMEONE);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            request.AddUrlSegment("userId", userId);
            request.AddJsonBody(vo);
            IRestResponse response;
            try
            {
                response = rs.Execute(request, Method.PUT);
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
                var types = rs.Deserialize<UserDto>(response);
                return types.Data;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="vo"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static void ResetUserPassword(ResetUserPassword vo, String token)
        {
            RestClient rs = new RestClient();
            var request = new RestRequest(GlobalConfig.RESET_USER_PASSWORD);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            request.AddJsonBody(vo);
            IRestResponse response;
            try
            {
                response = rs.Execute(request, Method.PATCH);
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
                var res = rs.Deserialize<CustomException>(response);
                var customException = res.Data;
                throw new BusinessException(customException.message);
            }
        }

        /// <summary>
        /// 启用用户
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static void EnableUser(long userId, String token)
        {
            RestClient rc = new RestClient();
            var request = new RestRequest(GlobalConfig.USER_ENABLE);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            request.AddUrlSegment("userId", userId);
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
        /// 禁用用户
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static void DisableUser(long userId, String token)
        {
            RestClient rc = new RestClient();
            var request = new RestRequest(GlobalConfig.USER_DISABLE);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            request.AddUrlSegment("userId", userId);
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
        /// 获取指定用户的权限列表
        /// </summary>
        /// <returns></returns>
        public static IList<String> getUserPermissionIds(long userId, String token)
        {
            RestClient rs = new RestClient();
            var request = new RestRequest(GlobalConfig.USER_PERMISSIONS);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            request.AddUrlSegment("userId", userId);
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
                var types = rs.Deserialize<List<String>>(response);
                return types.Data;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }
        /// <summary>
        /// 获取自己的权限列表
        /// </summary>
        /// <returns></returns>
        public static IList<String> GetMyPermissionIds(String token)
        {
            RestClient rs = new RestClient();
            var request = new RestRequest(GlobalConfig.MY_PERMISSIONS);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
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
                var types = rs.Deserialize<List<String>>(response);
                return types.Data;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }
     
        /// <summary>
        /// 获取用户同组织下所有激活用户
        /// </summary>
        /// <returns></returns>
        public static IList<UserDto> GetUsersSameByOrganization(String token, bool includeMyself = false)
        {
            RestClient rs = new RestClient();
            var request = new RestRequest(GlobalConfig.USERS_SAME_ORGANIZATION);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            request.AddParameter("include_myself", includeMyself);
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
                var types = rs.Deserialize<List<UserDto>>(response);
                return types.Data;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

        /// <summary>
        /// 修改指定用户的权限列表
        /// </summary>
        /// <returns></returns>
        public static void modifyUserPermissions(long userId, IList<string> permissionIds, String token)
        {
            RestClient rs = new RestClient();
            var request = new RestRequest(GlobalConfig.USER_PERMISSIONS);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            request.AddUrlSegment("userId", userId);
            request.AddJsonBody(permissionIds);
            IRestResponse response;
            try
            {
                response = rs.Execute(request, Method.PATCH);
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
                var res = rs.Deserialize<CustomException>(response);
                var customException = res.Data;
                throw new BusinessException(customException.message);
            }
        }


        /// <summary>
        /// 获取指定用户的权限列表
        /// </summary>
        /// <returns></returns>
        public static IList<UserProjectDto> GetProjectsByUserId(long userId, String token)
        {
            RestClient rs = new RestClient();
            var request = new RestRequest(GlobalConfig.USER_PROJECTS);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            request.AddUrlSegment("userId", userId);
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
                var types = rs.Deserialize<List<UserProjectDto>>(response);
                return types.Data;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }
    }
}
