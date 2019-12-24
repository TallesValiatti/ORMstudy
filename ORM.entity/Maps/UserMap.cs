using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ORM.entity.Models;
using Microsoft.EntityFrameworkCore;

namespace ORM.entity.Maps
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        //    public UserMap(EntityTypeBuilder<UserModel> entityBuilder)
        //    {
        //        entityBuilder.HasKey(t => t.id);
        //        entityBuilder.Property(t => t.name).IsRequired();
        //        entityBuilder.Property(t => t.password).IsRequired();
        //        entityBuilder.Property(t => t.email).IsRequired();
        //        //entityBuilder.HasOne(t => t.UserProfile).WithOne(u => u.User).HasForeignKey<UserProfile>(x => x.Id);
        //    }

       
        public void Configure(EntityTypeBuilder<UserModel> entityBuilder)
        {
            entityBuilder.HasKey(t => t.id);
            entityBuilder.Property(t => t.name).IsRequired();
            entityBuilder.Property(t => t.password).IsRequired();
            entityBuilder.Property(t => t.email).IsRequired();
        }
    }
}
