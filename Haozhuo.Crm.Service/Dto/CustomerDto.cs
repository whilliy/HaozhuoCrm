using System;

namespace Haozhuo.Crm.Service.Dto
{
    public class CustomerDto
    {
        public String id { get; set; }
        public Int32? projectId { get; set; }
        public String name { get; set; }
        public String mobile { get; set; }
        public Int64 currentUserId { get; set; }
        public String currentUserName { get; set; }
        public Int32? type { get; set; }
        public Int32? status { get; set; }
        public Int32 source { get; set; }
        public Int32 gender { get; set; }
        public String provinceId { get; set; }
        public String provinceName { get; set; }
        public String cityId { get; set; }
        public String cityName { get; set; }
        public String countyId { get; set; }
        public String countyName { get; set; }
        public DateTime? leaveWordsTime { get; set; }
        public DateTime? previousFollowTime { get; set; }
        public long previousFollowUserId { get; set; }
        public DateTime? lastFollowTime { get; set; }
        public long lastFollowUserId { get; set; }
        public DateTime? nextFollowTime { get; set; }
        public DateTime createdTime { get; set; }
        public String previousFollowUserName { get; set; }
        public String lastFollowUserName { get; set; }

        public Int32? firstOwnerId { get; set; }
        public DateTime? dispatchedTime { get; set; }
        public String firstOwnerName { get; set; }
        public String remark { get; set; }
    }
}
