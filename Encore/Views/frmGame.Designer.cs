namespace Encore
{
    partial class frmGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGame));
            this.btnRoll = new System.Windows.Forms.Button();
            this.pboNumberDie1 = new System.Windows.Forms.PictureBox();
            this.pboNumberDie2 = new System.Windows.Forms.PictureBox();
            this.pboColorDie1 = new System.Windows.Forms.PictureBox();
            this.pboColorDie2 = new System.Windows.Forms.PictureBox();
            this.pboEncoreLogo = new System.Windows.Forms.PictureBox();
            this.pboBonusGreen = new System.Windows.Forms.PictureBox();
            this.pboBonusYellow = new System.Windows.Forms.PictureBox();
            this.pboBonusBlue = new System.Windows.Forms.PictureBox();
            this.pboBonusPink = new System.Windows.Forms.PictureBox();
            this.pboBonusOrange = new System.Windows.Forms.PictureBox();
            this.txtColorPoints = new System.Windows.Forms.TextBox();
            this.txtColumnPoints = new System.Windows.Forms.TextBox();
            this.txtUnusedWilds = new System.Windows.Forms.TextBox();
            this.txtStarPoints = new System.Windows.Forms.TextBox();
            this.txtTotalScore = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTurnsLeft = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pboNumberDie1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboNumberDie2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboColorDie1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboColorDie2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboEncoreLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboBonusGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboBonusYellow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboBonusBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboBonusPink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboBonusOrange)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRoll
            // 
            this.btnRoll.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoll.Location = new System.Drawing.Point(40, 413);
            this.btnRoll.Name = "btnRoll";
            this.btnRoll.Size = new System.Drawing.Size(157, 48);
            this.btnRoll.TabIndex = 0;
            this.btnRoll.Text = "Roll";
            this.btnRoll.UseVisualStyleBackColor = true;
            this.btnRoll.Click += new System.EventHandler(this.btnRoll_Click);
            // 
            // pboNumberDie1
            // 
            this.pboNumberDie1.Location = new System.Drawing.Point(12, 148);
            this.pboNumberDie1.Name = "pboNumberDie1";
            this.pboNumberDie1.Padding = new System.Windows.Forms.Padding(5);
            this.pboNumberDie1.Size = new System.Drawing.Size(100, 90);
            this.pboNumberDie1.TabIndex = 1;
            this.pboNumberDie1.TabStop = false;
            this.pboNumberDie1.Click += new System.EventHandler(this.pboNumberDie1_Click);
            // 
            // pboNumberDie2
            // 
            this.pboNumberDie2.Location = new System.Drawing.Point(134, 148);
            this.pboNumberDie2.Name = "pboNumberDie2";
            this.pboNumberDie2.Padding = new System.Windows.Forms.Padding(5);
            this.pboNumberDie2.Size = new System.Drawing.Size(100, 90);
            this.pboNumberDie2.TabIndex = 2;
            this.pboNumberDie2.TabStop = false;
            this.pboNumberDie2.Click += new System.EventHandler(this.pboNumberDie2_Click);
            // 
            // pboColorDie1
            // 
            this.pboColorDie1.BackColor = System.Drawing.Color.White;
            this.pboColorDie1.Location = new System.Drawing.Point(12, 257);
            this.pboColorDie1.Name = "pboColorDie1";
            this.pboColorDie1.Padding = new System.Windows.Forms.Padding(5);
            this.pboColorDie1.Size = new System.Drawing.Size(100, 90);
            this.pboColorDie1.TabIndex = 3;
            this.pboColorDie1.TabStop = false;
            this.pboColorDie1.Click += new System.EventHandler(this.pboColorDie1_Click);
            // 
            // pboColorDie2
            // 
            this.pboColorDie2.BackColor = System.Drawing.Color.White;
            this.pboColorDie2.Location = new System.Drawing.Point(134, 257);
            this.pboColorDie2.Name = "pboColorDie2";
            this.pboColorDie2.Padding = new System.Windows.Forms.Padding(5);
            this.pboColorDie2.Size = new System.Drawing.Size(100, 90);
            this.pboColorDie2.TabIndex = 4;
            this.pboColorDie2.TabStop = false;
            this.pboColorDie2.Click += new System.EventHandler(this.pboColorDie2_Click);
            // 
            // pboEncoreLogo
            // 
            this.pboEncoreLogo.Image = ((System.Drawing.Image)(resources.GetObject("pboEncoreLogo.Image")));
            this.pboEncoreLogo.Location = new System.Drawing.Point(12, 13);
            this.pboEncoreLogo.Name = "pboEncoreLogo";
            this.pboEncoreLogo.Size = new System.Drawing.Size(222, 102);
            this.pboEncoreLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboEncoreLogo.TabIndex = 5;
            this.pboEncoreLogo.TabStop = false;
            // 
            // pboBonusGreen
            // 
            this.pboBonusGreen.Location = new System.Drawing.Point(1449, 53);
            this.pboBonusGreen.Name = "pboBonusGreen";
            this.pboBonusGreen.Size = new System.Drawing.Size(50, 50);
            this.pboBonusGreen.TabIndex = 6;
            this.pboBonusGreen.TabStop = false;
            // 
            // pboBonusYellow
            // 
            this.pboBonusYellow.Location = new System.Drawing.Point(1449, 109);
            this.pboBonusYellow.Name = "pboBonusYellow";
            this.pboBonusYellow.Size = new System.Drawing.Size(50, 50);
            this.pboBonusYellow.TabIndex = 7;
            this.pboBonusYellow.TabStop = false;
            // 
            // pboBonusBlue
            // 
            this.pboBonusBlue.Location = new System.Drawing.Point(1449, 165);
            this.pboBonusBlue.Name = "pboBonusBlue";
            this.pboBonusBlue.Size = new System.Drawing.Size(50, 50);
            this.pboBonusBlue.TabIndex = 8;
            this.pboBonusBlue.TabStop = false;
            // 
            // pboBonusPink
            // 
            this.pboBonusPink.Location = new System.Drawing.Point(1449, 221);
            this.pboBonusPink.Name = "pboBonusPink";
            this.pboBonusPink.Size = new System.Drawing.Size(50, 50);
            this.pboBonusPink.TabIndex = 9;
            this.pboBonusPink.TabStop = false;
            // 
            // pboBonusOrange
            // 
            this.pboBonusOrange.Location = new System.Drawing.Point(1449, 277);
            this.pboBonusOrange.Name = "pboBonusOrange";
            this.pboBonusOrange.Size = new System.Drawing.Size(50, 50);
            this.pboBonusOrange.TabIndex = 10;
            this.pboBonusOrange.TabStop = false;
            // 
            // txtColorPoints
            // 
            this.txtColorPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColorPoints.Location = new System.Drawing.Point(1449, 334);
            this.txtColorPoints.Name = "txtColorPoints";
            this.txtColorPoints.Size = new System.Drawing.Size(68, 49);
            this.txtColorPoints.TabIndex = 11;
            // 
            // txtColumnPoints
            // 
            this.txtColumnPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColumnPoints.Location = new System.Drawing.Point(1449, 389);
            this.txtColumnPoints.Name = "txtColumnPoints";
            this.txtColumnPoints.Size = new System.Drawing.Size(68, 49);
            this.txtColumnPoints.TabIndex = 12;
            // 
            // txtUnusedWilds
            // 
            this.txtUnusedWilds.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnusedWilds.Location = new System.Drawing.Point(1449, 444);
            this.txtUnusedWilds.Name = "txtUnusedWilds";
            this.txtUnusedWilds.Size = new System.Drawing.Size(68, 49);
            this.txtUnusedWilds.TabIndex = 13;
            // 
            // txtStarPoints
            // 
            this.txtStarPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStarPoints.Location = new System.Drawing.Point(1449, 499);
            this.txtStarPoints.Name = "txtStarPoints";
            this.txtStarPoints.Size = new System.Drawing.Size(68, 49);
            this.txtStarPoints.TabIndex = 14;
            // 
            // txtTotalScore
            // 
            this.txtTotalScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalScore.Location = new System.Drawing.Point(1449, 577);
            this.txtTotalScore.Name = "txtTotalScore";
            this.txtTotalScore.Size = new System.Drawing.Size(68, 49);
            this.txtTotalScore.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.DimGray;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1301, 580);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 44);
            this.label5.TabIndex = 20;
            this.label5.Text = "TOTAL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1363, 502);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 44);
            this.label1.TabIndex = 21;
            this.label1.Text = "(-2)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DimGray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1354, 447);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 44);
            this.label2.TabIndex = 22;
            this.label2.Text = "(+1)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DimGray;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1335, 392);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 44);
            this.label3.TabIndex = 23;
            this.label3.Text = "A - O";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DimGray;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1289, 337);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 44);
            this.label4.TabIndex = 24;
            this.label4.Text = "BONUS";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(59, 490);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 29);
            this.label6.TabIndex = 25;
            this.label6.Text = "Turns Left";
            // 
            // lblTurnsLeft
            // 
            this.lblTurnsLeft.AutoSize = true;
            this.lblTurnsLeft.BackColor = System.Drawing.Color.White;
            this.lblTurnsLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurnsLeft.Location = new System.Drawing.Point(80, 551);
            this.lblTurnsLeft.Name = "lblTurnsLeft";
            this.lblTurnsLeft.Size = new System.Drawing.Size(78, 55);
            this.lblTurnsLeft.TabIndex = 26;
            this.lblTurnsLeft.Text = "30";
            this.lblTurnsLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1632, 703);
            this.Controls.Add(this.lblTurnsLeft);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTotalScore);
            this.Controls.Add(this.txtStarPoints);
            this.Controls.Add(this.txtUnusedWilds);
            this.Controls.Add(this.txtColumnPoints);
            this.Controls.Add(this.txtColorPoints);
            this.Controls.Add(this.pboBonusOrange);
            this.Controls.Add(this.pboBonusPink);
            this.Controls.Add(this.pboBonusBlue);
            this.Controls.Add(this.pboBonusYellow);
            this.Controls.Add(this.pboBonusGreen);
            this.Controls.Add(this.pboEncoreLogo);
            this.Controls.Add(this.pboColorDie2);
            this.Controls.Add(this.pboColorDie1);
            this.Controls.Add(this.pboNumberDie2);
            this.Controls.Add(this.pboNumberDie1);
            this.Controls.Add(this.btnRoll);
            this.Name = "frmGame";
            this.ShowIcon = false;
            this.Text = "Encore!";
            this.Load += new System.EventHandler(this.frmGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboNumberDie1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboNumberDie2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboColorDie1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboColorDie2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboEncoreLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboBonusGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboBonusYellow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboBonusBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboBonusPink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboBonusOrange)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRoll;
        private System.Windows.Forms.PictureBox pboNumberDie1;
        private System.Windows.Forms.PictureBox pboNumberDie2;
        private System.Windows.Forms.PictureBox pboColorDie1;
        private System.Windows.Forms.PictureBox pboColorDie2;
        private System.Windows.Forms.PictureBox pboEncoreLogo;
        private System.Windows.Forms.PictureBox pboBonusGreen;
        private System.Windows.Forms.PictureBox pboBonusYellow;
        private System.Windows.Forms.PictureBox pboBonusBlue;
        private System.Windows.Forms.PictureBox pboBonusPink;
        private System.Windows.Forms.PictureBox pboBonusOrange;
        private System.Windows.Forms.TextBox txtColorPoints;
        private System.Windows.Forms.TextBox txtColumnPoints;
        private System.Windows.Forms.TextBox txtUnusedWilds;
        private System.Windows.Forms.TextBox txtStarPoints;
        private System.Windows.Forms.TextBox txtTotalScore;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTurnsLeft;
    }
}