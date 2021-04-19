
namespace Encore.Views
{
    partial class frmAdminView
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
            this.lblHello = new System.Windows.Forms.Label();
            this.rdoUser = new System.Windows.Forms.RadioButton();
            this.rdoBoard = new System.Windows.Forms.RadioButton();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lboList = new System.Windows.Forms.ListBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtPlays = new System.Windows.Forms.TextBox();
            this.txtAverage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblHello
            // 
            this.lblHello.AutoSize = true;
            this.lblHello.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHello.Location = new System.Drawing.Point(13, 18);
            this.lblHello.Name = "lblHello";
            this.lblHello.Size = new System.Drawing.Size(93, 32);
            this.lblHello.TabIndex = 0;
            this.lblHello.Text = "label1";
            // 
            // rdoUser
            // 
            this.rdoUser.AutoSize = true;
            this.rdoUser.Location = new System.Drawing.Point(18, 104);
            this.rdoUser.Name = "rdoUser";
            this.rdoUser.Size = new System.Drawing.Size(59, 21);
            this.rdoUser.TabIndex = 1;
            this.rdoUser.TabStop = true;
            this.rdoUser.Text = "User";
            this.rdoUser.UseVisualStyleBackColor = true;
            this.rdoUser.CheckedChanged += new System.EventHandler(this.rdoUser_CheckedChanged);
            // 
            // rdoBoard
            // 
            this.rdoBoard.AutoSize = true;
            this.rdoBoard.Location = new System.Drawing.Point(121, 104);
            this.rdoBoard.Name = "rdoBoard";
            this.rdoBoard.Size = new System.Drawing.Size(67, 21);
            this.rdoBoard.TabIndex = 2;
            this.rdoBoard.TabStop = true;
            this.rdoBoard.Text = "Board";
            this.rdoBoard.UseVisualStyleBackColor = true;
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Location = new System.Drawing.Point(237, 104);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(44, 21);
            this.rdoAll.TabIndex = 3;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "All";
            this.rdoAll.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Please select data to review:";
            // 
            // lboList
            // 
            this.lboList.FormattingEnabled = true;
            this.lboList.ItemHeight = 16;
            this.lboList.Location = new System.Drawing.Point(59, 155);
            this.lboList.Name = "lboList";
            this.lboList.Size = new System.Drawing.Size(168, 244);
            this.lboList.TabIndex = 5;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(349, 189);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(60, 24);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "label2";
            // 
            // txtPlays
            // 
            this.txtPlays.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlays.Location = new System.Drawing.Point(491, 260);
            this.txtPlays.Name = "txtPlays";
            this.txtPlays.Size = new System.Drawing.Size(59, 28);
            this.txtPlays.TabIndex = 7;
            // 
            // txtAverage
            // 
            this.txtAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAverage.Location = new System.Drawing.Point(491, 319);
            this.txtAverage.Name = "txtAverage";
            this.txtAverage.Size = new System.Drawing.Size(59, 28);
            this.txtAverage.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(323, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "Total Plays:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(323, 322);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "Average Score:";
            // 
            // frmAdminView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 438);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAverage);
            this.Controls.Add(this.txtPlays);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lboList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdoAll);
            this.Controls.Add(this.rdoBoard);
            this.Controls.Add(this.rdoUser);
            this.Controls.Add(this.lblHello);
            this.Name = "frmAdminView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAdminView";
            this.Load += new System.EventHandler(this.frmAdminView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHello;
        private System.Windows.Forms.RadioButton rdoUser;
        private System.Windows.Forms.RadioButton rdoBoard;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lboList;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtPlays;
        private System.Windows.Forms.TextBox txtAverage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}