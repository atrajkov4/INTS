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
            c.createState();
            c.createPlayers();
            c.createMatches();
            tt.calculateForm();
            db.distribute();



            
                foreach (Group g in db.giveGroups())
                {

                    tbRezultati.Text += "[Group " + g.name + "]" + Environment.NewLine + "--------------------------" + Environment.NewLine;
                    
                    foreach (GroupRow t in g.rows)
                    {
                    if(t.team.name.Length < 5) tbRezultati.Text += t.team.name + "\t\t\t\t" + t.points.ToString() + Environment.NewLine;
                    else if (t.team.name.Length >= 5 && t.team.name.Length < 10) tbRezultati.Text += t.team.name + "\t\t\t" + t.points.ToString() + Environment.NewLine;
                    else tbRezultati.Text += t.team.name + "\t\t" + t.points.ToString() + Environment.NewLine;

                    /*
                        if (t.team.name.Length < 6) tbRezultati.Text += t.team.name + "\t\t\t" + t.points.ToString() + Environment.NewLine;
                        else if (t.team.name.Length <= 6 && t.team.name.Length < 11) tbRezultati.Text += t.team.name + "\t\t" + t.points.ToString() + Environment.NewLine;
                        else tbRezultati.Text += t.team.name + "\t" + t.points.ToString() + Environment.NewLine;
                        */
                }
                    tbRezultati.Text += Environment.NewLine;
                }


            }


        }
    }

