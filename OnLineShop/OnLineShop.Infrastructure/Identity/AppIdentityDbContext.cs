using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnLineShop.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnLineShop.Infrastructure.Identity
{
   public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
//Add-Migration InitialCreate -Context AppIdentityDbContext  Добавление миграции для второго Context
//update-database -Context AppIdentityDbContext