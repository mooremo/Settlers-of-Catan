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
    public partial class PlayCard : Form
    {
        public CardType Choice;

        public PlayCard()
        {
            InitializeComponent();
            UpdateUILanguage();
            btn_Monopoly.Enabled = false;
            btn_RoadBuilding.Enabled = false;
            btn_YOP.Enabled = false;
            btn_playVictoryCard.Enabled = false;
        }

        private void UpdateUILanguage()
        {
            this.Text = Resources.playCard;
            btn_Monopoly.Text = Resources.monopoly;
            btn_RoadBuilding.Text = Resources.roadBuilding;
            btn_YOP.Text = Resources.yearOfPlenty;
        }

        private void btn_Monopoly_Click(object sender, EventArgs e)
        {
            Choice = CardType.Monopoly;
            DialogResult = DialogResult.OK;
        }

        private void btn_RoadBuilding_Click(object sender, EventArgs e)
        {
            Choice = CardType.RoadBuilding;
            DialogResult = DialogResult.OK;
        }

        private void btn_YOP_Click(object sender, EventArgs e)
        {
            Choice = CardType.YearOfPlenty;
            DialogResult = DialogResult.OK;
        }

        private void btn_playVictoryCard_Click(object sender, EventArgs e)
        {
            Choice = CardType.VictoryPoint;
            DialogResult = DialogResult.OK;
        }

        public void EnableMonopoly()
        {
            btn_Monopoly.Enabled = true;
        }

        public void EnableRoadBuilding()
        {
            btn_RoadBuilding.Enabled = true;
        }

        public void EnableYOP()
        {
            btn_YOP.Enabled = true;
        }

        public void EnableVictoryCard()
        {
            btn_playVictoryCard.Enabled = true;
        }
       
    }
}
