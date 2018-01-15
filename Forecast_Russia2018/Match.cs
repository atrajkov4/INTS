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

        public string home;
        public string away;
        public int home_score;
        public int away_score;
        List<Player> scorers = new List<Player>();
        List<Player> sent_off = new List<Player>();
    }
}
