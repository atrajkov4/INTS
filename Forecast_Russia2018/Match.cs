using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forecast_Russia2018
{
    class Match
    {
        public Match() {
        }

        Team home;
        Team away;
        int home_score;
        int away_score;
        List<Player> scorers = new List<Player>();
        List<Player> sent_off = new List<Player>();
    }
}
