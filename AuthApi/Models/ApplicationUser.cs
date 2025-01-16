﻿using Microsoft.AspNetCore.Identity;

namespace AuthApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
