using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileData;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;


namespace WebAPI.Data
{
    public class UserService : IUserService
    {
        private AdultsContext adultsContext;

        public UserService(AdultsContext adultsContext)
        {
            this.adultsContext = adultsContext;
        }

        public async Task<IList<User>>  GetUsersAsync()
        {
            return await adultsContext.Users.ToListAsync();
        }

        public async Task AddUserAsync(User newUser)
        {

            newUser.Role = "user";
            newUser.SecurityLevel = 1;
            
            await adultsContext.Users.AddAsync(newUser);
            await adultsContext.SaveChangesAsync();
        }

        public async Task RemoveUserAsync(int? userId)
        {
            var toDelete = await adultsContext.Users.FirstOrDefaultAsync(t => t.Id == userId);
            if (toDelete != null)
            {
                adultsContext.Users.Remove(toDelete);
                await adultsContext.SaveChangesAsync();
            }
        }

        public async Task UpdateUserAsync(User user)
        {
            try
            {
                User toUpdate = await adultsContext.Users.FirstOrDefaultAsync(t => t.Id == user.Id);
                toUpdate.UserName = user.UserName;
                toUpdate.Password = user.Password;
                toUpdate.Role = user.Role;
                toUpdate.SecurityLevel = user.SecurityLevel;
                
                adultsContext.Users.Update(toUpdate);
                await adultsContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"Did not find adult with id {user.Id}");
            }
            
        }

        public async Task<User> GetUserAsync(int? id)
        {
            return await adultsContext.Users.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<User> ValidateUserAsync(string userName, string password)
        {
            var user = await adultsContext.Users.FirstOrDefaultAsync(u => u.UserName.Equals(userName) && u.Password.Equals(password));
            if (user != null)
            {
                return user;
            } 
            throw new Exception("User not found");
        }
    }
}