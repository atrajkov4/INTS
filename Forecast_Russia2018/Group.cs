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
        int tp;
        int fop;

        public List<Match> all = new List<Match>();
        public List<GroupRow> rows = new List<GroupRow>();
       

    }
}
