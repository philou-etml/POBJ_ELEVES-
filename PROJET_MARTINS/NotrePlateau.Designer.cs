namespace Projet_Bataille_Navale
{
    partial class NotrePlateau
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotrePlateau));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl1 = new System.Windows.Forms.Label();
            this.PorteAvion = new System.Windows.Forms.PictureBox();
            this.Croiseur = new System.Windows.Forms.PictureBox();
            this.ContreTorpilleur = new System.Windows.Forms.PictureBox();
            this.SousMarin = new System.Windows.Forms.PictureBox();
            this.Torpilleur = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnLock = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PorteAvion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Croiseur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContreTorpilleur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SousMarin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Torpilleur)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Location = new System.Drawing.Point(43, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 484);
            this.panel1.TabIndex = 0;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(538, 45);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(35, 13);
            this.lbl1.TabIndex = 1;
            this.lbl1.Text = "label1";
            // 
            // PorteAvion
            // 
            this.PorteAvion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PorteAvion.Image = ((System.Drawing.Image)(resources.GetObject("PorteAvion.Image")));
            this.PorteAvion.Location = new System.Drawing.Point(541, 89);
            this.PorteAvion.Name = "PorteAvion";
            this.PorteAvion.Size = new System.Drawing.Size(211, 44);
            this.PorteAvion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PorteAvion.TabIndex = 0;
            this.PorteAvion.TabStop = false;
            this.PorteAvion.Click += new System.EventHandler(this.PorteAvion_Click);
            this.PorteAvion.DragDrop += new System.Windows.Forms.DragEventHandler(this.PorteAvion_DragDrop);
            this.PorteAvion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PorteAvion_MouseDown);
            this.PorteAvion.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PorteAvion_MouseMove);
            this.PorteAvion.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PorteAvion_MouseUp);
            // 
            // Croiseur
            // 
            this.Croiseur.BackColor = System.Drawing.Color.White;
            this.Croiseur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Croiseur.Image = ((System.Drawing.Image)(resources.GetObject("Croiseur.Image")));
            this.Croiseur.Location = new System.Drawing.Point(541, 160);
            this.Croiseur.Name = "Croiseur";
            this.Croiseur.Size = new System.Drawing.Size(169, 44);
            this.Croiseur.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Croiseur.TabIndex = 1;
            this.Croiseur.TabStop = false;
            this.Croiseur.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Croiseur_MouseDown);
            this.Croiseur.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Croiseur_MouseUp);
            // 
            // ContreTorpilleur
            // 
            this.ContreTorpilleur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ContreTorpilleur.Image = ((System.Drawing.Image)(resources.GetObject("ContreTorpilleur.Image")));
            this.ContreTorpilleur.Location = new System.Drawing.Point(541, 230);
            this.ContreTorpilleur.Name = "ContreTorpilleur";
            this.ContreTorpilleur.Size = new System.Drawing.Size(127, 45);
            this.ContreTorpilleur.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ContreTorpilleur.TabIndex = 2;
            this.ContreTorpilleur.TabStop = false;
            this.ContreTorpilleur.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ContreTorpilleur_MouseDown);
            this.ContreTorpilleur.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ContreTorpilleur_MouseUp);
            // 
            // SousMarin
            // 
            this.SousMarin.BackColor = System.Drawing.Color.White;
            this.SousMarin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SousMarin.Image = ((System.Drawing.Image)(resources.GetObject("SousMarin.Image")));
            this.SousMarin.Location = new System.Drawing.Point(541, 308);
            this.SousMarin.Name = "SousMarin";
            this.SousMarin.Size = new System.Drawing.Size(127, 45);
            this.SousMarin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SousMarin.TabIndex = 3;
            this.SousMarin.TabStop = false;
            this.SousMarin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SousMarin_MouseDown);
            this.SousMarin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SousMarin_MouseUp);
            // 
            // Torpilleur
            // 
            this.Torpilleur.BackColor = System.Drawing.Color.White;
            this.Torpilleur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Torpilleur.Image = ((System.Drawing.Image)(resources.GetObject("Torpilleur.Image")));
            this.Torpilleur.Location = new System.Drawing.Point(541, 381);
            this.Torpilleur.Name = "Torpilleur";
            this.Torpilleur.Size = new System.Drawing.Size(85, 45);
            this.Torpilleur.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Torpilleur.TabIndex = 4;
            this.Torpilleur.TabStop = false;
            this.Torpilleur.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Torpilleur_MouseDown);
            this.Torpilleur.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Torpilleur_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnLock
            // 
            this.btnLock.Location = new System.Drawing.Point(586, 483);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(124, 46);
            this.btnLock.TabIndex = 5;
            this.btnLock.Text = "button1";
            this.btnLock.UseVisualStyleBackColor = true;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // NotrePlateau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 595);
            this.Controls.Add(this.btnLock);
            this.Controls.Add(this.Torpilleur);
            this.Controls.Add(this.ContreTorpilleur);
            this.Controls.Add(this.SousMarin);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.Croiseur);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PorteAvion);
            this.Name = "NotrePlateau";
            this.Text = "Plateau de jeu";
            this.LocationChanged += new System.EventHandler(this.NotrePlateau_LocationChanged);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NotrePlateau_KeyPress);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NotrePlateau_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.PorteAvion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Croiseur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContreTorpilleur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SousMarin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Torpilleur)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.PictureBox PorteAvion;
        private System.Windows.Forms.PictureBox SousMarin;
        private System.Windows.Forms.PictureBox ContreTorpilleur;
        private System.Windows.Forms.PictureBox Croiseur;
        private System.Windows.Forms.PictureBox Torpilleur;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnLock;
    }
}

