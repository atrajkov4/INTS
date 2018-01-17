using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        

        public float takeTime() {
            Thread.Sleep(7);
            long dt = DateTime.Now.Millisecond;
            return (float)dt/10;
        }

        public long takeTicks() {
            Thread.Sleep(7);
            long dt = Environment.TickCount;
            return dt/1000000;
        }

        public void Play() {
            Random r = new Random();
            Random r2 = new Random();
            Random r3 = new Random();

            chancesHome = (h.potency / (h.potency + a.potency)) * 100;
            int b = StaticRandom.Instance.Next(1, 100);
            Console.Write(b + " <= " + chancesHome + Environment.NewLine);
            if ( b <= (int)chancesHome + 1)
            {
                
                if (StaticRandom.Instance.Next(1, 100) % 7 == 0)
                {
                   
                    do
                    {
                        home_score = r3.Next(0, 3);
                        away_score = r3.Next(0, 2);
                      

                    } while (home_score <= away_score);
                    h.goals += home_score;
                    a.goals += away_score;
                }
                else if (StaticRandom.Instance.Next(1, 100) % 3 == 0)
                {
                    
                    do
                    {
                        home_score = r3.Next(0, 3);
                        away_score = r3.Next(0, 3);
                        

                    } while (home_score != away_score);
                    h.goals += home_score;
                    a.goals += away_score;
                }
                else 
                {
                    
                    do
                    {
                        home_score = r3.Next(2, 4);
                        away_score = r3.Next(0, 3);
                        


                    } while (home_score <= away_score);
                    h.goals += home_score;
                    a.goals += away_score;
                }
            }
            else {
                
                if (StaticRandom.Instance.Next(1, 100) % 7 == 0)
                {
                    do
                    {
                        home_score = r3.Next(0, 2);
                        away_score = r3.Next(0, 3);
                        

                    } while (home_score >= away_score);
                    h.goals += home_score;
                    a.goals += away_score;
                }
                else if (StaticRandom.Instance.Next(1, 100) % 3 == 0)
                {
                    do
                    {
                        home_score = r3.Next(0, 3);
                        away_score = r3.Next(0, 3);
                        
                    } while (home_score != away_score);
                    h.goals += home_score;
                    a.goals += away_score;
                }
                else 
                {

                    do
                    {
                        home_score = r3.Next(0, 3);
                        away_score = r3.Next(2, 4);
                       
                    } while (home_score >= away_score);
                    h.goals += home_score;
                    a.goals += away_score;
                }

            }
        }
    }
}
