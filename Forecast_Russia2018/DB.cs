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
        int pomocna = 0;

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

        public void helper(string naziv1, string naziv2)
        {
            
            foreach (Group s in wc)
            {
                Team prvi = new Team();
                Team drugi = new Team();
                foreach (GroupRow gr in s.rows)
                {

                    if (gr.team.name == naziv1) prvi = gr.team;
                    if (gr.team.name == naziv2) drugi = gr.team;
                }


                if (prvi != null && drugi != null)
                {
                    Match game = new Match(prvi, drugi);
                    game.Play();
                    Console.Write(game.home + " " + game.home_score + ":" + game.away_score + " " + game.away + Environment.NewLine);
                    if (game.home_score > game.away_score)
                    {
                        foreach (GroupRow gr in s.rows)
                        {
                            if (gr.team.name == game.home) gr.points += 3;
                        }

                    }
                    else if (game.home_score < game.away_score)
                    {
                        foreach (GroupRow gr in s.rows)
                        {
                            if (gr.team.name == game.away)
                                gr.points += 3;
                        }
                    }
                    else {
                        foreach (GroupRow gr in s.rows)
                        {
                            if (gr.team.name == game.away) gr.points += 1;
                            if (gr.team.name == game.home) gr.points += 1;
                        }

                    }



                }
            }
        }

        public void PlayOff() {
            //proc grupama
            //nac parove za tekmu (9 tekma po grupi)
            //koristit Match(ekipa1,ekipa2), prilikom zavrsetka tekme azurirat bodove u grupi -> grouprows (team,points)

            helper("Belgium", "Panama");
            helper("Panama", "Belgium");
            helper("Tunisia", "England");
            helper("England", "Tunisia");
            helper("Tunisia","Belgium");
            helper("Belgium", "Tunisia");
            helper("Panama", "England");
            helper("England", "Panama");
            helper("England", "Belgium");
            helper("Belgium", "England");
            helper("Panama", "Tunisia");
            helper("Tunisia", "Panama");

            helper("Poland", "Senegal");
            helper("Senegal", "Poland");
            helper("Colombia", "Japan");
            helper("Japan", "Colombia");
            helper("Poland", "Colombia");
            helper("Colombia", "Poland");
            helper("Senegal", "Japan");
            helper("Japan", "Senegal");
            helper("Japan", "Poland");
            helper("Poland", "Japan");
            helper("Senegal", "Columbia");
            helper("Columbia", "Senegal");

            helper("Russia", "Egypt");
            helper("Egypt", "Russia");
            helper("Uruguay", "Saudi Arabia");
            helper("Saudi Arabia", "Uruguay");
            helper("Russia", "Uruguay");
            helper("Uruguay", "Russia");
            helper("Egypt", "Saudi Arabia");
            helper("Saudi Arabia", "Egypt");
            helper("Saudi Arabia", "Russia");
            helper("Russia", "Saudi Arabia");
            helper("Uruguay", "Egypt");
            helper("Egypt", "Uruguay");

            helper("Portugal", "Spain");
            helper("Spain", "Portugal");
            helper("Morocco", "Iran");
            helper("Iran", "Morocco");
            helper("Portugal", "Morocco");
            helper("Morocco", "Portugal");
            helper("Spain", "Iran");
            helper("Iran", "Spain");
            helper("Portugal", "Iran");
            helper("Iran", "Portugal");
            helper("Spain", "Morocco");
            helper("Morocco", "Spain");

            helper("France", "Australia");
            helper("Australia", "France");
            helper("Peru", "Denmark");
            helper("Denmark", "Peru");
            helper("France", "Peru");
            helper("Peru", "France");
            helper("Australia", "Denmark");
            helper("Denmark", "Australia");
            helper("France", "Denmark");
            helper("Denmark", "France");
            helper("Australia", "Peru");
            helper("Peru", "Australia");

            helper("Argentina", "Iceland");
            helper("Croatia", "Nigeria");
            helper("Iceland", "Argentina");
            helper("Nigeria", "Croatia");
            helper("Argentina", "Croatia");
            helper("Croatia", "Argentina");
            helper("Iceland", "Nigeria");
            helper("Nigeria", "Iceland");
            helper("Argentina", "Nigeria");
            helper("Nigeria", "Argentina");
            helper("Iceland", "Croatia");
            helper("Croatia", "Iceland");


            helper("Brazil", "Switzerland");
            helper("Brazil", "Costa Rica");
            helper("Brazil", "Serbia");
            helper("Switzerland", "Costa Rica");
            helper("Switzerland", "Serbia");
            helper("Costa Rica", "Serbia");
            helper("Switzerland", "Brazil");
            helper("Costa Rica", "Brazil");
            helper("Serbia", "Brazil");
            helper("Costa Rica", "Switzerland");
            helper("Serbia", "Switzerland");
            helper("Serbia", "Costa Rica");

            helper("Germany", "Mexico");
            helper("Germany", "Sweden");
            helper("Germany", "Korea Republic");
            helper("Mexico", "Sweden");
            helper("Mexico", "Korea Republic");
            helper("Sweden", "Korea Republic");
            helper("Mexico", "Germany");
            helper("Sweden", "Germany");
            helper("Korea Republic", "Germany");
            helper("Sweden", "Mexico");
            helper("Korea Republic", "Mexico");
            helper("Korea Republic", "Sweden");

            foreach (Group g in wc) {
                // g.rows.OrderByDescending(a => a.points);
                pomocna = 0;
                foreach(GroupRow gr in g.rows)
                {
                    if (gr.points > pomocna)
                    {
                        g.first = gr.team.name;
                        pomocna = gr.points;
                    }
                }
            }
            foreach (Group g in wc)
            {
                pomocna = 0;
                foreach (GroupRow gr in g.rows)
                {
                    if(!(g.first ==gr.team.name))
                    {
                        if (gr.points > pomocna)
                        {
                            g.second = gr.team.name;
                            pomocna = gr.points;
                        }

                    }
                }
            }

        }


    }
}
