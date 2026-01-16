using System.ComponentModel.DataAnnotations;
using System;

namespace DriverFinder.Core.Domain.Entites
{
    public class UserActivity
    {
              [Key]
            public Guid Id { get; set; }
            public Guid UserId { get; set; } 
            public string? LogType { get; set; }
            public DateTime Timestamp { get; set; }    
                  
        

    }
}
