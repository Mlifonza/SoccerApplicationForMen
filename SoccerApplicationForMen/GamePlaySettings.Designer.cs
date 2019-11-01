namespace SoccerApplicationForMen
{
    partial class GamePlaySettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.lstCountry = new System.Windows.Forms.ListBox();
            this.btnView = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstAddRemove = new System.Windows.Forms.ListBox();
            this.lstCompetition = new System.Windows.Forms.ListBox();
            this.lblCountryOfCompetition = new System.Windows.Forms.Label();
            this.lblRemovedCompetition = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 15F);
            this.label1.Location = new System.Drawing.Point(244, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "INTERFACE";
            // 
            // lstCountry
            // 
            this.lstCountry.BackColor = System.Drawing.Color.Ivory;
            this.lstCountry.FormattingEnabled = true;
            this.lstCountry.Location = new System.Drawing.Point(7, 64);
            this.lstCountry.Name = "lstCountry";
            this.lstCountry.Size = new System.Drawing.Size(139, 329);
            this.lstCountry.TabIndex = 1;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(146, 190);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(72, 41);
            this.btnView.TabIndex = 3;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Ivory;
            this.panel1.Controls.Add(this.lblRemovedCompetition);
            this.panel1.Controls.Add(this.lblCountryOfCompetition);
            this.panel1.Controls.Add(this.lstAddRemove);
            this.panel1.Controls.Add(this.lstCompetition);
            this.panel1.Location = new System.Drawing.Point(219, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 329);
            this.panel1.TabIndex = 4;
            // 
            // lstAddRemove
            // 
            this.lstAddRemove.FormattingEnabled = true;
            this.lstAddRemove.Location = new System.Drawing.Point(202, 30);
            this.lstAddRemove.Name = "lstAddRemove";
            this.lstAddRemove.Size = new System.Drawing.Size(139, 238);
            this.lstAddRemove.TabIndex = 6;
            // 
            // lstCompetition
            // 
            this.lstCompetition.FormattingEnabled = true;
            this.lstCompetition.Location = new System.Drawing.Point(7, 30);
            this.lstCompetition.Name = "lstCompetition";
            this.lstCompetition.Size = new System.Drawing.Size(139, 238);
            this.lstCompetition.TabIndex = 5;
            // 
            // lblCountryOfCompetition
            // 
            this.lblCountryOfCompetition.AutoSize = true;
            this.lblCountryOfCompetition.Location = new System.Drawing.Point(3, 10);
            this.lblCountryOfCompetition.Name = "lblCountryOfCompetition";
            this.lblCountryOfCompetition.Size = new System.Drawing.Size(134, 13);
            this.lblCountryOfCompetition.TabIndex = 7;
            this.lblCountryOfCompetition.Text = "Country of competition";
            // 
            // lblRemovedCompetition
            // 
            this.lblRemovedCompetition.AutoSize = true;
            this.lblRemovedCompetition.Location = new System.Drawing.Point(198, 10);
            this.lblRemovedCompetition.Name = "lblRemovedCompetition";
            this.lblRemovedCompetition.Size = new System.Drawing.Size(127, 13);
            this.lblRemovedCompetition.TabIndex = 8;
            this.lblRemovedCompetition.Text = "Removed Competition";
            // 
            // GamePlaySettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.lstCountry);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI Black", 8.25F);
            this.Name = "GamePlaySettings";
            this.Size = new System.Drawing.Size(577, 406);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstCountry;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lstAddRemove;
        private System.Windows.Forms.ListBox lstCompetition;
        private System.Windows.Forms.Label lblRemovedCompetition;
        private System.Windows.Forms.Label lblCountryOfCompetition;
    }
}
