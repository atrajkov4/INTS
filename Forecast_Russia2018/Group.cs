using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forecast_Russia2018
{
    class Group
    {
        public Group() {
        }
        public string name;
        public string first;
        public string second;
        public string firstQ;//osminafinala pobjednik matcha A1-B2
        public string secondQ;////osminafinala pobjednik matcha B1-A2
        public string firstQQ;////cetvrtfinale pobjednik matcha A1B2-C2D1
        public string secondQQ;////cetvrtfinale pobjednik matcha B1A2-C1D2
        public string firstS;////polufinale pobjednik matcha 
        public string secondS;////polufinale pobjednik matcha 
        public string firstFinal;////pobjednik Finala


        public List<Match> all = new List<Match>();
        public List<GroupRow> rows = new List<GroupRow>();
       

    }
}
