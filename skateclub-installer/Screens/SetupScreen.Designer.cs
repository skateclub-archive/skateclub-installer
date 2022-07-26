namespace skateclub_installer.Screens
{
    partial class SetupScreen
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
            this.installButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.shortcutBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.installPath = new System.Windows.Forms.TextBox();
            this.dependenciesBox = new System.Windows.Forms.CheckBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "skateclub Installer";
            // 
            // installButton
            // 
            this.installButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.installButton.Location = new System.Drawing.Point(398, 165);
            this.installButton.Name = "installButton";
            this.installButton.Size = new System.Drawing.Size(75, 23);
            this.installButton.TabIndex = 1;
            this.installButton.Text = "Install";
            this.installButton.UseVisualStyleBackColor = true;
            this.installButton.Click += new System.EventHandler(this.installButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(317, 165);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // shortcutBox
            // 
            this.shortcutBox.AutoSize = true;
            this.shortcutBox.Checked = true;
            this.shortcutBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.shortcutBox.ForeColor = System.Drawing.Color.White;
            this.shortcutBox.Location = new System.Drawing.Point(0, 90);
            this.shortcutBox.Name = "shortcutBox";
            this.shortcutBox.Size = new System.Drawing.Size(139, 17);
            this.shortcutBox.TabIndex = 3;
            this.shortcutBox.Text = "Create desktop shortcut";
            this.shortcutBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(-3, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Welcome to the skateclub Installer!";
            // 
            // installPath
            // 
            this.installPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.installPath.Location = new System.Drawing.Point(0, 46);
            this.installPath.Name = "installPath";
            this.installPath.Size = new System.Drawing.Size(392, 20);
            this.installPath.TabIndex = 5;
            // 
            // dependenciesBox
            // 
            this.dependenciesBox.AutoSize = true;
            this.dependenciesBox.Checked = true;
            this.dependenciesBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dependenciesBox.ForeColor = System.Drawing.Color.White;
            this.dependenciesBox.Location = new System.Drawing.Point(0, 113);
            this.dependenciesBox.Name = "dependenciesBox";
            this.dependenciesBox.Size = new System.Drawing.Size(199, 17);
            this.dependenciesBox.TabIndex = 6;
            this.dependenciesBox.Text = "Install dependencies (.NET 6.0, etc.)";
            this.dependenciesBox.UseVisualStyleBackColor = true;
            // 
            // browseButton
            // 
            this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseButton.Location = new System.Drawing.Point(398, 44);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 7;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(-3, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(254, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "If you have Skate 4 already installed, select its folder";
            // 
            // SetupScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.dependenciesBox);
            this.Controls.Add(this.installPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.shortcutBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.installButton);
            this.Controls.Add(this.label1);
            this.Name = "SetupScreen";
            this.Size = new System.Drawing.Size(473, 188);
            this.Load += new System.EventHandler(this.SetupScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button installButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox shortcutBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox installPath;
        private System.Windows.Forms.CheckBox dependenciesBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label label3;
    }
}
