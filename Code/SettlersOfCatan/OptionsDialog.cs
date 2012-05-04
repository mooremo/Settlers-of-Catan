using System;
using System.Windows.Forms;
using SettlersOfCatan.Properties;

namespace SettlersOfCatan
{
    public partial class OptionsDialog : Form
    {
        public Language SelectedLanguage = Language.English;

        public OptionsDialog()
        {
            InitializeComponent();
            UpdateUILangauge();
        }

        private void rbtn_English_CheckedChanged(object sender, EventArgs e)
        {
            SelectedLanguage = Language.English;
        }

        private void rbtn_Deutsch_CheckedChanged(object sender, EventArgs e)
        {
            SelectedLanguage = Language.Deutsch;
        }

        public void SetLanguage(Language lang)
        {
            if (lang == Language.English)
            {
                rbtn_English.Checked = true;
            }
            else
            {
                rbtn_Deutsch.Checked = true;
            }
            UpdateUILangauge();
        }

        private void UpdateUILangauge()
        {
            Text = Resources.options;
            grp_Language.Text = Resources.selectLanguage;
            btn_Ok.Text = Resources.OK;
            btn_Cancel.Text = Resources.Cancel;
        }
    }
}