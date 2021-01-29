using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace OnLineShop.Core.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public  string DisplayName { get; set; }
        public Adress Adress { get; set; }
    }
}
