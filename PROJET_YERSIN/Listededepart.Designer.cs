namespace Tournoi_Echec
{
    partial class FormListededepart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormListededepart));
            this.btn_addition_joueur = new System.Windows.Forms.Button();
            this.btn_suppresion_joueur = new System.Windows.Forms.Button();
            this.btn_Tri_LDD = new System.Windows.Forms.Button();
            this.btn_save_config = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TXT_NAME = new System.Windows.Forms.TextBox();
            this.TXT_SURNAME = new System.Windows.Forms.TextBox();
            this.TXT_CLUB = new System.Windows.Forms.TextBox();
            this.TXT_ELO = new System.Windows.Forms.TextBox();
            this.DGV_LDD = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CBO_Titres = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_rl1 = new System.Windows.Forms.Label();
            this.lbl_rl2 = new System.Windows.Forms.Label();
            this.btn_random = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_LDD)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_addition_joueur
            // 
            this.btn_addition_joueur.Location = new System.Drawing.Point(166, 599);
            this.btn_addition_joueur.Name = "btn_addition_joueur";
            this.btn_addition_joueur.Size = new System.Drawing.Size(37, 33);
            this.btn_addition_joueur.TabIndex = 0;
            this.btn_addition_joueur.Text = "+";
            this.btn_addition_joueur.UseVisualStyleBackColor = true;
            this.btn_addition_joueur.Click += new System.EventHandler(this.btn_addition_joueur_Click);
            // 
            // btn_suppresion_joueur
            // 
            this.btn_suppresion_joueur.Location = new System.Drawing.Point(241, 599);
            this.btn_suppresion_joueur.Name = "btn_suppresion_joueur";
            this.btn_suppresion_joueur.Size = new System.Drawing.Size(37, 33);
            this.btn_suppresion_joueur.TabIndex = 1;
            this.btn_suppresion_joueur.Text = "-";
            this.btn_suppresion_joueur.UseVisualStyleBackColor = true;
            this.btn_suppresion_joueur.Click += new System.EventHandler(this.btn_suppresion_joueur_Click);
            // 
            // btn_Tri_LDD
            // 
            this.btn_Tri_LDD.Location = new System.Drawing.Point(366, 599);
            this.btn_Tri_LDD.Name = "btn_Tri_LDD";
            this.btn_Tri_LDD.Size = new System.Drawing.Size(77, 33);
            this.btn_Tri_LDD.TabIndex = 2;
            this.btn_Tri_LDD.Text = "Tri";
            this.btn_Tri_LDD.UseVisualStyleBackColor = true;
            this.btn_Tri_LDD.Click += new System.EventHandler(this.btn_Tri_LDD_Click);
            // 
            // btn_save_config
            // 
            this.btn_save_config.Location = new System.Drawing.Point(532, 585);
            this.btn_save_config.Name = "btn_save_config";
            this.btn_save_config.Size = new System.Drawing.Size(135, 67);
            this.btn_save_config.TabIndex = 3;
            this.btn_save_config.Text = "Enregistrer les modifications";
            this.btn_save_config.UseVisualStyleBackColor = true;
            this.btn_save_config.Click += new System.EventHandler(this.btn_save_config_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(598, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nom :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(598, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Prenom :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(599, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Club :";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(598, 289);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "ELO :";
            // 
            // TXT_NAME
            // 
            this.TXT_NAME.Location = new System.Drawing.Point(567, 88);
            this.TXT_NAME.Name = "TXT_NAME";
            this.TXT_NAME.Size = new System.Drawing.Size(100, 20);
            this.TXT_NAME.TabIndex = 9;
            this.TXT_NAME.TextChanged += new System.EventHandler(this.TXT_NAME_TextChanged);
            // 
            // TXT_SURNAME
            // 
            this.TXT_SURNAME.Location = new System.Drawing.Point(567, 161);
            this.TXT_SURNAME.Name = "TXT_SURNAME";
            this.TXT_SURNAME.Size = new System.Drawing.Size(100, 20);
            this.TXT_SURNAME.TabIndex = 10;
            this.TXT_SURNAME.TextChanged += new System.EventHandler(this.TXT_SURNAME_TextChanged);
            // 
            // TXT_CLUB
            // 
            this.TXT_CLUB.Location = new System.Drawing.Point(567, 243);
            this.TXT_CLUB.Name = "TXT_CLUB";
            this.TXT_CLUB.Size = new System.Drawing.Size(100, 20);
            this.TXT_CLUB.TabIndex = 11;
            this.TXT_CLUB.TextChanged += new System.EventHandler(this.TXT_CLUB_TextChanged);
            // 
            // TXT_ELO
            // 
            this.TXT_ELO.Location = new System.Drawing.Point(567, 310);
            this.TXT_ELO.Name = "TXT_ELO";
            this.TXT_ELO.Size = new System.Drawing.Size(100, 20);
            this.TXT_ELO.TabIndex = 12;
            this.TXT_ELO.TextChanged += new System.EventHandler(this.TXT_ELO_TextChanged);
            // 
            // DGV_LDD
            // 
            this.DGV_LDD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_LDD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.DGV_LDD.Location = new System.Drawing.Point(66, 62);
            this.DGV_LDD.Name = "DGV_LDD";
            this.DGV_LDD.Size = new System.Drawing.Size(495, 517);
            this.DGV_LDD.TabIndex = 13;
            this.DGV_LDD.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_LDD_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "N°";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 25;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Nom :";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 95;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Prenom :";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 95;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Club :";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 95;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "ELO :";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 80;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Titre :";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 60;
            // 
            // CBO_Titres
            // 
            this.CBO_Titres.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBO_Titres.FormattingEnabled = true;
            this.CBO_Titres.Items.AddRange(new object[] {
            " ",
            "GM",
            "IM",
            "FM"});
            this.CBO_Titres.Location = new System.Drawing.Point(567, 391);
            this.CBO_Titres.Name = "CBO_Titres";
            this.CBO_Titres.Size = new System.Drawing.Size(100, 21);
            this.CBO_Titres.TabIndex = 14;
            this.CBO_Titres.SelectedIndexChanged += new System.EventHandler(this.CBO_Titres_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(598, 364);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Titre :";
            // 
            // lbl_rl1
            // 
            this.lbl_rl1.AutoSize = true;
            this.lbl_rl1.Location = new System.Drawing.Point(587, 438);
            this.lbl_rl1.Name = "lbl_rl1";
            this.lbl_rl1.Size = new System.Drawing.Size(72, 13);
            this.lbl_rl1.TabIndex = 16;
            this.lbl_rl1.Text = "Random Liste";
            // 
            // lbl_rl2
            // 
            this.lbl_rl2.AutoSize = true;
            this.lbl_rl2.Location = new System.Drawing.Point(587, 451);
            this.lbl_rl2.Name = "lbl_rl2";
            this.lbl_rl2.Size = new System.Drawing.Size(59, 13);
            this.lbl_rl2.TabIndex = 17;
            this.lbl_rl2.Text = "pour le test";
            // 
            // btn_random
            // 
            this.btn_random.Location = new System.Drawing.Point(568, 467);
            this.btn_random.Name = "btn_random";
            this.btn_random.Size = new System.Drawing.Size(99, 40);
            this.btn_random.TabIndex = 18;
            this.btn_random.Text = "Random Liste";
            this.btn_random.UseVisualStyleBackColor = true;
            this.btn_random.Click += new System.EventHandler(this.btn_random_Click);
            // 
            // FormListededepart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(743, 730);
            this.Controls.Add(this.btn_random);
            this.Controls.Add(this.lbl_rl2);
            this.Controls.Add(this.lbl_rl1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CBO_Titres);
            this.Controls.Add(this.DGV_LDD);
            this.Controls.Add(this.TXT_ELO);
            this.Controls.Add(this.TXT_CLUB);
            this.Controls.Add(this.TXT_SURNAME);
            this.Controls.Add(this.TXT_NAME);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_save_config);
            this.Controls.Add(this.btn_Tri_LDD);
            this.Controls.Add(this.btn_suppresion_joueur);
            this.Controls.Add(this.btn_addition_joueur);
            this.Name = "FormListededepart";
            this.Text = "Liste de depart";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormListededepart_FormClosing);
            this.Load += new System.EventHandler(this.Listededepart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_LDD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_addition_joueur;
        private System.Windows.Forms.Button btn_suppresion_joueur;
        private System.Windows.Forms.Button btn_Tri_LDD;
        private System.Windows.Forms.Button btn_save_config;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TXT_NAME;
        private System.Windows.Forms.TextBox TXT_SURNAME;
        private System.Windows.Forms.TextBox TXT_CLUB;
        private System.Windows.Forms.TextBox TXT_ELO;
        private System.Windows.Forms.DataGridView DGV_LDD;
        private System.Windows.Forms.ComboBox CBO_Titres;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Label lbl_rl1;
        private System.Windows.Forms.Label lbl_rl2;
        private System.Windows.Forms.Button btn_random;
    }
}