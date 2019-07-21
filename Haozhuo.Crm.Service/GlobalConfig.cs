﻿using System;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace Haozhuo.Crm.Service
{
    public class GlobalConfig
    {
        public static readonly String AUTHORIZATION = "Authorization";
        public static readonly String X_TOTAL_COUNT = "X_TOTAL_COUNT";
        private static readonly object lockS = new object();
        private static String domain;
        public static String Domain
        {
            get
            {
                if (domain == null)
                {
                    lock (lockS)
                    {
                        if (domain == null)
                        {
                            InitConfig();
                        }
                    }
                }
                return domain;
            }
        }

        static void InitConfig()
        {
            string baesePath = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;
            string fullName = Path.GetFileName(Assembly.GetCallingAssembly().Location);
            string path = string.Format(@"{0}\{1}.config", baesePath, fullName);
            if (File.Exists(path) == false)
            {
                string msg = string.Format("{0}路径下的文件未找到 ", path);
                throw new FileNotFoundException(msg);
            }
            try
            {
                ExeConfigurationFileMap configFile = new ExeConfigurationFileMap();
                configFile.ExeConfigFilename = path;
                Configuration Config = ConfigurationManager.OpenMappedExeConfiguration(configFile, ConfigurationUserLevel.None);
                domain = Config.AppSettings.Settings["domain"].Value;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        static GlobalConfig()
        {
        }

        /// <summary>
        /// 获取所有的省份接口
        /// </summary>
        public static String GET_ALL_PROVINCES = Domain + "/regions/provinces";

        /// <summary>
        /// 根据省Id获取其下所有的城市
        /// </summary>
        public static string GET_CITIES_BY_PROVINCE_ID = Domain + "/regions/provinces/{provinceId}/cities";

        /// <summary>
        ///根据市Id获取其下所有的县市区
        /// </summary>
        public static string GET_COUNTIES_BY_CITY_ID = Domain + "/regions/cities/{cityId}/counties";

        /// <summary>
        /// 用戶登陸
        /// </summary>
        public static String USER_LOGIN = Domain + "/users/login";

        /// <summary>
        /// 客戶相關
        /// </summary>
        public static String CUSTOMERS = Domain + "/customers";

        /// <summary>
        /// 所有的客户类型
        /// </summary>
        public static String CUSTOMER_TYPES = CUSTOMERS + "/types";

        /// <summary>
        /// 所有的客户来源
        /// </summary>
        public static String CUSTOMER_SOURCES = CUSTOMERS + "/sources";
    }
}
