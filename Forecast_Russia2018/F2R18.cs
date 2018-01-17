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
           

            db.PlayOff();
            foreach (Group g in db.giveGroups())
            {
                 
                tbRezultati.Text += "[Group " + g.name + "]\t\t\tPts\tPwr" + Environment.NewLine + "-------------------------------------------------------" + Environment.NewLine;

                foreach (GroupRow t in g.rows)
                {


                    // GLAVNI ISPIS
                    if (t.team.name.Length < 5) tbRezultati.Text += t.team.name + "\t\t\t\t" + t.points.ToString() + "\t" + t.team.potency + Environment.NewLine;
                    else if (t.team.name.Length >= 5 && t.team.name.Length < 10) tbRezultati.Text += t.team.name + "\t\t\t" + t.points.ToString() + "\t" + t.team.potency + Environment.NewLine;
                    else tbRezultati.Text += t.team.name + "\t\t" + t.points.ToString() + "\t" + t.team.potency + Environment.NewLine;

                }
                tbRezultati.Text += Environment.NewLine;
            }

            tbRezultati.Text += "\n-------------------------------------------------------\n\t\t[REZULTATI] 1.PlayOff svega";
            foreach (Match m in db.giveMatch()) {
                
                tbRezultati.Text += Environment.NewLine + m.home + " " + m.home_score + " : " + m.away_score + " " + m.away;
                
                
            }
            for (int i = 0; i < 100; i++) {
                
                tbUkupniPlasman.Text = "";
                db.PlayOff();
                if (i == 99) {
                    List<GroupRow> n = db.giveKonacna();
                     n.GroupBy(z => z.team).ToList();
                    //n.OrderByDescending(z => z.points).ToList();
                   if (n.Count() > 32) {
                       n.RemoveRange(0, n.Count()-32);
                    }
                    n = n.OrderByDescending(a => a.points).ToList();
                    foreach (GroupRow gr in n)
                    {
                        if(gr.points > 100) tbUkupniPlasman.Text += gr.team.name + " : " + gr.points + Environment.NewLine;
                    }
                }
               
            }
            tbUkupniPlasman.Text += "Total : " + db.giveKonacna().Count().ToString();

            
        }


    }

    internal class grouprow
    {
    }
}

