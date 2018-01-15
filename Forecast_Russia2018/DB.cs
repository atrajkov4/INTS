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

        private DB() {}

        public static DB getInstance() {
            return Instance;
        }

        List<Team> teams = new List<Team>();

        List<Group> A = new List<Group>();
        List<Group> B = new List<Group>();
        List<Group> C = new List<Group>();
        List<Group> D = new List<Group>();

        List<Group> E = new List<Group>();
        List<Group> F = new List<Group>();
        List<Group> G = new List<Group>();
        List<Group> H = new List<Group>();

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

        

        public void addPlayer(Player p, string team) {
            foreach (Team t in teams) {
                if (t.name == team) t.squad.Add(p);
            }
        }

        public List<Team> giveTeams() {
            return teams;
        }

    }
}
