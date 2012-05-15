namespace SettlersOfCatan
{
    partial class PlayersAndColorsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayersAndColorsDialog));
            this.lbl_NumPlayers = new System.Windows.Forms.Label();
            this.cbox_NumPlayers = new System.Windows.Forms.ComboBox();
            this.grp_Player1 = new System.Windows.Forms.GroupBox();
            this.lbl_Color1 = new System.Windows.Forms.Label();
            this.lbl_Name1 = new System.Windows.Forms.Label();
            this.cbox_Color1 = new System.Windows.Forms.ComboBox();
            this.txt_Name1 = new System.Windows.Forms.TextBox();
            this.grp_Player2 = new System.Windows.Forms.GroupBox();
            this.lbl_Color2 = new System.Windows.Forms.Label();
            this.lbl_Name2 = new System.Windows.Forms.Label();
            this.cbox_Color2 = new System.Windows.Forms.ComboBox();
            this.txt_Name2 = new System.Windows.Forms.TextBox();
            this.grp_Player3 = new System.Windows.Forms.GroupBox();
            this.lbl_Color3 = new System.Windows.Forms.Label();
            this.lbl_Name3 = new System.Windows.Forms.Label();
            this.cbox_Color3 = new System.Windows.Forms.ComboBox();
            this.txt_Name3 = new System.Windows.Forms.TextBox();
            this.grp_Player4 = new System.Windows.Forms.GroupBox();
            this.lbl_Color4 = new System.Windows.Forms.Label();
            this.lbl_Name4 = new System.Windows.Forms.Label();
            this.cbox_Color4 = new System.Windows.Forms.ComboBox();
            this.txt_Name4 = new System.Windows.Forms.TextBox();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.grp_Player1.SuspendLayout();
            this.grp_Player2.SuspendLayout();
            this.grp_Player3.SuspendLayout();
            this.grp_Player4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_NumPlayers
            // 
            this.lbl_NumPlayers.AutoSize = true;
            this.lbl_NumPlayers.Location = new System.Drawing.Point(106, 22);
            this.lbl_NumPlayers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_NumPlayers.Name = "lbl_NumPlayers";
            this.lbl_NumPlayers.Size = new System.Drawing.Size(96, 13);
            this.lbl_NumPlayers.TabIndex = 0;
            this.lbl_NumPlayers.Text = "Number of Players:";
            // 
            // cbox_NumPlayers
            // 
            this.cbox_NumPlayers.FormattingEnabled = true;
            this.cbox_NumPlayers.Items.AddRange(new object[] {
            "3",
            "4"});
            this.cbox_NumPlayers.Location = new System.Drawing.Point(207, 20);
            this.cbox_NumPlayers.Margin = new System.Windows.Forms.Padding(2);
            this.cbox_NumPlayers.Name = "cbox_NumPlayers";
            this.cbox_NumPlayers.Size = new System.Drawing.Size(37, 21);
            this.cbox_NumPlayers.TabIndex = 1;
            this.cbox_NumPlayers.SelectedIndexChanged += new System.EventHandler(this.cbox_NumPlayers_SelectedIndexChanged);
            // 
            // grp_Player1
            // 
            this.grp_Player1.Controls.Add(this.lbl_Color1);
            this.grp_Player1.Controls.Add(this.lbl_Name1);
            this.grp_Player1.Controls.Add(this.cbox_Color1);
            this.grp_Player1.Controls.Add(this.txt_Name1);
            this.grp_Player1.Location = new System.Drawing.Point(31, 56);
            this.grp_Player1.Margin = new System.Windows.Forms.Padding(2);
            this.grp_Player1.Name = "grp_Player1";
            this.grp_Player1.Padding = new System.Windows.Forms.Padding(2);
            this.grp_Player1.Size = new System.Drawing.Size(340, 60);
            this.grp_Player1.TabIndex = 2;
            this.grp_Player1.TabStop = false;
            this.grp_Player1.Text = "Player 1";
            // 
            // lbl_Color1
            // 
            this.lbl_Color1.AutoSize = true;
            this.lbl_Color1.Location = new System.Drawing.Point(191, 30);
            this.lbl_Color1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Color1.Name = "lbl_Color1";
            this.lbl_Color1.Size = new System.Drawing.Size(34, 13);
            this.lbl_Color1.TabIndex = 3;
            this.lbl_Color1.Text = "PlayerColor:";
            // 
            // lbl_Name1
            // 
            this.lbl_Name1.AutoSize = true;
            this.lbl_Name1.Location = new System.Drawing.Point(14, 30);
            this.lbl_Name1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Name1.Name = "lbl_Name1";
            this.lbl_Name1.Size = new System.Drawing.Size(38, 13);
            this.lbl_Name1.TabIndex = 2;
            this.lbl_Name1.Text = "Name:";
            // 
            // cbox_Color1
            // 
            this.cbox_Color1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Color1.FormattingEnabled = true;
            this.cbox_Color1.Items.AddRange(new object[] {
            "Red",
            "Blue",
            "White",
            "Orange"});
            this.cbox_Color1.Location = new System.Drawing.Point(230, 28);
            this.cbox_Color1.Margin = new System.Windows.Forms.Padding(2);
            this.cbox_Color1.Name = "cbox_Color1";
            this.cbox_Color1.Size = new System.Drawing.Size(84, 21);
            this.cbox_Color1.TabIndex = 1;
            this.cbox_Color1.SelectedIndexChanged += new System.EventHandler(this.cbox_Color1_SelectedIndexChanged);
            // 
            // txt_Name1
            // 
            this.txt_Name1.Location = new System.Drawing.Point(56, 28);
            this.txt_Name1.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Name1.Name = "txt_Name1";
            this.txt_Name1.Size = new System.Drawing.Size(125, 20);
            this.txt_Name1.TabIndex = 0;
            // 
            // grp_Player2
            // 
            this.grp_Player2.Controls.Add(this.lbl_Color2);
            this.grp_Player2.Controls.Add(this.lbl_Name2);
            this.grp_Player2.Controls.Add(this.cbox_Color2);
            this.grp_Player2.Controls.Add(this.txt_Name2);
            this.grp_Player2.Location = new System.Drawing.Point(31, 121);
            this.grp_Player2.Margin = new System.Windows.Forms.Padding(2);
            this.grp_Player2.Name = "grp_Player2";
            this.grp_Player2.Padding = new System.Windows.Forms.Padding(2);
            this.grp_Player2.Size = new System.Drawing.Size(340, 60);
            this.grp_Player2.TabIndex = 3;
            this.grp_Player2.TabStop = false;
            this.grp_Player2.Text = "Player 2";
            // 
            // lbl_Color2
            // 
            this.lbl_Color2.AutoSize = true;
            this.lbl_Color2.Location = new System.Drawing.Point(191, 30);
            this.lbl_Color2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Color2.Name = "lbl_Color2";
            this.lbl_Color2.Size = new System.Drawing.Size(34, 13);
            this.lbl_Color2.TabIndex = 3;
            this.lbl_Color2.Text = "PlayerColor:";
            // 
            // lbl_Name2
            // 
            this.lbl_Name2.AutoSize = true;
            this.lbl_Name2.Location = new System.Drawing.Point(14, 30);
            this.lbl_Name2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Name2.Name = "lbl_Name2";
            this.lbl_Name2.Size = new System.Drawing.Size(38, 13);
            this.lbl_Name2.TabIndex = 2;
            this.lbl_Name2.Text = "Name:";
            // 
            // cbox_Color2
            // 
            this.cbox_Color2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Color2.FormattingEnabled = true;
            this.cbox_Color2.Items.AddRange(new object[] {
            "Red",
            "Blue",
            "White",
            "Orange"});
            this.cbox_Color2.Location = new System.Drawing.Point(230, 28);
            this.cbox_Color2.Margin = new System.Windows.Forms.Padding(2);
            this.cbox_Color2.Name = "cbox_Color2";
            this.cbox_Color2.Size = new System.Drawing.Size(84, 21);
            this.cbox_Color2.TabIndex = 1;
            this.cbox_Color2.SelectedIndexChanged += new System.EventHandler(this.cbox_Color2_SelectedIndexChanged);
            // 
            // txt_Name2
            // 
            this.txt_Name2.Location = new System.Drawing.Point(56, 28);
            this.txt_Name2.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Name2.Name = "txt_Name2";
            this.txt_Name2.Size = new System.Drawing.Size(125, 20);
            this.txt_Name2.TabIndex = 0;
            // 
            // grp_Player3
            // 
            this.grp_Player3.Controls.Add(this.lbl_Color3);
            this.grp_Player3.Controls.Add(this.lbl_Name3);
            this.grp_Player3.Controls.Add(this.cbox_Color3);
            this.grp_Player3.Controls.Add(this.txt_Name3);
            this.grp_Player3.Location = new System.Drawing.Point(31, 186);
            this.grp_Player3.Margin = new System.Windows.Forms.Padding(2);
            this.grp_Player3.Name = "grp_Player3";
            this.grp_Player3.Padding = new System.Windows.Forms.Padding(2);
            this.grp_Player3.Size = new System.Drawing.Size(340, 60);
            this.grp_Player3.TabIndex = 4;
            this.grp_Player3.TabStop = false;
            this.grp_Player3.Text = "Player 3";
            // 
            // lbl_Color3
            // 
            this.lbl_Color3.AutoSize = true;
            this.lbl_Color3.Location = new System.Drawing.Point(191, 30);
            this.lbl_Color3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Color3.Name = "lbl_Color3";
            this.lbl_Color3.Size = new System.Drawing.Size(34, 13);
            this.lbl_Color3.TabIndex = 3;
            this.lbl_Color3.Text = "PlayerColor:";
            // 
            // lbl_Name3
            // 
            this.lbl_Name3.AutoSize = true;
            this.lbl_Name3.Location = new System.Drawing.Point(14, 30);
            this.lbl_Name3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Name3.Name = "lbl_Name3";
            this.lbl_Name3.Size = new System.Drawing.Size(38, 13);
            this.lbl_Name3.TabIndex = 2;
            this.lbl_Name3.Text = "Name:";
            // 
            // cbox_Color3
            // 
            this.cbox_Color3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Color3.FormattingEnabled = true;
            this.cbox_Color3.Items.AddRange(new object[] {
            "Red",
            "Blue",
            "White",
            "Orange"});
            this.cbox_Color3.Location = new System.Drawing.Point(230, 28);
            this.cbox_Color3.Margin = new System.Windows.Forms.Padding(2);
            this.cbox_Color3.Name = "cbox_Color3";
            this.cbox_Color3.Size = new System.Drawing.Size(84, 21);
            this.cbox_Color3.TabIndex = 1;
            this.cbox_Color3.SelectedIndexChanged += new System.EventHandler(this.cbox_Color3_SelectedIndexChanged);
            // 
            // txt_Name3
            // 
            this.txt_Name3.Location = new System.Drawing.Point(56, 28);
            this.txt_Name3.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Name3.Name = "txt_Name3";
            this.txt_Name3.Size = new System.Drawing.Size(125, 20);
            this.txt_Name3.TabIndex = 0;
            // 
            // grp_Player4
            // 
            this.grp_Player4.Controls.Add(this.lbl_Color4);
            this.grp_Player4.Controls.Add(this.lbl_Name4);
            this.grp_Player4.Controls.Add(this.cbox_Color4);
            this.grp_Player4.Controls.Add(this.txt_Name4);
            this.grp_Player4.Enabled = false;
            this.grp_Player4.Location = new System.Drawing.Point(31, 251);
            this.grp_Player4.Margin = new System.Windows.Forms.Padding(2);
            this.grp_Player4.Name = "grp_Player4";
            this.grp_Player4.Padding = new System.Windows.Forms.Padding(2);
            this.grp_Player4.Size = new System.Drawing.Size(340, 60);
            this.grp_Player4.TabIndex = 4;
            this.grp_Player4.TabStop = false;
            this.grp_Player4.Text = "Player 4";
            // 
            // lbl_Color4
            // 
            this.lbl_Color4.AutoSize = true;
            this.lbl_Color4.Location = new System.Drawing.Point(191, 30);
            this.lbl_Color4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Color4.Name = "lbl_Color4";
            this.lbl_Color4.Size = new System.Drawing.Size(34, 13);
            this.lbl_Color4.TabIndex = 3;
            this.lbl_Color4.Text = "PlayerColor:";
            // 
            // lbl_Name4
            // 
            this.lbl_Name4.AutoSize = true;
            this.lbl_Name4.Location = new System.Drawing.Point(14, 30);
            this.lbl_Name4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Name4.Name = "lbl_Name4";
            this.lbl_Name4.Size = new System.Drawing.Size(38, 13);
            this.lbl_Name4.TabIndex = 2;
            this.lbl_Name4.Text = "Name:";
            // 
            // cbox_Color4
            // 
            this.cbox_Color4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Color4.FormattingEnabled = true;
            this.cbox_Color4.Items.AddRange(new object[] {
            "Red",
            "Blue",
            "White",
            "Orange"});
            this.cbox_Color4.Location = new System.Drawing.Point(230, 28);
            this.cbox_Color4.Margin = new System.Windows.Forms.Padding(2);
            this.cbox_Color4.Name = "cbox_Color4";
            this.cbox_Color4.Size = new System.Drawing.Size(84, 21);
            this.cbox_Color4.TabIndex = 1;
            this.cbox_Color4.SelectedIndexChanged += new System.EventHandler(this.cbox_Color4_SelectedIndexChanged);
            // 
            // txt_Name4
            // 
            this.txt_Name4.Location = new System.Drawing.Point(56, 28);
            this.txt_Name4.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Name4.Name = "txt_Name4";
            this.txt_Name4.Size = new System.Drawing.Size(125, 20);
            this.txt_Name4.TabIndex = 0;
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(243, 329);
            this.btn_Ok.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(56, 19);
            this.btn_Ok.TabIndex = 5;
            this.btn_Ok.Text = "OK";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(315, 329);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(56, 19);
            this.btn_Cancel.TabIndex = 6;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // PlayersAndColorsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 366);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.grp_Player4);
            this.Controls.Add(this.grp_Player3);
            this.Controls.Add(this.grp_Player2);
            this.Controls.Add(this.grp_Player1);
            this.Controls.Add(this.cbox_NumPlayers);
            this.Controls.Add(this.lbl_NumPlayers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PlayersAndColorsDialog";
            this.Text = "Game Setup";
            this.grp_Player1.ResumeLayout(false);
            this.grp_Player1.PerformLayout();
            this.grp_Player2.ResumeLayout(false);
            this.grp_Player2.PerformLayout();
            this.grp_Player3.ResumeLayout(false);
            this.grp_Player3.PerformLayout();
            this.grp_Player4.ResumeLayout(false);
            this.grp_Player4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_NumPlayers;
        private System.Windows.Forms.ComboBox cbox_NumPlayers;
        private System.Windows.Forms.GroupBox grp_Player1;
        private System.Windows.Forms.Label lbl_Name1;
        private System.Windows.Forms.TextBox txt_Name1;
        private System.Windows.Forms.GroupBox grp_Player2;
        private System.Windows.Forms.Label lbl_Name2;
        private System.Windows.Forms.TextBox txt_Name2;
        private System.Windows.Forms.GroupBox grp_Player3;
        private System.Windows.Forms.Label lbl_Name3;
        private System.Windows.Forms.TextBox txt_Name3;
        private System.Windows.Forms.GroupBox grp_Player4;
        private System.Windows.Forms.Label lbl_Name4;
        private System.Windows.Forms.TextBox txt_Name4;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lbl_Color1;
        private System.Windows.Forms.ComboBox cbox_Color1;
        private System.Windows.Forms.Label lbl_Color2;
        private System.Windows.Forms.ComboBox cbox_Color2;
        private System.Windows.Forms.Label lbl_Color3;
        private System.Windows.Forms.ComboBox cbox_Color3;
        private System.Windows.Forms.Label lbl_Color4;
        private System.Windows.Forms.ComboBox cbox_Color4;
    }
}