using System;
using OAA.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OAA.Data.Map
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.PasswordHash);
            entityBuilder.Property(t => t.Email);
        }
    }
}
