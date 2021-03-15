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
            ((System.ComponentModel.ISupportInitialize)(this.pboNumberDie1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboNumberDie2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboColorDie1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboColorDie2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboEncoreLogo)).BeginInit();
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
            this.pboNumberDie1.Size = new System.Drawing.Size(100, 90);
            this.pboNumberDie1.TabIndex = 1;
            this.pboNumberDie1.TabStop = false;
            // 
            // pboNumberDie2
            // 
            this.pboNumberDie2.Location = new System.Drawing.Point(134, 148);
            this.pboNumberDie2.Name = "pboNumberDie2";
            this.pboNumberDie2.Size = new System.Drawing.Size(100, 90);
            this.pboNumberDie2.TabIndex = 2;
            this.pboNumberDie2.TabStop = false;
            // 
            // pboColorDie1
            // 
            this.pboColorDie1.BackColor = System.Drawing.Color.White;
            this.pboColorDie1.Location = new System.Drawing.Point(12, 257);
            this.pboColorDie1.Name = "pboColorDie1";
            this.pboColorDie1.Size = new System.Drawing.Size(100, 90);
            this.pboColorDie1.TabIndex = 3;
            this.pboColorDie1.TabStop = false;
            // 
            // pboColorDie2
            // 
            this.pboColorDie2.BackColor = System.Drawing.Color.White;
            this.pboColorDie2.Location = new System.Drawing.Point(134, 257);
            this.pboColorDie2.Name = "pboColorDie2";
            this.pboColorDie2.Size = new System.Drawing.Size(100, 90);
            this.pboColorDie2.TabIndex = 4;
            this.pboColorDie2.TabStop = false;
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
            // frmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1482, 703);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRoll;
        private System.Windows.Forms.PictureBox pboNumberDie1;
        private System.Windows.Forms.PictureBox pboNumberDie2;
        private System.Windows.Forms.PictureBox pboColorDie1;
        private System.Windows.Forms.PictureBox pboColorDie2;
        private System.Windows.Forms.PictureBox pboEncoreLogo;
    }
}