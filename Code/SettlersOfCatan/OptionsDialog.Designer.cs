﻿namespace SettlersOfCatan
{
    partial class OptionsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rbtn_English = new System.Windows.Forms.RadioButton();
            this.rbtn_Deutsch = new System.Windows.Forms.RadioButton();
            this.grp_Language = new System.Windows.Forms.GroupBox();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.grp_Language.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtn_English
            // 
            this.rbtn_English.AutoSize = true;
            this.rbtn_English.Checked = true;
            this.rbtn_English.Location = new System.Drawing.Point(8, 36);
            this.rbtn_English.Margin = new System.Windows.Forms.Padding(4);
            this.rbtn_English.Name = "rbtn_English";
            this.rbtn_English.Size = new System.Drawing.Size(75, 21);
            this.rbtn_English.TabIndex = 1;
            this.rbtn_English.TabStop = true;
            this.rbtn_English.Text = "English";
            this.rbtn_English.UseVisualStyleBackColor = true;
            this.rbtn_English.CheckedChanged += new System.EventHandler(this.rbtn_English_CheckedChanged);
            // 
            // rbtn_Deutsch
            // 
            this.rbtn_Deutsch.AutoSize = true;
            this.rbtn_Deutsch.Location = new System.Drawing.Point(115, 36);
            this.rbtn_Deutsch.Margin = new System.Windows.Forms.Padding(4);
            this.rbtn_Deutsch.Name = "rbtn_Deutsch";
            this.rbtn_Deutsch.Size = new System.Drawing.Size(81, 21);
            this.rbtn_Deutsch.TabIndex = 2;
            this.rbtn_Deutsch.TabStop = true;
            this.rbtn_Deutsch.Text = "Deutsch";
            this.rbtn_Deutsch.UseVisualStyleBackColor = true;
            this.rbtn_Deutsch.CheckedChanged += new System.EventHandler(this.rbtn_Deutsch_CheckedChanged);
            // 
            // grp_Language
            // 
            this.grp_Language.Controls.Add(this.rbtn_English);
            this.grp_Language.Controls.Add(this.rbtn_Deutsch);
            this.grp_Language.Location = new System.Drawing.Point(16, 15);
            this.grp_Language.Margin = new System.Windows.Forms.Padding(4);
            this.grp_Language.Name = "grp_Language";
            this.grp_Language.Padding = new System.Windows.Forms.Padding(4);
            this.grp_Language.Size = new System.Drawing.Size(219, 73);
            this.grp_Language.TabIndex = 3;
            this.grp_Language.TabStop = false;
            this.grp_Language.Text = "Choose a language:";
            // 
            // btn_Ok
            // 
            this.btn_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Ok.Location = new System.Drawing.Point(16, 95);
            this.btn_Ok.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(100, 28);
            this.btn_Ok.TabIndex = 4;
            this.btn_Ok.Text = "OK";
            this.btn_Ok.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(132, 95);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(100, 28);
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // OptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 134);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.grp_Language);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OptionsDialog";
            this.Text = "Options";
            this.grp_Language.ResumeLayout(false);
            this.grp_Language.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtn_English;
        private System.Windows.Forms.RadioButton rbtn_Deutsch;
        private System.Windows.Forms.GroupBox grp_Language;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Cancel;

    }
}