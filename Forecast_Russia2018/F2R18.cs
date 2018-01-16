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
            Team t = new Team();
            DB db = DB.getInstance();
            c.createState();
            c.createPlayers();
            c.createMatches();
            t.calculateForm();
            db.distribute();



             foreach (Group g in db.giveGroups())
            {
                tbRezultati.Text += g.rows.Count() + Environment.NewLine;

                foreach (Team tt in db.giveTeams())
                {
                    tbRezultati.Text += tt.name + " ";
                    tbRezultati.Text += tt.form + Environment.NewLine;

                }
            
            foreach (Group g in db.giveGroups()) {
                
                tbRezultati.Text += "Group " + g.name + Environment.NewLine;
                
               foreach (GroupRow t in g.rows) {
                    if (t.team.name.Length < 6)  tbRezultati.Text += t.team.name + "\t\t\t" + t.points.ToString() + Environment.NewLine;
                    else if (t.team.name.Length <= 6 && t.team.name.Length < 11) tbRezultati.Text += t.team.name + "\t\t" + t.points.ToString() + Environment.NewLine;
                    else tbRezultati.Text += t.team.name + "\t" + t.points.ToString() + Environment.NewLine; 
                }
                tbRezultati.Text += Environment.NewLine;
            }


    }


    }
}
