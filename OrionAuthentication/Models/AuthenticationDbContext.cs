using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace OrionAuthentication.Models
{
    public class AuthenticationDbContext : IdentityDbContext<IdentityUser>
    {
        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeding roles
            modelBuilder.Entity<IdentityRole>().HasData
                (
                    new IdentityRole { Id = "a545eeda-238e-4d0f-8173-21fef6c9faab", Name = "Admin", NormalizedName = "Admin".ToUpper() },
                    new IdentityRole { Id = "8047eafc-22db-474b-a47b-431c91a75c70", Name = "User", NormalizedName = "User".ToUpper() }
                );

            // Hasher for password
            var hasher = new PasswordHasher<IdentityUser>();

            //Seeding the User to AspNetUsers table
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "8cfc7dc6-b87f-4a9b-954b-51b5d6dcff98", // PK
                    UserName = "Admin", 
                    NormalizedUserName = "Admin".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "Test123$")
                },
                new IdentityUser
                {
                    Id = "118a6526-8e43-413c-965d-23082f747cb1",
                    UserName = "User",
                    NormalizedUserName = "User".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "Test123$")
                }
            );


            //Seeding the relation between our user and role to AspNetUserRoles table
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "a545eeda-238e-4d0f-8173-21fef6c9faab",
                    UserId = "8cfc7dc6-b87f-4a9b-954b-51b5d6dcff98"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "8047eafc-22db-474b-a47b-431c91a75c70",
                    UserId = "118a6526-8e43-413c-965d-23082f747cb1"
                }
            );
        }
    }
}
