using System.Collections.Generic;
using System.Threading.Tasks;
using Blazor.Models;

namespace Blazor.Data
{
    public interface IUserService
    {
        User ValidateUser(string UserName, string Password);
        Task<IList<User>> GetUsersAsync();
        Task RemoveUserAsync(int userId);
    }
}