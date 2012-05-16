using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SettlersOfCatan
{
    public partial class Victory : Form
    {
        public Victory()
        {
            InitializeComponent();
        }

        private void Victory_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Resources.victory;
            this.Size = Resources.victory.Size;
        }

        private void Victory_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
