using Microsoft.EntityFrameworkCore;
using ORM.entity.Maps;
using ORM.entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.repo.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UserMap(modelBuilder.Entity<UserModel>());
            //new UserProfileMap(modelBuilder.Entity<UserProfile>());
        }
    }
    
}
