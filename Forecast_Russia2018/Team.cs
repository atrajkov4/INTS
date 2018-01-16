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
        int overall; // prosjek
        int potential; // prosjek 
        int fail_potential; // između 1 - 5
        List<Match> last_games = new List<Match>();
        public int form; // ono na temelju zadnjih utakmica

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
    
        


    }
}
