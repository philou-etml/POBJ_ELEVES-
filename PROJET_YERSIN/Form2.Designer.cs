namespace Tournoi_Echec
{
    partial class FormSub1
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
            this.BTN_Ronde_suivante = new System.Windows.Forms.Button();
            this.BTN_Classement_Int = new System.Windows.Forms.Button();
            this.DGW_Ronde1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTN_GenRondes = new System.Windows.Forms.Button();
            this.lbl_Rondes = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGW_Ronde1)).BeginInit();
            this.SuspendLayout();
            // 
            // BTN_Ronde_suivante
            // 
            this.BTN_Ronde_suivante.Location = new System.Drawing.Point(764, 545);
            this.BTN_Ronde_suivante.Name = "BTN_Ronde_suivante";
            this.BTN_Ronde_suivante.Size = new System.Drawing.Size(133, 47);
            this.BTN_Ronde_suivante.TabIndex = 1;
            this.BTN_Ronde_suivante.Text = "Ronde suivante";
            this.BTN_Ronde_suivante.UseVisualStyleBackColor = true;
            this.BTN_Ronde_suivante.Click += new System.EventHandler(this.BTN_Ronde_suivante_Click);
            // 
            // BTN_Classement_Int
            // 
            this.BTN_Classement_Int.Location = new System.Drawing.Point(764, 617);
            this.BTN_Classement_Int.Name = "BTN_Classement_Int";
            this.BTN_Classement_Int.Size = new System.Drawing.Size(133, 43);
            this.BTN_Classement_Int.TabIndex = 2;
            this.BTN_Classement_Int.Text = "Classement intermediaire";
            this.BTN_Classement_Int.UseVisualStyleBackColor = true;
            this.BTN_Classement_Int.Click += new System.EventHandler(this.BTN_Classement_Int_Click);
            // 
            // DGW_Ronde1
            // 
            this.DGW_Ronde1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGW_Ronde1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12});
            this.DGW_Ronde1.Location = new System.Drawing.Point(-2, 68);
            this.DGW_Ronde1.Name = "DGW_Ronde1";
            this.DGW_Ronde1.Size = new System.Drawing.Size(747, 592);
            this.DGW_Ronde1.TabIndex = 3;
            this.DGW_Ronde1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGW_Ronde1_CellContentClick);
            this.DGW_Ronde1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGW_Ronde1_CellEnter);
            this.DGW_Ronde1.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGW_Ronde1_CellLeave);
            this.DGW_Ronde1.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGW_Ronde1_CellMouseLeave);
            this.DGW_Ronde1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGW_Ronde1_CellValueChanged);
            this.DGW_Ronde1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGW_Ronde1_RowEnter);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Echiquier";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "n°";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 30;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Joueur :";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Titre";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 50;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Pts :";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 40;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "W";
            this.Column6.Name = "Column6";
            this.Column6.Width = 30;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "-";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 10;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "S";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 30;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "n°";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 30;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Joueur :";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 150;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Titre";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 50;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Pts :";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 40;
            // 
            // BTN_GenRondes
            // 
            this.BTN_GenRondes.Location = new System.Drawing.Point(764, 12);
            this.BTN_GenRondes.Name = "BTN_GenRondes";
            this.BTN_GenRondes.Size = new System.Drawing.Size(133, 47);
            this.BTN_GenRondes.TabIndex = 4;
            this.BTN_GenRondes.Text = "Générer la ronde";
            this.BTN_GenRondes.UseVisualStyleBackColor = true;
            this.BTN_GenRondes.Click += new System.EventHandler(this.BTN_GenRondes_Click);
            // 
            // lbl_Rondes
            // 
            this.lbl_Rondes.AutoSize = true;
            this.lbl_Rondes.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Rondes.Location = new System.Drawing.Point(231, 4);
            this.lbl_Rondes.Name = "lbl_Rondes";
            this.lbl_Rondes.Size = new System.Drawing.Size(283, 61);
            this.lbl_Rondes.TabIndex = 5;
            this.lbl_Rondes.Text = "Ronde n°1";
            this.lbl_Rondes.Click += new System.EventHandler(this.lbl_Rondes_Click);
            // 
            // FormSub1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(909, 672);
            this.Controls.Add(this.lbl_Rondes);
            this.Controls.Add(this.BTN_GenRondes);
            this.Controls.Add(this.DGW_Ronde1);
            this.Controls.Add(this.BTN_Classement_Int);
            this.Controls.Add(this.BTN_Ronde_suivante);
            this.Name = "FormSub1";
            this.Text = "Ronde";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSub1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.DGW_Ronde1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BTN_Ronde_suivante;
        private System.Windows.Forms.Button BTN_Classement_Int;
        private System.Windows.Forms.DataGridView DGW_Ronde1;
        private System.Windows.Forms.Button BTN_GenRondes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.Label lbl_Rondes;
    }
}