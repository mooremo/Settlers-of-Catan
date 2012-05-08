﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SettlersOfCatan.Properties;

namespace SettlersOfCatan
{
    public partial class PlayersAndColorsDialog : Form
    {
        public int NumPlayers = 3;

        public List<String> AvailibleColors;

        public String Player1ColorTemp;
        public String Player2ColorTemp;
        public String Player3ColorTemp;
        public String Player4ColorTemp;

        public Colors Player1Color;
        public string Player1Name;
        public Colors Player2Color;
        public string Player2Name;
        public Colors Player3Color;
        public string Player3Name;
        public Colors Player4Color;
        public string Player4Name;


        public PlayersAndColorsDialog()
        {
            InitializeComponent();
            UpdateUILangauge();
            cbox_NumPlayers.SelectedIndex = 0;
        }

        private void cbox_NumPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            NumPlayers = int.Parse(cbox_NumPlayers.SelectedItem.ToString());
            switch (NumPlayers)
            {
                case 3:
                    grp_Player4.Enabled = false;
                    cbox_Color4.SelectedItem = null;
                    break;
                case 4:
                    grp_Player4.Enabled = true;
                    break;
            }
        }

        private void UpdateUILangauge()
        {
            AvailibleColors = new List<String>(new String[] { Resources.Red, Resources.Orange, Resources.Blue, Resources.White, null, });
            Text = Resources.gameSetup;
            lbl_NumPlayers.Text = Resources.numberOfPlayers;
            grp_Player1.Text = Resources.player + " 1";
            grp_Player2.Text = Resources.player + " 2";
            grp_Player3.Text = Resources.player + " 3";
            grp_Player4.Text = Resources.player + " 4";
            lbl_Color1.Text = Resources.color;
            lbl_Color2.Text = Resources.color;
            lbl_Color3.Text = Resources.color;
            lbl_Color4.Text = Resources.color;
            lbl_Name1.Text = Resources.name;
            lbl_Name2.Text = Resources.name;
            lbl_Name3.Text = Resources.name;
            lbl_Name4.Text = Resources.name;
           
            cbox_Color1.SelectedItem = null;
            cbox_Color2.SelectedItem = null;
            cbox_Color3.SelectedItem = null;
            cbox_Color4.SelectedItem = null;
            btn_Ok.Text = Resources.OK;
            btn_Cancel.Text = Resources.Cancel;
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (
                txt_Name1.Text == ""
                || txt_Name2.Text == ""
                || txt_Name3.Text == ""
                || (txt_Name4.Text == "" && NumPlayers > 3)
                || cbox_Color1.SelectedItem == null
                || cbox_Color2.SelectedItem == null
                || cbox_Color3.SelectedItem == null
                || (cbox_Color1.SelectedItem == null && NumPlayers > 3)
                )
            {
                MessageBox.Show(
                    "You have not completed all of the required fields.",
                    "Incomplete Field",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                Player1Name = txt_Name1.Text;
                Player1Color = (Colors)Enum.Parse(typeof(Colors), getColor(cbox_Color1.SelectedItem.ToString()));
                Player2Name = txt_Name2.Text;
                Player2Color = (Colors) Enum.Parse(typeof (Colors), getColor(cbox_Color2.SelectedItem.ToString()));
                Player3Name = txt_Name3.Text;
                Player3Color = (Colors) Enum.Parse(typeof (Colors), getColor(cbox_Color3.SelectedItem.ToString()));
                if (NumPlayers > 3)
                {
                    Player4Name = txt_Name4.Text;
                    Player4Color = (Colors) Enum.Parse(typeof (Colors), getColor(cbox_Color4.SelectedItem.ToString()));
                }
                btn_Ok.DialogResult = DialogResult.OK;
                return;
            }
        }

        private string getColor(string localColorName)
        {
            switch (localColorName)
            {
                case "Red":
                    return "Red";
                case "Rot":
                    return "Red";
                case "Orange":
                    return "Orange";
                case "Blue":
                    return "Blue";
                case "Blau":
                    return "Blue";
                case "White":
                    return "White";
                case "Weiss":
                    return "White";
                default:
                    return "A";
            }
        }

        private void cbox_Color1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Player1ColorTemp != null)
            {
                cbox_Color2.Items.Add(Player1ColorTemp);
                cbox_Color3.Items.Add(Player1ColorTemp);
                cbox_Color4.Items.Add(Player1ColorTemp);
            }
            Player1ColorTemp = ((String)cbox_Color1.SelectedItem);
            cbox_Color2.Items.Remove(Player1ColorTemp);
            cbox_Color3.Items.Remove(Player1ColorTemp);
            cbox_Color4.Items.Remove(Player1ColorTemp);
        }

        private void cbox_Color2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Player2ColorTemp != null)
            {
                cbox_Color1.Items.Add(Player2ColorTemp);
                cbox_Color3.Items.Add(Player2ColorTemp);
                cbox_Color4.Items.Add(Player2ColorTemp);
            }
            Player2ColorTemp = ((String)cbox_Color2.SelectedItem);
            cbox_Color1.Items.Remove(Player2ColorTemp);
            cbox_Color3.Items.Remove(Player2ColorTemp);
            cbox_Color4.Items.Remove(Player2ColorTemp);
        }

        private void cbox_Color3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Player3ColorTemp != null)
            {
                cbox_Color2.Items.Add(Player3ColorTemp);
                cbox_Color1.Items.Add(Player3ColorTemp);
                cbox_Color4.Items.Add(Player3ColorTemp);
            }
            Player3ColorTemp = ((String)cbox_Color3.SelectedItem);
            cbox_Color2.Items.Remove(Player3ColorTemp);
            cbox_Color1.Items.Remove(Player3ColorTemp);
            cbox_Color4.Items.Remove(Player3ColorTemp);
        }

        private void cbox_Color4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Player4ColorTemp != null)
            {
                cbox_Color2.Items.Add(Player4ColorTemp);
                cbox_Color3.Items.Add(Player4ColorTemp);
                cbox_Color1.Items.Add(Player4ColorTemp);
            }
            Player4ColorTemp = ((String)cbox_Color4.SelectedItem);
            cbox_Color2.Items.Remove(Player4ColorTemp);
            cbox_Color3.Items.Remove(Player4ColorTemp);
            cbox_Color1.Items.Remove(Player4ColorTemp);
        }
    }
}