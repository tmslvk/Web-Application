using Azure.Core;
using Microsoft.EntityFrameworkCore;

namespace webapi.Models
{
    public class UserService
    {
        UserContext db;

        public UserService(UserContext context) 
        {
            this.db = context;
        }

        public async Task<User> Add(UserDto userDto) 
        {
            var user = new User()
            {
                Username = userDto.Username,
                Email = userDto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password),
                Lastname = userDto.Lastname,
                Firstname = userDto.Firstname,
                DateOfBirth = userDto.DateOfBirth 
            };

             await db.Users.AddAsync(user);
             await db.SaveChangesAsync();

             return user;
        }

        public async Task<User?> Login(LoginDto loginDto)
        {
            User? user = await db.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
            if (user == null)
            {
                return null;
            }
            bool verified = BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password);
            if(!verified)
            {
                return null;
            }
            return user;
        }

        public async Task<User?> GetOne(int id)
        {
            return await db.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> LinkMusician(int userId, Musician musician)
        {
            User? user = await this.GetOne(userId);

            if(user == null)
            {
                return null;
            }
            user.Musician = musician;
            db.SaveChanges();

            return user;
        }

        public async Task<bool> CheckUsername(string username)
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.Username == username);
            return user != null;
        }
    }
}
