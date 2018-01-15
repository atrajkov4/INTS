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

       

        public string Connect() {
            string p2 = putanja + "/DEFGH1.txt";
            string[] linije = System.IO.File.ReadAllLines(p2);
            p2 = "";
            foreach (string l in linije) {
                string[] n = l.Split(';');
                Player g = new Player();
                g.id = Int32.Parse(n[0]);
                //g.
                    
                }


            //p2 += Environment.NewLine + l;
            return p2;
        }

        public void createState() {
            DB db = DB.getInstance();
            string p2 = putanja + "/DEFGH1.txt";
            string[] linije = System.IO.File.ReadAllLines(p2);
            p2 = "";
            foreach (string l in linije) {
                string[] data = l.Split(';');
                if (db.provjeri(data[3]) == false) {
                    Team t = new Team();
                    t.name = data[3];
                }
            }
            {
            }
           
        }
       

    }
}
