using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonaKeyCore.EntityLayer.Concrete;

namespace PersonaKeyCore.DataAccessLayer.Concrete.Context
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Door> Doors { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<AccessLog> AccessLogs { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // AppUser ve AppRole tablolarının adını açıkça belirtiyoruz
            builder.Entity<AppUser>().ToTable("AppUsers");
            builder.Entity<AppRole>().ToTable("AppRoles");

            // RefreshToken ve AppUser arasındaki ilişkiyi açıkça tanımlıyoruz
            builder.Entity<RefreshToken>()
                   .HasOne(rt => rt.User)
                   .WithMany()
                   .HasForeignKey(rt => rt.UserId);

            // Personel Role sınıfı ile Person ve Permission ilişkisini açıkça tanımlıyoruz
            builder.Entity<Role>().ToTable("PersonnelRoles");
        }
    }
}
