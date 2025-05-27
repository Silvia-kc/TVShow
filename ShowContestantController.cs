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
    public class ShowContestantController
    {
        TVShowContext context = new TVShowContext();
        public async Task AddShowContestant(int showId, int contestantId)
        {
            ShowContestant showContestant = new ShowContestant()
            {
               showId = showId,
               contestantId = contestantId
            };
            context.ShowContestants.Add(showContestant);
            await context.SaveChangesAsync();
        }
        public async Task<List<ShowContestant>> ViewAllQuestions()
        {
            var showContestants = await context.ShowContestants.ToListAsync();
            return showContestants;
        }
        public async Task RemoveShowContestantById(int showId, int conestantId)
        {
            var showContestant = await context.ShowContestants.FirstOrDefaultAsync(sc=>sc.showId == showId && sc.contestantId == conestantId);
            context.ShowContestants.Remove(showContestant);
            await context.SaveChangesAsync();
        }
        public async Task UpdateShowContestant(int showId, int conestantId, int newShowId, int newConestantId)
        {
            var showContestant = await context.ShowContestants.FirstOrDefaultAsync(sc => sc.showId == showId && sc.contestantId == conestantId);
            showContestant.showId = newShowId;
            showContestant.contestantId = conestantId;
            await context.SaveChangesAsync();
        }
    }
}
