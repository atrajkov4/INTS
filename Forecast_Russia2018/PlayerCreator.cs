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

        void Connect() {
            string[] linije = System.IO.File.ReadAllLines(putanja);

            //splitaj cuda isusova
        }
       

    }
}
