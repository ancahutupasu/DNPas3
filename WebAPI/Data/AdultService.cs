using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using FileData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace WebAPI.Data
{
    public class AdultService : IAdultService
    {
        private FileContext FileContext;
        private AdultsContext adultsContext;

        public AdultService(AdultsContext adultsContext)
        {
            this.adultsContext = adultsContext;

        }

        public async Task<IList<Adult>>  GetAdultsAsync()
        {
            return await adultsContext.Adults.Include("JobTitle").ToListAsync();
        }

        public async Task<Adult> AddAdultAsync(Adult newAdult)
        {
            EntityEntry<Adult> newlyAdded = await adultsContext.Adults.AddAsync(newAdult);
            await adultsContext.SaveChangesAsync();
            return newlyAdded.Entity;
        }

        public async Task RemoveAdultAsync(int adultId)
        {
            Adult toDelete = await adultsContext.Adults.FirstOrDefaultAsync(t => t.Id == adultId);
            if (toDelete != null)
            {
                adultsContext.Adults.Remove(toDelete);
                adultsContext.Jobs.Remove(toDelete.JobTitle);
                await adultsContext.SaveChangesAsync();
            }
        }

        public Task<Adult> UpdateAdultAsync(Adult adult)
        {
            throw new NotImplementedException();
        }


        public async Task<Adult> GetAdultAsync(int? id)
        {
            Adult adult =  await adultsContext.Adults.Include("JobTitle").FirstOrDefaultAsync(t => t.Id == id);
           return adult;
        }


    }
}