using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Contestant
    {
        public int id {  get; set; }
        [Required]
        public string fullName {  get; set; }   
        public int age {  get; set; }
        [MaxLength(50)]
        public string contactEmail {  get; set; }
        [MaxLength(10)]
        public string phoneNumber {  get; set; }
        public ICollection<ShowContestant> ShowContestant { get; set; }
    }
}
