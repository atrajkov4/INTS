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
        int fip;
        int sp;
        int tp;
        int fop;

        List<Match> all = new List<Match>();

        Team first = new Team();
        Team second = new Team();
        Team third = new Team();
        Team forth = new Team();

        public Group(Team a, Team b, Team c, Team d) {
            first = a;
            second = b;
            third = c;
            forth = d;
        }



    }
}
