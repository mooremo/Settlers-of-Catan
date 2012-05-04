using System;
using System.Windows.Forms;
using SettlersOfCatan.Properties;

namespace SettlersOfCatan
{
    public partial class PlayersAndColorsDialog : Form
    {
        public int NumPlayers = 3;

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
            cbox_NumPlayers.SelectedIndex = 0;
        }

        private void cbox_NumPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            NumPlayers = int.Parse(cbox_NumPlayers.SelectedItem.ToString());
            switch (NumPlayers)
            {
                case 3:
                    grp_Player4.Enabled = false;
                    break;
                case 4:
                    grp_Player4.Enabled = true;
                    break;
            }
        }

        private void UpdateUILangauge()
        {
            this.Text = Resources.gameSetup;
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
            btn_Ok.Text = Resources.OK;
            btn_Cancel.Text = Resources.Cancel;

        }

        public void SetLanguage(Language lang)
        {
            UpdateUILangauge();
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
                Player1Color = (Colors) Enum.Parse(typeof (Colors), cbox_Color1.SelectedItem.ToString());
                Player2Name = txt_Name2.Text;
                Player2Color = (Colors) Enum.Parse(typeof (Colors), cbox_Color2.SelectedItem.ToString());
                Player3Name = txt_Name3.Text;
                Player3Color = (Colors) Enum.Parse(typeof (Colors), cbox_Color3.SelectedItem.ToString());
                if (NumPlayers > 3)
                {
                    Player4Name = txt_Name4.Text;
                    Player4Color = (Colors) Enum.Parse(typeof (Colors), cbox_Color4.SelectedItem.ToString());
                }
                btn_Ok.DialogResult = DialogResult.OK;
                return;
            }
        }
    }
}