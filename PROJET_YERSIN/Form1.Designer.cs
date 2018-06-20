namespace Tournoi_Echec
{
    partial class FormMain
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.BTN_Demarrer_Tournoi = new System.Windows.Forms.Button();
            this.Nb_Rondes = new System.Windows.Forms.NumericUpDown();
            this.Label_NbRondes = new System.Windows.Forms.Label();
            this.BTN_LDD = new System.Windows.Forms.Button();
            this.Txt_Participants = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Help = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Nb_Rondes)).BeginInit();
            this.SuspendLayout();
            // 
            // BTN_Demarrer_Tournoi
            // 
            this.BTN_Demarrer_Tournoi.Location = new System.Drawing.Point(277, 318);
            this.BTN_Demarrer_Tournoi.Name = "BTN_Demarrer_Tournoi";
            this.BTN_Demarrer_Tournoi.Size = new System.Drawing.Size(92, 81);
            this.BTN_Demarrer_Tournoi.TabIndex = 0;
            this.BTN_Demarrer_Tournoi.Text = "Démarrer le tournoi !";
            this.BTN_Demarrer_Tournoi.UseVisualStyleBackColor = true;
            this.BTN_Demarrer_Tournoi.Click += new System.EventHandler(this.BTN_Demarrer_Tournoi_Click);
            // 
            // Nb_Rondes
            // 
            this.Nb_Rondes.Location = new System.Drawing.Point(277, 40);
            this.Nb_Rondes.Maximum = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.Nb_Rondes.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.Nb_Rondes.Name = "Nb_Rondes";
            this.Nb_Rondes.ReadOnly = true;
            this.Nb_Rondes.Size = new System.Drawing.Size(92, 20);
            this.Nb_Rondes.TabIndex = 1;
            this.Nb_Rondes.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.Nb_Rondes.ValueChanged += new System.EventHandler(this.Nb_Rondes_ValueChanged);
            // 
            // Label_NbRondes
            // 
            this.Label_NbRondes.AutoSize = true;
            this.Label_NbRondes.BackColor = System.Drawing.Color.Transparent;
            this.Label_NbRondes.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Label_NbRondes.Location = new System.Drawing.Point(274, 24);
            this.Label_NbRondes.Name = "Label_NbRondes";
            this.Label_NbRondes.Size = new System.Drawing.Size(100, 13);
            this.Label_NbRondes.TabIndex = 2;
            this.Label_NbRondes.Text = "Nombre de rondes :";
            // 
            // BTN_LDD
            // 
            this.BTN_LDD.Location = new System.Drawing.Point(277, 100);
            this.BTN_LDD.Name = "BTN_LDD";
            this.BTN_LDD.Size = new System.Drawing.Size(92, 44);
            this.BTN_LDD.TabIndex = 3;
            this.BTN_LDD.Text = "Liste de départ";
            this.BTN_LDD.UseVisualStyleBackColor = true;
            this.BTN_LDD.Click += new System.EventHandler(this.BTN_LDD_Click);
            // 
            // Txt_Participants
            // 
            this.Txt_Participants.AutoSize = true;
            this.Txt_Participants.BackColor = System.Drawing.Color.Transparent;
            this.Txt_Participants.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Txt_Participants.Location = new System.Drawing.Point(290, 84);
            this.Txt_Participants.Name = "Txt_Participants";
            this.Txt_Participants.Size = new System.Drawing.Size(68, 13);
            this.Txt_Participants.TabIndex = 4;
            this.Txt_Participants.Text = "Participants :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(523, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Created by :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("SWRomnc", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(486, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Franck Yersin";
            // 
            // btn_Help
            // 
            this.btn_Help.Location = new System.Drawing.Point(540, 376);
            this.btn_Help.Name = "btn_Help";
            this.btn_Help.Size = new System.Drawing.Size(71, 36);
            this.btn_Help.TabIndex = 7;
            this.btn_Help.Text = "Help";
            this.btn_Help.UseVisualStyleBackColor = true;
            this.btn_Help.Click += new System.EventHandler(this.btn_Help_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::Tournoi_Echec.Properties.Resources.echec1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(623, 423);
            this.Controls.Add(this.btn_Help);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Txt_Participants);
            this.Controls.Add(this.BTN_LDD);
            this.Controls.Add(this.Label_NbRondes);
            this.Controls.Add(this.Nb_Rondes);
            this.Controls.Add(this.BTN_Demarrer_Tournoi);
            this.Name = "FormMain";
            this.Text = "Tournoi d\'échec - programme pour gérer un tournoi";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Nb_Rondes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_Demarrer_Tournoi;
        private System.Windows.Forms.NumericUpDown Nb_Rondes;
        private System.Windows.Forms.Label Label_NbRondes;
        private System.Windows.Forms.Button BTN_LDD;
        private System.Windows.Forms.Label Txt_Participants;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Help;
    }
}

