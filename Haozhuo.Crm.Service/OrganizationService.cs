using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
using Haozhuo.Crm.Service.vo;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace Haozhuo.Crm.Service
{
    public class OrganizationService
    {
        private static readonly object obj = new object();
        private static IList<OrganizationDto> organizations;
        public static IList<OrganizationDto> Organizations
        {
            get
            {
                if (organizations == null)
                {
                    lock (obj)
                    {
                        if (organizations == null)
                        {
                            organizations = allOrganizations();
                        }
                    }
                }
                return organizations;
            }
        }

        public static IList<OrganizationDto> OrganizationsCopy
        {
            get
            {
                //IList<ProjectDto> dtos = new List<ProjectDto>();
                //foreach (ProjectDto p in Projects)
                //{
                //    dtos.Add(new ProjectDto(p.id, p.name));
                //}
                //return dtos;
                return allOrganizations();
            }
        }

        private static Dictionary<String, String> dicOrganizations;
        public static Dictionary<String, String> DicOrganizations
        {
            get
            {
                //if (dicProjects == null)
                //{
                dicOrganizations = new Dictionary<String, string>();
                foreach (OrganizationDto p in Organizations)
                {
                    dicOrganizations.Add(p.id, p.name);
                }
                //}
                return dicOrganizations;
            }
        }

        /// <summary>
        /// 添加组织
        /// </summary>
        /// <param name="organizationName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static OrganizationDto AddOrganization(String organizationName, String token)
        {
            RestClient rs = new RestClient();
            var request = new RestRequest(GlobalConfig.ORGANIZATIONS);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            request.AddJsonBody(new OrganizationVo { name = organizationName });
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
                var types = rs.Deserialize<OrganizationDto>(response);
                return types.Data;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }
        /// <summary>
        /// 更新项目
        /// </summary>
        /// <param name="projectName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static OrganizationDto UpdateOrganization(String organizationId, String organizationName, String token)
        {
            RestClient rs = new RestClient();
            var request = new RestRequest(GlobalConfig.ORGANIZATIONS_SOMEONE);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            request.AddUrlSegment("organizationId", organizationId);
            request.AddJsonBody(new OrganizationVo { name = organizationName });
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
                var types = rs.Deserialize<OrganizationDto>(response);
                return types.Data;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }
        /// <summary>
        /// 删除项目
        /// </summary>
        /// <param name="projectName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static void DeleteOrganizationt(String organizationId, String token)
        {
            RestClient rs = new RestClient();
            var request = new RestRequest(GlobalConfig.ORGANIZATIONS_SOMEONE);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            request.AddUrlSegment("organizationId", organizationId);
            IRestResponse response;
            try
            {
                response = rs.Execute(request, Method.DELETE);
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
        /// 获取所有的组织列表
        /// </summary>
        /// <returns></returns>
        private static IList<OrganizationDto> allOrganizations()
        {
            RestClient rs = new RestClient();
            var request = new RestRequest(GlobalConfig.ORGANIZATIONS);
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
                var types = rs.Deserialize<List<OrganizationDto>>(response);
                return types.Data;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

    }
}
