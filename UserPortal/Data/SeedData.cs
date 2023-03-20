using AndonCloudDAL;
using AndonCloudDAL.Model;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace UserPortal.Data
{
    public class SeedData
    {
        public static async Task CreateRootUserOnStartup(LeanCloudContext context)
        {
            var role = new Role
            {
                Name = "Test"
            };

            var hmac = new HMACSHA512();
            var password = "password123";
            var rootUser = new User
            {
                FirstName = "Root",
                LastName = "User",
                Email = "root@user.com",
                Country= "Imaginary",
                PhoneNumber = "077777",
                Role = role,
                PasswordSalt = hmac.Key,
                PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password))
            };
            context.Database.Migrate();
            if (context.Users.Any()) return;

            context.Users.Add(rootUser);
            await context.SaveChangesAsync();
        }
    }
}
