using Data.Entities;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Core
{
    public class ContestantController
    {
        TVShowContext context = new TVShowContext();
        public async Task AddContestant(string fullName, int age, string contactEmail, string phoneNumber)
        {
            Contestant contestant = new Contestant()
            {
                fullName = fullName,
                age = age,
                contactEmail = contactEmail,
                phoneNumber = phoneNumber
            };
            context.Contestants.Add(contestant);
            await context.SaveChangesAsync();
        }
        public async Task<List<Contestant>> ViewAllContesntants()
        {
            var contestants = await context.Contestants.ToListAsync();
            return contestants;
        }
        public async Task RemoveContestantById(int id)
        {
            var contesntant = await context.Contestants.FirstOrDefaultAsync(c => c.id == id);
            context.Contestants.Remove(contesntant);
            await context.SaveChangesAsync();
        }
        public async Task UpdateContestant(int id, string newFullName, int newAge, string newContactEmail, string newPhoneNumber)
        {
            var contestant = await context.Contestants.FirstOrDefaultAsync(c => c.id == id);
            contestant.fullName = newFullName;
            contestant.age = newAge;
            contestant.contactEmail = newContactEmail;
            contestant.phoneNumber = newPhoneNumber;
            await context.SaveChangesAsync();
        }
    }
}
