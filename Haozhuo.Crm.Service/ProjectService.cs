using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
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




        private static IList<ProjectDto> allProjects()
        {
            RestClient rs = new RestClient();
            var request = new RestRequest(GlobalConfig.ALL_PROJECTS);
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
