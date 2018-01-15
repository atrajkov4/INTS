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
        int fip;
        int sp;
        int tp;
        int fop;

        public List<Match> all = new List<Match>();
        public List<GroupRow> local = new List<GroupRow>();
       

    }
}
