﻿using System;
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

        
        public List<GroupRow> giveKonacna() {
            return konacna;
        }
        public void konacnaAdd(GroupRow gr) {
            bool found = false;
            foreach(GroupRow t in konacna) {
                if (t.team.name == gr.team.name) {
                    found = true;
                }
            }
            if(!found) konacna.Add(gr);
            
        }

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
        List<Match> odigrane = new List<Match>();
        public void getMatch(Match m) {
            odigrane.Add(m);
        }
        public List<Match> giveMatch() {
            return odigrane;
        }
        public int helper(string naziv1, string naziv2)
        {
            int b = 5;
            foreach (Group s in wc)
            {
                Team prvi = new Team();
                bool da = false;
                bool da2 = false;
                Team drugi = new Team();
                foreach (GroupRow gr in s.rows)
                {

                    if (gr.team.name == naziv1) {
                        prvi = gr.team;
                        da = true;
                    }
                    
                    if (gr.team.name == naziv2) {
                        drugi = gr.team;
                        da2 = true;
                    }
                    
                }


                if (da && da2)
                {
                    Match game = new Match(prvi, drugi);
                    game.Play();
                    //Console.Write(game.home + " " + game.home_score + ":" + game.away_score + " " + game.away + Environment.NewLine);
                    getMatch(game);
                    if (game.home_score > game.away_score)
                    {
                        foreach (GroupRow gr in s.rows)
                        {
                            if (gr.team.name == game.home) gr.points += 1;
                            b = 1;
                        }

                    }
                    else if (game.home_score < game.away_score)
                    {
                        foreach (GroupRow gr in s.rows)
                        {
                            if (gr.team.name == game.away)
                                gr.points += 1;
                            b = 2;
                        }
                    }
                    else {
                        foreach (GroupRow gr in s.rows)
                        {
                            if (gr.team.name == game.away) gr.points += 1;
                            if (gr.team.name == game.home) gr.points += 1;
                            b =  0;
                        }

                    }



                }
                
            }
            return b;
        }
        public void copycat() {
            foreach (Group g in wc) {
                foreach (GroupRow gg in g.rows) {
                    GroupRow what = new GroupRow();
                    what = gg;
                    konacna.Add(gg);
                }
            }
        }
        List<GroupRow> konacna = new List<GroupRow>();

        public Team getTeam(string naziv) {
            Team b = new Team();
            foreach (Group g in wc) {
                foreach (GroupRow gr in g.rows) {
                    if (gr.team.name == naziv) b = gr.team;
                }
            }
            return b;
        }

        public void PlayOff() {
            copycat();
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

            ///prviuGrupi
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
            ///DrugiUGrupi
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
            ///OsminaFinala
            foreach (Group g in wc)
            {
                if(g.name == "A")
                {
                    foreach(Group gg in wc)
                    {
                        if(gg.name == "B")
                        {
                            m1: int rez = helper(g.first, gg.second);
                            if (rez == 1)
                            {
                                GroupRow gr = new GroupRow();

                                gr.team = getTeam(gg.second);
                                gr.points += 1;
                                konacnaAdd(gr);
                            }
                            else if (rez == 2)
                            {
                                GroupRow gr = new GroupRow();

                                gr.team = getTeam(g.first);
                                gr.points += 1;
                                konacnaAdd(gr);

                            }
                            else if (rez == 0) goto m1;

                            m2: rez = helper(g.second, gg.first);
                            if (rez == 1)
                            {
                                GroupRow gr = new GroupRow();

                                gr.team = getTeam(gg.first);
                                gr.points += 1;
                                konacnaAdd(gr);
                            }
                            else if (rez == 2)
                            {
                                GroupRow gr = new GroupRow();

                                gr.team = getTeam(g.second);
                                gr.points += 1;
                                konacnaAdd(gr);

                            }
                            else if (rez == 0) goto m2;
                        }
                    }
                    //pobjedniciOsminaFinala-----Ab1
                    pomocna = 0;
                    foreach (GroupRow gr in g.rows)
                    {
                        if (gr.points > pomocna)
                        {
                            g.firstQ = gr.team.name;
                            pomocna = gr.points;
                        }
                    }
                    //pobjedniciOsminaFinala-----Ab2
                    pomocna = 0;
                    foreach (GroupRow gr in g.rows)
                    {
                        if (!(g.firstQ == gr.team.name))
                        {
                            if (gr.points > pomocna)
                            {
                                g.secondQ = gr.team.name;
                                pomocna = gr.points;
                            }

                        }
                    }
                }
                if (g.name == "C")
                {
                    foreach (Group gg in wc)
                    {
                        if (gg.name == "D")
                        {
                            m1: int rez = helper(g.first, gg.second);
                            if (rez == 1)
                            {
                                GroupRow gr = new GroupRow();

                                gr.team = getTeam(gg.second);
                                gr.points += 1;
                                konacnaAdd(gr);
                            }
                            else if (rez == 2)
                            {
                                GroupRow gr = new GroupRow();

                                gr.team = getTeam(g.first);
                                gr.points += 1;
                                konacnaAdd(gr);

                            }
                            else if (rez == 0) goto m1;
                            m2: rez = helper(g.second, gg.first);
                            if (rez == 1)
                            {
                                GroupRow gr = new GroupRow();

                                gr.team = getTeam(gg.first);
                                gr.points += 1;
                                konacnaAdd(gr);
                            }
                            else if (rez == 2)
                            {
                                GroupRow gr = new GroupRow();

                                gr.team = getTeam(g.second);
                                gr.points += 1;
                                konacnaAdd(gr);

                            }
                            else if (rez == 0) goto m2;
                        }
                    }
                    //pobjedniciOsminaFinala-----cd1
                    pomocna = 0;
                    foreach (GroupRow gr in g.rows)
                    {
                        if (gr.points > pomocna)
                        {
                            g.firstQ = gr.team.name;
                            pomocna = gr.points;
                        }
                    }
                    //pobjedniciOsminaFinala-----cd2
                    pomocna = 0;
                    foreach (GroupRow gr in g.rows)
                    {
                        if (!(g.firstQ == gr.team.name))
                        {
                            if (gr.points > pomocna)
                            {
                                g.secondQ = gr.team.name;
                                pomocna = gr.points;
                            }

                        }
                    }
                }
                if (g.name == "E")
                {
                    foreach (Group gg in wc)
                    {
                        if (gg.name == "F")
                        {
                            m1: int rez = helper(g.first, gg.second);
                            if (rez == 1)
                            {
                                GroupRow gr = new GroupRow();

                                gr.team = getTeam(gg.second);
                                gr.points += 1;
                                konacnaAdd(gr);
                            }
                            else if (rez == 2)
                            {
                                GroupRow gr = new GroupRow();

                                gr.team = getTeam(g.first);
                                gr.points += 1;
                                konacnaAdd(gr);

                            }
                            else if (rez == 0) goto m1;
                            m2: rez = helper(g.second, gg.first);
                            if (rez == 1)
                            {
                                GroupRow gr = new GroupRow();

                                gr.team = getTeam(gg.first);
                                gr.points += 1;
                                konacnaAdd(gr);
                            }
                            else if (rez == 2)
                            {
                                GroupRow gr = new GroupRow();

                                gr.team = getTeam(g.second);
                                gr.points += 1;
                                konacnaAdd(gr);

                            }
                            else if (rez == 0) goto m2;
                        }
                    }
                    //pobjedniciOsminaFinala-----ef1
                    pomocna = 0;
                    foreach (GroupRow gr in g.rows)
                    {
                        if (gr.points > pomocna)
                        {
                            g.firstQ = gr.team.name;
                            pomocna = gr.points;
                        }
                    }
                    //pobjedniciOsminaFinala-----ef2
                    pomocna = 0;
                    foreach (GroupRow gr in g.rows)
                    {
                        if (!(g.firstQ == gr.team.name))
                        {
                            if (gr.points > pomocna)
                            {
                                g.secondQ = gr.team.name;
                                pomocna = gr.points;
                            }

                        }
                    }
                }
                if (g.name == "G")
                {
                    foreach (Group gg in wc)
                    {
                        if (gg.name == "H")
                        {
                            m1: int rez = helper(g.first, gg.second);
                            if (rez == 1)
                            {
                                GroupRow gr = new GroupRow();

                                gr.team = getTeam(gg.second);
                                gr.points += 1;
                                konacnaAdd(gr);
                            }
                            else if (rez == 2)
                            {
                                GroupRow gr = new GroupRow();

                                gr.team = getTeam(g.first);
                                gr.points += 1;
                                konacnaAdd(gr);

                            }
                            else if (rez == 0) goto m1;
                            m2: rez = helper(g.second, gg.first);
                            if (rez == 1)
                            {
                                GroupRow gr = new GroupRow();

                                gr.team = getTeam(gg.first);
                                gr.points += 1;
                                konacnaAdd(gr);
                            }
                            else if (rez == 2)
                            {
                                GroupRow gr = new GroupRow();

                                gr.team = getTeam(g.second);
                                gr.points += 1;
                                konacnaAdd(gr);

                            }
                            else if (rez == 0) goto m2;
                        }
                    }
                    //pobjedniciOsminaFinala-----gh1
                    pomocna = 0;
                    foreach (GroupRow gr in g.rows)
                    {
                        if (gr.points > pomocna)
                        {
                            g.firstQ = gr.team.name;
                            pomocna = gr.points;
                        }
                    }
                    //pobjedniciOsminaFinala-----gh2
                    pomocna = 0;
                    foreach (GroupRow gr in g.rows)
                    {
                        if (!(g.firstQ == gr.team.name))
                        {
                            if (gr.points > pomocna)
                            {
                                g.secondQ = gr.team.name;
                                pomocna = gr.points;
                            }

                        }
                    }
                }

            }
            //Cetvrtfinale
            foreach(Group g in wc)
            {
                if (g.name == "A")
                {
                    foreach (Group gg in wc)
                    {
                        if (gg.name == "C")
                        {
                            m1: int rez = helper(g.firstQ, gg.secondQ);
                            if (rez == 1)
                            {
                                GroupRow gr = new GroupRow();

                                gr.team = getTeam(gg.secondQ);
                                gr.points += 6;
                                konacnaAdd(gr);
                            }
                            else if (rez == 2)
                            {
                                GroupRow gr = new GroupRow();

                                gr.team = getTeam(g.firstQ);
                                gr.points += 6;
                                konacnaAdd(gr);

                            }
                            else if (rez == 0) goto m1;
                            m2: rez = helper(g.secondQ, gg.firstQ);
                            if (rez == 1)
                            {
                                GroupRow gr = new GroupRow();

                                gr.team = getTeam(gg.firstQ);
                                gr.points += 6;
                                konacnaAdd(gr);
                            }
                            else if (rez == 2)
                            {
                                GroupRow gr = new GroupRow();

                                gr.team = getTeam(g.secondQ);
                                gr.points += 6;
                                konacnaAdd(gr);

                            }
                            else if (rez == 0) goto m2;
                        }
                    }
                    //pobjedniciCEtvrfinala-----A1b2 vs D1c2
                    pomocna = 0;
                    foreach (GroupRow gr in g.rows)
                    {
                        if (gr.points > pomocna)
                        {
                            g.firstQQ = gr.team.name;
                            pomocna = gr.points;
                        }
                    }
                    //pobjedniciCEtvrfinala-----A2b1 vs C1D2
                    pomocna = 0;
                    foreach (GroupRow gr in g.rows)
                    {
                        if (!(g.firstQQ == gr.team.name))
                        {
                            if (gr.points > pomocna)
                            {
                                g.secondQQ = gr.team.name;
                                pomocna = gr.points;
                            }

                        }
                    }
                }
                if (g.name == "D")
                {
                    foreach (Group gg in wc)
                    {
                        if (gg.name == "F")
                        {
                            m1: int rez = helper(g.firstQ, gg.secondQ);
                            if (rez == 1)
                            {
                                GroupRow gr = new GroupRow();

                                gr.team = getTeam(gg.secondQ);
                                gr.points += 6;
                                konacnaAdd(gr);
                            }
                            else if (rez == 2)
                            {
                                GroupRow gr = new GroupRow();

                                gr.team = getTeam(g.firstQ);
                                gr.points += 6;
                                konacnaAdd(gr);

                            }
                            else if (rez == 0) goto m1;
                            m2: rez = helper(g.secondQ, gg.firstQ);
                            if (rez == 1)
                            {
                                GroupRow gr = new GroupRow();

                                gr.team = getTeam(gg.firstQ);
                                gr.points += 6;
                                konacnaAdd(gr);
                            }
                            else if (rez == 2)
                            {
                                GroupRow gr = new GroupRow();

                                gr.team = getTeam(g.secondQ);
                                gr.points += 6;
                                konacnaAdd(gr);

                            }
                            else if (rez == 0) goto m2;
                        }
                    }
                    //pobjedniciCEtvrfinala-----D1E2 vs F2G1
                    pomocna = 0;
                    foreach (GroupRow gr in g.rows)
                    {
                        if (gr.points > pomocna)
                        {
                            g.firstQQ = gr.team.name;
                            pomocna = gr.points;
                        }
                    }
                    //pobjedniciCEtvrfinala-----D2E1 vs F1G2
                    pomocna = 0;
                    foreach (GroupRow gr in g.rows)
                    {
                        if (!(g.firstQQ == gr.team.name))
                        {
                            if (gr.points > pomocna)
                            {
                                g.secondQQ = gr.team.name;
                                pomocna = gr.points;
                            }

                        }
                    }
                }
            }
            //polufinale
            foreach (Group g in wc)
            {
                if (g.name == "A")
                {
                    foreach (Group gg in wc)
                    {
                        if (gg.name == "E")
                        {
                            m1: int rez = helper(g.firstS, gg.secondS);
                            if (rez == 1)
                            {
                                GroupRow gr = new GroupRow();

                                gr.team = getTeam(gg.secondS);
                                gr.points += 18;
                                konacnaAdd(gr);
                            }
                            else if (rez == 2)
                            {
                                GroupRow gr = new GroupRow();

                                gr.team = getTeam(g.firstS);
                                gr.points += 18;
                                konacnaAdd(gr);

                            }
                            else if (rez == 0) goto m1;
                            m2: rez= helper(g.secondS, gg.firstS);
                            if (rez == 1)
                            {
                                GroupRow gr = new GroupRow();

                                gr.team = getTeam(gg.firstS);
                                gr.points += 18;
                                konacnaAdd(gr);
                            }
                            else if (rez == 2)
                            {
                                GroupRow gr = new GroupRow();

                                gr.team = getTeam(g.secondS);
                                gr.points += 18;
                                konacnaAdd(gr);

                            }
                            else if (rez == 0) goto m2;
                        }
                    }
                    //pobjedniciPrvogPolufinala
                    pomocna = 0;
                    foreach (GroupRow gr in g.rows)
                    {
                        if (gr.points > pomocna)
                        {
                            g.firstS = gr.team.name;
                            pomocna = gr.points;
                        }
                    }
                    //pobjedniciDrugogPolufinala
                    pomocna = 0;
                    foreach (GroupRow gr in g.rows)
                    {
                        if (!(g.firstS == gr.team.name))
                        {
                            if (gr.points > pomocna)
                            {
                                g.secondS = gr.team.name;
                                pomocna = gr.points;
                            }

                        }
                    }
                }
            }
            /////FINALE
            foreach (Group g in wc)
            {
                if (g.name == "A")
                {                    
                    m1: int rez = helper(g.firstS, g.secondS);
                    if (rez == 1)
                    {
                        GroupRow gr = new GroupRow();

                        gr.team = getTeam(g.secondS);
                        gr.points += 30;
                        konacnaAdd(gr);

                        GroupRow gr2 = new GroupRow();
                        gr2.team = getTeam(g.firstS);
                        gr2.points += 50;
                        konacna.Add(gr2);
                    }
                    else if (rez == 2)
                    {
                        GroupRow gr = new GroupRow();

                        gr.team = getTeam(g.firstS);
                        gr.points += 30;
                        konacnaAdd(gr);

                        GroupRow gr2 = new GroupRow();
                        gr2.team = getTeam(g.secondS);
                        gr2.points += 50;
                        konacna.Add(gr2);

                    }
                    else if (rez == 0) goto m1;
                    //pobjedniciFinala
                    pomocna = 0;
                    foreach (GroupRow gr in g.rows)
                    {
                        if (gr.points > pomocna)
                        {
                            g.firstFinal = gr.team.name;
                            pomocna = gr.points;
                        }
                    }

                }

            }
            //konacna.OrderBy(a=>a.points);
           
        }


    }
}
