namespace VManagment_BDD_V1
{
    partial class dgvDataBase
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
            this.btnAjouter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnModif = new System.Windows.Forms.Button();
            this.btnSupr = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.DGVBenevoles = new System.Windows.Forms.DataGridView();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prenom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Addresse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelShadowVolunteer = new System.Windows.Forms.Button();
            this.btnDelShadowTask = new System.Windows.Forms.Button();
            this.DGVTask = new System.Windows.Forms.DataGridView();
            this.txtSearchTask = new System.Windows.Forms.TextBox();
            this.btnSearchTask = new System.Windows.Forms.Button();
            this.btnDeleteTask = new System.Windows.Forms.Button();
            this.btnChangeTask = new System.Windows.Forms.Button();
            this.btnRefreshTask = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVBenevoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTask)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(41, 48);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(75, 23);
            this.btnAjouter.TabIndex = 0;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ajouter un bénévole :";
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(590, 475);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(65, 23);
            this.btnRefresh.TabIndex = 22;
            this.btnRefresh.Text = "Rafraîchir";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnModif
            // 
            this.btnModif.Location = new System.Drawing.Point(41, 116);
            this.btnModif.Name = "btnModif";
            this.btnModif.Size = new System.Drawing.Size(127, 23);
            this.btnModif.TabIndex = 23;
            this.btnModif.Text = "Modifier le bénévole";
            this.btnModif.UseVisualStyleBackColor = true;
            this.btnModif.Click += new System.EventHandler(this.btnModif_Click);
            // 
            // btnSupr
            // 
            this.btnSupr.Location = new System.Drawing.Point(180, 116);
            this.btnSupr.Name = "btnSupr";
            this.btnSupr.Size = new System.Drawing.Size(127, 23);
            this.btnSupr.TabIndex = 24;
            this.btnSupr.Text = "Supprimer le bénévole";
            this.btnSupr.UseVisualStyleBackColor = true;
            this.btnSupr.Click += new System.EventHandler(this.btnSupr_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(323, 116);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(138, 23);
            this.btnSearch.TabIndex = 25;
            this.btnSearch.Text = "Rechercher dans la liste :";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(467, 118);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 20);
            this.txtSearch.TabIndex = 26;
            // 
            // DGVBenevoles
            // 
            this.DGVBenevoles.AllowUserToAddRows = false;
            this.DGVBenevoles.AllowUserToDeleteRows = false;
            this.DGVBenevoles.AllowUserToOrderColumns = true;
            this.DGVBenevoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVBenevoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Num,
            this.Prenom,
            this.Nom,
            this.Tel,
            this.Email,
            this.Age,
            this.Addresse});
            this.DGVBenevoles.Location = new System.Drawing.Point(41, 156);
            this.DGVBenevoles.Name = "DGVBenevoles";
            this.DGVBenevoles.Size = new System.Drawing.Size(819, 299);
            this.DGVBenevoles.TabIndex = 28;
            // 
            // Num
            // 
            this.Num.HeaderText = "N°";
            this.Num.Name = "Num";
            this.Num.ReadOnly = true;
            this.Num.Width = 40;
            // 
            // Prenom
            // 
            this.Prenom.HeaderText = "Prénom";
            this.Prenom.Name = "Prenom";
            this.Prenom.ReadOnly = true;
            // 
            // Nom
            // 
            this.Nom.HeaderText = "Nom";
            this.Nom.Name = "Nom";
            this.Nom.ReadOnly = true;
            // 
            // Tel
            // 
            this.Tel.HeaderText = "Téléphone";
            this.Tel.Name = "Tel";
            this.Tel.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.HeaderText = "e-mail";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 150;
            // 
            // Age
            // 
            this.Age.HeaderText = "Age";
            this.Age.Name = "Age";
            this.Age.ReadOnly = true;
            this.Age.Width = 35;
            // 
            // Addresse
            // 
            this.Addresse.HeaderText = "Addresse";
            this.Addresse.Name = "Addresse";
            this.Addresse.ReadOnly = true;
            this.Addresse.Width = 250;
            // 
            // btnDelShadowVolunteer
            // 
            this.btnDelShadowVolunteer.Location = new System.Drawing.Point(114, 475);
            this.btnDelShadowVolunteer.Name = "btnDelShadowVolunteer";
            this.btnDelShadowVolunteer.Size = new System.Drawing.Size(174, 23);
            this.btnDelShadowVolunteer.TabIndex = 30;
            this.btnDelShadowVolunteer.Text = "Redistribuer les N°";
            this.btnDelShadowVolunteer.UseVisualStyleBackColor = true;
            this.btnDelShadowVolunteer.Click += new System.EventHandler(this.btnDelShadowVolunteer_Click);
            // 
            // btnDelShadowTask
            // 
            this.btnDelShadowTask.Location = new System.Drawing.Point(1018, 475);
            this.btnDelShadowTask.Name = "btnDelShadowTask";
            this.btnDelShadowTask.Size = new System.Drawing.Size(174, 23);
            this.btnDelShadowTask.TabIndex = 39;
            this.btnDelShadowTask.Text = "Redistribuer les N°";
            this.btnDelShadowTask.UseVisualStyleBackColor = true;
            this.btnDelShadowTask.Click += new System.EventHandler(this.btnDelShadowTask_Click);
            // 
            // DGVTask
            // 
            this.DGVTask.AllowUserToAddRows = false;
            this.DGVTask.AllowUserToDeleteRows = false;
            this.DGVTask.AllowUserToOrderColumns = true;
            this.DGVTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVTask.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Column1,
            this.dataGridViewTextBoxColumn3,
            this.Column2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.DGVTask.Location = new System.Drawing.Point(945, 156);
            this.DGVTask.Name = "DGVTask";
            this.DGVTask.Size = new System.Drawing.Size(904, 299);
            this.DGVTask.TabIndex = 38;
            // 
            // txtSearchTask
            // 
            this.txtSearchTask.Location = new System.Drawing.Point(1371, 118);
            this.txtSearchTask.Name = "txtSearchTask";
            this.txtSearchTask.Size = new System.Drawing.Size(100, 20);
            this.txtSearchTask.TabIndex = 37;
            // 
            // btnSearchTask
            // 
            this.btnSearchTask.Location = new System.Drawing.Point(1227, 116);
            this.btnSearchTask.Name = "btnSearchTask";
            this.btnSearchTask.Size = new System.Drawing.Size(138, 23);
            this.btnSearchTask.TabIndex = 36;
            this.btnSearchTask.Text = "Rechercher dans la liste :";
            this.btnSearchTask.UseVisualStyleBackColor = true;
            this.btnSearchTask.Click += new System.EventHandler(this.btnSearchTask_Click);
            // 
            // btnDeleteTask
            // 
            this.btnDeleteTask.Location = new System.Drawing.Point(1084, 116);
            this.btnDeleteTask.Name = "btnDeleteTask";
            this.btnDeleteTask.Size = new System.Drawing.Size(127, 23);
            this.btnDeleteTask.TabIndex = 35;
            this.btnDeleteTask.Text = "Supprimer une tâche";
            this.btnDeleteTask.UseVisualStyleBackColor = true;
            this.btnDeleteTask.Click += new System.EventHandler(this.btnDeleteTask_Click);
            // 
            // btnChangeTask
            // 
            this.btnChangeTask.Location = new System.Drawing.Point(945, 116);
            this.btnChangeTask.Name = "btnChangeTask";
            this.btnChangeTask.Size = new System.Drawing.Size(127, 23);
            this.btnChangeTask.TabIndex = 34;
            this.btnChangeTask.Text = "Modifier une tâche";
            this.btnChangeTask.UseVisualStyleBackColor = true;
            this.btnChangeTask.Click += new System.EventHandler(this.btnChangeTask_Click);
            // 
            // btnRefreshTask
            // 
            this.btnRefreshTask.Location = new System.Drawing.Point(1494, 475);
            this.btnRefreshTask.Name = "btnRefreshTask";
            this.btnRefreshTask.Size = new System.Drawing.Size(65, 23);
            this.btnRefreshTask.TabIndex = 33;
            this.btnRefreshTask.Text = "Rafraîchir";
            this.btnRefreshTask.UseVisualStyleBackColor = true;
            this.btnRefreshTask.Click += new System.EventHandler(this.btnRefreshTask_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(932, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Ajouter une tâche:";
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(945, 48);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(75, 23);
            this.btnAddTask.TabIndex = 31;
            this.btnAddTask.Text = "Ajouter";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(783, 527);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(223, 69);
            this.button7.TabIndex = 40;
            this.button7.Text = "Compiler";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "N°";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Nom";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Type";
            this.Column1.Name = "Column1";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Nbr De bénévoles";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Jour/semaine";
            this.Column2.Name = "Column2";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Horaires";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Description";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 270;
            // 
            // dgvDataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1917, 622);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.btnDelShadowTask);
            this.Controls.Add(this.DGVTask);
            this.Controls.Add(this.txtSearchTask);
            this.Controls.Add(this.btnSearchTask);
            this.Controls.Add(this.btnDeleteTask);
            this.Controls.Add(this.btnChangeTask);
            this.Controls.Add(this.btnRefreshTask);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.btnDelShadowVolunteer);
            this.Controls.Add(this.DGVBenevoles);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnSupr);
            this.Controls.Add(this.btnModif);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAjouter);
            this.Name = "dgvDataBase";
            this.Text = "Volounteer Managment V1";
            this.Shown += new System.EventHandler(this.dgvDataBase_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVBenevoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTask)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Label label1;
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnSupr;
        private System.Windows.Forms.Button btnModif;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView DGVBenevoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prenom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewTextBoxColumn Addresse;
        private System.Windows.Forms.Button btnDelShadowVolunteer;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btnDelShadowTask;
        private System.Windows.Forms.DataGridView DGVTask;
        private System.Windows.Forms.TextBox txtSearchTask;
        private System.Windows.Forms.Button btnSearchTask;
        private System.Windows.Forms.Button btnDeleteTask;
        private System.Windows.Forms.Button btnChangeTask;
        private System.Windows.Forms.Button btnRefreshTask;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}

