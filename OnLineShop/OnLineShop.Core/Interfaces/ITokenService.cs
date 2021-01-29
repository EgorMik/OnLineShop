using OnLineShop.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnLineShop.Core.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
