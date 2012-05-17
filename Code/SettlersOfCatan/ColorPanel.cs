using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SettlersOfCatan
{
    public partial class ColorPanel : UserControl
    {

        public ColorPanel()
        {
            InitializeComponent();
            Width = 1;
        }

        public void setColors(GameController myGC, int h)
        {
            var dim = h/myGC.Players.Count;
            Height = h-2;
            Width = dim;
            var y = 0;
            foreach (var p in myGC.Players)
            {
                var temp = new Label
                               {Size = new Size(dim, dim), BackColor = p.GetDrawColor(), Location = new Point(0, y)};
                this.Controls.Add(temp);
                y += dim;
            }
        }
    }
}
