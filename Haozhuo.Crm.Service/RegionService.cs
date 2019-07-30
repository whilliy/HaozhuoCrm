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
        private static IList<ProvinceDto> provinces;
        private static readonly object obj = new object();

        public static IList<ProvinceDto> PROVINCES
        {
            get
            {
                if (provinces == null)
                {
                    lock (obj)
                    {
                        if (provinces == null)
                        {
                            provinces = getAllProvinces();
                        }
                    }
                }
                return provinces;
            }
        }

        public static String getProvinceIdByName(String provinceName)
        {
            foreach (ProvinceDto province in PROVINCES)
            {
                if (province.provinceName == provinceName)
                {
                    return province.provinceId;
                }
            }
            return null;
        }

        public static String getCityIdByName(String provinceId, String cityName)
        {
            IList<CityDto> cities = getCitiesByProviceId(provinceId);
            if (cities == null || cities.Count < 1)
            {
                return null;
            }
            foreach (CityDto city in cities)
            {
                if (city.cityName == cityName||city.cityName.Contains(cityName))
                {
                    return city.cityId;
                }
            }
            return null;
        }

        private static IList<ProvinceDto> getAllProvinces()
        {
            RestClient restClient = new RestClient();
            IRestRequest request = new RestRequest(GlobalConfig.GET_ALL_PROVINCES, Method.GET);
            try
            {
                var response = restClient.Get(request);
                if (response.StatusCode == 0)
                {
                    throw new BusinessException("网络异常");
                }
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new BusinessException(response.Content);
                }
                IList<ProvinceDto> provinces = JsonConvert.DeserializeObject<List<ProvinceDto>>(response.Content);
                return provinces;
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
