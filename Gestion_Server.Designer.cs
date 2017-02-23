namespace Gestion_Maisha
{
    partial class Gestion_Server
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
            this.components = new System.ComponentModel.Container();
            MetroFramework.Controls.MetroButton stop_button;
            MetroFramework.Controls.MetroButton Reboot_buttons;
            MetroFramework.Controls.MetroButton Start_Buttons;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gestion_Server));
            this.CheckMD5 = new System.ComponentModel.BackgroundWorker();
            this.TabControl = new MetroFramework.Controls.MetroTabControl();
            this.MaishaRP = new MetroFramework.Controls.MetroTabPage();
            this.Label_HASH_server = new System.Windows.Forms.Label();
            this.metroProgressSpinner2 = new MetroFramework.Controls.MetroProgressSpinner();
            this.elapsedtime = new System.Windows.Forms.Label();
            this.elapsedtime_text = new System.Windows.Forms.Label();
            this.Command_start = new MetroFramework.Controls.MetroTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_message = new System.Windows.Forms.Label();
            this.metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
            this.label_player = new System.Windows.Forms.Label();
            this.label_Mission = new System.Windows.Forms.Label();
            this.label_map = new System.Windows.Forms.Label();
            this.label_status = new System.Windows.Forms.Label();
            this.label_nom_serveur = new System.Windows.Forms.Label();
            this.label_ip_serv = new System.Windows.Forms.Label();
            this.Label_HASH = new System.Windows.Forms.Label();
            this.CreateMD5 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            stop_button = new MetroFramework.Controls.MetroButton();
            Reboot_buttons = new MetroFramework.Controls.MetroButton();
            Start_Buttons = new MetroFramework.Controls.MetroButton();
            this.TabControl.SuspendLayout();
            this.MaishaRP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // stop_button
            // 
            stop_button.Highlight = false;
            stop_button.Location = new System.Drawing.Point(904, 165);
            stop_button.Name = "stop_button";
            stop_button.Size = new System.Drawing.Size(160, 37);
            stop_button.Style = MetroFramework.MetroColorStyle.Blue;
            stop_button.StyleManager = null;
            stop_button.TabIndex = 12;
            stop_button.Text = "Arreté le serveur";
            stop_button.Theme = MetroFramework.MetroThemeStyle.Light;
            stop_button.Click += new System.EventHandler(this.stop_button_Click);
            // 
            // Reboot_buttons
            // 
            Reboot_buttons.Highlight = false;
            Reboot_buttons.Location = new System.Drawing.Point(904, 208);
            Reboot_buttons.Name = "Reboot_buttons";
            Reboot_buttons.Size = new System.Drawing.Size(160, 37);
            Reboot_buttons.Style = MetroFramework.MetroColorStyle.Blue;
            Reboot_buttons.StyleManager = null;
            Reboot_buttons.TabIndex = 13;
            Reboot_buttons.Text = "Redémarrer le serveur";
            Reboot_buttons.Theme = MetroFramework.MetroThemeStyle.Light;
            Reboot_buttons.Click += new System.EventHandler(this.Reboot_buttons_Click);
            // 
            // Start_Buttons
            // 
            Start_Buttons.Highlight = false;
            Start_Buttons.Location = new System.Drawing.Point(904, 272);
            Start_Buttons.Name = "Start_Buttons";
            Start_Buttons.Size = new System.Drawing.Size(160, 37);
            Start_Buttons.Style = MetroFramework.MetroColorStyle.Blue;
            Start_Buttons.StyleManager = null;
            Start_Buttons.TabIndex = 14;
            Start_Buttons.Text = "Démarrer le serveur";
            Start_Buttons.Theme = MetroFramework.MetroThemeStyle.Light;
            Start_Buttons.Click += new System.EventHandler(this.Start_Buttons_Click);
            // 
            // CheckMD5
            // 
            this.CheckMD5.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CheckMD5_DoWork);
            this.CheckMD5.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.CheckMD5_RunWorkerCompleted);
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.MaishaRP);
            this.TabControl.CustomBackground = false;
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.FontSize = MetroFramework.MetroTabControlSize.Medium;
            this.TabControl.FontWeight = MetroFramework.MetroTabControlWeight.Light;
            this.TabControl.Location = new System.Drawing.Point(20, 60);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(1140, 465);
            this.TabControl.Style = MetroFramework.MetroColorStyle.Blue;
            this.TabControl.StyleManager = null;
            this.TabControl.TabIndex = 0;
            this.TabControl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TabControl.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TabControl.UseStyleColors = false;
            // 
            // MaishaRP
            // 
            this.MaishaRP.Controls.Add(this.Label_HASH_server);
            this.MaishaRP.Controls.Add(this.metroProgressSpinner2);
            this.MaishaRP.Controls.Add(this.elapsedtime);
            this.MaishaRP.Controls.Add(this.elapsedtime_text);
            this.MaishaRP.Controls.Add(this.Command_start);
            this.MaishaRP.Controls.Add(this.label1);
            this.MaishaRP.Controls.Add(Start_Buttons);
            this.MaishaRP.Controls.Add(Reboot_buttons);
            this.MaishaRP.Controls.Add(stop_button);
            this.MaishaRP.Controls.Add(this.label_message);
            this.MaishaRP.Controls.Add(this.metroProgressSpinner1);
            this.MaishaRP.Controls.Add(this.label_player);
            this.MaishaRP.Controls.Add(this.label_Mission);
            this.MaishaRP.Controls.Add(this.label_map);
            this.MaishaRP.Controls.Add(this.label_status);
            this.MaishaRP.Controls.Add(this.label_nom_serveur);
            this.MaishaRP.Controls.Add(this.label_ip_serv);
            this.MaishaRP.Controls.Add(this.Label_HASH);
            this.MaishaRP.CustomBackground = false;
            this.MaishaRP.HorizontalScrollbar = false;
            this.MaishaRP.HorizontalScrollbarBarColor = true;
            this.MaishaRP.HorizontalScrollbarHighlightOnWheel = false;
            this.MaishaRP.HorizontalScrollbarSize = 10;
            this.MaishaRP.Location = new System.Drawing.Point(4, 35);
            this.MaishaRP.Name = "MaishaRP";
            this.MaishaRP.Size = new System.Drawing.Size(1132, 426);
            this.MaishaRP.Style = MetroFramework.MetroColorStyle.Blue;
            this.MaishaRP.StyleManager = null;
            this.MaishaRP.TabIndex = 0;
            this.MaishaRP.Text = "MaishaRP";
            this.MaishaRP.Theme = MetroFramework.MetroThemeStyle.Light;
            this.MaishaRP.VerticalScrollbar = false;
            this.MaishaRP.VerticalScrollbarBarColor = true;
            this.MaishaRP.VerticalScrollbarHighlightOnWheel = false;
            this.MaishaRP.VerticalScrollbarSize = 10;
            // 
            // Label_HASH_server
            // 
            this.Label_HASH_server.AutoSize = true;
            this.Label_HASH_server.Font = new System.Drawing.Font("Baskerville Old Face", 12F);
            this.Label_HASH_server.Location = new System.Drawing.Point(833, 405);
            this.Label_HASH_server.Name = "Label_HASH_server";
            this.Label_HASH_server.Size = new System.Drawing.Size(52, 18);
            this.Label_HASH_server.TabIndex = 21;
            this.Label_HASH_server.Text = "-----------";
            // 
            // metroProgressSpinner2
            // 
            this.metroProgressSpinner2.CustomBackground = false;
            this.metroProgressSpinner2.Location = new System.Drawing.Point(787, 383);
            this.metroProgressSpinner2.Maximum = 100;
            this.metroProgressSpinner2.Name = "metroProgressSpinner2";
            this.metroProgressSpinner2.Size = new System.Drawing.Size(40, 40);
            this.metroProgressSpinner2.Style = MetroFramework.MetroColorStyle.Green;
            this.metroProgressSpinner2.StyleManager = null;
            this.metroProgressSpinner2.TabIndex = 20;
            this.metroProgressSpinner2.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroProgressSpinner2.Visible = false;
            // 
            // elapsedtime
            // 
            this.elapsedtime.AutoSize = true;
            this.elapsedtime.Font = new System.Drawing.Font("Baskerville Old Face", 12F);
            this.elapsedtime.Location = new System.Drawing.Point(1024, 47);
            this.elapsedtime.Name = "elapsedtime";
            this.elapsedtime.Size = new System.Drawing.Size(40, 18);
            this.elapsedtime.TabIndex = 19;
            this.elapsedtime.Text = "--------";
            // 
            // elapsedtime_text
            // 
            this.elapsedtime_text.AutoSize = true;
            this.elapsedtime_text.Font = new System.Drawing.Font("Baskerville Old Face", 12F);
            this.elapsedtime_text.Location = new System.Drawing.Point(904, 47);
            this.elapsedtime_text.Name = "elapsedtime_text";
            this.elapsedtime_text.Size = new System.Drawing.Size(114, 18);
            this.elapsedtime_text.TabIndex = 18;
            this.elapsedtime_text.Text = "Prochain reboot:";
            // 
            // Command_start
            // 
            this.Command_start.CustomBackground = false;
            this.Command_start.CustomForeColor = false;
            this.Command_start.FontSize = MetroFramework.MetroTextBoxSize.Small;
            this.Command_start.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            this.Command_start.Location = new System.Drawing.Point(3, 58);
            this.Command_start.Multiline = false;
            this.Command_start.Name = "Command_start";
            this.Command_start.SelectedText = "";
            this.Command_start.Size = new System.Drawing.Size(639, 23);
            this.Command_start.Style = MetroFramework.MetroColorStyle.Blue;
            this.Command_start.StyleManager = null;
            this.Command_start.TabIndex = 17;
            this.Command_start.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Command_start.UseStyleColors = false;
            this.Command_start.Leave += new System.EventHandler(this.Command_start_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Baskerville Old Face", 12F);
            this.label1.Location = new System.Drawing.Point(0, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "Commande de lancement";
            // 
            // label_message
            // 
            this.label_message.AutoSize = true;
            this.label_message.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_message.Location = new System.Drawing.Point(228, 367);
            this.label_message.Name = "label_message";
            this.label_message.Size = new System.Drawing.Size(0, 24);
            this.label_message.TabIndex = 11;
            // 
            // metroProgressSpinner1
            // 
            this.metroProgressSpinner1.CustomBackground = false;
            this.metroProgressSpinner1.Location = new System.Drawing.Point(787, 337);
            this.metroProgressSpinner1.Maximum = 100;
            this.metroProgressSpinner1.Name = "metroProgressSpinner1";
            this.metroProgressSpinner1.Size = new System.Drawing.Size(40, 40);
            this.metroProgressSpinner1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroProgressSpinner1.StyleManager = null;
            this.metroProgressSpinner1.TabIndex = 10;
            this.metroProgressSpinner1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroProgressSpinner1.Visible = false;
            // 
            // label_player
            // 
            this.label_player.AutoSize = true;
            this.label_player.Font = new System.Drawing.Font("Baskerville Old Face", 12F);
            this.label_player.Location = new System.Drawing.Point(3, 356);
            this.label_player.Name = "label_player";
            this.label_player.Size = new System.Drawing.Size(56, 18);
            this.label_player.TabIndex = 9;
            this.label_player.Text = "------------";
            // 
            // label_Mission
            // 
            this.label_Mission.AutoSize = true;
            this.label_Mission.Font = new System.Drawing.Font("Baskerville Old Face", 12F);
            this.label_Mission.Location = new System.Drawing.Point(3, 334);
            this.label_Mission.Name = "label_Mission";
            this.label_Mission.Size = new System.Drawing.Size(56, 18);
            this.label_Mission.TabIndex = 8;
            this.label_Mission.Text = "------------";
            // 
            // label_map
            // 
            this.label_map.AutoSize = true;
            this.label_map.Font = new System.Drawing.Font("Baskerville Old Face", 12F);
            this.label_map.Location = new System.Drawing.Point(3, 312);
            this.label_map.Name = "label_map";
            this.label_map.Size = new System.Drawing.Size(56, 18);
            this.label_map.TabIndex = 7;
            this.label_map.Text = "------------";
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Font = new System.Drawing.Font("Baskerville Old Face", 12F);
            this.label_status.Location = new System.Drawing.Point(3, 290);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(56, 18);
            this.label_status.TabIndex = 6;
            this.label_status.Text = "------------";
            // 
            // label_nom_serveur
            // 
            this.label_nom_serveur.AutoSize = true;
            this.label_nom_serveur.Font = new System.Drawing.Font("Baskerville Old Face", 12F);
            this.label_nom_serveur.Location = new System.Drawing.Point(3, 265);
            this.label_nom_serveur.Name = "label_nom_serveur";
            this.label_nom_serveur.Size = new System.Drawing.Size(56, 18);
            this.label_nom_serveur.TabIndex = 4;
            this.label_nom_serveur.Text = "------------";
            // 
            // label_ip_serv
            // 
            this.label_ip_serv.AutoSize = true;
            this.label_ip_serv.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ip_serv.Location = new System.Drawing.Point(3, 243);
            this.label_ip_serv.Name = "label_ip_serv";
            this.label_ip_serv.Size = new System.Drawing.Size(56, 18);
            this.label_ip_serv.TabIndex = 3;
            this.label_ip_serv.Text = "------------";
            // 
            // Label_HASH
            // 
            this.Label_HASH.AutoSize = true;
            this.Label_HASH.Font = new System.Drawing.Font("Baskerville Old Face", 12F);
            this.Label_HASH.Location = new System.Drawing.Point(833, 337);
            this.Label_HASH.Name = "Label_HASH";
            this.Label_HASH.Size = new System.Drawing.Size(52, 18);
            this.Label_HASH.TabIndex = 2;
            this.Label_HASH.Text = "-----------";
            // 
            // CreateMD5
            // 
            this.CreateMD5.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CreateMD5_DoWork);
            this.CreateMD5.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.CreateMD5_RunWorkerCompleted);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1130, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 600000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1094, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // Gestion_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 545);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TabControl);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Gestion_Server";
            this.Text = "Gestion_Server";
            this.Load += new System.EventHandler(this.Gestion_Server_Load);
            this.TabControl.ResumeLayout(false);
            this.MaishaRP.ResumeLayout(false);
            this.MaishaRP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker CheckMD5;
        private System.Windows.Forms.Label Label_HASH;
        private MetroFramework.Controls.MetroTabPage MaishaRP;
        private MetroFramework.Controls.MetroTabControl TabControl;
        private System.ComponentModel.BackgroundWorker CreateMD5;
        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner1;
        private System.Windows.Forms.Label label_player;
        private System.Windows.Forms.Label label_Mission;
        private System.Windows.Forms.Label label_map;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Label label_nom_serveur;
        private System.Windows.Forms.Label label_ip_serv;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label_message;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroTextBox Command_start;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label elapsedtime;
        private System.Windows.Forms.Label elapsedtime_text;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label Label_HASH_server;
        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner2;
    }
}