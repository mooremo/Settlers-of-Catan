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
    public partial class ResourceSelect : Form
    {
        public CardType Result;
        public CardType OtherResult;

        public bool YOP;
        private bool _madeFirstChoice;

        public ResourceSelect()
        {
            InitializeComponent();
            UpdateUILanguage();
            YOP = false;
            _madeFirstChoice = false;
        }

        private void UpdateUILanguage()
        {
            Text = Resources.resourceSelect;
            btn_Brick.Text = Resources.brick;
            btn_grain.Text = Resources.grain;
            btn_lumber.Text = Resources.wood;
            btn_ore.Text = Resources.ore;
            btn_wool.Text = Resources.wool;
        }

        private void btn_Brick_Click(object sender, EventArgs e)
        {
            if (!YOP || _madeFirstChoice)
            {
                Result = CardType.Brick;
                DialogResult = DialogResult.OK;
            }

            OtherResult = CardType.Brick;
            _madeFirstChoice = true;
        }

        private void btn_grain_Click(object sender, EventArgs e)
        {
            if (!YOP || _madeFirstChoice)
            {
                Result = CardType.Grain;
                DialogResult = DialogResult.OK;
            }

            OtherResult = CardType.Grain;
            _madeFirstChoice = true;
        }

        private void btn_lumber_Click(object sender, EventArgs e)
        {
            if (!YOP || _madeFirstChoice)
            {
                Result = CardType.Lumber;
                DialogResult = DialogResult.OK;
            }

            OtherResult = CardType.Lumber;
            _madeFirstChoice = true;
        }

        private void btn_ore_Click(object sender, EventArgs e)
        {
            if (!YOP || _madeFirstChoice)
            {
                Result = CardType.Ore;
                DialogResult = DialogResult.OK;
            }

            OtherResult = CardType.Ore;
            _madeFirstChoice = true;
        }

        private void btn_wool_Click(object sender, EventArgs e)
        {
            if (!YOP || _madeFirstChoice)
            {
                Result = CardType.Wool;
                DialogResult = DialogResult.OK;
            }

            OtherResult = CardType.Wool;
            _madeFirstChoice = true;
        }
    }
}
