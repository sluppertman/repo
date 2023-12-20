namespace BackDropCreate
{
    partial class BackDropCreate
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
            this.btnCreateBackDrop = new System.Windows.Forms.Button();
            this.btnCreateCache = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateBackDrop
            // 
            this.btnCreateBackDrop.Location = new System.Drawing.Point(22, 25);
            this.btnCreateBackDrop.Name = "btnCreateBackDrop";
            this.btnCreateBackDrop.Size = new System.Drawing.Size(230, 126);
            this.btnCreateBackDrop.TabIndex = 0;
            this.btnCreateBackDrop.Text = "Create backdrops";
            this.btnCreateBackDrop.UseVisualStyleBackColor = true;
            this.btnCreateBackDrop.Click += new System.EventHandler(this.btnCreateBackdrops_Click);
            // 
            // btnCreateCache
            // 
            this.btnCreateCache.Location = new System.Drawing.Point(22, 176);
            this.btnCreateCache.Name = "btnCreateCache";
            this.btnCreateCache.Size = new System.Drawing.Size(229, 44);
            this.btnCreateCache.TabIndex = 1;
            this.btnCreateCache.Text = "Create mapping cache";
            this.btnCreateCache.UseVisualStyleBackColor = true;
            this.btnCreateCache.Click += new System.EventHandler(this.btnCreateCache_Click);
            // 
            // BackDropCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 244);
            this.Controls.Add(this.btnCreateCache);
            this.Controls.Add(this.btnCreateBackDrop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "BackDropCreate";
            this.Text = "knLoader Bacdrops";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateBackDrop;
        private System.Windows.Forms.Button btnCreateCache;
    }
}

