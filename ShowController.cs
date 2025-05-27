using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ShowController
    {
        TVShowContext context = new TVShowContext();
        public async Task AddShow(string name, DateTime airDate, string description)
        {
            Show show = new Show()
            {
                name = name,
                airDate = airDate,
                description = description
            };
            context.Shows.Add(show);
            await context.SaveChangesAsync();
        }
        public async Task<List<Show>> ViewAllShows()
        {
            var shows = await context.Shows.ToListAsync();
            return shows;
        }
        public async Task RemoveShowById(int id)
        {
            var show = await context.Shows.FirstOrDefaultAsync(s => s.id == id);
            context.Shows.Remove(show);
            await context.SaveChangesAsync();
        }
        public async Task UpdateShow(int id, string newName, DateTime newAirDate, string newDescription)
        {
            var show = await context.Shows.FirstOrDefaultAsync(s => s.id == id);
            show.name = newName;
            show.airDate = newAirDate;
            show.description = newDescription;
            await context.SaveChangesAsync();
        }
    }
}
