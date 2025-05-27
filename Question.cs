using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Question
    {
        public int id {  get; set; }
        [Required]
        public string text {  get; set; }
        [Required]
        public string optionA {  get; set; }
        [Required]
        public string optionB { get; set; }
        [Required]
        public string optionC { get; set; }
        [Required]
        public string optionD { get; set; }
        [Required]
        public string correctAnswer {  get; set; }
        public int quizId {  get; set; }
        public Quiz Quiz { get; set; }

    }
}
