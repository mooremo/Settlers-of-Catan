using System.Drawing;
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
        }

        private void btn_Options_Click(object sender, System.EventArgs e)
        {
            OptionsDialog options = new OptionsDialog(this);
            options.Show();
        }

        private void btn_Exit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}