using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetPlanning
{
    public partial class DemandePlanning : Form
    {
        //Variable pour faire avancer les jour
        public int jour = 0;
        //Variable des totaux à afficher
        public int totalDim, totalT1, totalT2;

        //objet où enregistrer les informations
        Planning vendredi = new Planning();

        Planning samedi = new Planning();

        Planning dimanche = new Planning();

        Planning lundi = new Planning();

        public DemandePlanning()
        {
            InitializeComponent();
        }
        //Méthode pour reprendre les informations dans le Form1
        public int GetParam(ref Planning jour1, ref Planning jour2, ref Planning jour3, ref Planning jour4)
        {
            int total;

            jour1 = vendredi;
            jour2 = samedi;
            jour3 = dimanche;
            jour4 = lundi;

            //Contrôle le nombre maximum de personne nécessaire pour le planning
            if(totalT1 >= totalT2)
            {
                if (totalT1 >= totalDim)
                {
                    total = totalT1;
                }
                else
                {
                    total = totalDim;
                }
            }
            else
            {
                if(totalT2 >= totalDim)
                {
                    total = totalT2;
                }
                else
                {
                    total = totalDim;
                }
            }
            //Retourne le nombre de personne que l'on a besoin
            return total;
        }

        //Si on clique sur le bouton "suivant"
        private void btnSuivant_Click(object sender, EventArgs e)
        {
            switch(jour)
            {
                //vendredi
                case 0:
                    //Sauvegarde les informations
                    vendredi.cantine_T1 = (int)nudCantineTranche1.Value;
                    vendredi.cantine_T2 = (int)nudCantineTranche2.Value;

                    vendredi.saucisse_T1 = (int)nudSaucisseTranche1.Value;
                    vendredi.saucisse_T2 = (int)nudSaucisseTranche2.Value;

                    vendredi.pompier_T1 = (int)nudPompierTranche1.Value;
                    vendredi.pompier_T2 = (int)nudPompierTranche2.Value;

                    vendredi.parc_T1 = (int)nudParcTranche1.Value;
                    vendredi.parc_T2 = (int)nudParcTranche2.Value;

                    vendredi.cave_T1 = (int)nudCaveTranche1.Value;
                    vendredi.cave_T2 = (int)nudCaveTranche2.Value;

                    vendredi.rav_T1 = (int)nudRavTranche1.Value;
                    vendredi.rav_T2 = (int)nudRavTranche2.Value;

                    //Passe au jour suivant
                    lblJour.Text = "Samedi";
                    break;
                //samedi
                case 1:
                    //Sauvegarde les informations
                    samedi.cantine_T1 = (int)nudCantineTranche1.Value;
                    samedi.cantine_T2 = (int)nudCantineTranche2.Value;

                    samedi.saucisse_T1 = (int)nudSaucisseTranche1.Value;
                    samedi.saucisse_T2 = (int)nudSaucisseTranche2.Value;

                    samedi.pompier_T1 = (int)nudPompierTranche1.Value;
                    samedi.pompier_T2 = (int)nudPompierTranche2.Value;

                    samedi.parc_T1 = (int)nudParcTranche1.Value;
                    samedi.parc_T2 = (int)nudParcTranche2.Value;

                    samedi.cave_T1 = (int)nudCaveTranche1.Value;
                    samedi.cave_T2 = (int)nudCaveTranche2.Value;

                    samedi.rav_T1 = (int)nudRavTranche1.Value;
                    samedi.rav_T2 = (int)nudRavTranche2.Value;

                    //Passe au jour suivant
                    lblJour.Text = "Dimanche";

                    //Active les tranches de l'après midi
                    nudCantineDim.Enabled = true;
                    nudCantineDim.Value = 2;
                    nudSaucisseDim.Enabled = true;
                    nudSaucisseDim.Value = 2;
                    nudCaveDim.Enabled = true;
                    nudCaveDim.Value = 2;
                    nudRavDim.Enabled = true;
                    nudRavDim.Value = 1;

                    //Texte horaire
                    lblDimanche.Text = "15:00 - 20:00";

                    //Désactive les tranches non utilisées du dimanche
                    nudParcTranche1.Value = 0;
                    nudParcTranche1.Enabled = false;
                    nudParcTranche2.Value = 0;
                    nudParcTranche2.Enabled = false;

                    nudSaucisseTranche2.Value = 0;
                    nudSaucisseTranche2.Enabled = false;
                    
                    break;

                //Dimanche
                case 2:
                    //Sauvegarde les informations
                    dimanche.cantine_T1 = (int)nudCantineTranche1.Value;
                    dimanche.cantine_T2 = (int)nudCantineTranche2.Value;
                    dimanche.cantine_DIM = (int)nudCantineDim.Value;

                    dimanche.saucisse_T1 = (int)nudSaucisseTranche1.Value;
                    dimanche.saucisse_DIM = (int)nudSaucisseDim.Value;

                    dimanche.pompier_T1 = (int)nudPompierTranche1.Value;
                    dimanche.pompier_T2 = (int)nudPompierTranche2.Value;

                    dimanche.cave_T1 = (int)nudCaveTranche1.Value;
                    dimanche.cave_T2 = (int)nudCaveTranche2.Value;
                    dimanche.cave_DIM = (int)nudCaveDim.Value;

                    dimanche.rav_T1 = (int)nudRavTranche1.Value;
                    dimanche.rav_T2 = (int)nudRavTranche2.Value;
                    dimanche.rav_DIM = (int)nudRavDim.Value;

                    //Passe au jour suivant
                    lblJour.Text = "Lundi";

                    //Remet la colonne du dimanche inactive
                    lblDimanche.Text = "XX:XX - XX:XX";

                    nudCantineDim.Value = 0;
                    nudCantineDim.Enabled = false;
                    nudSaucisseDim.Value = 0;
                    nudSaucisseDim.Enabled = false;
                    nudCaveDim.Value = 0;
                    nudCaveDim.Enabled = false;
                    nudRavDim.Value = 0;
                    nudRavDim.Enabled = false;

                    //Indique que la prochaine fois on a terminé
                    btnSuivant.Text = "Terminer";
                    break;
                //Sauvegarde le lundi et sort de la page
                case 3:
                    //Sauvegarder les informations
                    lundi.cantine_T1 = (int)nudCantineTranche1.Value;
                    lundi.cantine_T2 = (int)nudCantineTranche2.Value;

                    lundi.saucisse_T1 = (int)nudSaucisseTranche1.Value;

                    lundi.pompier_T1 = (int)nudPompierTranche1.Value;
                    lundi.pompier_T2 = (int)nudPompierTranche2.Value;

                    lundi.cave_T1 = (int)nudCaveTranche1.Value;
                    lundi.cave_T2 = (int)nudCaveTranche2.Value;

                    lundi.rav_T1 = (int)nudRavTranche1.Value;
                    lundi.rav_T2 = (int)nudRavTranche2.Value;


                    //Fermer la fenêtre
                    this.Hide();
                    break;
                default:
                    break;
            }
            //Passe au jour suivant
            jour++;
        }

        //Gestion butées des Numerique Up Down (nud)
        private void nudCantineTranche1_ValueChanged(object sender, EventArgs e)
        {
            if(nudCantineTranche1.Value < 2)
            {
                nudCantineTranche1.Value = 2;
            }
            totalT1 = (int)nudCantineTranche1.Value + (int)nudSaucisseTranche1.Value + (int)nudPompierTranche1.Value + (int)nudParcTranche1.Value + (int)nudCaveTranche1.Value + (int)nudRavTranche1.Value;
            lblTotalTranche1.Text = totalT1.ToString();
        }

        private void nudSaucisseTranche1_ValueChanged(object sender, EventArgs e)
        {
            if(nudSaucisseTranche1.Value < 2)
            {
                nudSaucisseTranche1.Value = 2;
            }
            totalT1 = (int)nudCantineTranche1.Value + (int)nudSaucisseTranche1.Value + (int)nudPompierTranche1.Value + (int)nudParcTranche1.Value + (int)nudCaveTranche1.Value + (int)nudRavTranche1.Value;
            lblTotalTranche1.Text = totalT1.ToString();
        }

        private void nudPompierTranche1_ValueChanged(object sender, EventArgs e)
        {
            if (nudPompierTranche1.Value < 2)
            {
                nudPompierTranche1.Value = 2;
            }
            totalT1 = (int)nudCantineTranche1.Value + (int)nudSaucisseTranche1.Value + (int)nudPompierTranche1.Value + (int)nudParcTranche1.Value + (int)nudCaveTranche1.Value + (int)nudRavTranche1.Value;
            lblTotalTranche1.Text = totalT1.ToString();
        }

        private void nudParcTranche1_ValueChanged(object sender, EventArgs e)
        {
            if (nudParcTranche1.Value < 2 && nudParcTranche1.Value > 0)
            {
                nudParcTranche1.Value = 2;
            }
            totalT1 = (int)nudCantineTranche1.Value + (int)nudSaucisseTranche1.Value + (int)nudPompierTranche1.Value + (int)nudParcTranche1.Value + (int)nudCaveTranche1.Value + (int)nudRavTranche1.Value;
            lblTotalTranche1.Text = totalT1.ToString();
        }

        private void nudCaveTranche1_ValueChanged(object sender, EventArgs e)
        {
            if (nudCaveTranche1.Value < 2)
            {
                nudCaveTranche1.Value = 2;
            }
            totalT1 = (int)nudCantineTranche1.Value + (int)nudSaucisseTranche1.Value + (int)nudPompierTranche1.Value + (int)nudParcTranche1.Value + (int)nudCaveTranche1.Value + (int)nudRavTranche1.Value;
            lblTotalTranche1.Text = totalT1.ToString();
        }

        private void nudRavTranche1_ValueChanged(object sender, EventArgs e)
        {
            if (nudRavTranche1.Value < 1)
            {
                nudRavTranche1.Value = 1;
            }
            totalT1 = (int)nudCantineTranche1.Value + (int)nudSaucisseTranche1.Value + (int)nudPompierTranche1.Value + (int)nudParcTranche1.Value + (int)nudCaveTranche1.Value + (int)nudRavTranche1.Value;
            lblTotalTranche1.Text = totalT1.ToString();
        }

        private void nudCantineTranche2_ValueChanged(object sender, EventArgs e)
        {
            if (nudCantineTranche2.Value < 2)
            {
                nudCantineTranche2.Value = 2;
            }
            totalT2 = (int)nudCantineTranche2.Value + (int)nudSaucisseTranche2.Value + (int)nudPompierTranche2.Value + (int)nudParcTranche2.Value + (int)nudCaveTranche2.Value + (int)nudRavTranche2.Value;
            lblTotalTranche2.Text = totalT2.ToString();
        }

        private void nudSaucisseTranche2_ValueChanged(object sender, EventArgs e)
        {
            if (nudSaucisseTranche2.Value < 2)
            {
                nudSaucisseTranche2.Value = 2;
            }
            totalT2 = (int)nudCantineTranche2.Value + (int)nudSaucisseTranche2.Value + (int)nudPompierTranche2.Value + (int)nudParcTranche2.Value + (int)nudCaveTranche2.Value + (int)nudRavTranche2.Value;
            lblTotalTranche2.Text = totalT2.ToString();
        }

        private void nudPompierTranche2_ValueChanged(object sender, EventArgs e)
        {
            if (nudPompierTranche2.Value < 2)
            {
                nudPompierTranche2.Value = 2;
            }
            totalT2 = (int)nudCantineTranche2.Value + (int)nudSaucisseTranche2.Value + (int)nudPompierTranche2.Value + (int)nudParcTranche2.Value + (int)nudCaveTranche2.Value + (int)nudRavTranche2.Value;
            lblTotalTranche2.Text = totalT2.ToString();
        }

        private void nudParcTranche2_ValueChanged(object sender, EventArgs e)
        {
            if (nudParcTranche2.Value < 2 && nudParcTranche2.Value > 0)
            {
                nudParcTranche2.Value = 2;
            }
            totalT2 = (int)nudCantineTranche2.Value + (int)nudSaucisseTranche2.Value + (int)nudPompierTranche2.Value + (int)nudParcTranche2.Value + (int)nudCaveTranche2.Value + (int)nudRavTranche2.Value;
            lblTotalTranche2.Text = totalT2.ToString();
        }

        private void nudCaveTranche2_ValueChanged(object sender, EventArgs e)
        {
            if (nudCaveTranche2.Value < 2)
            {
                nudCaveTranche2.Value = 2;
            }
            totalT2 = (int)nudCantineTranche2.Value + (int)nudSaucisseTranche2.Value + (int)nudPompierTranche2.Value + (int)nudParcTranche2.Value + (int)nudCaveTranche2.Value + (int)nudRavTranche2.Value;
            lblTotalTranche2.Text = totalT2.ToString();
        }

        private void nudRavTranche2_ValueChanged(object sender, EventArgs e)
        {
            if (nudRavTranche2.Value < 1)
            {
                nudRavTranche2.Value = 1;
            }
            totalT2 = (int)nudCantineTranche2.Value + (int)nudSaucisseTranche2.Value + (int)nudPompierTranche2.Value + (int)nudParcTranche2.Value + (int)nudCaveTranche2.Value + (int)nudRavTranche2.Value;
            lblTotalTranche2.Text = totalT2.ToString();
        }

        private void nudCantineDim_ValueChanged(object sender, EventArgs e)
        {
            if (nudCantineDim.Value < 2 && nudCantineDim.Value > 0)
            {
                nudCantineDim.Value = 2;
            }
            totalDim = (int)nudCantineDim.Value + (int)nudSaucisseDim.Value + (int)nudCaveDim.Value + (int)nudRavDim.Value;
            lblTotalDim.Text = totalDim.ToString();
        }

        private void nudSaucisseDim_ValueChanged(object sender, EventArgs e)
        {
            if (nudSaucisseDim.Value < 2 && nudSaucisseDim.Value > 0)
            {
                nudSaucisseDim.Value = 2;
            }
            totalDim = (int)nudCantineDim.Value + (int)nudSaucisseDim.Value + (int)nudCaveDim.Value + (int)nudRavDim.Value;
            lblTotalDim.Text = totalDim.ToString();
        }

        private void nudCaveDim_ValueChanged(object sender, EventArgs e)
        {
            if (nudCaveDim.Value < 2 && nudCaveDim.Value > 0)
            {
                nudCaveDim.Value = 2;
            }
            totalDim = (int)nudCantineDim.Value + (int)nudSaucisseDim.Value + (int)nudCaveDim.Value + (int)nudRavDim.Value;
            lblTotalDim.Text = totalDim.ToString();
        }

        private void nudRavDim_ValueChanged(object sender, EventArgs e)
        {
            if (nudRavDim.Value < 1 && nudRavDim.Value > 0)
            {
                nudRavDim.Value = 1;
            }
            totalDim = (int)nudCantineDim.Value + (int)nudSaucisseDim.Value + (int)nudCaveDim.Value + (int)nudRavDim.Value;
            lblTotalDim.Text = totalDim.ToString();
        }

        
    }
    //Classe planning
    public class Planning
    {
        //Attributs
        public int cantine_T1 = 0;
        public int cantine_T2 = 0;
        public int cantine_DIM = 0;

        public int saucisse_T1 = 0;
        public int saucisse_T2 = 0;
        public int saucisse_DIM = 0;

        public int pompier_T1 = 0;
        public int pompier_T2 = 0;
        public int pompier_DIM = 0;

        public int parc_T1 = 0;
        public int parc_T2 = 0;
        public int parc_DIM = 0;

        public int cave_T1 = 0;
        public int cave_T2 = 0;
        public int cave_DIM = 0;

        public int rav_T1 = 0;
        public int rav_T2 = 0;
        public int rav_DIM = 0;


        //Constructeur
        public Planning()
        {
            
        }
    }
}


