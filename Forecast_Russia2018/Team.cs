using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forecast_Russia2018
{
    class Team
    {
        List<Player> squad = new List<Player>();
        string name;
        int overall; // prosjek
        int potential; // prosjek 
        int fail_potential; // između 1 - 5
        List<string> last_games = new List<string>();
        int form; // ono na temelju zadnjih utakmica

        public Team() {

        }


    }
}
