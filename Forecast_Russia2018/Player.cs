using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forecast_Russia2018
{
    class Player
    {


        public int id;
        public int age; // dodat nešto da ako su igrači stariji od npr 34 godine, malo slabije statistike budu
        public int overall;
        public int potential;
        public int aggression;
        public int composure;
        public int reactions;
        public int visions;
        int kreator;
        public int sent_away;
        public string[] preffered;
        public string name;
        public bool selected;
        public bool eligible; // ozljeda ili crveni karton
        

        public Player()
        {

        }

        public int kreatorGen() {
            kreator = (composure * visions * reactions) / 100000;
            return kreator;
        }

        public int beingSentOff() {
            sent_away = ((100 - reactions) * aggression) / 1000;
            return sent_away;
        }


    }
}
