using System;
using System.Collections.Generic;

namespace HaoZhuoCRM
{
    static class Global
    {
        public static String USER_TOKEN { get; set; }
        public static long USER_ID { get; set; }
        public static IList<String> PERMISSION_IDS { get; set; }
    }
}
