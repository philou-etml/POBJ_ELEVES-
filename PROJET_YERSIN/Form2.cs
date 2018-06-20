using System;
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
    public partial class FormSub1 : Form
    {
        // Accès au autres formes
        private Classement FClassement = new Classement();
        // Liste des joueurs
        List<Joueur> Participants;
        int Nombre_de_Joueurs = 0;
        // Variable pour la gestion des échiquiers et prise de valeur des résultats
        int Separation = 0;
        int Init_Echiquier = 0;
        int Echiquier_Resultat = 0;
        // Blanc (1) ou noir (0)
        int Couleur = 1;
        // Ronde actuellement jouée
        int Ronde = 1;
        // Pour pouvoir copier des informations depuis une cellule du tableau
        int ligne, colonne, ligne_selectionnee, colonne_selectionnee;
        // Pour pouvoir détécter la mise à jour des résultats
        int MAJ = 0;
        // Afin d'éviter un bug au démarrage
        bool Demarrage = false;
        public FormSub1()
        {
            InitializeComponent();
            Demarrage = true;
            BTN_Ronde_suivante.Hide();
        }

        private void FormSub1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void DGW_Ronde1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {   // Evenement lors de la séléction d'une cellule
            ligne = e.RowIndex;
            colonne = e.ColumnIndex;
        }

        private void BTN_GenRondes_Click(object sender, EventArgs e)
        {
            // Affiche la ronde actuelle dans le label correspondant
            lbl_Rondes.Text = ("Ronde n°" + Ronde);
            // Utilisation de la fonction Genere_Ronde()
            Genere_Ronde();
        }

        private void BTN_Ronde_suivante_Click(object sender, EventArgs e)
        {
            // Ronde maximale
            int Ronde_Max = Tournoi.Ronde_Max();
            // Pirse du numero de tête de série du joueur
            int TeteDeSerie_Blanc, TeteDeSerie_Noir;
            // Prise du résultat de chaque joueur
            double ResultatBlanc, ResultatNoir;
            int Indice_Colonne = 0;
            // Variable de test
            int OK = 0, OK_for_MAJ = 0;
            // Mise à jour des résultats
            Separation = Nombre_de_Joueurs / 2;
            Couleur = 1;
            // Test pour voir si tout les champs sont remplis
            for (Echiquier_Resultat = 0; Echiquier_Resultat < Separation; Echiquier_Resultat++)
            {
                // Mets les resultats dans les strings
                try
                {
                    string resblanc = DGW_Ronde1.Rows[Echiquier_Resultat].Cells[5].Value.ToString();
                    string resnoir = DGW_Ronde1.Rows[Echiquier_Resultat].Cells[7].Value.ToString();
                    // Incrémente la valeur seulement si les champs ne sont pas vides
                    if (resblanc != "" && resnoir != "")
                    {
                        OK++;
                    }
                }
                catch (NullReferenceException)
                {
                    // Mettre un message d'erreur
                    MessageBox.Show("Un champ non rempli à été détécté (peut s'afficher plusieurs fois si plusieurs champs vides sont détéctés !)");
                }
            }
            // Si OK est égale à Echiquier_Resultat, c'est qu'aucun champ n'est vide
            if (Echiquier_Resultat == OK)
            {
                // On peut commencer à mettre à jour
                OK_for_MAJ = 1;
            }
            // Effectuer seulement si la mise à jour n'est pas faite et que le tampon de vérification est ok
            if ((MAJ == 0) && (OK_for_MAJ == 1))
            {
                // S'il s'agit de la première ronde
                if(Ronde == 1)
                {
                    // Reprendre les joueurs des cellules et y mettre à jour leurs résultats
                    for (Echiquier_Resultat = 0; Echiquier_Resultat < Separation; Echiquier_Resultat++)
                    {
                        if (Couleur == 1)
                        {
                            // Prise des n° de tête de série
                            TeteDeSerie_Blanc = Participants[Echiquier_Resultat].n_Depart_Du_JoueurLoad();
                            TeteDeSerie_Noir = Participants[Echiquier_Resultat + Separation].n_Depart_Du_JoueurLoad();
                            // Chargement du résultat inscrit dans le tableau
                            string resultat_blanc = DGW_Ronde1.Rows[Indice_Colonne].Cells[5].Value.ToString();
                            // Prise du résultat
                            if (resultat_blanc == "1")
                            {
                                ResultatBlanc = 1;
                                ResultatNoir = 0;
                            }
                            else if (resultat_blanc == "0")
                            {
                                ResultatBlanc = 0;
                                ResultatNoir = 1;
                            }
                            else
                            {
                                ResultatBlanc = 0.5;
                                ResultatNoir = 0.5;
                            }
                            // Mise à jour des éléments du joueur (ronde, adversaire, couleur, résultat)
                            Participants[Echiquier_Resultat].Stat_Ronde(Ronde, TeteDeSerie_Noir, 1, ResultatBlanc);
                            Participants[Separation + Echiquier_Resultat].Stat_Ronde(Ronde, TeteDeSerie_Blanc, 0, ResultatNoir);
                            Couleur = 0;
                            Indice_Colonne++;
                        }
                        else
                        {
                            // Chargement des têtes de séries
                            TeteDeSerie_Blanc = Participants[Echiquier_Resultat + Separation].n_Depart_Du_JoueurLoad();
                            TeteDeSerie_Noir = Participants[Echiquier_Resultat].n_Depart_Du_JoueurLoad();
                            // Chargement du résultat inscrit dans le tableau
                            string resultat_blanc = DGW_Ronde1.Rows[Indice_Colonne].Cells[5].Value.ToString();
                            // Prise du résultat
                            if (resultat_blanc == "1")
                            {
                                ResultatBlanc = 1;
                                ResultatNoir = 0;
                            }
                            else if (resultat_blanc == "0")
                            {
                                ResultatBlanc = 0;
                                ResultatNoir = 1;
                            }
                            else
                            {
                                ResultatBlanc = 0.5;
                                ResultatNoir = 0.5;
                            }
                            // Mise à jour des éléments du joueur (ronde, adversaire, couleur, résultat)
                            Participants[Echiquier_Resultat + Separation].Stat_Ronde(Ronde, TeteDeSerie_Noir, 1, ResultatBlanc);
                            Participants[Echiquier_Resultat].Stat_Ronde(Ronde, TeteDeSerie_Blanc, 0, ResultatNoir);
                            Couleur = 1;
                            Indice_Colonne++;
                        }
                    }
                }
                // Dans le cas d'une autre ronde
                else
                {
                    // Reprendre les joueurs des cellules et y mettre à jour leurs résultats
                    for (Echiquier_Resultat = 0; Echiquier_Resultat < (Nombre_de_Joueurs - 1); Echiquier_Resultat = Echiquier_Resultat + 2)
                    {
                        // Prise des n° de tête de série
                        TeteDeSerie_Blanc = Participants[Echiquier_Resultat].n_Depart_Du_JoueurLoad();
                        TeteDeSerie_Noir = Participants[Echiquier_Resultat + 1].n_Depart_Du_JoueurLoad();
                        // Chargement du résultat inscrit dans le tableau
                        string resultat_blanc = DGW_Ronde1.Rows[Indice_Colonne].Cells[5].Value.ToString();
                        // Prise du résultat
                        if (resultat_blanc == "1")
                        {
                            ResultatBlanc = 1;
                            ResultatNoir = 0;
                        }
                        else if (resultat_blanc == "0")
                        {
                            ResultatBlanc = 0;
                            ResultatNoir = 1;
                        }
                        else
                        {
                            ResultatBlanc = 0.5;
                            ResultatNoir = 0.5;
                        }
                        // Mise à jour des éléments du joueur (ronde, adversaire, couleur, résultat)
                        Participants[Echiquier_Resultat].Stat_Ronde(Ronde, TeteDeSerie_Noir, 1, ResultatBlanc);
                        Participants[Echiquier_Resultat + 1].Stat_Ronde(Ronde, TeteDeSerie_Blanc, 0, ResultatNoir);
                        Indice_Colonne++;
                    }
                }
                
                MessageBox.Show("Test : MAJ Réussie");
                // Cacher le bouton "ronde suivante" et réafficher le bouton "générer ronde" pour pouvoir
                // générer la ronde suivante
                BTN_Ronde_suivante.Hide();

                // Effacer tout le tableau
                DGW_Ronde1.Rows.Clear();
                // Ajouter une ronde et repermettre la mise à jour
                Ronde++;
                // Si c'était la dernière ronde (dès que la ronde actuelle dépasse le nombre de rondes maximum)
                if(Ronde > Ronde_Max)
                {
                    MessageBox.Show("Le tournoi est terminé !\r\nCliquer sur <Classement> pour voir le classement");
                }
                else
                {
                    BTN_GenRondes.Show();
                }
                // Permet la remise à jour des rondes
                MAJ = 1;
            }
            else
            {
                // Si la mise à jour a déjà été faite
                if (MAJ == 1)
                {
                    MessageBox.Show("Mise à jour déjà éffectuée");
                }
                // Sinon (donc si le tampon de mise à jour a été refusé
                else
                {
                    MessageBox.Show("Veuillez remplir tout les champs SVP !");
                }
            }

        }

        private void DGW_Ronde1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGW_Ronde1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            ligne_selectionnee = e.RowIndex;
            colonne_selectionnee = e.ColumnIndex;
        }

        private void DGW_Ronde1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGW_Ronde1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BTN_Classement_Int_Click(object sender, EventArgs e)
        {
            // Mise à jour des résultats
            if (MAJ == 1)
            {
                FClassement.ShowDialog();
            }
            else
            {
                MessageBox.Show("Mettez à jour la ronde SVP !");
            }
        }

        private void lbl_Rondes_Click(object sender, EventArgs e)
        {

        }

        private void DGW_Ronde1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Variable afin d'éviter un bug au démarrage
            if(Demarrage)
            {
                // Permettra de définir le résultat des noirs selon celui des blancs
                try
                {
                    // Prise de la valeur de la cellule quittée (ne dépend que de la colonne, mais va pointer sur la ligne en question)
                    string valeur_resultat = DGW_Ronde1.Rows[ligne_selectionnee].Cells[5].Value.ToString();
                    // Rempli la valeur du résultat opposé
                    // Si le joueur à gagné, l'autre à perdu
                    if (valeur_resultat == "1")
                    {
                        DGW_Ronde1.Rows[ligne_selectionnee].Cells[7].Value = "0";
                    }
                    // Si le joueur à perdu, l'autre à gagné
                    else if (valeur_resultat == "0")
                    {
                        DGW_Ronde1.Rows[ligne_selectionnee].Cells[7].Value = "1";
                    }
                    // Si la case n'est pas remplie ou donne un autre résultat : forcé au nul (½) au deux joueurs
                    else
                    {
                        DGW_Ronde1.Rows[ligne_selectionnee].Cells[5].Value = "½";
                        DGW_Ronde1.Rows[ligne_selectionnee].Cells[7].Value = "½";
                    }
                }
                // Si le champ est vide (génération d'une exception)
                catch (NullReferenceException)
                {
                    MessageBox.Show("Champ vide !", "Erreur de remplissage des cellules", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Methode pour la gestion des rondes
        public void Genere_Ronde()
        {
            // Pirse du numero de tête de série du joueur
            int TeteDeSerie_Blanc, TeteDeSerie_Noir;
            // Prise du nombre de joueurs ayant le même nombre de points
            int Nb_Joueurs_Meme_Points = 0;
            // Pour détécter le nombre d'échiquier à initialisé (dans le cas où il y a plusieurs rondes)
            int Pointeur_Echiquier_Debut = 0;
            int Pointeur_Echiquier_Fin = 0;
            int Echiquier = 0;
            // Pour la boucle for
            double i;
            int j;
            // MAJ de la ronde jouee
            Tournoi.MAJ_Ronde_Jouee(Ronde);
            Ronde = Tournoi.Ronde_Jouee();
            // Prise de la liste de depart
            Participants = Tournoi.ChargerListe();
            // Prise du nombre de joueur
            Nombre_de_Joueurs = Tournoi.Joueurs_Totaux();

            // Si c'est la première ronde, il y a besoin de moins d'étapes (pas de couleurs, pas d'adversaires, 1ère ronde vérouillée)
            if(Ronde == 1)
            {
                // Etape 1 : séparer en deux la liste de départ
                Separation = Nombre_de_Joueurs / 2;
                // Etape 2 : gérer la ronde de départ
                for (Init_Echiquier = 0; Init_Echiquier < Separation; Init_Echiquier++)
                {
                    if (Couleur == 1)
                    {
                        // Chargement des têtes de séries
                        TeteDeSerie_Blanc = Participants[Init_Echiquier].n_Depart_Du_JoueurLoad();
                        TeteDeSerie_Noir = Participants[Init_Echiquier + Separation].n_Depart_Du_JoueurLoad();
                        string[] row = new string[] { (Init_Echiquier + 1).ToString(), TeteDeSerie_Blanc.ToString(), Participants[Init_Echiquier].nom + " " + Participants[Init_Echiquier].prenom, Participants[Init_Echiquier].Titre, "(0)", "", "-", "", TeteDeSerie_Noir.ToString(), Participants[Separation + Init_Echiquier].nom + " " + Participants[Separation + Init_Echiquier].prenom, Participants[Separation + Init_Echiquier].Titre, "(0)" };
                        DGW_Ronde1.Rows.Add(row);
                        Couleur = 0;
                    }
                    else
                    {
                        // Chargement des têtes de séries
                        TeteDeSerie_Blanc = Participants[Init_Echiquier + Separation].n_Depart_Du_JoueurLoad();
                        TeteDeSerie_Noir = Participants[Init_Echiquier].n_Depart_Du_JoueurLoad();
                        string[] row = new string[] { (Init_Echiquier + 1).ToString(), TeteDeSerie_Blanc.ToString(), Participants[Separation + Init_Echiquier].nom + " " + Participants[Separation + Init_Echiquier].prenom, Participants[Separation + Init_Echiquier].Titre, "(0)", "", "-", "", TeteDeSerie_Noir.ToString(), Participants[Init_Echiquier].nom + " " + Participants[Init_Echiquier].prenom, Participants[Init_Echiquier].Titre, "(0)" };
                        DGW_Ronde1.Rows.Add(row);
                        Couleur = 1;
                    }
                }
            }
            // Mais si il y a déjà eu une ronde jouée, il va falloir traité plus de choses
            else
            {
                // Etape 1 : Trier le nombre de joueurs selon leurs points
                TriGesRonde(Participants, Ronde, Nombre_de_Joueurs);
                // Etape 2 : Compter le nombre de joueurs ayant le même nombre de points en partant par le nombre de points maximum
                for (i = (Ronde - 1); i >= 0; i = i - 0.5)
                {
                    // Traitement n°1 : Les joueurs ayant le maximum de points
                    // ... dernier traitement : Les joueurs ayant le minimum de points
                    for (j = 0; j < Nombre_de_Joueurs; j++)
                    {
                        // Calcul du nombre de joueurs ayant le même nombre de points
                        if (Participants[j].PointsJoueur() == i)
                        {
                            Nb_Joueurs_Meme_Points++;
                        }
                    }
                    // Il y a traitement d'information que s'il y a au moins 1 joueur avec le nombre de poitns requis
                    if(Nb_Joueurs_Meme_Points > 0)
                    {
                        // Ensuite, pour la première gestion des rondes, on effectue la même chose que pour la première ronde
                        Separation = Nb_Joueurs_Meme_Points / 2;
                        // Dans le cas ou le nombre de joueurs est pair
                        if ((Nb_Joueurs_Meme_Points % 2) == 0)
                        {
                            // Chargement du nombre d'échiquier à initialiser
                            Pointeur_Echiquier_Fin = Pointeur_Echiquier_Fin + Separation;
                            // Gestion des rondes
                            for (Init_Echiquier = Pointeur_Echiquier_Debut; Init_Echiquier < Pointeur_Echiquier_Fin; Init_Echiquier++)
                            {
                                // Chargement des têtes de séries
                                TeteDeSerie_Blanc = Participants[Pointeur_Echiquier_Debut].n_Depart_Du_JoueurLoad();
                                TeteDeSerie_Noir = Participants[Pointeur_Echiquier_Debut + 1].n_Depart_Du_JoueurLoad();
                                string[] row = new string[] { (Echiquier + 1).ToString(), TeteDeSerie_Blanc.ToString(), Participants[Pointeur_Echiquier_Debut].nom + " " + Participants[Pointeur_Echiquier_Debut].prenom, Participants[Pointeur_Echiquier_Debut].Titre, "(" + Participants[Pointeur_Echiquier_Debut].PointsJoueur() + ")", "", "-", "", TeteDeSerie_Noir.ToString(), Participants[Pointeur_Echiquier_Debut + 1].nom + " " + Participants[Pointeur_Echiquier_Debut + 1].prenom, Participants[Pointeur_Echiquier_Debut + 1].Titre, "(" + Participants[Pointeur_Echiquier_Debut + 1].PointsJoueur() + ")" };
                                DGW_Ronde1.Rows.Add(row);
                                // Incrémenataion du pointeur de l'échiquier DE DEUX (car un échiquier = deux joueurs)
                                Pointeur_Echiquier_Debut = Pointeur_Echiquier_Debut + 2;
                                // Incrémentation pour afficher le bon échiquier
                                Echiquier++;
                            }
                            // Reinitialise les pointeurs d'échiquiers
                            Pointeur_Echiquier_Fin = Pointeur_Echiquier_Debut;
                            // Remise à 0 des joueurs ayant le même nombre de points
                            Nb_Joueurs_Meme_Points = 0;
                        }
                        // Dans le cas ou le nombre de joueur est impair
                        else
                        {
                            // Chargement du nombre d'échiquier à initialiser + 1 avec un joueur ayant le nombre de points inférieur
                            Pointeur_Echiquier_Fin = Pointeur_Echiquier_Fin + Separation + 1;
                            // Gestion des rondes
                            for (Init_Echiquier = Pointeur_Echiquier_Debut; Init_Echiquier < Pointeur_Echiquier_Fin; Init_Echiquier++)
                            {
                                // Chargement des têtes de séries
                                TeteDeSerie_Blanc = Participants[Pointeur_Echiquier_Debut].n_Depart_Du_JoueurLoad();
                                TeteDeSerie_Noir = Participants[Pointeur_Echiquier_Debut + 1].n_Depart_Du_JoueurLoad();
                                string[] row = new string[] { (Echiquier + 1).ToString(), TeteDeSerie_Blanc.ToString(), Participants[Pointeur_Echiquier_Debut].nom + " " + Participants[Pointeur_Echiquier_Debut].prenom, Participants[Pointeur_Echiquier_Debut].Titre, "(" + Participants[Pointeur_Echiquier_Debut].PointsJoueur() + ")", "", "-", "", TeteDeSerie_Noir.ToString(), Participants[Pointeur_Echiquier_Debut + 1].nom + " " + Participants[Pointeur_Echiquier_Debut + 1].prenom, Participants[Pointeur_Echiquier_Debut + 1].Titre, "(" + Participants[Pointeur_Echiquier_Debut + 1].PointsJoueur() + ")" };
                                DGW_Ronde1.Rows.Add(row);
                                // Incrémenataion du pointeur de l'échiquier DE DEUX (car un échiquier = deux joueurs)
                                Pointeur_Echiquier_Debut = Pointeur_Echiquier_Debut + 2;
                                // Incrémentation pour afficher le bon échiquier
                                Echiquier++;
                            }
                            // Reinitialise les pointeurs d'échiquiers
                            Pointeur_Echiquier_Fin = Pointeur_Echiquier_Debut;
                            // Remise à -1 des joueurs ayant le même nombre de points (pour retirer un joueur avec le nombre de points inférieur)
                            Nb_Joueurs_Meme_Points = -1;
                        }
                    }
                }
            }
            // Faire disparaitre le bouton "générer ronde" et afficher le bouton "ronde suivante"
            BTN_GenRondes.Hide();
            BTN_Ronde_suivante.Show();
            MAJ = 0;
        }
        public void TriGesRonde(List<Joueur> Participants, int Ronde_Jouee, int NombreParticipants)
        {
            // Variable pour rechercher et trier les joueurs
            int n_DebutTri = 0;
            int n_FinTri = (NombreParticipants - 1);

            // Variable pour les comptages
            int i;
            int j;
            double k;

            // Pour détécter le nombre d'échiquier à initialisé (dans le cas où il y a plusieurs rondes)
            int Pointeur_Echiquier_Debut = 0;
            int Pointeur_Echiquier_Fin = 0;
            int Pointeur_Joueur = 0;
            int Echiquier = 0;

            // Tableau pour stocker des joueurs pour retrié
            Joueur[] Stockage_Supp = new Joueur[NombreParticipants];
            Joueur[] Stockage_Inf = new Joueur[NombreParticipants];

            // Variable pour le tri selon le nombre de points
            int Nb_Joueurs_Meme_Points = 0;

            while (n_DebutTri < n_FinTri)
            {
                int DebutTri = n_DebutTri;
                int FinTri = n_FinTri;
                n_DebutTri = NombreParticipants;
                // Premier tri : selon le nombre de points
                for (i = DebutTri; i < FinTri; i++)
                {
                    // Premier tri : selon le nombre de points
                    if (Participants[i].PointsJoueur() < Participants[i + 1].PointsJoueur())
                    {
                        Joueur Tirroir = Participants[i];
                        Participants[i] = Participants[i + 1];
                        Participants[i + 1] = Tirroir;
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
                    else if (Participants[i].PointsJoueur() == Participants[i + 1].PointsJoueur())
                    {
                        // Deuxième tri : selon le n° de tête de série
                        if (Participants[i].n_Depart_Du_JoueurLoad() > Participants[i + 1].n_Depart_Du_JoueurLoad())
                        {
                            Joueur Tirroir = Participants[i];
                            Participants[i] = Participants[i + 1];
                            Participants[i + 1] = Tirroir;
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
            // Séparer en deux chaque "partie" (joueur avec le même nombre de points) pour respecter le principe échiquéen
            // Compter le nombre de joueurs ayant le même nombre de points en partant par le nombre de points maximum
            for (k = (Ronde - 1); k >= 0; k = k - 0.5)
            {
                // Traitement n°1 : Les joueurs ayant le maximum de points
                // ... dernier traitement : Les joueurs ayant le minimum de points
                for (j = 0; j < Nombre_de_Joueurs; j++)
                {
                    // Calcul du nombre de joueurs ayant le même nombre de points
                    if (Participants[j].PointsJoueur() == k)
                    {
                        Nb_Joueurs_Meme_Points++;
                    }
                }
                // Il y a traitement d'information que s'il y a au moins 1 joueur avec le nombre de poitns requis
                if (Nb_Joueurs_Meme_Points > 0)
                {
                    // Ensuite, pour la première gestion des rondes, on effectue la même chose que pour la première ronde
                    Separation = Nb_Joueurs_Meme_Points / 2;
                    // Dans le cas ou le nombre de joueurs est pair
                    if ((Nb_Joueurs_Meme_Points % 2) == 0)
                    {
                        // Chargement du nombre d'échiquier à initialiser
                        Pointeur_Echiquier_Fin = Pointeur_Echiquier_Fin + Separation;
                        // Gestion des rondes
                        for (Init_Echiquier = Pointeur_Echiquier_Debut; Init_Echiquier < Pointeur_Echiquier_Fin; Init_Echiquier++)
                        {
                            // Remplissage des tableaux
                            Stockage_Supp[Init_Echiquier] = Participants[Pointeur_Joueur];
                            Stockage_Inf[Init_Echiquier] = Participants[Pointeur_Joueur + Separation];
                            // Incrémenataion du pointeur de l'échiquier
                            Pointeur_Echiquier_Debut++;
                            // Incrémentation du pointeur du joueur
                            Pointeur_Joueur++;
                            // Incrémentation pour afficher le bon échiquier
                            Echiquier++;
                        }
                        // Reinitialise les pointeurs d'échiquiers
                        Pointeur_Echiquier_Fin = Pointeur_Echiquier_Debut;
                        // Remise à 0 des joueurs ayant le même nombre de points
                        Nb_Joueurs_Meme_Points = 0;
                        // Remise à jour du pointeur du joueur
                        Pointeur_Joueur = Pointeur_Joueur + Separation;
                    }
                    // Dans le cas ou le nombre de joueur est impair
                    else
                    {
                        // Chargement du nombre d'échiquier à initialiser + 1 avec un joueur ayant le nombre de points inférieur
                        Pointeur_Echiquier_Fin = Pointeur_Echiquier_Fin + Separation;
                        // Gestion des rondes
                        for (Init_Echiquier = Pointeur_Echiquier_Debut; Init_Echiquier < Pointeur_Echiquier_Fin; Init_Echiquier++)
                        {
                            // Remplissage des tableaux
                            Stockage_Supp[Init_Echiquier] = Participants[Pointeur_Joueur];
                            Stockage_Inf[Init_Echiquier] = Participants[Pointeur_Joueur + Separation];
                            // Incrémenataion du pointeur de l'échiquier
                            Pointeur_Echiquier_Debut++;
                            // Incrémentation du pointeur du joueur DE DEUX
                            Pointeur_Joueur++;
                            // Incrémentation pour afficher le bon échiquier
                            Echiquier++;
                        }
                        // Remise à jour du pointeur du joueur
                        Pointeur_Joueur = Pointeur_Joueur + Separation;
                        // Rajout d'un échiquier avec le dernier ayant le même nombre de poins versus le premier ayant le nombre de points inférieur
                        Stockage_Supp[Init_Echiquier] = Participants[Pointeur_Joueur];
                        Stockage_Inf[Init_Echiquier] = Participants[Pointeur_Joueur + 1];
                        Pointeur_Echiquier_Debut++;
                        Pointeur_Joueur = Pointeur_Joueur + 2;
                        Init_Echiquier++;
                        // Reinitialise les pointeurs d'échiquiers
                        Pointeur_Echiquier_Fin = Pointeur_Echiquier_Debut;
                        // Remise à -1 des joueurs ayant le même nombre de points (pour retirer un joueur avec le nombre de points inférieur)
                        Nb_Joueurs_Meme_Points = -1;
                    }
                }
            }
            // Et on refait le tableau
            j = 0;
            for(i = 0; i < (NombreParticipants / 2); i++ )
            {
                Participants[j] = Stockage_Supp[i];
                Participants[j + 1] = Stockage_Inf[i];
                j = j + 2;
            }
            // Après avoir fait le tri par points et par n° de départ, ainsi que le tri par moitié, il faut contrôler si chaque joueur ont déjà joué l'un contre l'autre
            TestAdversaireEtCouleur(Participants, Ronde_Jouee, NombreParticipants);
        }

        // Deuxième tri, pour tester l'adversité et la couleur de chaque joueur
        public void TestAdversaireEtCouleur(List<Joueur> Participants, int Ronde_Jouee, int NombreParticipants)
        {
            int n_DebutTri = 0;
            int n_FinTri = (NombreParticipants - 1);
            int i, j;
            // Variable indice pour éviter de changer toujours le même adversaire en cas de changement d'adversaire
            int indice = 0;
            // Variable indiquant s'il faut retesté les échiquiers
            int retest_echiquier = 0;
            // Variables pour prend les valeurs des couleurs des deux joueurs (1 = blanc, 0 = noir)
            int J1_Couleur_1 = 0, J2_Couleur_1 = 0, J1_Couleur_2 = 0, J2_Couleur_2;

            // Début des tests
            int DebutTri = n_DebutTri;
            int FinTri = n_FinTri;
            n_DebutTri = NombreParticipants;

            do
            {
                // On remet le détécteur à 0
                retest_echiquier = 0;
                // Et on décale l'indice
                switch(indice)
                {
                    case 2:
                        indice = 3;
                        break;

                    case 3:
                        indice = 4;
                        break;

                    case 4:
                        indice = 5;
                        break;

                    case 5:
                        indice = 6;
                        break;

                    case 6:
                        indice = 7;
                        break;

                    // De base, mettre 2 s'il y a un débordement
                    default:
                        indice = 2;
                        break;
                }
                // Limitation de l'indice pour éviter d'être hors course
                if(indice >= (NombreParticipants/2))
                {
                    indice = 1;
                }
                // Test de l'adversité
                for (i = DebutTri; i < FinTri; i = i + 2)
                {
                    for(j = 1; j <= (Ronde_Jouee - 1); j++)
                    {
                        // Test chaque ronde si les deux joueurs de chaque échiquier ont déjà joué ensemble
                        if (Participants[i].Adv_To_Return(j) == Participants[i + 1].n_Depart_Du_JoueurLoad())
                        {
                            // Dans un sens si c'est la première moitié du classement qui est traitée (pour éviter un participant [-1]
                            if (i < (NombreParticipants / 2))
                            {
                                Joueur Tirroir = Participants[i + 1];
                                Participants[i + 1] = Participants[i + indice];
                                Participants[i + indice] = Tirroir;
                            }
                            // Dans l'autre sens si c'est la deuxième moitié du classement qui est traitée (pour éviter un participant [NbParticipants + 1]
                            else
                            {
                                Joueur Tirroir = Participants[i];
                                Participants[i] = Participants[i - (indice - 1)];
                                Participants[i - (indice - 1)] = Tirroir;
                            }
                            // Indique qu'il faudra de nouveau testé l'adversité
                            retest_echiquier = 1;
                        }
                    }
                }
            } while (retest_echiquier == 1);
            // Remise de l'indice à 2
            indice = 2;
            // Une fois le test de l'adversité OK, on attribue les couleurs
            for (i = DebutTri; i < FinTri; i = i + 2)
            {
                // Couleur du joueur 1
                J1_Couleur_1 = Participants[i].Couleur_To_Return(Ronde_Jouee - 1);
                // Couleur du joueur 2
                J2_Couleur_1 = Participants[i + 1].Couleur_To_Return(Ronde_Jouee - 1);
                // Si la couleur des deux joueurs est opposée :
                if (J1_Couleur_1 != J2_Couleur_1)
                {
                    // Si c'est le joueur 1 qui a eu les blancs et le joueur 2 qui a eu les noirs à la dernière ronde :
                    if ((J1_Couleur_1 == 1) && (J2_Couleur_1 == 0))
                    {
                        // Le joueur 1 jouera les noirs et le joueur 2 jouera les blancs
                        Joueur Tirroir = Participants[i];
                        Participants[i] = Participants[i + 1];
                        Participants[i + 1] = Tirroir;
                    }
                }
                // Autre cas à éviter : si un joueur a déjà joué 2 fois avec les blancs ou les noirs, il doit changer de couleur
                else
                {
                    // (cas possible uniquement après 2 rondes)
                    if (Ronde_Jouee > 2)
                    {
                        // Couleur du joueur 1
                        J1_Couleur_2 = Participants[i].Couleur_To_Return(Ronde_Jouee - 2);
                        // Couleur du joueur 2
                        J2_Couleur_2 = Participants[i + 1].Couleur_To_Return(Ronde_Jouee - 2);
                        // Si le joueur 1 a déjà joué 2 fois avec les blancs ou que le joueur 2 a déjà joué 2 fois avec les noirs :
                        if (((J1_Couleur_1 == 1) && (J1_Couleur_2 == 1)) || ((J2_Couleur_1 == 0) && (J2_Couleur_2 == 0)))
                        {
                            // Le joueur 1 jouera les noirs et le joueur 2 jouera les blancs
                            Joueur Tirroir = Participants[i];
                            Participants[i] = Participants[i + 1];
                            Participants[i + 1] = Tirroir;
                        }
                        // Dans tout les autres cas (même couleur où joueur 2 qui avait les blancs), la structure restera la même
                    }
                }
            }
        }
    }
}
