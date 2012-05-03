using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SettlersOfCatan
{
    public partial class frm_Start : Form
    {
        public Language SelectedLanguage;

        public frm_Start()
        {
            InitializeComponent();

            lbl_Title.Location = new Point(this.Width/2 - lbl_Title.Width/2, this.Height/10);

            btn_NewGame.Location = new Point(this.Width / 2 - btn_NewGame.Width / 2, (this.Height / 10)*3);
            btn_LoadGame.Location = new Point(this.Width / 2 - btn_NewGame.Width / 2, (this.Height / 10) * 4);
            btn_Options.Location = new Point(this.Width / 2 - btn_NewGame.Width / 2, (this.Height / 10) * 5);
            btn_Exit.Location = new Point(this.Width / 2 - btn_NewGame.Width / 2, (this.Height / 10) * 6);
            ofd_LoadGame.InitialDirectory = Directory.GetCurrentDirectory();
            ofd_LoadGame.Filter = "Saved Games (.dat)|*.dat|All Files (*.*)|*.*";
            ofd_LoadGame.FilterIndex = 1;
        }

        private void btn_Options_Click(object sender, System.EventArgs e)
        {
            OptionsDialog options = new OptionsDialog();
            options.ShowDialog();
            if(options.DialogResult == DialogResult.OK)
            {
                SelectedLanguage = options.SelectedLanguage;
            }
        }

        private void btn_Exit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btn_NewGame_Click(object sender, System.EventArgs e)
        {
            PlayersAndColorsDialog players = new PlayersAndColorsDialog();
            players.ShowDialog();
        }

        private void btn_LoadGame_Click(object sender, System.EventArgs e)
        {
            ofd_LoadGame.ShowDialog();
        }
    }
}