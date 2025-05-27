using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ShowContestant
    {
        public int showId {  get; set; }
        public Show Show { get; set; }
        public int contestantId {  get; set; }
        public Contestant Contestant { get; set; }
    }
}
