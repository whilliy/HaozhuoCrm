using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
using Haozhuo.Crm.Service.vo;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace Haozhuo.Crm.Service
{
    public class ProjectService
    {
        private static readonly object obj = new object();
        private static IList<ProjectDto> projects;
        public static IList<ProjectDto> Projects
        {
            get
            {
                if (projects == null)
                {
                    lock (obj)
                    {
                        if (projects == null)
                        {
                            projects = allProjects();
                        }
                    }
                }
                return projects;
            }
        }

        public static IList<ProjectDto> ProjectsCopy
        {
            get
            {
                IList<ProjectDto> dtos = new List<ProjectDto>();
                foreach (ProjectDto p in Projects)
                {
                    dtos.Add(new ProjectDto(p.id, p.name));
                }
                return dtos;
            }
        }

        private static Dictionary<Int32, String> dicProjects;
        public static Dictionary<Int32, String> DicProjects
        {
            get
            {
                if (dicProjects == null)
                {
                    dicProjects = new Dictionary<Int32, string>();
                    foreach (ProjectDto p in Projects)
                    {
                        dicProjects.Add(p.id, p.name);
                    }
                }
                return dicProjects;
            }
        }

        /// <summary>
        /// 添加项目
        /// </summary>
        /// <param name="projectName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static ProjectDto AddProject(String projectName, String token)
        {
            RestClient rs = new RestClient();
            var request = new RestRequest(GlobalConfig.PROJECTS);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            request.AddJsonBody(new ProjectVo(projectName));
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
                var types = rs.Deserialize<ProjectDto>(response);
                return types.Data;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        } /// <summary>
          /// 更新项目
          /// </summary>
          /// <param name="projectName"></param>
          /// <param name="token"></param>
          /// <returns></returns>
        public static ProjectDto UpdateProject(Int32 projectId, String projectName, String token)
        {
            RestClient rs = new RestClient();
            var request = new RestRequest(GlobalConfig.PROJECTS_SOMEONE);
            request.AddHeader(GlobalConfig.AUTHORIZATION, token);
            request.AddUrlSegment("projectId", projectId);
            request.AddJsonBody(new ProjectVo(projectName));
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
                var types = rs.Deserialize<ProjectDto>(response);
                return types.Data;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }


        /// <summary>
        /// 获取所有的项目列表
        /// </summary>
        /// <returns></returns>
        private static IList<ProjectDto> allProjects()
        {
            RestClient rs = new RestClient();
            var request = new RestRequest(GlobalConfig.PROJECTS);
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
                var types = rs.Deserialize<List<ProjectDto>>(response);
                return types.Data;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

    }
}
