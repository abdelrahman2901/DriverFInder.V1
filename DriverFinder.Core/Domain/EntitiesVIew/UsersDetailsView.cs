using System;

namespace DriverFinder.Core.Domain.EntitiesVIew
{
    public  class UsersDetailsView
    {
        public  Guid userID { get; set; }
        public string? email { get; set; }
        public string? personName { get; set; }
        public string? role { get; set; }
        public bool? isblocked { get; set; }
    }
}
