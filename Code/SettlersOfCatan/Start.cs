using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using SettlersOfCatan.Properties;

namespace SettlersOfCatan
{
    public partial class frm_Start : Form
    {
        public frm_Start()
        {
            InitializeComponent();

            SelectedLanguage = Language.English;

            lbl_Title.Location = new Point(Width/2 - lbl_Title.Width/2, Height/10);

            btn_NewGame.Location = new Point(Width/2 - btn_NewGame.Width/2, (Height/10)*3);
            btn_LoadGame.Location = new Point(Width/2 - btn_NewGame.Width/2, (Height/10)*4);
            btn_Options.Location = new Point(Width/2 - btn_NewGame.Width/2, (Height/10)*5);
            btn_Exit.Location = new Point(Width/2 - btn_NewGame.Width/2, (Height/10)*6);
            ofd_LoadGame.InitialDirectory = Directory.GetCurrentDirectory();
            ofd_LoadGame.Filter = "Saved Games (.dat)|*.dat|All Files (*.*)|*.*";
            ofd_LoadGame.FilterIndex = 1;

            UpdateUILangauge();
        }

        public Language SelectedLanguage { get; set; }

        private void btn_Options_Click(object sender, EventArgs e)
        {
            var options = new OptionsDialog();
            options.SetLanguage(SelectedLanguage);
            options.ShowDialog();
            if (options.DialogResult == DialogResult.OK)
            {
                SelectedLanguage = options.SelectedLanguage;
                Thread.CurrentThread.CurrentUICulture =
                    CultureInfo.GetCultureInfo(SelectedLanguage == Language.English ? "en-US" : "de-DE");
                UpdateUILangauge();
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_NewGame_Click(object sender, EventArgs e)
        {
            var players = new PlayersAndColorsDialog();
            this.Hide();
            players.ShowDialog();
            if (players.DialogResult == DialogResult.Cancel)
            {
                this.Show();
            }
        }

        private void btn_LoadGame_Click(object sender, EventArgs e)
        {
            ofd_LoadGame.ShowDialog();
        }

        private void UpdateUILangauge()
        {
            Text = Resources.startTitle;
            lbl_Title.Text = Resources.startTitle;
            btn_NewGame.Text = Resources.newGame;
            btn_LoadGame.Text = Resources.loadGame;
            btn_Options.Text = Resources.options;
            btn_Exit.Text = Resources.exit;

            lbl_Title.Location = new Point(Width/2 - lbl_Title.Width/2, Height/10);
            btn_NewGame.Location = new Point(Width/2 - btn_NewGame.Width/2, (Height/10)*3);
            btn_LoadGame.Location = new Point(Width/2 - btn_NewGame.Width/2, (Height/10)*4);
            btn_Options.Location = new Point(Width/2 - btn_NewGame.Width/2, (Height/10)*5);
            btn_Exit.Location = new Point(Width/2 - btn_NewGame.Width/2, (Height/10)*6);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var gameBoard = new frm_gameBoard();
            this.Hide();
            gameBoard.Show();
        }
    }
}