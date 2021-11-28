using System.Collections.Generic;
using Blazor.Models;

namespace Blazor.Data
{
    public interface IAdultService
    {
        IList<Adult> GetAllAdults();
        void AddAdult(Adult adult);
        IList<Job> GetAllJobs();
        void RemoveAdult(int id);
        void UpdateAdult(Adult adult);
        Adult GetAdultById(int id);
    }
}