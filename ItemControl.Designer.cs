using System.ComponentModel;

namespace lika_laba3
{
    partial class ItemControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.i = new System.Windows.Forms.Label();
            this.w = new System.Windows.Forms.TextBox();
            this.c = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // i
            // 
            this.i.Location = new System.Drawing.Point(0, 0);
            this.i.Name = "i";
            this.i.Size = new System.Drawing.Size(44, 17);
            this.i.TabIndex = 0;
            this.i.Text = "index";
            // 
            // w
            // 
            this.w.Location = new System.Drawing.Point(41, 0);
            this.w.Name = "w";
            this.w.Size = new System.Drawing.Size(38, 20);
            this.w.TabIndex = 1;
            // 
            // c
            // 
            this.c.Location = new System.Drawing.Point(94, 0);
            this.c.Name = "c";
            this.c.Size = new System.Drawing.Size(37, 20);
            this.c.TabIndex = 2;
            // 
            // ItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.c);
            this.Controls.Add(this.w);
            this.Controls.Add(this.i);
            this.Name = "ItemControl";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox c;
        private System.Windows.Forms.Label i;
        private System.Windows.Forms.TextBox w;

        #endregion
    }
}