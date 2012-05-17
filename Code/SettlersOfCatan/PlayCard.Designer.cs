namespace SettlersOfCatan
{
    partial class PlayCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayCard));
            this.btn_Monopoly = new System.Windows.Forms.Button();
            this.btn_YOP = new System.Windows.Forms.Button();
            this.btn_RoadBuilding = new System.Windows.Forms.Button();
            this.btn_playVictoryCard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Monopoly
            // 
            this.btn_Monopoly.Location = new System.Drawing.Point(12, 12);
            this.btn_Monopoly.Name = "btn_Monopoly";
            this.btn_Monopoly.Size = new System.Drawing.Size(106, 32);
            this.btn_Monopoly.TabIndex = 0;
            this.btn_Monopoly.Text = "Monopoly";
            this.btn_Monopoly.UseVisualStyleBackColor = true;
            this.btn_Monopoly.Click += new System.EventHandler(this.btn_Monopoly_Click);
            // 
            // btn_YOP
            // 
            this.btn_YOP.Location = new System.Drawing.Point(124, 11);
            this.btn_YOP.Name = "btn_YOP";
            this.btn_YOP.Size = new System.Drawing.Size(106, 33);
            this.btn_YOP.TabIndex = 1;
            this.btn_YOP.Text = "Years of Plenty";
            this.btn_YOP.UseVisualStyleBackColor = true;
            this.btn_YOP.Click += new System.EventHandler(this.btn_YOP_Click);
            // 
            // btn_RoadBuilding
            // 
            this.btn_RoadBuilding.Location = new System.Drawing.Point(12, 49);
            this.btn_RoadBuilding.Name = "btn_RoadBuilding";
            this.btn_RoadBuilding.Size = new System.Drawing.Size(106, 33);
            this.btn_RoadBuilding.TabIndex = 2;
            this.btn_RoadBuilding.Text = "Road Building";
            this.btn_RoadBuilding.UseVisualStyleBackColor = true;
            this.btn_RoadBuilding.Click += new System.EventHandler(this.btn_RoadBuilding_Click);
            // 
            // btn_playVictoryCard
            // 
            this.btn_playVictoryCard.Location = new System.Drawing.Point(124, 49);
            this.btn_playVictoryCard.Name = "btn_playVictoryCard";
            this.btn_playVictoryCard.Size = new System.Drawing.Size(106, 33);
            this.btn_playVictoryCard.TabIndex = 3;
            this.btn_playVictoryCard.Text = "Victory Point";
            this.btn_playVictoryCard.UseVisualStyleBackColor = true;
            this.btn_playVictoryCard.Click += new System.EventHandler(this.btn_playVictoryCard_Click);
            // 
            // PlayCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 97);
            this.Controls.Add(this.btn_playVictoryCard);
            this.Controls.Add(this.btn_RoadBuilding);
            this.Controls.Add(this.btn_YOP);
            this.Controls.Add(this.btn_Monopoly);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PlayCard";
            this.Text = "Play Card";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Monopoly;
        private System.Windows.Forms.Button btn_YOP;
        private System.Windows.Forms.Button btn_RoadBuilding;
        private System.Windows.Forms.Button btn_playVictoryCard;
    }
}