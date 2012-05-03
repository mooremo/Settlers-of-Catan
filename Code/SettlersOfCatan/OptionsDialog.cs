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
    public partial class OptionsDialog : Form
    {
        private frm_Start _mainForm;

        public OptionsDialog()
        {
            InitializeComponent();
        }

        public OptionsDialog(frm_Start start)
        {
            _mainForm = start;
            InitializeComponent();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if(rbtn_Deutsch.Checked)
            {
                _mainForm.SelectedLanguage = Language.Deutsch;
            }
            else
            {
                _mainForm.SelectedLanguage = Language.English;
            }
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
