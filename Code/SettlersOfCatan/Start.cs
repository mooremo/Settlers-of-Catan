using System;
using System.Collections.Generic;
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
            else if (players.DialogResult == DialogResult.OK)
            {
                var gameBoard = new frm_gameBoard(players.Controller);
                this.Hide();
                gameBoard.Show();
            }
        }

        private void UpdateUILangauge()
        {
            Text = Resources.startTitle;
            lbl_Title.Text = Resources.startTitle;
            btn_NewGame.Text = Resources.newGame;
            btn_Options.Text = Resources.options;
            btn_Exit.Text = Resources.exit;
            btn_Rules.Text = Resources.rules;

            lbl_Title.Location = new Point(Width/2 - lbl_Title.Width/2, Height/10);
            btn_NewGame.Location = new Point(Width/2 - btn_NewGame.Width/2, (Height/10)*3);
            btn_Rules.Location = new Point(Width / 2 - btn_NewGame.Width / 2, (Height / 10) * 4);
            btn_Options.Location = new Point(Width/2 - btn_NewGame.Width/2, (Height/10)*5);
            btn_Exit.Location = new Point(Width/2 - btn_NewGame.Width/2, (Height/10)*6);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var players = new List<Player> {new Player("Barry") {PlayerColor = Colors.Orange},
                                            new Player("Alice") {PlayerColor = Colors.Blue},
                                            new Player("Pat") {PlayerColor = Colors.White}};
            var controller = new GameController(players);
            var gameBoard = new frm_gameBoard(controller);
            this.Hide();
            gameBoard.Show();
        }

        private void btn_Rules_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
# if DEBUG
            path = path.Remove(path.LastIndexOf('\\'));
            path = path.Remove(path.LastIndexOf('\\'));
            path = path.Remove(path.LastIndexOf('\\'));
            path = Path.Combine(path, Resources.rulesPDF);
            System.Diagnostics.Process.Start(path);
#else
            path = Path.Combine(path, Resources.rulesPDF);
            System.Diagnostics.Process.Start(path);
#endif
        }
    }
}