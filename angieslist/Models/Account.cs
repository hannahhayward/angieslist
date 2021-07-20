using System;
using System.Collections.Generic;

namespace angieslist.Models
{
    public class Account : Profile
    {
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt {get; set;}
    
    }
}