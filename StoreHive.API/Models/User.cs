using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace StoreHive.API.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime DateRegistered { get; set; }
        public ICollection<Store> Stores { get; set; }

    }
}