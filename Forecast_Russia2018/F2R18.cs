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
            DB db = DB.getInstance();
            c.createState();
            c.createPlayers();
            c.createMatches();
            db.distribute();

            foreach (Group g in db.giveGroups()) {
                tbRezultati.Text += g.rows.Count() + Environment.NewLine;

               /* foreach (GroupRow t in g.rows) {
                    tbRezultati.Text += t.team.name + "  " + t.points.ToString() + Environment.NewLine; 
                }
                tbRezultati.Text += Environment.NewLine;
                /*foreach (Player p in s.squad) {
                    tbRezultati.Text += Environment.NewLine+ "     " + p.name;
                    //tbRezultati.Text += Environment.NewLine + p.club;
                }
                */
            }

    }


    }
}
