using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domin;

namespace Presistence
{
    public class Seeding
    {
        public static async Task DataSeed(DbContextApp DbContext)
        {
            if(DbContext.Activities.Any()) return;
            var Activities = new List<Activity>{
                new Activity{
                    Username="Admin",
                    password="Admin",
                },
            };
            await DbContext.Activities.AddRangeAsync(Activities);
            await DbContext.SaveChangesAsync();
        }
    }
    
}