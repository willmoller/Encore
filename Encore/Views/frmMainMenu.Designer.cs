namespace Encore
{
    partial class frmMainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainMenu));
            this.btnPlayGame = new System.Windows.Forms.Button();
            this.btnRules = new System.Windows.Forms.Button();
            this.btnHighScores = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cboBoardSelection = new System.Windows.Forms.ComboBox();
            this.lblHello = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlayGame
            // 
            this.btnPlayGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayGame.Location = new System.Drawing.Point(509, 297);
            this.btnPlayGame.Name = "btnPlayGame";
            this.btnPlayGame.Size = new System.Drawing.Size(120, 53);
            this.btnPlayGame.TabIndex = 1;
            this.btnPlayGame.Text = "Play";
            this.btnPlayGame.UseVisualStyleBackColor = true;
            this.btnPlayGame.Click += new System.EventHandler(this.btnPlayGame_Click);
            // 
            // btnRules
            // 
            this.btnRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRules.Location = new System.Drawing.Point(646, 385);
            this.btnRules.Name = "btnRules";
            this.btnRules.Size = new System.Drawing.Size(142, 53);
            this.btnRules.TabIndex = 2;
            this.btnRules.Text = "Rules";
            this.btnRules.UseVisualStyleBackColor = true;
            this.btnRules.Click += new System.EventHandler(this.btnRules_Click);
            // 
            // btnHighScores
            // 
            this.btnHighScores.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHighScores.Location = new System.Drawing.Point(12, 385);
            this.btnHighScores.Name = "btnHighScores";
            this.btnHighScores.Size = new System.Drawing.Size(245, 53);
            this.btnHighScores.TabIndex = 3;
            this.btnHighScores.Text = "My High Scores";
            this.btnHighScores.UseVisualStyleBackColor = true;
            this.btnHighScores.Click += new System.EventHandler(this.btnHighScores_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(85, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(628, 206);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // cboBoardSelection
            // 
            this.cboBoardSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBoardSelection.FormattingEnabled = true;
            this.cboBoardSelection.Location = new System.Drawing.Point(187, 302);
            this.cboBoardSelection.Name = "cboBoardSelection";
            this.cboBoardSelection.Size = new System.Drawing.Size(286, 44);
            this.cboBoardSelection.TabIndex = 5;
            // 
            // lblHello
            // 
            this.lblHello.AutoSize = true;
            this.lblHello.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHello.ForeColor = System.Drawing.Color.White;
            this.lblHello.Location = new System.Drawing.Point(239, 247);
            this.lblHello.Name = "lblHello";
            this.lblHello.Size = new System.Drawing.Size(64, 25);
            this.lblHello.TabIndex = 6;
            this.lblHello.Text = "label1";
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblHello);
            this.Controls.Add(this.cboBoardSelection);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnHighScores);
            this.Controls.Add(this.btnRules);
            this.Controls.Add(this.btnPlayGame);
            this.Name = "frmMainMenu";
            this.ShowIcon = false;
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.frmMainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPlayGame;
        private System.Windows.Forms.Button btnRules;
        private System.Windows.Forms.Button btnHighScores;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cboBoardSelection;
        private System.Windows.Forms.Label lblHello;
    }
}

