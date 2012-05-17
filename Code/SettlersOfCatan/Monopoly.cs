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
    public partial class Monopoly : Form
    {
        public CardType Result;

        public Monopoly()
        {
            InitializeComponent();
        }

        private void btn_Brick_Click(object sender, EventArgs e)
        {
            Result = CardType.Brick;
            DialogResult = DialogResult.OK;
        }

        private void btn_grain_Click(object sender, EventArgs e)
        {
            Result = CardType.Grain;
            DialogResult = DialogResult.OK;
        }

        private void btn_lumber_Click(object sender, EventArgs e)
        {
            Result = CardType.Lumber;
            DialogResult = DialogResult.OK;
        }

        private void btn_ore_Click(object sender, EventArgs e)
        {
            Result = CardType.Ore;
            DialogResult = DialogResult.OK;
        }

        private void btn_wool_Click(object sender, EventArgs e)
        {
            Result = CardType.Wool;
            DialogResult = DialogResult.OK;
        }
    }
}
