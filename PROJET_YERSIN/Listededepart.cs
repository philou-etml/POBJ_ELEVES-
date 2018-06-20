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
    public partial class FormListededepart : Form
    {
        // Creation d'une liste
        List<Joueur> Participant;
        // Variables pour y prendre les valeurs
        string Nom;
        string Prenom;
        string Club;
        int ELO;
        string Titre;
        int Nombre_de_Joueurs = 0;

        // Variable detectant si le tri à bien été fait, et qu'il n'y a pas eu de joueur ajouter / retirer entre temps
        int Tri_Fait = 0;
        public FormListededepart()
        {
            InitializeComponent();
            // Mise sur le premier élément du combobox
            this.CBO_Titres.SelectedIndex = 0;
        }

        private void Listededepart_Load(object sender, EventArgs e)
        {

        }

        private void btn_addition_joueur_Click(object sender, EventArgs e)
        {
            Participant = Tournoi.ChargerListe();

            Nom = TXT_NAME.Text;
            Prenom = TXT_SURNAME.Text;
            Club = TXT_CLUB.Text;
            Titre = CBO_Titres.Text;
            // Vérifie que le champ ELO est bien un chiffre entier
            if (int.TryParse(TXT_ELO.Text, out ELO) == true)
            {
                // Pas plus que 3'000 (le champion du monde à 2884 actuellement ;))
                if (ELO > 3000)
                {
                    ELO = 3000;
                    MessageBox.Show("Valeur ELO fixée au seuil de 3'000 !", "Enregistrement des joueurs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // Minimum de 100 (un peu de respect quand même)
                if (ELO < 100)
                {
                    ELO = 100;
                    MessageBox.Show("Valeur ELO fixée au seuil de 100 !", "Enregistrement des joueurs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Participant.Add(new Joueur(Nom, Prenom, Club, ELO, Titre));
                string[] row = new string[] { (Nombre_de_Joueurs + 1).ToString(), Participant[Nombre_de_Joueurs].nom, Participant[Nombre_de_Joueurs].prenom, Participant[Nombre_de_Joueurs].club, Participant[Nombre_de_Joueurs].ELO.ToString(), Participant[Nombre_de_Joueurs].Titre };
                DGV_LDD.Rows.Add(row);
                // Clear les champs de texte
                TXT_NAME.Clear();
                TXT_SURNAME.Clear();
                TXT_CLUB.Clear();
                TXT_ELO.Clear();
                // Retour sur le premier champ du combobox
                this.CBO_Titres.SelectedIndex = 0;
                // Il faudra trier
                Tri_Fait = 0;
                // MAJ des joueurs de tournoi
                Nombre_de_Joueurs = Tournoi.Joueurs_Totaux();
                Nombre_de_Joueurs++;
                Tournoi.MAJ_Joueurs_Totaux(Nombre_de_Joueurs);
            }
            else
            {
                MessageBox.Show("Joueur non inscrit ! \r\nVeuillez entrer une valeur ELO valide !", "Enregistrement des joueurs", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_suppresion_joueur_Click(object sender, EventArgs e)
        {
            // Si le nombre de joueurs est suppérieur à 0
            if (Nombre_de_Joueurs > 0)
            {
                // Retirer le dernier joueur entrer
                Participant.RemoveAt((Nombre_de_Joueurs - 1));
                DGV_LDD.Rows.RemoveAt((Nombre_de_Joueurs - 1));
                Nombre_de_Joueurs = Tournoi.Joueurs_Totaux();
                Nombre_de_Joueurs--;
                Tournoi.MAJ_Joueurs_Totaux(Nombre_de_Joueurs);
                // Il faudra trier
                Tri_Fait = 0;
            }
            else
            {
                // Message pour préciser qu'il n'y a plus de joueurs
                MessageBox.Show("Il n'y a pas de joueur dans votre tournoi !", "Enregistrement des joueurs", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btn_Tri_LDD_Click(object sender, EventArgs e)
        {
            // Appel une fonction pour le tri
            Tri();
        }

        private void btn_save_config_Click(object sender, EventArgs e)
        {
            int i = 0;
            // Si il y a au moins un joueur inscrit ET que le tri a été fait
            if ((Nombre_de_Joueurs > 0) && (Tri_Fait == 1))
            {
                // Ajout/Suppréssion d'un joueur "spielfrei" s'il y a un nombre impair de joueur
                if (Nombre_de_Joueurs % 2 != 0)
                {
                    // Vérifier s'il n'y a pas déjà un joueur spielfrei (forcément le dernier joueur à cause de la limitation d'ELO et l'obligation de trier les joueurs pour valider la liste de départ
                    if (Participant[Nombre_de_Joueurs - 1].ELO == 0)
                    {
                        // Si un joueur spielfrei existe déjà, éffacer le joueur
                        Nombre_de_Joueurs--;
                        MessageBox.Show("Suppression joueur spielfrei !", "Enregistrement des joueurs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DGV_LDD.Rows.RemoveAt(Nombre_de_Joueurs);
                        Participant.RemoveAt(Nombre_de_Joueurs);
                    }
                    else
                    {
                        // Si un joueur spielfrei n'existe pas, le rajouter à la liste de départ
                        Participant.Add(new Joueur("spielfrei", " ", " ", 0, " "));
                        Participant[Nombre_de_Joueurs].n_Depart_Du_Joueur(Nombre_de_Joueurs + 1);
                        MessageBox.Show("Ajout d'un joueur spielfrei, car nombre de joueur impair !", "Enregistrement des joueurs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Ajout du joueur dans le tableau
                        string[] row = new string[] { (Nombre_de_Joueurs + 1).ToString(), Participant[Nombre_de_Joueurs].nom, Participant[Nombre_de_Joueurs].prenom, Participant[Nombre_de_Joueurs].club, Participant[Nombre_de_Joueurs].ELO.ToString(), Participant[Nombre_de_Joueurs].Titre };
                        DGV_LDD.Rows.Add(row);
                        Nombre_de_Joueurs++;
                    }
                    // Mettre à jour le nombre de joueurs
                    Tournoi.MAJ_Joueurs_Totaux(Nombre_de_Joueurs);
                    MessageBox.Show("Nombre de Joueurs : " + Nombre_de_Joueurs + ".\r\n" + "Tête de série n°1 : " + Participant[0].nom + " " + Participant[0].prenom + ".", "Enregistrement des joueurs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Nombre de Joueurs : " + Nombre_de_Joueurs + ".\r\n" + "Tête de série n°1 : " + Participant[0].nom + " " + Participant[0].prenom + ".", "Enregistrement des joueurs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // Copier la liste dans la classe Tournoi
                Tournoi.SaveListe(Participant);
                // Ferme la fenêtre
                this.Hide();
            }
            // Si aucun joueur n'a été enregistrer
            else if (Nombre_de_Joueurs == 0)
            {
                MessageBox.Show("Pas de joueur enregistré !", "Enregistrement des joueurs", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                // On ne ferme pas la fenêtre ==> il faut au moins un joueur inscrit
            }
            // Si le tri n'a pas été fait
            else if (Tri_Fait == 0)
            {
                MessageBox.Show("Vous n'avez pas effectué le tri !\r\n" + "Veuillez cliquer sur le bouton <Tri> !", "Enregistrement des joueurs", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                // On ne ferme pas la fenêtre ==> il faut faire le tri
            }
            // S'il y a un autre problème
            else
            {
                // Pour prévention - debug
                MessageBox.Show("Il y a un bug !", "Enregistrement des joueurs", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FormListededepart_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void LB_LDD_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TXT_NAME_TextChanged(object sender, EventArgs e)
        {

        }

        private void TXT_SURNAME_TextChanged(object sender, EventArgs e)
        {

        }

        private void TXT_CLUB_TextChanged(object sender, EventArgs e)
        {

        }

        private void TXT_ELO_TextChanged(object sender, EventArgs e)
        {

        }

        private void DGV_LDD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // Methode pour gérer le tri des joueurs et l'affichage dans le tableau
        public void Tri()
        {
            int Tri = 0;
            int Tete_de_serie = 1;
            // Tri du tableau selon le nombre d'ELO
            TriELO(Participant);
            // Ré-affichage de la liste
            DGV_LDD.Rows.Clear();
            for (Tri = 0; Tri < Nombre_de_Joueurs; Tri++)
            {
                string[] row = new string[] { (Tete_de_serie).ToString(), Participant[Tri].nom, Participant[Tri].prenom, Participant[Tri].club, Participant[Tri].ELO.ToString(), Participant[Tri].Titre };
                DGV_LDD.Rows.Add(row);
                Participant[Tri].n_Depart_Du_Joueur(Tete_de_serie);
                Tete_de_serie++;
            }
            // Le tri a été fait
            Tri_Fait = 1;
        }

        // Methode de tri (https://www.developpez.net/forums/d568159/dotnet/langages/csharp/trier-liste-d-objets/) (https://www.developpez.net/forums/d1433633/c-cpp/c/debuter/fonction-tri-croissant-tri-decroissant/)
        public void TriELO(List<Joueur> Participant)
        {
            int n_DebutTri = 0;
            int n_FinTri = (Nombre_de_Joueurs - 1);

            while (n_DebutTri < n_FinTri)
            {
                int DebutTri = n_DebutTri;
                int FinTri = n_FinTri;
                n_DebutTri = Nombre_de_Joueurs;
                for (int i = DebutTri; i < FinTri; i++)
                {
                    if (Participant[i].ELO < Participant[i + 1].ELO)
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void CBO_Titres_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_random_Click(object sender, EventArgs e)
        {
            // Le but est de créer une liste de joueurs, afin d'éviter de perdre trop de temps à taper chaque joueur pour tester à chaque fois
            // sert pour les tests
            // Déclaration des variables locales
            int i = 1;
            int nb_joueur_random = 40;

            // Chargement de la liste
            Participant = Tournoi.ChargerListe();
            // Création de 40 joueurs, avec des clubs, ELO et valeur aléatoire
            for(i = 1; i <= nb_joueur_random; i++)
            {
                // Va rechercher et créer un des joueurs random
                switch(i)
                {
                    case 1:
                        Participant.Add(new Joueur("Page", "Ismaël", "Avenches", 1671, " "));
                        break;
                    case 2:
                        Participant.Add(new Joueur("Pasquier", "Arthur", "Estavanens", 1426, " "));
                        break;
                    case 3:
                        Participant.Add(new Joueur("Henrio", "Alexandre", "Les Moulins", 1773, " "));
                        break;
                    case 4:
                        Participant.Add(new Joueur("Habibi", "Ali", "Berne", 2229, "IM"));
                        break;
                    case 5:
                        Participant.Add(new Joueur("Graf", "Antonin", "Ayent", 1590, " "));
                        break;
                    case 6:
                        Participant.Add(new Joueur("Weibel", "Romain", "Bossonnens", 1786, " "));
                        break;
                    case 7:
                        Participant.Add(new Joueur("Fürst", "Fabien", "Neuchatel", 1898, " "));
                        break;
                    case 8:
                        Participant.Add(new Joueur("Ben Rehuma", "Malek", "Renens", 1643, " "));
                        break;
                    case 9:
                        Participant.Add(new Joueur("Stoeri", "Simon", "Payerne", 2195, "FM"));
                        break;
                    case 10:
                        Participant.Add(new Joueur("Chabloz", "Alexis", "Gérignoz", 1760, " "));
                        break;
                    case 11:
                        Participant.Add(new Joueur("Resplendino", "Maxime", "Lausanne", 1549, " "));
                        break;
                    case 12:
                        Participant.Add(new Joueur("Da Costa", "Yann", "Neuchatel", 1540, " "));
                        break;
                    case 13:
                        Participant.Add(new Joueur("Chabloz", "Simon", "Gérignoz", 1641, " "));
                        break;
                    case 14:
                        Participant.Add(new Joueur("Turrian", "Alexandre", "Château-d'Oex", 1600, " "));
                        break;
                    case 15:
                        Participant.Add(new Joueur("Flückiger", "Harris", "Morges", 1645, " "));
                        break;
                    case 16:
                        Participant.Add(new Joueur("Weibel", "Nicolas", "Bossonnens", 1770, " "));
                        break;
                    case 17:
                        Participant.Add(new Joueur("Martins", "David", "Lausanne", 1515, " "));
                        break;
                    case 18:
                        Participant.Add(new Joueur("Pin", "Gaël", "Neuchatel", 1701, " "));
                        break;
                    case 19:
                        Participant.Add(new Joueur("Djoric", "Jordan", "Neuchatel", 1490, " "));
                        break;
                    case 20:
                        Participant.Add(new Joueur("Raetsky", "Alexander", "Russie", 2374, "GM"));
                        break;
                    case 21:
                        Participant.Add(new Joueur("Morard", "Cédric", "Nyon", 1850, " "));
                        break;
                    case 22:
                        Participant.Add(new Joueur("Yersin", "Dominique", "Château-d'Oex", 1740, " "));
                        break;
                    case 23:
                        Participant.Add(new Joueur("Garcia", "Oscar", "Neuchatel", 1470, " "));
                        break;
                    case 24:
                        Participant.Add(new Joueur("Assadi", "Ghadir", "Yverdon", 1444, " "));
                        break;
                    case 25:
                        Participant.Add(new Joueur("Volet", "Jérémy", "St-Martin", 1703, " "));
                        break;
                    case 26:
                        Participant.Add(new Joueur("Sellem", "Johan", "Montbovon", 1609, " "));
                        break;
                    case 27:
                        Participant.Add(new Joueur("Morier", "Olivier", "Château-d'Oex", 1596, " "));
                        break;
                    case 28:
                        Participant.Add(new Joueur("Gautschi", "Simon", "Lausanne", 1666, " "));
                        break;
                    case 29:
                        Participant.Add(new Joueur("Morier", "Matthis", "Château-d'Oex", 1543, " "));
                        break;
                    case 30:
                        Participant.Add(new Joueur("Gomes", "João", "Echallens", 1663, " "));
                        break;
                    case 31:
                        Participant.Add(new Joueur("Favre", "Patrick", "Lausanne", 1479, " "));
                        break;
                    case 32:
                        Participant.Add(new Joueur("Combremont", "Didier", "L'Etivaz", 1842, " "));
                        break;
                    case 33:
                        Participant.Add(new Joueur("Karnstadt", "Steve", "La Tine", 1690, " "));
                        break;
                    case 34:
                        Participant.Add(new Joueur("Strambace", "Dario", "Lausanne", 1659, " "));
                        break;
                    case 35:
                        Participant.Add(new Joueur("Pasquier", "Simon", "Estavanens", 1239, " "));
                        break;
                    case 36:
                        Participant.Add(new Joueur("Karnstadt", "Kevin", "La Tine", 1774, " "));
                        break;
                    case 37:
                        Participant.Add(new Joueur("Provenzano", "Yohann", "Villeneuve", 1588, " "));
                        break;
                    case 38:
                        Participant.Add(new Joueur("Favre", "Arnaud", "Estavanens", 1637, " "));
                        break;
                    case 39:
                        Participant.Add(new Joueur("Isoz", "Jean-Michel", "Château-d'Oex", 1415, " "));
                        break;
                    case 40:
                        Participant.Add(new Joueur("Bovey", "Philippe", "Lausanne", 1699, " "));
                        break;
                    //Sinon, pas de joueur à inscrire
                    default:
                        break;
                }
                // Affiche sur le tableau
                string[] row = new string[] { (Nombre_de_Joueurs + 1).ToString(), Participant[Nombre_de_Joueurs].nom, Participant[Nombre_de_Joueurs].prenom, Participant[Nombre_de_Joueurs].club, Participant[Nombre_de_Joueurs].ELO.ToString(), Participant[Nombre_de_Joueurs].Titre };
                DGV_LDD.Rows.Add(row);
                Nombre_de_Joueurs++;
            }
            // Remettre à jour le nombre de joueur
            Tournoi.MAJ_Joueurs_Totaux(Nombre_de_Joueurs);
            // Il faudra trier
            Tri_Fait = 0;
            // A la fin, on fait disparaitre le bouton et les lables correspondants
            btn_random.Hide();
            lbl_rl1.Hide();
            lbl_rl2.Hide();
        }
    }
}
