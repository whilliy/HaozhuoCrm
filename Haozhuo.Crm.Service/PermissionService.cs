using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace Haozhuo.Crm.Service
{
    public class PermissionService
    {
        private static readonly object obj = new object();
        private static IList<PermissionDto> permissionTrees;
        public static IList<PermissionDto> PERMISSION_TREES
        {
            get
            {
                if (permissionTrees == null)
                {
                    lock (obj)
                    {
                        if (permissionTrees == null)
                        {
                            permissionTrees = getPremissionTrees();
                        }
                    }
                }
                return permissionTrees;
            }
        }
        /// <summary>
        /// 获取权限树
        /// </summary>
        /// <returns></returns>
        private static IList<PermissionDto> getPremissionTrees()
        {
            RestClient rs = new RestClient();
            var request = new RestRequest(GlobalConfig.PERMISSION_TREES);
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
                var types = rs.Deserialize<List<PermissionDto>>(response);
                return types.Data;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }
    }
}
