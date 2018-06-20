namespace Tournoi_Echec
{
    partial class Classement
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_ShowClassement = new System.Windows.Forms.Button();
            this.btn_ShowClassementDetaille = new System.Windows.Forms.Button();
            this.btn_csv1 = new System.Windows.Forms.Button();
            this.lbl_classement = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column12,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11});
            this.dataGridView1.Location = new System.Drawing.Point(12, 83);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(857, 553);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Pos :";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 60;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "N°";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 50;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Joueur :";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Club :";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "ELO :";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 70;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Titre";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 55;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "V";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 30;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "N";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 30;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "P";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 30;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Pts :";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 60;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Bucch:";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 60;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "SoBerg :";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 60;
            // 
            // btn_ShowClassement
            // 
            this.btn_ShowClassement.Location = new System.Drawing.Point(909, 12);
            this.btn_ShowClassement.Name = "btn_ShowClassement";
            this.btn_ShowClassement.Size = new System.Drawing.Size(252, 54);
            this.btn_ShowClassement.TabIndex = 1;
            this.btn_ShowClassement.Text = "Voir le classement";
            this.btn_ShowClassement.UseVisualStyleBackColor = true;
            this.btn_ShowClassement.Click += new System.EventHandler(this.btn_ShowClassement_Click);
            // 
            // btn_ShowClassementDetaille
            // 
            this.btn_ShowClassementDetaille.Location = new System.Drawing.Point(910, 83);
            this.btn_ShowClassementDetaille.Name = "btn_ShowClassementDetaille";
            this.btn_ShowClassementDetaille.Size = new System.Drawing.Size(251, 54);
            this.btn_ShowClassementDetaille.TabIndex = 2;
            this.btn_ShowClassementDetaille.Text = "Voir classement détaillé";
            this.btn_ShowClassementDetaille.UseVisualStyleBackColor = true;
            this.btn_ShowClassementDetaille.Click += new System.EventHandler(this.btn_ShowClassementDetaille_Click);
            // 
            // btn_csv1
            // 
            this.btn_csv1.Location = new System.Drawing.Point(911, 583);
            this.btn_csv1.Name = "btn_csv1";
            this.btn_csv1.Size = new System.Drawing.Size(250, 53);
            this.btn_csv1.TabIndex = 3;
            this.btn_csv1.Text = "Extraire sous fichier csv";
            this.btn_csv1.UseVisualStyleBackColor = true;
            this.btn_csv1.Click += new System.EventHandler(this.btn_csv1_Click);
            // 
            // lbl_classement
            // 
            this.lbl_classement.AutoSize = true;
            this.lbl_classement.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_classement.Location = new System.Drawing.Point(292, 5);
            this.lbl_classement.Name = "lbl_classement";
            this.lbl_classement.Size = new System.Drawing.Size(315, 61);
            this.lbl_classement.TabIndex = 4;
            this.lbl_classement.Text = "Classement";
            // 
            // Classement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 648);
            this.Controls.Add(this.lbl_classement);
            this.Controls.Add(this.btn_csv1);
            this.Controls.Add(this.btn_ShowClassementDetaille);
            this.Controls.Add(this.btn_ShowClassement);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Classement";
            this.Text = "Classement";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_ShowClassement;
        private System.Windows.Forms.Button btn_ShowClassementDetaille;
        private System.Windows.Forms.Button btn_csv1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.Label lbl_classement;
    }
}