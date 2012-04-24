namespace Cards
{
    partial class frmMain
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
            this.btnDraw = new System.Windows.Forms.Button();
            this.lblHand = new System.Windows.Forms.Label();
            this.ucCard9 = new Cards.ucCard();
            this.ucCard8 = new Cards.ucCard();
            this.ucCard7 = new Cards.ucCard();
            this.ucCard6 = new Cards.ucCard();
            this.ucCard5 = new Cards.ucCard();
            this.ucCard4 = new Cards.ucCard();
            this.ucCard3 = new Cards.ucCard();
            this.ucCard2 = new Cards.ucCard();
            this.ucCard1 = new Cards.ucCard();
            this.lblHand2 = new System.Windows.Forms.Label();
            this.lblWinner = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(592, 469);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 23);
            this.btnDraw.TabIndex = 7;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // lblHand
            // 
            this.lblHand.AutoSize = true;
            this.lblHand.Location = new System.Drawing.Point(13, 480);
            this.lblHand.Name = "lblHand";
            this.lblHand.Size = new System.Drawing.Size(36, 13);
            this.lblHand.TabIndex = 8;
            this.lblHand.Text = "Hand:";
            // 
            // ucCard9
            // 
            this.ucCard9.BackColor = System.Drawing.Color.White;
            this.ucCard9.Card = null;
            this.ucCard9.Location = new System.Drawing.Point(343, 13);
            this.ucCard9.Name = "ucCard9";
            this.ucCard9.Size = new System.Drawing.Size(109, 150);
            this.ucCard9.TabIndex = 10;
            // 
            // ucCard8
            // 
            this.ucCard8.BackColor = System.Drawing.Color.White;
            this.ucCard8.Card = null;
            this.ucCard8.Location = new System.Drawing.Point(227, 13);
            this.ucCard8.Name = "ucCard8";
            this.ucCard8.Size = new System.Drawing.Size(109, 150);
            this.ucCard8.TabIndex = 9;
            // 
            // ucCard7
            // 
            this.ucCard7.BackColor = System.Drawing.Color.White;
            this.ucCard7.Card = null;
            this.ucCard7.Location = new System.Drawing.Point(342, 343);
            this.ucCard7.Name = "ucCard7";
            this.ucCard7.Size = new System.Drawing.Size(109, 150);
            this.ucCard7.TabIndex = 6;
            // 
            // ucCard6
            // 
            this.ucCard6.BackColor = System.Drawing.Color.White;
            this.ucCard6.Card = null;
            this.ucCard6.Location = new System.Drawing.Point(227, 343);
            this.ucCard6.Name = "ucCard6";
            this.ucCard6.Size = new System.Drawing.Size(109, 150);
            this.ucCard6.TabIndex = 5;
            // 
            // ucCard5
            // 
            this.ucCard5.BackColor = System.Drawing.Color.White;
            this.ucCard5.Card = null;
            this.ucCard5.Location = new System.Drawing.Point(515, 177);
            this.ucCard5.Name = "ucCard5";
            this.ucCard5.Size = new System.Drawing.Size(109, 150);
            this.ucCard5.TabIndex = 4;
            // 
            // ucCard4
            // 
            this.ucCard4.BackColor = System.Drawing.Color.White;
            this.ucCard4.Card = null;
            this.ucCard4.Location = new System.Drawing.Point(400, 177);
            this.ucCard4.Name = "ucCard4";
            this.ucCard4.Size = new System.Drawing.Size(109, 150);
            this.ucCard4.TabIndex = 3;
            // 
            // ucCard3
            // 
            this.ucCard3.BackColor = System.Drawing.Color.White;
            this.ucCard3.Card = null;
            this.ucCard3.Location = new System.Drawing.Point(285, 177);
            this.ucCard3.Name = "ucCard3";
            this.ucCard3.Size = new System.Drawing.Size(109, 150);
            this.ucCard3.TabIndex = 2;
            // 
            // ucCard2
            // 
            this.ucCard2.BackColor = System.Drawing.Color.White;
            this.ucCard2.Card = null;
            this.ucCard2.Location = new System.Drawing.Point(170, 177);
            this.ucCard2.Name = "ucCard2";
            this.ucCard2.Size = new System.Drawing.Size(109, 150);
            this.ucCard2.TabIndex = 1;
            // 
            // ucCard1
            // 
            this.ucCard1.BackColor = System.Drawing.Color.White;
            this.ucCard1.Card = null;
            this.ucCard1.Location = new System.Drawing.Point(55, 177);
            this.ucCard1.Name = "ucCard1";
            this.ucCard1.Size = new System.Drawing.Size(109, 150);
            this.ucCard1.TabIndex = 0;
            // 
            // lblHand2
            // 
            this.lblHand2.AutoSize = true;
            this.lblHand2.Location = new System.Drawing.Point(16, 13);
            this.lblHand2.Name = "lblHand2";
            this.lblHand2.Size = new System.Drawing.Size(36, 13);
            this.lblHand2.TabIndex = 11;
            this.lblHand2.Text = "Hand:";
            // 
            // lblWinner
            // 
            this.lblWinner.AutoSize = true;
            this.lblWinner.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinner.ForeColor = System.Drawing.Color.Red;
            this.lblWinner.Location = new System.Drawing.Point(589, 453);
            this.lblWinner.Name = "lblWinner";
            this.lblWinner.Size = new System.Drawing.Size(51, 13);
            this.lblWinner.TabIndex = 12;
            this.lblWinner.Text = "Winner:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(679, 505);
            this.Controls.Add(this.lblWinner);
            this.Controls.Add(this.lblHand2);
            this.Controls.Add(this.ucCard9);
            this.Controls.Add(this.ucCard8);
            this.Controls.Add(this.lblHand);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.ucCard7);
            this.Controls.Add(this.ucCard6);
            this.Controls.Add(this.ucCard5);
            this.Controls.Add(this.ucCard4);
            this.Controls.Add(this.ucCard3);
            this.Controls.Add(this.ucCard2);
            this.Controls.Add(this.ucCard1);
            this.Name = "frmMain";
            this.Text = "Poker";
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucCard ucCard1;
        private ucCard ucCard2;
        private ucCard ucCard3;
        private ucCard ucCard4;
        private ucCard ucCard5;
        private ucCard ucCard6;
        private ucCard ucCard7;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Label lblHand;
        private ucCard ucCard8;
        private ucCard ucCard9;
        private System.Windows.Forms.Label lblHand2;
        private System.Windows.Forms.Label lblWinner;
    }
}