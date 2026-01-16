using System;

namespace DriverFinder.Core.DTO.UserActivityDTO
{
    public class UserActivityCountDTO
    {
        public int? Daily { get; set; }
        public int? Weakly { get; set; }
        public int? Monthly { get; set; }
        public int? Annual { get; set; }
        public int? NewUsers { get; set; }
        public int? blockedUsers { get; set; }
    }
}
