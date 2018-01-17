using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forecast_Russia2018
{
    public partial class F2R18 : Form
    {
        public F2R18()
        {
            InitializeComponent();
            Creator c = new Creator();
            Team tt = new Team();
            DB db = DB.getInstance();
            tbRezultati.Text = "";
            c.createState();
            c.createPlayers();
            c.createMatches();
            tt.calculateForm();
            tt.calculateOverallAndPotential();
            tt.calculateFailPotential();
            db.distribute();
            
            foreach (Group g in db.giveGroups()) {
                foreach (GroupRow gr in g.rows) gr.team.genPot();
            }
            /*
            Team t1 = new Team();
            Team t2 = new Team();
            foreach (Group g in db.giveGroups()) {
                foreach (GroupRow gr in g.rows) {
                    if (gr.team.name == "Germany") t1 = gr.team;
                    if (gr.team.name == "Sweden") t2 = gr.team;
                }
            }
            Match m = new Match(t1, t2);
            m.Play();
            tbRezultati.Text += m.home + " " + m.home_score + ":" + m.away_score + " " + m.away + Environment.NewLine;

            foreach (Group g in db.giveGroups())
            {
                foreach (GroupRow gr in g.rows)
                {
                    if (gr.team.name == "Switzerland") t1 = gr.team;
                    if (gr.team.name == "Serbia") t2 = gr.team;
                }

            }
           
            Match m2 = new Match(t1, t2);
            m2.Play();
            tbRezultati.Text += m2.home + " " + m2.home_score + ":" + m2.away_score + " " + m2.away + Environment.NewLine;
           */
             
            db.PlayOff();
            foreach (Group g in db.giveGroups())
                {
                    
                    tbRezultati.Text += "[Group " + g.name + "]\t\t\tPts\tPwr" + Environment.NewLine + "-------------------------------------------------------" + Environment.NewLine;
                
                    foreach (GroupRow t in g.rows)
                    {
                    
                   
                    // GLAVNI ISPIS
                    if(t.team.name.Length < 5) tbRezultati.Text += t.team.name + "\t\t\t\t" + t.points.ToString() + "\t" + t.team.potency + Environment.NewLine;
                    else if (t.team.name.Length >= 5 && t.team.name.Length < 10) tbRezultati.Text += t.team.name + "\t\t\t" + t.points.ToString() + "\t" + t.team.potency + Environment.NewLine;
                    else tbRezultati.Text += t.team.name + "\t\t" + t.points.ToString() + "\t" + t.team.potency +  Environment.NewLine;

                }
                    tbRezultati.Text += Environment.NewLine;
                }
            




        }


    }
    }

