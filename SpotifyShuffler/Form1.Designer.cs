namespace SpotifyShuffler
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BUTTON_Login = new System.Windows.Forms.Button();
            this.ManagePanel = new System.Windows.Forms.Panel();
            this.Shuffle = new System.Windows.Forms.Button();
            this.CreateShuffle = new System.Windows.Forms.Button();
            this.PlaylistListbox = new System.Windows.Forms.ListBox();
            this.ManagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BUTTON_Login
            // 
            this.BUTTON_Login.BackColor = System.Drawing.Color.White;
            this.BUTTON_Login.FlatAppearance.BorderSize = 0;
            this.BUTTON_Login.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BUTTON_Login.Location = new System.Drawing.Point(1, 5);
            this.BUTTON_Login.Name = "BUTTON_Login";
            this.BUTTON_Login.Size = new System.Drawing.Size(85, 35);
            this.BUTTON_Login.TabIndex = 0;
            this.BUTTON_Login.Text = "Login";
            this.BUTTON_Login.UseVisualStyleBackColor = false;
            this.BUTTON_Login.Click += new System.EventHandler(this.BUTTON_Login_Click);
            // 
            // ManagePanel
            // 
            this.ManagePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ManagePanel.Controls.Add(this.Shuffle);
            this.ManagePanel.Controls.Add(this.CreateShuffle);
            this.ManagePanel.Controls.Add(this.PlaylistListbox);
            this.ManagePanel.Enabled = false;
            this.ManagePanel.Location = new System.Drawing.Point(92, -2);
            this.ManagePanel.Name = "ManagePanel";
            this.ManagePanel.Size = new System.Drawing.Size(710, 453);
            this.ManagePanel.TabIndex = 1;
            this.ManagePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ManagePanel_Paint);
            // 
            // Shuffle
            // 
            this.Shuffle.Location = new System.Drawing.Point(3, 48);
            this.Shuffle.Name = "Shuffle";
            this.Shuffle.Size = new System.Drawing.Size(199, 35);
            this.Shuffle.TabIndex = 2;
            this.Shuffle.Text = "Shuffle";
            this.Shuffle.UseVisualStyleBackColor = true;
            this.Shuffle.Click += new System.EventHandler(this.button2_Click);
            // 
            // CreateShuffle
            // 
            this.CreateShuffle.Location = new System.Drawing.Point(3, 7);
            this.CreateShuffle.Name = "CreateShuffle";
            this.CreateShuffle.Size = new System.Drawing.Size(199, 35);
            this.CreateShuffle.TabIndex = 1;
            this.CreateShuffle.Text = "Create new and Shuffle";
            this.CreateShuffle.UseVisualStyleBackColor = true;
            this.CreateShuffle.Click += new System.EventHandler(this.button1_Click);
            // 
            // PlaylistListbox
            // 
            this.PlaylistListbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.PlaylistListbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlaylistListbox.Font = new System.Drawing.Font("Leelawadee UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PlaylistListbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(223)))), ((int)(((byte)(100)))));
            this.PlaylistListbox.FormattingEnabled = true;
            this.PlaylistListbox.HorizontalScrollbar = true;
            this.PlaylistListbox.ItemHeight = 15;
            this.PlaylistListbox.Location = new System.Drawing.Point(208, 0);
            this.PlaylistListbox.MultiColumn = true;
            this.PlaylistListbox.Name = "PlaylistListbox";
            this.PlaylistListbox.Size = new System.Drawing.Size(502, 452);
            this.PlaylistListbox.Sorted = true;
            this.PlaylistListbox.TabIndex = 0;
            this.PlaylistListbox.SelectedIndexChanged += new System.EventHandler(this.PlaylistListbox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ManagePanel);
            this.Controls.Add(this.BUTTON_Login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Randomizer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ManagePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public Button BUTTON_Login;
        public Panel ManagePanel;
        public ListBox PlaylistListbox;
        public Button Shuffle;
        public Button CreateShuffle;
    }
}