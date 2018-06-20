namespace ProjetPlanning
{
    partial class Form1
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
            this.btnSave = new System.Windows.Forms.Button();
            this.cbCuisine = new System.Windows.Forms.CheckBox();
            this.rbHomme = new System.Windows.Forms.RadioButton();
            this.rbFemme = new System.Windows.Forms.RadioButton();
            this.lblTitre = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.tbPrenom = new System.Windows.Forms.TextBox();
            this.lblInscrits = new System.Windows.Forms.Label();
            this.cbPrésident = new System.Windows.Forms.CheckBox();
            this.cbCaissier = new System.Windows.Forms.CheckBox();
            this.btnGeneration = new System.Windows.Forms.Button();
            this.lblNbrInscrits = new System.Windows.Forms.Label();
            this.lblCuisiniers = new System.Windows.Forms.Label();
            this.lblNbrCuisiniers = new System.Windows.Forms.Label();
            this.cbExperience = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(245, 237);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Enregistrer";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbCuisine
            // 
            this.cbCuisine.AutoSize = true;
            this.cbCuisine.Location = new System.Drawing.Point(192, 52);
            this.cbCuisine.Name = "cbCuisine";
            this.cbCuisine.Size = new System.Drawing.Size(60, 17);
            this.cbCuisine.TabIndex = 1;
            this.cbCuisine.Text = "Cuisine";
            this.cbCuisine.UseVisualStyleBackColor = true;
            // 
            // rbHomme
            // 
            this.rbHomme.AutoSize = true;
            this.rbHomme.Checked = true;
            this.rbHomme.Location = new System.Drawing.Point(29, 174);
            this.rbHomme.Name = "rbHomme";
            this.rbHomme.Size = new System.Drawing.Size(61, 17);
            this.rbHomme.TabIndex = 2;
            this.rbHomme.TabStop = true;
            this.rbHomme.Text = "Homme";
            this.rbHomme.UseVisualStyleBackColor = true;
            // 
            // rbFemme
            // 
            this.rbFemme.AutoSize = true;
            this.rbFemme.Location = new System.Drawing.Point(29, 198);
            this.rbFemme.Name = "rbFemme";
            this.rbFemme.Size = new System.Drawing.Size(59, 17);
            this.rbFemme.TabIndex = 3;
            this.rbFemme.Text = "Femme";
            this.rbFemme.UseVisualStyleBackColor = true;
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitre.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblTitre.Location = new System.Drawing.Point(145, 9);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(78, 20);
            this.lblTitre.TabIndex = 6;
            this.lblTitre.Text = "Planning";
            this.lblTitre.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(26, 104);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(29, 13);
            this.lblNom.TabIndex = 7;
            this.lblNom.Text = "Nom";
            // 
            // lblPrenom
            // 
            this.lblPrenom.AutoSize = true;
            this.lblPrenom.Location = new System.Drawing.Point(194, 104);
            this.lblPrenom.Name = "lblPrenom";
            this.lblPrenom.Size = new System.Drawing.Size(43, 13);
            this.lblPrenom.TabIndex = 8;
            this.lblPrenom.Text = "Prénom";
            // 
            // tbNom
            // 
            this.tbNom.Location = new System.Drawing.Point(29, 130);
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(134, 20);
            this.tbNom.TabIndex = 9;
            // 
            // tbPrenom
            // 
            this.tbPrenom.Location = new System.Drawing.Point(197, 130);
            this.tbPrenom.Name = "tbPrenom";
            this.tbPrenom.Size = new System.Drawing.Size(133, 20);
            this.tbPrenom.TabIndex = 10;
            // 
            // lblInscrits
            // 
            this.lblInscrits.AutoSize = true;
            this.lblInscrits.Location = new System.Drawing.Point(26, 285);
            this.lblInscrits.Name = "lblInscrits";
            this.lblInscrits.Size = new System.Drawing.Size(49, 13);
            this.lblInscrits.TabIndex = 12;
            this.lblInscrits.Text = "Inscrits : ";
            // 
            // cbPrésident
            // 
            this.cbPrésident.AutoSize = true;
            this.cbPrésident.Checked = true;
            this.cbPrésident.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPrésident.Location = new System.Drawing.Point(29, 52);
            this.cbPrésident.Name = "cbPrésident";
            this.cbPrésident.Size = new System.Drawing.Size(70, 17);
            this.cbPrésident.TabIndex = 13;
            this.cbPrésident.Text = "Président";
            this.cbPrésident.UseVisualStyleBackColor = true;
            // 
            // cbCaissier
            // 
            this.cbCaissier.AutoSize = true;
            this.cbCaissier.Location = new System.Drawing.Point(29, 75);
            this.cbCaissier.Name = "cbCaissier";
            this.cbCaissier.Size = new System.Drawing.Size(62, 17);
            this.cbCaissier.TabIndex = 14;
            this.cbCaissier.Text = "Caissier";
            this.cbCaissier.UseVisualStyleBackColor = true;
            // 
            // btnGeneration
            // 
            this.btnGeneration.Enabled = false;
            this.btnGeneration.Location = new System.Drawing.Point(245, 275);
            this.btnGeneration.Name = "btnGeneration";
            this.btnGeneration.Size = new System.Drawing.Size(75, 23);
            this.btnGeneration.TabIndex = 15;
            this.btnGeneration.Text = "Générer";
            this.btnGeneration.UseVisualStyleBackColor = true;
            this.btnGeneration.Click += new System.EventHandler(this.btnGeneration_Click);
            // 
            // lblNbrInscrits
            // 
            this.lblNbrInscrits.AutoSize = true;
            this.lblNbrInscrits.Location = new System.Drawing.Point(81, 285);
            this.lblNbrInscrits.Name = "lblNbrInscrits";
            this.lblNbrInscrits.Size = new System.Drawing.Size(13, 13);
            this.lblNbrInscrits.TabIndex = 16;
            this.lblNbrInscrits.Text = "0";
            // 
            // lblCuisiniers
            // 
            this.lblCuisiniers.AutoSize = true;
            this.lblCuisiniers.Location = new System.Drawing.Point(26, 252);
            this.lblCuisiniers.Name = "lblCuisiniers";
            this.lblCuisiniers.Size = new System.Drawing.Size(58, 13);
            this.lblCuisiniers.TabIndex = 17;
            this.lblCuisiniers.Text = "Cusiniers : ";
            // 
            // lblNbrCuisiniers
            // 
            this.lblNbrCuisiniers.AutoSize = true;
            this.lblNbrCuisiniers.Location = new System.Drawing.Point(90, 252);
            this.lblNbrCuisiniers.Name = "lblNbrCuisiniers";
            this.lblNbrCuisiniers.Size = new System.Drawing.Size(13, 13);
            this.lblNbrCuisiniers.TabIndex = 18;
            this.lblNbrCuisiniers.Text = "0";
            // 
            // cbExperience
            // 
            this.cbExperience.AutoSize = true;
            this.cbExperience.Location = new System.Drawing.Point(192, 75);
            this.cbExperience.Name = "cbExperience";
            this.cbExperience.Size = new System.Drawing.Size(120, 17);
            this.cbExperience.TabIndex = 19;
            this.cbExperience.Text = "Expérience (+2 ans)";
            this.cbExperience.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 337);
            this.Controls.Add(this.cbExperience);
            this.Controls.Add(this.lblNbrCuisiniers);
            this.Controls.Add(this.lblCuisiniers);
            this.Controls.Add(this.lblNbrInscrits);
            this.Controls.Add(this.btnGeneration);
            this.Controls.Add(this.cbCaissier);
            this.Controls.Add(this.cbPrésident);
            this.Controls.Add(this.lblInscrits);
            this.Controls.Add(this.tbPrenom);
            this.Controls.Add(this.tbNom);
            this.Controls.Add(this.lblPrenom);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.rbFemme);
            this.Controls.Add(this.rbHomme);
            this.Controls.Add(this.cbCuisine);
            this.Controls.Add(this.btnSave);
            this.Name = "Form1";
            this.Text = "Planning";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox cbCuisine;
        private System.Windows.Forms.RadioButton rbHomme;
        private System.Windows.Forms.RadioButton rbFemme;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.TextBox tbNom;
        private System.Windows.Forms.TextBox tbPrenom;
        private System.Windows.Forms.Label lblInscrits;
        private System.Windows.Forms.CheckBox cbPrésident;
        private System.Windows.Forms.Button btnGeneration;
        private System.Windows.Forms.CheckBox cbCaissier;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblNbrInscrits;
        private System.Windows.Forms.Label lblCuisiniers;
        private System.Windows.Forms.Label lblNbrCuisiniers;
        private System.Windows.Forms.CheckBox cbExperience;
    }
}

