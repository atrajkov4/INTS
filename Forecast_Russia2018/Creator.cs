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

       

        public void createPlayers() {
            DB db = DB.getInstance();
            string p2 = putanja + "/DEFGH1.txt";
            string[] linije = System.IO.File.ReadAllLines(p2);
            
            foreach (string l in linije) {
                string[] n = l.Split(';');
                Player g = new Player();

                g.id = Int32.Parse(n[0]);
                g.name = n[1];
                g.age = Int32.Parse(n[2]);
                g.overall = Int32.Parse(n[4]);
                g.potential = Int32.Parse(n[5]);
                g.club = n[6];
                g.aggression = Int32.Parse(n[7]);
                g.composure = Int32.Parse(n[8]);
                g.reactions = Int32.Parse(n[9]);
                g.visions = Int32.Parse(n[10]);
                string[] pp = n[11].Split(' ');
                foreach (string p in pp) {
                    g.preffered.Add(p);
                }
                db.addPlayer(g, n[3]);
                    
                }
            
        }

        public void createState() {
            DB db = DB.getInstance();
            string p2 = putanja + "/DEFGH1.txt";
            string[] linije = System.IO.File.ReadAllLines(p2);
            p2 = "";
            foreach (string l in linije) {
                string[] data = l.Split(';');
                if(data[3] != "" || data[3] != null) {
                    if (db.checkName(data[3]) == false)
                    {
                        Team t = new Team();
                        t.name = data[3];
                        db.addTeam(t);
                    }
                }
                
            }
            {
            }
           
        }
       

    }
}
