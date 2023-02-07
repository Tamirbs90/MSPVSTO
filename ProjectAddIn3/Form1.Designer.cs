namespace Mobideo.Integration.ProjectVSTOAddIn
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label_UpdateMobideoToMsp = new System.Windows.Forms.Label();
            this.label_UpdateMspToMobideo = new System.Windows.Forms.Label();
            this.SubProjectsList = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(556, 364);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // label_UpdateMobideoToMsp
            // 
            this.label_UpdateMobideoToMsp.AutoSize = true;
            this.label_UpdateMobideoToMsp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_UpdateMobideoToMsp.Location = new System.Drawing.Point(447, 438);
            this.label_UpdateMobideoToMsp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_UpdateMobideoToMsp.Name = "label_UpdateMobideoToMsp";
            this.label_UpdateMobideoToMsp.Size = new System.Drawing.Size(254, 22);
            this.label_UpdateMobideoToMsp.TabIndex = 1;
            this.label_UpdateMobideoToMsp.Text = "Update Project data from Mobideo";
            this.label_UpdateMobideoToMsp.Click += new System.EventHandler(this.label_UpdateMobideoToMsp_Click);
            // 
            // label_UpdateMspToMobideo
            // 
            this.label_UpdateMspToMobideo.AutoSize = true;
            this.label_UpdateMspToMobideo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_UpdateMspToMobideo.Location = new System.Drawing.Point(443, 505);
            this.label_UpdateMspToMobideo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_UpdateMspToMobideo.Name = "label_UpdateMspToMobideo";
            this.label_UpdateMspToMobideo.Size = new System.Drawing.Size(258, 22);
            this.label_UpdateMspToMobideo.TabIndex = 2;
            this.label_UpdateMspToMobideo.Text = "Update Mobideo from Project data ";
            this.label_UpdateMspToMobideo.Click += new System.EventHandler(this.label_UpdateMspToMobideo_Click);
            // 
            // SubProjectsList
            // 
            this.SubProjectsList.FormattingEnabled = true;
            this.SubProjectsList.Location = new System.Drawing.Point(392, 128);
            this.SubProjectsList.Name = "SubProjectsList";
            this.SubProjectsList.Size = new System.Drawing.Size(357, 211);
            this.SubProjectsList.TabIndex = 3;
            this.SubProjectsList.DisplayMember = "FileName";
            this.SubProjectsList.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.SubProjectsList);
            this.Controls.Add(this.label_UpdateMspToMobideo);
            this.Controls.Add(this.label_UpdateMobideoToMsp);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_UpdateMobideoToMsp;
        private System.Windows.Forms.Label label_UpdateMspToMobideo;
        private System.Windows.Forms.CheckedListBox SubProjectsList;
    }
}