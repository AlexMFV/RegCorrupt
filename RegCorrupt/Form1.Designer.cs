namespace RegCorrupt
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
            this.lstRegistry = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstRegistry
            // 
            this.lstRegistry.FormattingEnabled = true;
            this.lstRegistry.Location = new System.Drawing.Point(12, 12);
            this.lstRegistry.Name = "lstRegistry";
            this.lstRegistry.Size = new System.Drawing.Size(782, 433);
            this.lstRegistry.TabIndex = 0;
            this.lstRegistry.DoubleClick += new System.EventHandler(this.lstRegistry_DoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 459);
            this.Controls.Add(this.lstRegistry);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstRegistry;
    }
}

