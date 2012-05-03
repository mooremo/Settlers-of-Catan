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
    public partial class PlayersAndColorsDialog : Form
    {
        public int NumPlayers = 3;

        public string Player1Name;
        public string Player2Name;
        public string Player3Name;
        public string Player4Name;

        public Colors Player1Color;
        public Colors Player2Color;
        public Colors Player3Color;
        public Colors Player4Color;


        public PlayersAndColorsDialog()
        {
            InitializeComponent();
            cbox_NumPlayers.SelectedIndex = 0;
        }

        private void cbox_NumPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            NumPlayers = int.Parse(cbox_NumPlayers.SelectedItem.ToString());
            switch(NumPlayers)
            {
                case 3:
                    grp_Player4.Enabled = false;
                    break;
                case 4:
                    grp_Player4.Enabled = true;
                    break;
            }
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            Player1Name = txt_Name1.Text;
            Player1Color = (Colors) Enum.Parse(typeof(Colors), cbox_Color1.SelectedItem.ToString());
            Player2Name = txt_Name2.Text;
            Player2Color = (Colors)Enum.Parse(typeof(Colors), cbox_Color2.SelectedItem.ToString());
            Player3Name = txt_Name3.Text;
            Player3Color = (Colors)Enum.Parse(typeof(Colors), cbox_Color3.SelectedItem.ToString());
            if (NumPlayers > 3)
            {
                Player4Name = txt_Name4.Text;
                Player4Color = (Colors) Enum.Parse(typeof (Colors), cbox_Color4.SelectedItem.ToString());
            }

        }
    }
}
