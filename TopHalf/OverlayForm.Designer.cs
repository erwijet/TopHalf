namespace TopHalf
{
    partial class OverlayForm
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
            this.listbox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listbox
            // 
            this.listbox.BackColor = System.Drawing.Color.White;
            this.listbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listbox.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listbox.FormattingEnabled = true;
            this.listbox.ItemHeight = 34;
            this.listbox.Location = new System.Drawing.Point(0, 0);
            this.listbox.Margin = new System.Windows.Forms.Padding(10);
            this.listbox.Name = "listbox";
            this.listbox.Size = new System.Drawing.Size(1202, 616);
            this.listbox.TabIndex = 0;
            this.listbox.SelectedIndexChanged += new System.EventHandler(this.listbox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 616);
            this.Controls.Add(this.listbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Opacity = 0.5D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.DarkGray;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listbox;
    }
}

