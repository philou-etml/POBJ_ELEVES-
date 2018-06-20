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
    public partial class ClassementDetaille : Form
    {
        // tableau pour prendre le nombre d'adversaire et les couleurs de chaque ronde
        int[] nbAdversaire = new int[11];
        char[] nbCouleur = new char[11];
        char[] nbResultat = new char[11];
        string[,] Ronde_Texte = new string[100,100]; // Obligatoire, car des attribus par variable ne fonctionne pas
        public ClassementDetaille()
        {
            InitializeComponent();
            btn_csv2.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_ShowClassementDetaille2_Click(object sender, EventArgs e)
        {
            // Liste des joueurs
            List<Joueur> Participants;
            List<Joueur> Classement;
            // Element pour l'affichage et les calculs
            int Ronde, Adv, Pos;
            int i, j, TeteDeSerie;
            float Pts, Buchh, SoBerg;
            // Prend le nombre de joueur
            int NbParticipants;
            // Vider le tableau
            dataGridView1.Rows.Clear();
            // Prise de la liste de depart
            Participants = Tournoi.ChargerListe();
            // Prise du nombre de joueur
            NbParticipants = Tournoi.Joueurs_Totaux();
            // Effectuer le calcul du Buchholtz et de la somme de Buchholtz de tous les joueurs dans la gestion du classement
            // parce que ceux-ci évolue selon le tournoi des joueurs adverses
            // Prend le nombre de rondes
            Ronde = Tournoi.Ronde_Jouee();
            // On retrie par n° de départ pour prendre les positions finales de chaque joueur
            TriParNdeDepart(Participants, NbParticipants);
            // Prendre les adversaires selon leurs classements
            for (i = 0; i < (NbParticipants); i++)
            {
                // Prise de la valeur de chaque adversaire / chaque couleur et chaque resultat pour chaque ronde
                for (j = 1; j <= Ronde; j++)
                {
                    // Prise de l'adversaire (son n° indice)
                    Adv = (Participants[i].Adv_To_Return(j)) - 1;
                    // Remplacer la valeur de l'adversaire ==> l'indice devient son classement final
                    Pos = Participants[Adv].RangFinal();
                    Participants[i].MAJ_n_adversaire(Pos, j);
                }
            }
            // Copie de la liste des participants dans la zone prévue pour l'affichage du classement
            Classement = Participants;
            // On retrie selon la position
            TriParPosition(Classement, NbParticipants);
            // Génération du tableau
            for (i = 0; i < (NbParticipants); i++)
            {
                // Prise de la valeur de chaque adversaire / chaque couleur et chaque resultat pour chaque ronde
                for (j = 1; j <= Ronde; j++)
                {
                    // Prise de l'adversaire (son n° de classement FINAL)
                    Adv = (Participants[i].Adv_To_Return(j)) - 1;
                    nbAdversaire[j - 1] = Participants[Adv].RangFinal();
                    // Prise de la couleur
                    if ((Participants[i].Couleur_To_Return(j) == 0))
                    {
                        // 0 = noir ==> mise de S (Schwarz)
                        nbCouleur[j - 1] = 'S';
                    }
                    else
                    {
                        // 1 = blanc ==> mise de W (Weiss)
                        nbCouleur[j - 1] = 'W';
                    }
                    // Prise du résultat
                    nbResultat[j - 1] = Participants[i].Resultat_To_Return(j);
                    // Mettre tout ça dans un string
                    Ronde_Texte[i,j - 1] = nbAdversaire[j - 1].ToString() + nbCouleur[j - 1].ToString() + nbResultat[j - 1].ToString();
                }
                // Pour les rondes non jouées (pour y mettre des cases 'X' pour indiqué une ronde non jouée
                for(j = (Ronde + 1); j <= 11; j++)
                {
                    Ronde_Texte[i,j - 1] = "X";
                }
                // Elements à afficher
                TeteDeSerie = Classement[i].n_Depart_Du_JoueurLoad();
                Pts = Classement[i].PointsJoueur();
                Buchh = Classement[i].BuchhJoueur();
                SoBerg = Classement[i].SoBergJoueur();
                // Création des lignes pour le classement
                string[] row = new string[] { (i + 1).ToString(), TeteDeSerie.ToString(), Classement[i].nom + " " + Classement[i].prenom, Classement[i].club, Classement[i].ELO.ToString(), Classement[i].Titre, Ronde_Texte[i,0], Ronde_Texte[i,1], Ronde_Texte[i,2], Ronde_Texte[i,3], Ronde_Texte[i,4], Ronde_Texte[i,5], Ronde_Texte[i,6], Ronde_Texte[i,7], Ronde_Texte[i,8], Ronde_Texte[i,9], Ronde_Texte[i,10], Pts.ToString(), Buchh.ToString(), SoBerg.ToString() };
                dataGridView1.Rows.Add(row);
            }
            // Faire disparaitre le bouton pour afficher le classement détaillé (pour éviter un bug de remise de valeur incompréhensible)
            btn_ShowClassementDetaille2.Hide();
            // Faire apparaitre le bouton pour extraire sur csv
            btn_csv2.Show();
        }
        // Methode de tri (https://www.developpez.net/forums/d568159/dotnet/langages/csharp/trier-liste-d-objets/) (https://www.developpez.net/forums/d1433633/c-cpp/c/debuter/fonction-tri-croissant-tri-decroissant/)
        public void TriParPosition(List<Joueur> Participant, int NombreParticipants)
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
                    if (Participant[i].RangFinal() > Participant[i + 1].RangFinal())
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

        private void btn_csv2_Click(object sender, EventArgs e)
        {
            // Déclaration de variables locales pour prendre le nombre de participants à écrire dans le fichier csv
            int NbParticipants = Tournoi.Joueurs_Totaux();
            int i = 0;
            // Reprend la liste des joueurs
            List<Joueur> Participants;
            Participants = Tournoi.ChargerListe();
            // Faire disparaitre le bouton pour extraire sur csv
            //btn_csv2.Hide();
            // Cherche le chemin
            string path = @"H:\GENLOG\POBJ\Projet_Tournoi_Echec\Tournoi_Echec\Classement detaille.csv";
            // Ecriture (avec l'encoding UTF8)
            File.WriteAllText(path, "Pos : ;N° ;Joueur : ;Club : ;ELO : ;Titre ;R1 : ;R2 : ;R3 : ;R4 : ;R5 : ;R6 : ;R7 : ;R8 : ;R9 : ;R10 : ;R11 : ;Pts : ;Buchh : ;SoBerg :" + Environment.NewLine + Environment.NewLine, Encoding.UTF8);
            for (i = 0; i < NbParticipants; i++)
            {
                File.AppendAllText(path, (i + 1).ToString() + ';' + Participants[i].n_Depart_Du_JoueurLoad().ToString() + ';' + Participants[i].nom + ' ' + Participants[i].prenom + ';' + Participants[i].club + ';' + Participants[i].ELO.ToString() + ';' + Participants[i].Titre + ';' + Ronde_Texte[i, 0] + ';' + Ronde_Texte[i, 1] + ';' + Ronde_Texte[i, 2] + ';' + Ronde_Texte[i, 3] + ';' + Ronde_Texte[i, 4] + ';' + Ronde_Texte[i, 5] + ';' + Ronde_Texte[i, 6] + ';' + Ronde_Texte[i, 7] + ';' + Ronde_Texte[i, 8] + ';' + Ronde_Texte[i, 9] + ';' + Ronde_Texte[i, 10] + ';' + Participants[i].PointsJoueur().ToString() + ';' + Participants[i].BuchhJoueur().ToString() + ';' + Participants[i].SoBergJoueur().ToString() + Environment.NewLine, Encoding.UTF8);
            }
        }
    }
}
