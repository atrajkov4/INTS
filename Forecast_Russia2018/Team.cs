using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forecast_Russia2018
{
    class Team
    {
        public List<Player> squad = new List<Player>();
        public string name;
        public int overall; // prosjek
        public int potential; // prosjek 
        public int fail_potential; // između 1 - 5
        List<Match> last_games = new List<Match>();
        public int form; // ono na temelju zadnjih utakmica
        int broj; //broj igraca po timu
        public Team() {

        }

        public void calculateForm()
        {
            DB db = DB.getInstance();
            foreach (Match m in db.giveMatches())
            {
                foreach (Team t in db.giveTeams())
                {
                    if (m.home.Trim('"') == t.name)
                    {
                        if (m.home_score > m.away_score) t.form = t.form + 3;
                        if (m.home_score == m.away_score) t.form = t.form + 1;
                    }
                    if (m.away.Trim('"') == t.name)
                    {
                        if (m.away_score > m.home_score) t.form = t.form + 3;
                        if (m.home_score == m.away_score) t.form = t.form + 1;
                    }
                }

            }
        }

        public void calculateOverall()
        {
            DB db = DB.getInstance();
            foreach (Team t in db.giveTeams())
            {
                broj = 0;
                foreach (Player p in t.squad)
                {
                    t.overall = t.overall + p.overall;
                    broj++;
                }
                t.overall = t.overall / broj;
            }

        }

    }
}
