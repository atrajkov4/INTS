using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forecast_Russia2018
{
    class PlayerCreator
    {
        string naziv;
        public PlayerCreator() {

        }
        private string putanja = System.IO.Directory.GetCurrentDirectory();

        public string Connect() {
            string p2 = putanja + "/DEFGH.txt";
            string[] linije = System.IO.File.ReadAllLines(p2);
            p2 = "";
            foreach (string l in linije) {



                //p2 += Environment.NewLine + l;
            }
            return p2;
        }
       

    }
}
