using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace Haozhuo.Crm.Service
{
    public class RegionService
    {
        public static IList<ProvinceDto> getAllProvinces()
        {
            RestClient restClient = new RestClient();
            IRestRequest request = new RestRequest(GlobalConfig.GET_ALL_PROVINCES, Method.GET);
            try
            {
                var response = restClient.Get(request);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new BusinessException(response.Content);
                }
                IList<ProvinceDto> provinces = JsonConvert.DeserializeObject<List<ProvinceDto>>(response.Content);
                return provinces;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }

        }

        public static IList<CityDto> getCitiesByProviceId(String provinceId)
        {
            RestClient rc = new RestClient();
            var request = new RestRequest(GlobalConfig.GET_CITIES_BY_PROVINCE_ID, Method.GET);
            request.AddUrlSegment("provinceId", provinceId);
            try
            {
                var response = rc.Get(request);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new BusinessException(response.Content);
                }
                IList<CityDto> cities = JsonConvert.DeserializeObject<List<CityDto>>(response.Content);
                return cities;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }
        public static IList<CountyDto> getCountiesByCityId(String cityId)
        {
            RestClient rc = new RestClient();
            var request = new RestRequest(GlobalConfig.GET_COUNTIES_BY_CITY_ID, Method.GET);
            request.AddUrlSegment("cityId", cityId);
            try
            {
                var response = rc.Get(request);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new BusinessException(response.Content);
                }
                IList<CountyDto> counties = JsonConvert.DeserializeObject<List<CountyDto>>(response.Content);
                return counties;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }
    }
}
