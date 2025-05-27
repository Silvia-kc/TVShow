using Data.Entities;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Core
{
    public class QuizController
    {
        TVShowContext context = new TVShowContext();
        public async Task AddQuiz(string title, int showId, string description)
        {
            Quiz quiz = new Quiz()
            {
               title = title,
               showId = showId,
               description = description
            };
            context.Quizes.Add(quiz);
            await context.SaveChangesAsync();
        }
        public async Task<List<Quiz>> ViewAllQuizes()
        {
            var quizes = await context.Quizes.ToListAsync();
            return quizes;
        }
        public async Task RemoveQuizById(int id)
        {
            var quiz = await context.Quizes.FirstOrDefaultAsync(q => q.id == id);
            context.Quizes.Remove(quiz);
            await context.SaveChangesAsync();
        }
        public async Task UpdateQuiz(int id, string newTitle, int newShowId, string newDescription)
        {
            var quiz = await context.Quizes.FirstOrDefaultAsync(q => q.id == id);
            quiz.title = newTitle;
            quiz.showId = newShowId;
            quiz.description = newDescription;
            await context.SaveChangesAsync();
        }
    }
}
