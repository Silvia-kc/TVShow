using Core;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Display
    {
        ShowController showController = new ShowController();
        ContestantController contestantController = new ContestantController(); 
        QuizController quizController = new QuizController();
        QuestionController questionController = new QuestionController();
        public async Task AddShow()
        {
            Console.WriteLine("Enter show name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Emter show air date: ");
            DateTime airDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter show descriotion: ");
            string description = Console.ReadLine();
            await showController.AddShow(name, airDate, description);
            Console.WriteLine("Show was added successfully!");
        }
        public async Task AddContestant()
        {
            Console.WriteLine("Enter contestant full name: ");
            string fullName = Console.ReadLine();
            Console.WriteLine("Enter contestant age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter contestant email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter contestant phonr number: ");
            string phoneNumber = Console.ReadLine();
            await contestantController.AddContestant(fullName, age, email, phoneNumber);
            Console.WriteLine("Contestant was added successfully!");
        }
        public async Task AddQuiz()
        {
            Console.WriteLine("Enter quiz title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter quiz show id: ");
            int showId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter quiz description: ");
            string description = Console.ReadLine();
            await quizController.AddQuiz(title, showId, description);
            Console.WriteLine("Quiz was added successfully!");
        }
        public async Task AddQuestion()
        {
            Console.WriteLine("Enter question text: ");
            string text= Console.ReadLine();
            Console.WriteLine("Enter question option A: ");
            string optionA = Console.ReadLine();
            Console.WriteLine("Enter question option B: ");
            string optionB = Console.ReadLine();
            Console.WriteLine("Enter question option C: ");
            string optionC = Console.ReadLine();
            Console.WriteLine("Enter question option D: ");
            string optionD = Console.ReadLine();
            Console.WriteLine("Enter question correct answer: ");
            string correctAnswer = Console.ReadLine();
            Console.WriteLine("Enter question quiz id: ");
            int quizId = int.Parse(Console.ReadLine());
            await questionController.AddQuestion(text, optionA, optionB, optionC, optionD, correctAnswer, quizId);
            Console.WriteLine("Question was added successfully!");
        }
        public async Task ViewAllShows()
        {
            List<Show> shows = await showController.ViewAllShows();
            foreach(var show in shows)
            {
                Console.WriteLine($"Show {show.name}. Air date: {show.airDate}. Description: {show.description}");
            }
        }
        public async Task ViewAllQuizes()
        {
            List<Quiz> quizes = await quizController.ViewAllQuizes();
            foreach(var quiz in quizes)
            {
                Console.WriteLine($"Quiz {quiz.title}. Description: {quiz.description}. Show with id {quiz.showId}");
            }
        }
        public async Task ViewAllQuestions()
        {
            List<Question> questions = await questionController.ViewAllQuestions();
            foreach(var question in questions)
            {
                Console.WriteLine($"Question: {question.text}");
                Console.WriteLine($"Possible answers: ");
                Console.WriteLine($"A: {question.optionA}");
                Console.WriteLine($"B: {question.optionB}");
                Console.WriteLine($"C: {question.optionC}");
                Console.WriteLine($"D: {question.optionD}");
                Console.WriteLine($"Correct answer is: {question.correctAnswer}");
                Console.WriteLine($"Question from quiz with id: {question.quizId}");
            }
        }
        public void Menu()
        {
            Console.WriteLine("1.Add show");
            Console.WriteLine("2.Add contestant");
            Console.WriteLine("3.Add quiz");
            Console.WriteLine("4.Add question");
            Console.WriteLine("5.View all shows");
            Console.WriteLine("6.View all quizes");
            Console.WriteLine("7.View all questions");
            Console.WriteLine("8.Exit");
            Console.WriteLine("Choose option: ");
        }
        public async Task ViewMenu()
        {
            while(true)
            {
                Menu();
                int num = int.Parse(Console.ReadLine());
                if(num == 8)
                {
                    break;
                }
                switch (num)
                {
                    case 1:
                        await AddShow();
                        break;
                    case 2:
                        await AddContestant();
                        break;
                    case 3:
                        await AddQuiz();
                        break;
                    case 4:
                        await AddQuestion();
                        break;
                    case 5:
                        await ViewAllShows();
                        break;
                    case 6:
                        await ViewAllQuizes();
                        break;
                    case 7:
                        await ViewAllQuestions();
                        break;
                }

            }
        }

    }
}
