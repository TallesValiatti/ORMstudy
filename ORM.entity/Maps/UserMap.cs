using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ORM.entity.Models;

namespace ORM.entity.Maps
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<UserModel> entityBuilder)
        {
            entityBuilder.HasKey(t => t.id);
            entityBuilder.Property(t => t.name).IsRequired();
            entityBuilder.Property(t => t.password).IsRequired();
            entityBuilder.Property(t => t.email).IsRequired();
            //entityBuilder.HasOne(t => t.UserProfile).WithOne(u => u.User).HasForeignKey<UserProfile>(x => x.Id);
        }
    }
}
