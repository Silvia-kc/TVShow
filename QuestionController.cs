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
    public class QuestionController
    {
        TVShowContext context = new TVShowContext();
        public async Task AddQuestion(string text, string optionA, string optionB, string optionC, string optionD, string correctAnswer, int quizId)
        {
            Question question = new Question()
            { 
                text = text,
                optionA = optionA,
                optionB = optionB,
                optionC = optionC,
                optionD = optionD,
                correctAnswer = correctAnswer,
                quizId = quizId
            };
            context.Questions.Add(question);
            await context.SaveChangesAsync();
        }
        public async Task<List<Question>> ViewAllQuestions()
        {
            var questions = await context.Questions.ToListAsync();
            return questions;
        }
        public async Task RemoveQuestionById(int id)
        {
            var question = await context.Questions.FirstOrDefaultAsync(q => q.id == id);
            context.Questions.Remove(question);
            await context.SaveChangesAsync();
        }
        public async Task UpdateQuestion(int id, string newText, string newOptionA, string newOptionB, string newOptionC, string newOptionD, string newCorrectAnswer, int newQuizId)
        {
            var question = await context.Questions.FirstOrDefaultAsync(q => q.id == id);
            question.text = newText;
            question.optionA = newOptionA;
            question.optionB = newOptionB;
            question.optionC = newOptionC;
            question.optionD = newOptionD;
            question.correctAnswer = newCorrectAnswer;
            question.quizId = newQuizId;
            await context.SaveChangesAsync();
        }
    }
}
