namespace SettlersOfCatan
{
    partial class Monopoly
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
            this.btn_Brick = new System.Windows.Forms.Button();
            this.btn_lumber = new System.Windows.Forms.Button();
            this.btn_ore = new System.Windows.Forms.Button();
            this.btn_grain = new System.Windows.Forms.Button();
            this.btn_wool = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Brick
            // 
            this.btn_Brick.Location = new System.Drawing.Point(58, 12);
            this.btn_Brick.Name = "btn_Brick";
            this.btn_Brick.Size = new System.Drawing.Size(148, 43);
            this.btn_Brick.TabIndex = 0;
            this.btn_Brick.Text = "Brick";
            this.btn_Brick.UseVisualStyleBackColor = true;
            this.btn_Brick.Click += new System.EventHandler(this.btn_Brick_Click);
            // 
            // btn_lumber
            // 
            this.btn_lumber.Location = new System.Drawing.Point(58, 134);
            this.btn_lumber.Name = "btn_lumber";
            this.btn_lumber.Size = new System.Drawing.Size(148, 43);
            this.btn_lumber.TabIndex = 1;
            this.btn_lumber.Text = "Lumber";
            this.btn_lumber.UseVisualStyleBackColor = true;
            this.btn_lumber.Click += new System.EventHandler(this.btn_lumber_Click);
            // 
            // btn_ore
            // 
            this.btn_ore.Location = new System.Drawing.Point(58, 199);
            this.btn_ore.Name = "btn_ore";
            this.btn_ore.Size = new System.Drawing.Size(148, 43);
            this.btn_ore.TabIndex = 2;
            this.btn_ore.Text = "Ore";
            this.btn_ore.UseVisualStyleBackColor = true;
            this.btn_ore.Click += new System.EventHandler(this.btn_ore_Click);
            // 
            // btn_grain
            // 
            this.btn_grain.Location = new System.Drawing.Point(58, 73);
            this.btn_grain.Name = "btn_grain";
            this.btn_grain.Size = new System.Drawing.Size(148, 43);
            this.btn_grain.TabIndex = 3;
            this.btn_grain.Text = "Grain";
            this.btn_grain.UseVisualStyleBackColor = true;
            this.btn_grain.Click += new System.EventHandler(this.btn_grain_Click);
            // 
            // btn_wool
            // 
            this.btn_wool.Location = new System.Drawing.Point(58, 264);
            this.btn_wool.Name = "btn_wool";
            this.btn_wool.Size = new System.Drawing.Size(148, 43);
            this.btn_wool.TabIndex = 4;
            this.btn_wool.Text = "Wool";
            this.btn_wool.UseVisualStyleBackColor = true;
            this.btn_wool.Click += new System.EventHandler(this.btn_wool_Click);
            // 
            // Monopoly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 342);
            this.Controls.Add(this.btn_wool);
            this.Controls.Add(this.btn_grain);
            this.Controls.Add(this.btn_ore);
            this.Controls.Add(this.btn_lumber);
            this.Controls.Add(this.btn_Brick);
            this.Name = "Monopoly";
            this.Text = "Monopoly";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Brick;
        private System.Windows.Forms.Button btn_lumber;
        private System.Windows.Forms.Button btn_ore;
        private System.Windows.Forms.Button btn_grain;
        private System.Windows.Forms.Button btn_wool;
    }
}