using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forecast_Russia2018
{
    class DB
    {
        private static volatile DB Instance = new DB();

        private DB() { }

        public static DB getInstance() {
            return Instance;
        }

        List<Group> wc = new List<Group>();
        public void addGroup(Group Z) { wc.Add(Z); }

        List<Team> teams = new List<Team>();
        
        public bool checkName(string naziv) {
            bool found = false;
            foreach (Team t in teams) {
                if (t.name == naziv) found = true;
            }
            return found;
        }

        public void addTeam(Team t) {
            teams.Add(t);
        }

        public List<Group> giveGroups() {
            return wc;
        }

        public void addPlayer(Player p, string team) {
            foreach (Team t in teams) {
                if (t.name == team) t.squad.Add(p);
            }
        }

        public List<Team> giveTeams() {
            return teams;
        }

        //group g  -  belg,panama,tunisia,england
        //group h -  poland,senegal,colombia,

        public void distribute() {
            if (teams.Count > 0) {
                Group G = new Group() { };
                G.name = "G";
                Group H = new Group() { };
                H.name = "H";
                
                foreach (Team t in teams)
                {
                    if (t.name == "Belgium" || t.name == "Panama" || t.name == "Tunisia" || t.name == "England") {
                        GroupRow gr = new GroupRow();
                        gr.team = t;
                        gr.points = 0;
                        G.rows.Add(gr);

                    };
                    if (t.name == "Poland" || t.name == "Senegal" || t.name == "Colombia" || t.name == "Japan") {
                        GroupRow hr = new GroupRow();
                        hr.team = t;
                        hr.points = 0;
                        H.rows.Add(hr);
                    }
            }

                addGroup(H);
                addGroup(G);

            }
            

        }

    }
}
