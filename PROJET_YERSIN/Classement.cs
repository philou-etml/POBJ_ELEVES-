using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tournoi_Echec
{
    
    public partial class Classement : Form
    {
        private ClassementDetaille ClDetaille = new ClassementDetaille();
        public Classement()
        {
            InitializeComponent();
            btn_ShowClassementDetaille.Hide();
            btn_csv1.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_ShowClassement_Click(object sender, EventArgs e)
        {
            // Liste des joueurs
            List<Joueur> Participants;
            List<Joueur> Classement;
            // Element pour l'affichage et les calculs
            int Ronde, Adv;
            int i, j, TeteDeSerie, V, N, D;
            float Pts = 0, Buchh = 0, SoBerg = 0;
            float Buchh_A_Ajouter = 0, SoBerg_A_Ajouter = 0;
            // Prend le nombre de joueur
            int NbParticipants;
            // Prise de la liste de depart
            Participants = Tournoi.ChargerListe();
            // Prise du nombre de joueur
            NbParticipants = Tournoi.Joueurs_Totaux();
            // Retrié par n° de départ du joueur, pour que le calcul s'effectue correctement
            TriParNdeDepart(Participants, NbParticipants);
            // Effacer toutes les cases du tableau (par précaution)
            dataGridView1.Rows.Clear();
            // Remise à 0 du buchholz et du SoBerg de tous les joueurs (si plusieurs appuis sur le bouton classement, il ne doit pas y avoir de changements)
            for (i = 0; i < (NbParticipants); i++)
            {
                // Effacer
                Participants[i].MAJ_Buchh(0);
                Participants[i].MAJ_SoBerg(0);
            }
            // Effectuer le calcul du Buchholtz et de la somme de Buchholtz de tous les joueurs dans la gestion du classement
            // parce que ceux-ci évolue selon le tournoi des joueurs adverses
            // Prend le nombre de rondes
            Ronde = Tournoi.Ronde_Jouee();
            for (j = 1; j <= Ronde; j++)
            {
                // D'abord mettre à jour tous les buchholtz avant les SoBerg
                for (i = 0; i < (NbParticipants); i++)
                {
                    // Va chercher l'adversaire du joueur (-1 car le joueur tête de série n°1 à l'indice 0)
                    Adv = (Participants[i].Adv_To_Return(j)) - 1;
                    // Mise à jour du buchholtz à ajouter
                    Buchh_A_Ajouter = Participants[Adv].PointsJoueur();
                    // Va chercher le buccholtz actuel du joueur
                    Buchh = Participants[i].BuchhJoueur();
                    // Remet à jour le buchholtz du joueur
                    Participants[i].MAJ_Buchh(Buchh_A_Ajouter + Buchh);
                }
            }
            for (j = 1; j <= Ronde; j++)
            {
                // Et on refait la même opération pour les SoBerg
                for (i = 0; i < (NbParticipants); i++)
                {
                    // Va chercher l'adversaire du joueur (-1 car le joueur tête de série n°1 à l'indice 0)
                    Adv = (Participants[i].Adv_To_Return(j)) - 1;
                    // Mise à jour du soberg à ajouter
                    SoBerg_A_Ajouter = Participants[Adv].BuchhJoueur();
                    // Va chercher le soberg actuel du joueur
                    SoBerg = Participants[i].SoBergJoueur();
                    // Remet à jour le soberg du joueur
                    Participants[i].MAJ_SoBerg(SoBerg_A_Ajouter + SoBerg);
                }
            }
            //  Copie de la liste des participants dans la zone prévue pour l'affichage du classement
            Classement = Participants;
            // Génération du classement et tri selon le nombre de points / Bucch / SoBerg et Victoire des joueurs
            TriClassement(Classement, NbParticipants);
            // Génération du tableau
            for (i = 0; i < (NbParticipants); i++)
            {
                // Elements à afficher
                TeteDeSerie = Classement[i].n_Depart_Du_JoueurLoad();
                V = Classement[i].VictoireJoueur();
                N = Classement[i].NulJoueur();
                D = Classement[i].DefaiteJoueur();
                Pts = Classement[i].PointsJoueur();
                Buchh = Classement[i].BuchhJoueur();
                SoBerg = Classement[i].SoBergJoueur();
                // Mise à jour du rang final du joueur
                Classement[i].MAJ_RangFinal(i + 1);
                // Création des lignes pour le classement
                string[] row = new string[] { (i + 1).ToString(), TeteDeSerie.ToString(), Classement[i].nom + " " + Classement[i].prenom, Classement[i].club, Classement[i].ELO.ToString(), Classement[i].Titre, V.ToString(), N.ToString(), D.ToString(), Pts.ToString(), Buchh.ToString(), SoBerg.ToString()  };
                dataGridView1.Rows.Add(row);
            }
            // Enregistrer la liste
            Tournoi.SaveListe(Participants);
            // Faire apparaître le bouton pour un classement complet
            btn_ShowClassementDetaille.Show();
            // Faire apparaitre le bouton pour extraire sur csv
            btn_csv1.Show();
        }
        // Methode de tri (https://www.developpez.net/forums/d568159/dotnet/langages/csharp/trier-liste-d-objets/) (https://www.developpez.net/forums/d1433633/c-cpp/c/debuter/fonction-tri-croissant-tri-decroissant/)
        public void TriClassement(List<Joueur> Classement, int NombreParticipants)
        {
            int n_DebutTri = 0;
            int n_FinTri = (NombreParticipants - 1);

            while (n_DebutTri < n_FinTri)
            {
                int DebutTri = n_DebutTri;
                int FinTri = n_FinTri;
                n_DebutTri = NombreParticipants;
                // Premier tri : selon le nombre de points
                for (int i = DebutTri; i < FinTri; i++)
                {
                    // Premier tri : selon le nombre de points
                    if (Classement[i].PointsJoueur() < Classement[i + 1].PointsJoueur())
                    {
                        Joueur Tirroir = Classement[i];
                        Classement[i] = Classement[i + 1];
                        Classement[i + 1] = Tirroir;
                        if (i < n_DebutTri)
                        {
                            n_DebutTri = i - 1;
                            if (n_DebutTri < 0)
                            {
                                n_DebutTri = 0;
                            }
                        }
                        else if (i > n_FinTri)
                        {
                            n_FinTri = i + 1;
                        }
                    }
                    // Si le nombre de points est le même pour les deux joueurs :
                    else if(Classement[i].PointsJoueur() == Classement[i + 1].PointsJoueur())
                    {
                        // Deuxième tri : selon le nombre de buchholtz
                        if (Classement[i].BuchhJoueur() < Classement[i + 1].BuchhJoueur())
                        {
                            Joueur Tirroir = Classement[i];
                            Classement[i] = Classement[i + 1];
                            Classement[i + 1] = Tirroir;
                            if (i < n_DebutTri)
                            {
                                n_DebutTri = i - 1;
                                if (n_DebutTri < 0)
                                {
                                    n_DebutTri = 0;
                                }
                            }
                            else if (i > n_FinTri)
                            {
                                n_FinTri = i + 1;
                            }
                        }
                        // Si le nombre de buchholtz est le même pour les deux joueurs :
                        else if(Classement[i].BuchhJoueur() == Classement[i + 1].BuchhJoueur())
                        {
                            // Troisième tri : selon le nombre de somme de buchholtz
                            if (Classement[i].SoBergJoueur() < Classement[i + 1].SoBergJoueur())
                            {
                                Joueur Tirroir = Classement[i];
                                Classement[i] = Classement[i + 1];
                                Classement[i + 1] = Tirroir;
                                if (i < n_DebutTri)
                                {
                                    n_DebutTri = i - 1;
                                    if (n_DebutTri < 0)
                                    {
                                        n_DebutTri = 0;
                                    }
                                }
                                else if (i > n_FinTri)
                                {
                                    n_FinTri = i + 1;
                                }
                            }
                            // Si le nombre de somme de buchholtz est le même pour les deux joueurs :
                            else if(Classement[i].SoBergJoueur() == Classement[i + 1].SoBergJoueur())
                            {
                                // Dernier tri : selon le nombre de victoires de chaque joueur
                                if (Classement[i].VictoireJoueur() < Classement[i + 1].VictoireJoueur())
                                {
                                    Joueur Tirroir = Classement[i];
                                    Classement[i] = Classement[i + 1];
                                    Classement[i + 1] = Tirroir;
                                    if (i < n_DebutTri)
                                    {
                                        n_DebutTri = i - 1;
                                        if (n_DebutTri < 0)
                                        {
                                            n_DebutTri = 0;
                                        }
                                    }
                                    else if (i > n_FinTri)
                                    {
                                        n_FinTri = i + 1;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        // Methode de tri (https://www.developpez.net/forums/d568159/dotnet/langages/csharp/trier-liste-d-objets/) (https://www.developpez.net/forums/d1433633/c-cpp/c/debuter/fonction-tri-croissant-tri-decroissant/)
        public void TriParNdeDepart(List<Joueur> Participant, int NombreParticipants)
        {
            int n_DebutTri = 0;
            int n_FinTri = (NombreParticipants - 1);

            while (n_DebutTri < n_FinTri)
            {
                int DebutTri = n_DebutTri;
                int FinTri = n_FinTri;
                n_DebutTri = NombreParticipants;
                for (int i = DebutTri; i < FinTri; i++)
                {
                    if (Participant[i].n_de_depart > Participant[i + 1].n_de_depart)
                    {
                        Joueur Tirroir = Participant[i];
                        Participant[i] = Participant[i + 1];
                        Participant[i + 1] = Tirroir;
                        if (i < n_DebutTri)
                        {
                            n_DebutTri = i - 1;
                            if (n_DebutTri < 0)
                            {
                                n_DebutTri = 0;
                            }
                        }
                        else if (i > n_FinTri)
                        {
                            n_FinTri = i + 1;
                        }
                    }
                }
            }
        }

        private void btn_ShowClassementDetaille_Click(object sender, EventArgs e)
        {
            // Ouverture d'une nouvelle page pour le classement détaillé (seulement si toutes les rondes ont étées jouées)
            if(Tournoi.Ronde_Jouee() != Tournoi.Ronde_Max())
            {
                MessageBox.Show("Vous ne pouvez afficher le classement détaillé uniquement lorsque toutes les rondes sont jouées", "Pas de classement detaille", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ClDetaille.ShowDialog();
            }

        }

        private void btn_csv1_Click(object sender, EventArgs e)
        {
            // Déclaration de variables locales pour prendre le nombre de participants à écrire dans le fichier csv
            int NbParticipants = Tournoi.Joueurs_Totaux();
            int i = 0;
            // Reprend la liste des joueurs
            List<Joueur> Participants;
            Participants = Tournoi.ChargerListe();
            // Cherche le chemin
            string path = @"H:\GENLOG\POBJ\Projet_Tournoi_Echec\Tournoi_Echec\Classement.csv";
            // Ecriture (avec l'encoding UTF8)
            File.WriteAllText(path, "Pos : ;N° ;Joueur : ;Club : ;ELO : ;Titre;V;N;P;Pts : ;Buchh : ;SoBerg :" + Environment.NewLine + Environment.NewLine, Encoding.UTF8);
            for (i = 0; i < NbParticipants; i++)
            {
                File.AppendAllText(path, (i + 1).ToString() + ';' + Participants[i].n_Depart_Du_JoueurLoad().ToString() + ';' + Participants[i].nom + ' ' + Participants[i].prenom + ';' + Participants[i].club + ';' + Participants[i].ELO.ToString() + ';' + Participants[i].Titre + ';' + Participants[i].VictoireJoueur().ToString() + ';' + Participants[i].NulJoueur().ToString() + ';' + Participants[i].DefaiteJoueur().ToString() + ';' + Participants[i].PointsJoueur().ToString() + ';' + Participants[i].BuchhJoueur().ToString() + ';' + Participants[i].SoBergJoueur().ToString() + Environment.NewLine, Encoding.UTF8);
            }
        }
    }
}
