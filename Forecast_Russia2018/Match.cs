using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forecast_Russia2018
{
    class Match
    {
        public Match() {
        }

        float chancesHome;
        float chancesAway;
        public string home;
        public string away;
        public int home_score;
        public int away_score;
        List<Player> scorers = new List<Player>();
        List<Player> sent_off = new List<Player>();
        Team h;
        Team a;


        public Match(Team home1, Team away1) {
            h = home1;
            a = away1;
            home = h.name;
            away = a.name;
        }

        Random r = new Random();
        Random r2 = new Random();
        Random r3 = new Random();

        public void Play() {
            chancesHome = (h.potency / (h.potency + a.potency))*100;
            chancesAway = 100 - chancesAway;
            if (r.Next(0, 100) < chancesHome + 1)
            {
                int result = r2.Next(0, 100);
                if (result <= 58)
                {
                    do
                    {
                        home_score = r3.Next(0, 4);
                        away_score = r3.Next(0, 4);

                    } while (home_score <= away_score);

                }
                else if (result > 58 && result < 84)
                {
                    do
                    {
                        home_score = r3.Next(2, 5);
                        away_score = r3.Next(2, 5);

                    } while (home_score <= away_score);
                }
                else
                {

                    do
                    {
                        home_score = r3.Next(1, 7);
                        away_score = r3.Next(1, 7);

                    } while (home_score <= away_score);
                }
            }
            else {

                int result = r2.Next(0, 100);
                if (result <= 58)
                {
                    do
                    {
                        home_score = r3.Next(0, 4);
                        away_score = r3.Next(0, 4);

                    } while (home_score >= away_score);

                }
                else if (result > 58 && result < 84)
                {
                    do
                    {
                        home_score = r3.Next(2, 5);
                        away_score = r3.Next(2, 5);

                    } while (home_score >= away_score);
                }
                else
                {

                    do
                    {
                        home_score = r3.Next(1, 7);
                        away_score = r3.Next(1, 7);

                    } while (home_score >= away_score);
                }

            }
        }
    }
}
