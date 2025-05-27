using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Show
    {
        public int id {  get; set; }
        [Required]
        [MaxLength(100)]
        public string name { get; set; }
        public DateTime airDate { get; set; }
        public string description {  get; set; }
        public ICollection<Quiz> Quizes {  get; set; }
        public ICollection<ShowContestant> ShowContestant {  get; set; }
    }
}
