namespace SoccerApplicationForMen
{
    partial class SettingsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.pnlTypes = new System.Windows.Forms.Panel();
            this.btnGeneral = new System.Windows.Forms.Button();
            this.btnAccount = new System.Windows.Forms.Button();
            this.btnGamePlay = new System.Windows.Forms.Button();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlButtons.Controls.Add(this.btnGamePlay);
            this.pnlButtons.Controls.Add(this.btnAccount);
            this.pnlButtons.Controls.Add(this.btnGeneral);
            this.pnlButtons.Location = new System.Drawing.Point(3, 3);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(137, 447);
            this.pnlButtons.TabIndex = 0;
            // 
            // pnlTypes
            // 
            this.pnlTypes.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlTypes.Location = new System.Drawing.Point(150, 3);
            this.pnlTypes.Name = "pnlTypes";
            this.pnlTypes.Size = new System.Drawing.Size(576, 447);
            this.pnlTypes.TabIndex = 1;
            // 
            // btnGeneral
            // 
            this.btnGeneral.Location = new System.Drawing.Point(3, 8);
            this.btnGeneral.Name = "btnGeneral";
            this.btnGeneral.Size = new System.Drawing.Size(131, 39);
            this.btnGeneral.TabIndex = 0;
            this.btnGeneral.Text = "General";
            this.btnGeneral.UseVisualStyleBackColor = true;
            // 
            // btnAccount
            // 
            this.btnAccount.Location = new System.Drawing.Point(3, 53);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(131, 39);
            this.btnAccount.TabIndex = 1;
            this.btnAccount.Text = "Account";
            this.btnAccount.UseVisualStyleBackColor = true;
            // 
            // btnGamePlay
            // 
            this.btnGamePlay.Location = new System.Drawing.Point(3, 98);
            this.btnGamePlay.Name = "btnGamePlay";
            this.btnGamePlay.Size = new System.Drawing.Size(131, 39);
            this.btnGamePlay.TabIndex = 2;
            this.btnGamePlay.Text = "Game Play";
            this.btnGamePlay.UseVisualStyleBackColor = true;
            this.btnGamePlay.Click += new System.EventHandler(this.btnGamePlay_Click);
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlTypes);
            this.Controls.Add(this.pnlButtons);
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(738, 461);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Panel pnlTypes;
        private System.Windows.Forms.Button btnGamePlay;
        private System.Windows.Forms.Button btnAccount;
        private System.Windows.Forms.Button btnGeneral;
    }
}
