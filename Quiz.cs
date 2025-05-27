using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Quiz
    {
        public int id {  get; set; }
        [Required]
        [MaxLength(100)]
        public string title {  get; set; }
        public int showId { get; set; }
        public Show Show { get; set; }
        public string description {  get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
