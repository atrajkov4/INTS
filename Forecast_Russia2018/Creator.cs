using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forecast_Russia2018
{
    class Creator
    {
        string naziv;
        public Creator() {

        }

        private string putanja = System.IO.Directory.GetCurrentDirectory();
        private Random rnd = new Random();



        public void createPlayers() {
            DB db = DB.getInstance();
            string p2 = putanja + "/DEFGH.txt";
            string[] linije = System.IO.File.ReadAllLines(p2);
            
            foreach (string l in linije) {
                string[] n = l.Split(';');
                Player g = new Player();

                g.id = Int32.Parse(n[0]);
                g.name = n[1];

                try { g.age = Int32.Parse(n[2]); }
                catch (Exception) { if (n[2] == "") g.age = 25; }

                g.overall = Int32.Parse(n[4]);

                try { g.potential = Int32.Parse(n[5]); }
                catch (Exception) { if (n[5] == "") g.potential = rnd.Next(60, 90); }

                if (n[6] == "") g.club = "None at the time";
                else g.club = (n[6]);

                try { g.aggression = Int32.Parse(n[7]); }
                catch (Exception) { if (n[7] == "") g.aggression = rnd.Next(60, 90); }

                try { g.composure = Int32.Parse(n[8]); }
                catch (Exception e) { if (n[8]=="") g.composure = rnd.Next(60, 90); }

                try { g.reactions = Int32.Parse(n[9]); }
                catch (Exception) { if (n[9] == "") g.reactions = rnd.Next(60, 90); }

                try { g.visions = Int32.Parse(n[10]); }
                catch (Exception) { if (n[10] == "") g.visions = rnd.Next(60, 90); }

                string[] pp = n[11].Split(' ');
                foreach (string p in pp) {
                    g.preffered.Add(p);
                }
                db.addPlayer(g, n[3]);
                    
                }
            
        }

        public void createState() {
            DB db = DB.getInstance();
            string p2 = putanja + "/DEFGH.txt";
            string[] linije = System.IO.File.ReadAllLines(p2);
            p2 = "";
            foreach (string l in linije) {
                string[] data = l.Split(';');
                if(data[3] != "" || data[3] != null) {
                    if (db.checkName(data[3]) == false)
                    {
                        Team t = new Team();
                        string neu = data[3].Trim('"');
                        t.name = neu;
                        db.addTeam(t);
                    }
                }
                
            }
            {
            }
           
        }

        public string createMatches()
        {
            string p3 = putanja + "/Rezultati.txt";
            string[] linije = System.IO.File.ReadAllLines(p3);
            p3 = "";
            foreach (string l in linije)
            {
                string[] n = l.Split(';');
                Match g = new Match();
                g.home = n[1];
                g.away = n[2];
                g.home_score = Int32.Parse(n[3]);
                g.away_score = Int32.Parse(n[4]);

            }

            return p3;
        }


    }
}
