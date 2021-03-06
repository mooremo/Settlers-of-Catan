﻿namespace SettlersOfCatan
{
    partial class frm_Start
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Start));
            this.lbl_Title = new System.Windows.Forms.Label();
            this.btn_NewGame = new System.Windows.Forms.Button();
            this.btn_Options = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_Rules = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Title.Font = new System.Drawing.Font("Georgia", 55F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_Title.Location = new System.Drawing.Point(237, 59);
            this.lbl_Title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(838, 105);
            this.lbl_Title.TabIndex = 0;
            this.lbl_Title.Text = "Settlers of C#tan";
            // 
            // btn_NewGame
            // 
            this.btn_NewGame.Font = new System.Drawing.Font("Georgia", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NewGame.Location = new System.Drawing.Point(501, 235);
            this.btn_NewGame.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_NewGame.Name = "btn_NewGame";
            this.btn_NewGame.Size = new System.Drawing.Size(204, 54);
            this.btn_NewGame.TabIndex = 1;
            this.btn_NewGame.Text = "New Game";
            this.btn_NewGame.UseVisualStyleBackColor = true;
            this.btn_NewGame.Click += new System.EventHandler(this.btn_NewGame_Click);
            // 
            // btn_Options
            // 
            this.btn_Options.Font = new System.Drawing.Font("Georgia", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Options.Location = new System.Drawing.Point(501, 398);
            this.btn_Options.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Options.Name = "btn_Options";
            this.btn_Options.Size = new System.Drawing.Size(204, 54);
            this.btn_Options.TabIndex = 3;
            this.btn_Options.Text = "Options";
            this.btn_Options.UseVisualStyleBackColor = true;
            this.btn_Options.Click += new System.EventHandler(this.btn_Options_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Font = new System.Drawing.Font("Georgia", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Exit.Location = new System.Drawing.Point(501, 476);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(204, 54);
            this.btn_Exit.TabIndex = 4;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(1100, 350);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Rules
            // 
            this.btn_Rules.Font = new System.Drawing.Font("Georgia", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Rules.Location = new System.Drawing.Point(501, 319);
            this.btn_Rules.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Rules.Name = "btn_Rules";
            this.btn_Rules.Size = new System.Drawing.Size(204, 54);
            this.btn_Rules.TabIndex = 6;
            this.btn_Rules.Text = "Rules";
            this.btn_Rules.UseVisualStyleBackColor = true;
            this.btn_Rules.Click += new System.EventHandler(this.btn_Rules_Click);
            // 
            // frm_Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1357, 911);
            this.Controls.Add(this.btn_Rules);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Options);
            this.Controls.Add(this.btn_NewGame);
            this.Controls.Add(this.lbl_Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frm_Start";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settlers of C#tan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Button btn_NewGame;
        private System.Windows.Forms.Button btn_Options;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_Rules;
    }
}

