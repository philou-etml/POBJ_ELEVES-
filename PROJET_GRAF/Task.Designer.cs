namespace VManagment_BDD_V1
{
    partial class Task
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
            this.btnEnd = new System.Windows.Forms.Button();
            this.txtDescritpion = new System.Windows.Forms.TextBox();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.lblNom = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NudHstart = new System.Windows.Forms.NumericUpDown();
            this.NudmStart = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.NudmEnd = new System.Windows.Forms.NumericUpDown();
            this.NudHEnd = new System.Windows.Forms.NumericUpDown();
            this.NudVolNeeded = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.CBType = new System.Windows.Forms.ComboBox();
            this.cbDay = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NudHstart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudmStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudmEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudHEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudVolNeeded)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEnd
            // 
            this.btnEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnd.Location = new System.Drawing.Point(477, 181);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(120, 32);
            this.btnEnd.TabIndex = 76;
            this.btnEnd.Text = "Terminer";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // txtDescritpion
            // 
            this.txtDescritpion.Location = new System.Drawing.Point(100, 107);
            this.txtDescritpion.Name = "txtDescritpion";
            this.txtDescritpion.Size = new System.Drawing.Size(313, 20);
            this.txtDescritpion.TabIndex = 60;
            // 
            // lblPrenom
            // 
            this.lblPrenom.AutoSize = true;
            this.lblPrenom.Location = new System.Drawing.Point(28, 110);
            this.lblPrenom.Name = "lblPrenom";
            this.lblPrenom.Size = new System.Drawing.Size(66, 13);
            this.lblPrenom.TabIndex = 59;
            this.lblPrenom.Text = "Description :";
            // 
            // txtNom
            // 
            this.txtNom.BackColor = System.Drawing.Color.White;
            this.txtNom.ForeColor = System.Drawing.Color.Black;
            this.txtNom.Location = new System.Drawing.Point(100, 81);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(100, 20);
            this.txtNom.TabIndex = 58;
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(59, 84);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(35, 13);
            this.lblNom.TabIndex = 57;
            this.lblNom.Text = "Nom :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(124, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 31);
            this.label1.TabIndex = 56;
            this.label1.Text = "Ajouter une tâche :";
            // 
            // btnAjouter
            // 
            this.btnAjouter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouter.Location = new System.Drawing.Point(477, 86);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(120, 59);
            this.btnAjouter.TabIndex = 55;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 77;
            this.label2.Text = "Heure de début :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(275, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 78;
            this.label3.Text = "Heure de fin :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(275, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 13);
            this.label4.TabIndex = 79;
            this.label4.Text = "Nombre de bénévoles nécessaires :";
            // 
            // NudHstart
            // 
            this.NudHstart.Location = new System.Drawing.Point(31, 217);
            this.NudHstart.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.NudHstart.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudHstart.Name = "NudHstart";
            this.NudHstart.Size = new System.Drawing.Size(50, 20);
            this.NudHstart.TabIndex = 80;
            this.NudHstart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NudmStart
            // 
            this.NudmStart.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.NudmStart.Location = new System.Drawing.Point(111, 217);
            this.NudmStart.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.NudmStart.Name = "NudmStart";
            this.NudmStart.Size = new System.Drawing.Size(50, 20);
            this.NudmStart.TabIndex = 81;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(87, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 20);
            this.label5.TabIndex = 82;
            this.label5.Text = "h";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(334, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 20);
            this.label6.TabIndex = 85;
            this.label6.Text = "h";
            // 
            // NudmEnd
            // 
            this.NudmEnd.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.NudmEnd.Location = new System.Drawing.Point(358, 217);
            this.NudmEnd.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.NudmEnd.Name = "NudmEnd";
            this.NudmEnd.Size = new System.Drawing.Size(50, 20);
            this.NudmEnd.TabIndex = 84;
            // 
            // NudHEnd
            // 
            this.NudHEnd.Location = new System.Drawing.Point(278, 217);
            this.NudHEnd.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.NudHEnd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudHEnd.Name = "NudHEnd";
            this.NudHEnd.Size = new System.Drawing.Size(50, 20);
            this.NudHEnd.TabIndex = 83;
            this.NudHEnd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NudVolNeeded
            // 
            this.NudVolNeeded.Location = new System.Drawing.Point(278, 276);
            this.NudVolNeeded.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NudVolNeeded.Name = "NudVolNeeded";
            this.NudVolNeeded.Size = new System.Drawing.Size(50, 20);
            this.NudVolNeeded.TabIndex = 86;
            this.NudVolNeeded.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 87;
            this.label7.Text = "Type de  tâche :";
            // 
            // CBType
            // 
            this.CBType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBType.FormattingEnabled = true;
            this.CBType.Items.AddRange(new object[] {
            "Bars",
            "Restauration",
            "Animations",
            "Sécurité",
            "Montage",
            "Démontage",
            "Logistique"});
            this.CBType.Location = new System.Drawing.Point(101, 134);
            this.CBType.Name = "CBType";
            this.CBType.Size = new System.Drawing.Size(121, 21);
            this.CBType.TabIndex = 88;
            // 
            // cbDay
            // 
            this.cbDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDay.FormattingEnabled = true;
            this.cbDay.Items.AddRange(new object[] {
            "Jeudi",
            "Vendredi",
            "Samedi",
            "Dimanche",
            "Lundi",
            "Semaine Montage",
            "Semaine Démontage"});
            this.cbDay.Location = new System.Drawing.Point(31, 276);
            this.cbDay.Name = "cbDay";
            this.cbDay.Size = new System.Drawing.Size(121, 21);
            this.cbDay.TabIndex = 89;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 255);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 13);
            this.label8.TabIndex = 90;
            this.label8.Text = "Jour de la seamaine :";
            // 
            // Task
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 443);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbDay);
            this.Controls.Add(this.CBType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.NudVolNeeded);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.NudmEnd);
            this.Controls.Add(this.NudHEnd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.NudmStart);
            this.Controls.Add(this.NudHstart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.txtDescritpion);
            this.Controls.Add(this.lblPrenom);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAjouter);
            this.Name = "Task";
            this.Text = "AddTask";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Task_FormClosed);
            this.Shown += new System.EventHandler(this.Task_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.NudHstart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudmStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudmEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudHEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudVolNeeded)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.TextBox txtDescritpion;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NudHstart;
        private System.Windows.Forms.NumericUpDown NudmStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown NudmEnd;
        private System.Windows.Forms.NumericUpDown NudHEnd;
        private System.Windows.Forms.NumericUpDown NudVolNeeded;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CBType;
        private System.Windows.Forms.ComboBox cbDay;
        private System.Windows.Forms.Label label8;
    }
}