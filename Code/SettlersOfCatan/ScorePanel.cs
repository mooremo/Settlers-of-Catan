using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SettlersOfCatan
{
    class ScorePanel : Label
    {
        public GameController gc { get; set; }

        public void UpdateScores()
        {
            this.Text = "";
            this.Font = new Font(FontFamily.GenericSerif, 15, FontStyle.Bold);
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = SystemColors.Control;
            foreach (var p in gc.Players)
            {
                if (p == gc.CurrentPlayer)
                {
                    this.Text += ">>" + p.Name + ":\t\t" + p.Score.ToString() + "\n";
                }else
                {
                    this.Text += "    " + p.Name + ":\t\t" + p.Score.ToString() + "\n";
                }
            }

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}
