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
        public static readonly String DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
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
        /// 用户管理
        /// </summary>
        public static string USERS = Domain + "/users";

        /// <summary>
        /// 与当前用户同组织下的所有可用用户
        /// </summary>
        public static String USERS_SAME_ORGANIZATION = USERS + "/same_organization_users";

        /// <summary>
        /// 某个用户
        /// </summary>
        public static String USERS_SOMEONE = USERS + "/{userId}";
        /// <summary>
        /// 用戶登陸
        /// </summary>
        public static String USER_LOGIN = USERS + "/login";
        /// <summary>
        /// 用户修改密码
        /// </summary>
        public static String USER_MODIFY_PASSWORD = USERS + "/modify_password";

        /// <summary>
        /// 重置指定用户密码
        /// </summary>
        public static String RESET_USER_PASSWORD = USERS + "/reset_password";
        /// <summary>
        /// 禁用指定用户
        /// </summary>
        public static String USER_DISABLE = USERS + "/{userId}/disable";
        /// <summary>
        /// 激活指定用户
        /// </summary>
        public static String USER_ENABLE = USERS + "/{userId}/active";

        /// <summary>
        /// 客戶相關
        /// </summary>
        public static String CUSTOMERS = Domain + "/customers";
        /// <summary>
        /// 我的客戶相关
        /// </summary>
        public static String MY_CUSTOMERS = CUSTOMERS + "/my";
        /// <summary>
        /// 公海查询
        /// </summary>
        public static String CUSTOMERS_PUBLIC = CUSTOMERS + "/public";

        public static String CUSTOMERS_UNASSIGNED = CUSTOMERS + "/unassigned";

        /// <summary>
        /// 所有的客户类型
        /// </summary>
        public static String CUSTOMER_TYPES = CUSTOMERS + "/types";
        /// <summary>
        /// 导入客户
        /// </summary>
        public static String IMPORT_CUSTOMERS = CUSTOMERS + "/import_customers";
        /// <summary>
        /// 所有的客户来源
        /// </summary>
        public static String CUSTOMER_SOURCES = CUSTOMERS + "/sources";
        /// <summary>
        /// 所有的客户状态
        /// </summary>
        public static String CUSTOMER_STATUSES = CUSTOMERS + "/statuses";
        /// <summary>
        /// 所有的客户状态（分派之后的）
        /// </summary>
        public static String CUSTOMER_ASSIGNED_STATUSES = CUSTOMERS + "/assigned_statuses";

        /// <summary>
        /// 将选定顾客转移给目标用户
        /// </summary>
        public static String CUSTOMER_TRANSFER = CUSTOMERS + "/transfer_customers";
        /// <summary>
        /// 将选定顾客转移给目标用户
        /// </summary>
        public static String ADMIN_CUSTOMER_TRANSFER = CUSTOMERS + "/admin_transfer_customers";
        /// <summary>
        /// 将选定顾客转移给目标用户
        /// </summary>
        public static String CUSTOMER_DISPATCH = CUSTOMERS + "/dispatch_customers";
        /// <summary>
        /// 从公海中抓取数据
        /// </summary>
        public static String GRASP_CUSTOMERS_FROM_PUBLIC = CUSTOMERS + "/grasp_customers_from_public";

        /// <summary>
        /// 获取客户的跟进记录
        /// </summary>
        public static String CUSTOER_FOLLOW_RECORDS = CUSTOMERS + "/{customerId}/follow_records";
        /// <summary>
        /// 指定客户
        /// </summary>
        public static String CUSTOER_SOMEONE = CUSTOMERS + "/{customerId}";
        /// <summary>
        /// 扔回公海
        /// </summary>
        public static String CUSTOER_RETURN_PUBLIC = CUSTOMERS + "/return_public";

        /// <summary>
        /// 所有的项目
        /// </summary>
        public static String PROJECTS = Domain + "/projects";

        /// <summary>
        /// 指定项目
        /// </summary>
        public static String PROJECTS_SOMEONE = PROJECTS + "/{projectId}";
        /// <summary>
        /// 所有的组织
        /// </summary>
        public static String ORGANIZATIONS = Domain + "/organizations";

        /// <summary>
        /// 指定组织
        /// </summary>
        public static String ORGANIZATIONS_SOMEONE = ORGANIZATIONS + "/{organizationId}";

        public static String PERMISSIONS = Domain + "/permissions";

        public static String PERMISSION_TREES = PERMISSIONS + "/trees";

        public static String USER_PERMISSIONS = USERS + "/{userId}/permissions";

        public static String USER_PROJECTS = USERS + "/{userId}/projects";

        public static String MY_PERMISSIONS = USERS + "/my_permissions";
    }
}
