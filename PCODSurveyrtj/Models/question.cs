using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCODSurvey.Models
{
    internal class question
    {
        public int questionno { get; set; }
        public int questionid { get; set; } = 0;
        public int questiontype { get; set; } = 0;
        public int questionvalue { get; set; } = 0;
        public int questionvaluetype { get; set;} = 0;
    }
}
