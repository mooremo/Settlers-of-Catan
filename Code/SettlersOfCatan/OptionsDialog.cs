using System;
using System.Windows.Forms;

namespace SettlersOfCatan
{
    public partial class OptionsDialog : Form
    {
        public Language SelectedLanguage = Language.English;

        public OptionsDialog()
        {
            InitializeComponent();
        }

        private void rbtn_English_CheckedChanged(object sender, EventArgs e)
        {
            SelectedLanguage = Language.English;
        }

        private void rbtn_Deutsch_CheckedChanged(object sender, EventArgs e)
        {
            SelectedLanguage = Language.Deutsch;
        }
    }
}