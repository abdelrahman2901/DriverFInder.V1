using System;

namespace DriverFinder.Core.DTO.UserActivityDTO
{
    public class UserActivityResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
