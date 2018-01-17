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
        public float potency;
        public int goals;

        public string genPot() {
            float omjer = ((float)fail_potential * 3);
            potency = (int)(this.form*0.25) + (float)((0.75  * this.overall + 0.5 * this.potential)) - omjer;
            return this.form.ToString() + " " + (float)((overall * potential) / 100) + " " + omjer;
        }

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

        public void calculateOverallAndPotential()
        {
            DB db = DB.getInstance();
            foreach (Team t in db.giveTeams())
            {
                broj = 0;
                foreach (Player p in t.squad)
                {
                    t.overall = t.overall + p.overall;
                    t.potential = t.potential + p.potential;
                    broj++;
                }
                t.overall = t.overall / broj;
                t.potential = t.potential / broj;
            }

        }
        public void calculateFailPotential()
        {
            DB db = DB.getInstance();
            foreach (Team t in db.giveTeams())
            {
                if (t.form < 8) t.fail_potential = 5;
                if (t.form >= 8 & t.form < 10) t.fail_potential = 4;
                if (t.form >= 10 & t.form < 13) t.fail_potential = 3;
                if (t.form >= 13 & t.form < 16) t.fail_potential = 2;
                if (t.form >= 16) t.fail_potential = 1;
            }

        }

    }
}
