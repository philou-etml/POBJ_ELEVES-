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
    public partial class Form1 : Form
    {
        int nbrCusinier = 0;
        int nbrInscrit = 0;
        int nbrBesoin = 0;

        public bool pres = false;
        public bool cash = false;
        public bool HF = false;
        public bool XP = false;
        public bool food = false;

        //List pour engregistrer les travailleurs
        List<personne> Monequipe = new List<personne>();

        //Objets pour le nombre de personnes par stand par soir.
        Planning vendredi = new Planning();
        Planning samedi = new Planning();
        Planning dimanche = new Planning();
        Planning lundi = new Planning();


        
        public Form1()
        {
            InitializeComponent();
            DemandePlanning MonPlanning = new DemandePlanning();
            this.Hide();
            MonPlanning.ShowDialog();

            //Récupération des informations du planning
            nbrBesoin = MonPlanning.GetParam(ref vendredi, ref samedi, ref dimanche,ref lundi);
        }
        
        
        //Classe personne
        public class personne
        {
            //Attributs
            public string nom;
            public string prenom;

            public bool experience;
            public bool cuisine = false;
            public bool president = false;
            public bool caissier = false;
            //true = homme
            //False = femme
            public bool sexe = false;

            

            //Methode
            public personne(string name, string firstName, bool presid, bool caisse, bool hommeFemme, bool cui, bool exp)
            {
                nom = name;
                prenom = firstName;
                sexe = hommeFemme;
                president = presid;
                caissier = caisse;
                cuisine = cui;
                experience = exp;
            } 

            /*public bool getExpe()
            {
                return experience;
            }
            public bool getCuisine()
            {
                return cuisine;
            }
            public bool getPresident()
            {
                return president;
            }
            public bool getCaissier()
            {
                return caissier;
            }
            public bool getSexe()
            {
                return sexe;
            }*/
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            //Si président
            if (cbPrésident.Checked)
            {
                //Banni la case président
                cbPrésident.Checked = false;
                cbPrésident.Enabled = false;

                pres = true;
            }
            else
            {
                pres = false;
            }


            //Si caissier
            if (cbCaissier.Checked)
            {
                //Banni la case caissier
                cbCaissier.Checked = false;
                cbCaissier.Enabled = false;

                cash = true;
            }
            else
            {
                cash = false;
            }


            //Control si capacite a cuisiner
            if (cbCuisine.Checked)
            {
                //Augmente et indique le nombre actuel de cuisinier
                nbrCusinier++;
                lblNbrCuisiniers.Text = nbrCusinier.ToString();

                //Decoche la case cuisine
                cbCuisine.Checked = false;

                food = true;
            }
            else
            {
                food = false;
            }

            //Control si plus de 2 ans d'experiences
            if (cbExperience.Checked)
            {
                XP = true;
                cbExperience.Checked = false;
            }
            else
            {
                XP = false;
            }

            if(rbHomme.Checked)
            {
                HF = true;
            }
            else
            {
                HF = false;
            }

            //On ajoute ce travailleur à l'équipe
            Monequipe.Add(new personne(tbNom.Text.ToString(), tbPrenom.Text.ToString(), pres, cash, HF, food, XP));


            //Clear les textBox
            tbNom.Clear();
            tbPrenom.Clear();

            

            //Augmente et indique le nombre d'inscrits
            nbrInscrit++;
            lblNbrInscrits.Text = nbrInscrit.ToString();

            //Contrôle si on a assez de travailleurs
            if (nbrInscrit == nbrBesoin)
            {
                //Libère le bouton de génération
                btnGeneration.Enabled = true;
            }
        }

        private void btnGeneration_Click(object sender, EventArgs e)
        {
            //Contrôle si on a assez de travailleurs
            if(nbrInscrit != nbrBesoin)
            {
                //Indique qu'il y en a pas assez
            }
            //Si asssez
            else
            {
                //Trie les travailleurs

                //Inscrit les joueurs dans le fichier csv
            }
        }
    }
}
