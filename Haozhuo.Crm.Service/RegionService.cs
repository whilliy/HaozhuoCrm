using Haozhuo.Crm.Service.Dto;
using Haozhuo.Crm.Service.Utils;
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
                if (city.cityName == cityName || city.cityName.Contains(cityName))
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
                    var res = restClient.Deserialize<CustomException>(response);
                    var customException = res.Data;
                    throw new BusinessException(customException.message);
                }
                var provinces = restClient.Deserialize<List<ProvinceDto>>(response);
                return provinces.Data;
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
                    var res = rc.Deserialize<CustomException>(response);
                    var customException = res.Data;
                    throw new BusinessException(customException.message);
                }
                var cities = rc.Deserialize<List<CityDto>>(response);
                return cities.Data;
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
                    var res = rc.Deserialize<CustomException>(response);
                    var customException = res.Data;
                    throw new BusinessException(customException.message);
                }
                var counties = rc.Deserialize<List<CountyDto>>(response);
                return counties.Data;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }
    }
}
