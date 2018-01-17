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

        List<Match> matches = new List<Match>();

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

        public void addMatch(Match m)
        {
            matches.Add(m);
        }

        public List<Match> giveMatches()
        {
            return matches;
        }

        //group g  -  belg,panama,tunisia,england
        //group h -  poland,senegal,colombia,

        public void distribute() {
            if (teams.Count > 0) {
                Group A = new Group() { };
                A.name = "A";
                Group B = new Group() { };
                B.name = "B";
                Group C = new Group() { };
                C.name = "C";
                Group D = new Group() { };
                D.name = "D";
                Group E = new Group() { };
                E.name = "E";
                Group F = new Group() { };
                F.name = "F";
                Group G = new Group() { };
                G.name = "G";
                Group H = new Group() { };
                H.name = "H";
                

                foreach (Team t in teams)
                {
                    if (t.name == "Russia" || t.name == "Saudi Arabia" || t.name == "Egypt" || t.name == "Uruguay")
                    {
                        GroupRow ar = new GroupRow();
                        ar.team = t;
                        ar.points = 0;
                        A.rows.Add(ar);
                    }
                    if (t.name == "Portugal" || t.name == "Spain" || t.name == "Morocco" || t.name == "Iran")
                    {
                        GroupRow br = new GroupRow();
                        br.team = t;
                        br.points = 0;
                        B.rows.Add(br);
                    }
                    if (t.name == "France" || t.name == "Australia" || t.name == "Peru" || t.name == "Denmark")
                    {
                        GroupRow cr = new GroupRow();
                        cr.team = t;
                        cr.points = 0;
                        C.rows.Add(cr);
                    }
                    if (t.name == "Argentina" || t.name == "Iceland" || t.name == "Croatia" || t.name == "Nigeria")
                    {
                        GroupRow dr = new GroupRow();
                        dr.team = t;
                        dr.points = 0;
                        D.rows.Add(dr);
                    }
                    if (t.name == "Brazil" || t.name == "Switzerland" || t.name == "Costa Rica" || t.name == "Serbia")
                    {
                        GroupRow er = new GroupRow();
                        er.team = t;
                        er.points = 0;
                        E.rows.Add(er);
                    }

                    if (t.name == "Germany" || t.name == "Mexico" || t.name == "Sweden" || t.name == "Korea Republic")
                    {
                        GroupRow fr = new GroupRow();
                        fr.team = t;
                        fr.points = 0;
                        F.rows.Add(fr);
                    }
                    if (t.name == "Belgium" || t.name == "Panama" || t.name == "Tunisia" || t.name == "England")
                    {
                        GroupRow gr = new GroupRow();
                        gr.team = t;
                        gr.points = 0;
                        G.rows.Add(gr);
                    }
                   
                    if (t.name == "Poland" || t.name == "Senegal" || t.name == "Colombia" || t.name == "Japan") {
                        GroupRow hr = new GroupRow();
                        hr.team = t;
                        hr.points = 0;
                        H.rows.Add(hr);
                    }
            }
                addGroup(A);
                addGroup(B);
                addGroup(C);
                addGroup(D);
                addGroup(E);
                addGroup(F);
                addGroup(G);
                addGroup(H);

            }
            

        }

        public void PlayOff() {
            //proc grupama
            //nac parove za tekmu (9 tekma po grupi)
            //koristit Match(ekipa1,ekipa2), prilikom zavrsetka tekme azurirat bodove u grupi -> grouprows (team,points)
            


        }


    }
}
