using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#if (BLANC)
    1
#endif

#if (NOIR)
    0
#endif


namespace Tournoi_Echec
{
    public partial class FormMain : Form
    {
        // Objet pour les class
        private Tournoi Tournoi = new Tournoi();
        private FormSub1 Ronde1 = new FormSub1();
        private FormListededepart ListeDeDepart = new FormListededepart();
        // Variables locales
        int Nb_Rondes_Choisie;
        int Nombre_de_joueurs;
        decimal Ratio;

        public FormMain()
        {
            InitializeComponent();
        }

        private void TB_ListeDeDepart_Paint(object sender, PaintEventArgs e)
        {
      
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Nb_Rondes_ValueChanged(object sender, EventArgs e)
        {

        }

        private void BTN_Demarrer_Tournoi_Click(object sender, EventArgs e)
        {
            // Calcul du nombre de joueur minimum selon le ratio suivant
            Nb_Rondes_Choisie = (int)Nb_Rondes.Value;
            Ratio = ((Nb_Rondes_Choisie - 5) * 4 )+ 12;
            Nombre_de_joueurs = Tournoi.Joueurs_Totaux();
            if (Nombre_de_joueurs < Ratio)
            {
                MessageBox.Show("Pas assez de joueur !\r\nMinimum " + Ratio + " joueur requis pour " + Nb_Rondes_Choisie + " rondes !", "Warning Start", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Bienvenue !", "Welcome Start", MessageBoxButtons.OK);
                // Prend le nombre de ronde maximum choisi
                Tournoi.MAJ_Ronde_Max(Nb_Rondes_Choisie);
                Ronde1.ShowDialog();
            }   
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BTN_LDD_Click(object sender, EventArgs e)
        {
            ListeDeDepart.ShowDialog();
        }

        private void btn_Help_Click(object sender, EventArgs e)
        {
            // Ouverture de la "message box" pérsonalisée, avec le logo du programme et les boutons personalisé
            // Le texte d'entrée sera le même que le premier a afficher
            CustomMsgBox.Show("Bienvenu dans le mode aide de ce programme !", "HELP", "<<", ">>", "Fin");
        }
    }
    // class tournoi
    public class Tournoi
    {
        private static int NbJoueurs;
        private static int Ronde_Actuelle;
        private static int Ronde_Totale;
        public static List<Joueur> Joueurs = new List<Joueur>();

        // Voir le nombre de joueurs totaux
        public static int Joueurs_Totaux()
        {
            int m_NbJoueurs;
            m_NbJoueurs = NbJoueurs;
            return (m_NbJoueurs);
        }
        // Redefinir le nombre de joueurs totaux
        public static void MAJ_Joueurs_Totaux(int m_NbJoueurs)
        {
            NbJoueurs = m_NbJoueurs;
        }
        // Creation d'une liste
        public static List<Joueur> ChargerListe()
        {
            List<Joueur> m_Joueur;
            m_Joueur = Joueurs;
            return m_Joueur;
        }
        public static void SaveListe(List<Joueur> J)
        {
            Joueurs = J;
        }
        // Detecteur de la ronde
        public static int Ronde_Jouee()
        {
            int m_ronde_actuelle;
            m_ronde_actuelle = Ronde_Actuelle;
            return (m_ronde_actuelle);
        }
        // Redefinir la ronde jouée
        public static void MAJ_Ronde_Jouee(int m_Ronde_actuelle)
        {
            Ronde_Actuelle = m_Ronde_actuelle;
        }
        // Detecteur du nombre de ronde max
        public static int Ronde_Max()
        {
            int m_ronde_totale;
            m_ronde_totale = Ronde_Totale;
            return (m_ronde_totale);
        }
        // Redefinir la ronde jouée
        public static void MAJ_Ronde_Max(int m_Ronde_totale)
        {
            Ronde_Totale = m_Ronde_totale;
        }
        // constructeur
        public Tournoi()
        {
            NbJoueurs = 0;
        }
    }
    // class joueur
    public class Joueur
    {
        // attribus du joueur
        public string nom;
        public string prenom;
        public int n_de_depart;
        public int ELO;
        public string Titre;
        public string club;
        private int victoire;
        private int matchnul;
        private int defaite;
        private float points;
        private float buchholtz;
        private float somme_buccholtz;
        // Adversaire et couleur par liste
        public static List<Adversaire> Adverse = new List<Adversaire>();
        public static List<Couleur> Color = new List<Couleur>();
        // Adversaire et couleur par 11 attributs
        private int Adv_1;
        private int Adv_2;
        private int Adv_3;
        private int Adv_4;
        private int Adv_5;
        private int Adv_6;
        private int Adv_7;
        private int Adv_8;
        private int Adv_9;
        private int Adv_10;
        private int Adv_11;
        private int Couleur_1;
        private int Couleur_2;
        private int Couleur_3;
        private int Couleur_4;
        private int Couleur_5;
        private int Couleur_6;
        private int Couleur_7;
        private int Couleur_8;
        private int Couleur_9;
        private int Couleur_10;
        private int Couleur_11;
        // Resultat des 11 rondes (sous char)
        private char Resultat_1;
        private char Resultat_2;
        private char Resultat_3;
        private char Resultat_4;
        private char Resultat_5;
        private char Resultat_6;
        private char Resultat_7;
        private char Resultat_8;
        private char Resultat_9;
        private char Resultat_10;
        private char Resultat_11;
        // Position finale
        private int PositionFinale;

        // Pour la mise à jour des résultats propre aux joueurs lui-même (V/N/D, points)
        public void MAJ_Resultat(double Resultat)
        {
            if (Resultat == 1)
            {
                victoire++;
                points = points + 1;
            }
            else if (Resultat == 0.5)
            {
                matchnul++;
                points = points + (float)0.5;
            }
            else if (Resultat == 0)
            {
                defaite++;
            }
        }
        // Pour la mise à jour des résultats propre aux adversaires des joueurs (Buchh, SoBerg)
        public void MAJ_Buchh(float PtsAdv)
        {
            buchholtz = PtsAdv;
        }
        public void MAJ_SoBerg(float BuchhAdv)
        {
            somme_buccholtz = BuchhAdv;
        }
        // Pour y prendre les statiques du joueur de la ronde jouée
        public void Stat_Ronde(int n_Ronde, int n_adversaire, int n_Couleur, double Resultat)
        {
            /*
            // Mise à jour de la couleur de de l'adversaire de la ronde en question
            Adverse.Add(new Adversaire(n_adversaire));
            Color.Add(new Couleur(n_Couleur));

            // Sauvegarde des listes
            SaveAdversaire(Adverse);
            */
            // Variable char interne pour mettre à jour les resultats de chaque ronde
            char Resultat_char;
            // Rempli cette variable pour la copié ensuite dans l'attribut correspondant
            if(Resultat == 1)
            {
                Resultat_char = '1';
            }
            else if(Resultat == 0.5)
            {
                Resultat_char = '½';
            }
            else
            {
                Resultat_char = '0';
            }

            switch(n_Ronde)
            {
                case 1:
                    Adv_1 = n_adversaire;
                    Couleur_1 = n_Couleur;
                    Resultat_1 = Resultat_char;
                    break;
                case 2:
                    Adv_2 = n_adversaire;
                    Couleur_2 = n_Couleur;
                    Resultat_2 = Resultat_char;
                    break;
                case 3:
                    Adv_3 = n_adversaire;
                    Couleur_3 = n_Couleur;
                    Resultat_3 = Resultat_char;
                    break;
                case 4:
                    Adv_4 = n_adversaire;
                    Couleur_4 = n_Couleur;
                    Resultat_4 = Resultat_char;
                    break;
                case 5:
                    Adv_5 = n_adversaire;
                    Couleur_5 = n_Couleur;
                    Resultat_5 = Resultat_char;
                    break;
                case 6:
                    Adv_6 = n_adversaire;
                    Couleur_6 = n_Couleur;
                    Resultat_6 = Resultat_char;
                    break;
                case 7:
                    Adv_7 = n_adversaire;
                    Couleur_7 = n_Couleur;
                    Resultat_7 = Resultat_char;
                    break;
                case 8:
                    Adv_8 = n_adversaire;
                    Couleur_8 = n_Couleur;
                    Resultat_8 = Resultat_char;
                    break;
                case 9:
                    Adv_9 = n_adversaire;
                    Couleur_9 = n_Couleur;
                    Resultat_9 = Resultat_char;
                    break;
                case 10:
                    Adv_10 = n_adversaire;
                    Couleur_10 = n_Couleur;
                    Resultat_10 = Resultat_char;
                    break;
                case 11:
                    Adv_11 = n_adversaire;
                    Couleur_11 = n_Couleur;
                    Resultat_11 = Resultat_char;
                    break;
                default:
                    break;
            }
            // Mise à jour du résultat
            MAJ_Resultat(Resultat);
        }
        // Mise à jour indépendante du n° de l'adversaire
        public void MAJ_n_adversaire(int n_adversaire, int n_Ronde)
        {
            switch (n_Ronde)
            {
                case 1:
                    Adv_1 = n_adversaire;
                    break;
                case 2:
                    Adv_2 = n_adversaire;
                    break;
                case 3:
                    Adv_3 = n_adversaire;
                    break;
                case 4:
                    Adv_4 = n_adversaire;
                    break;
                case 5:
                    Adv_5 = n_adversaire;
                    break;
                case 6:
                    Adv_6 = n_adversaire;
                    break;
                case 7:
                    Adv_7 = n_adversaire;
                    break;
                case 8:
                    Adv_8 = n_adversaire;
                    break;
                case 9:
                    Adv_9 = n_adversaire;
                    break;
                case 10:
                    Adv_10 = n_adversaire;
                    break;
                case 11:
                    Adv_11 = n_adversaire;
                    break;
                default:
                    break;
            }
        }

        // Pour retourner l'adversaire qui a été joué
        // par les listes
        /*
        public List<Adversaire> Return_Adv()
        {
            // Retourne l'adversaire de la ronde souhaitée
            List<Adversaire> m_adversaire;
            m_adversaire = Adverse;
            return (m_adversaire);
        }
        public void SaveAdversaire(List<Adversaire> A)
        {
            Adverse = A;
        }
        */
        // par les attributs
        public int Adv_To_Return(int n_Ronde)
        {
            switch (n_Ronde)
            {
                case 1:
                    return (Adv_1);
                case 2:
                    return (Adv_2);
                case 3:
                    return (Adv_3);
                case 4:
                    return (Adv_4);
                case 5:
                    return (Adv_5);
                case 6:
                    return (Adv_6);
                case 7:
                    return (Adv_7);
                case 8:
                    return (Adv_8);
                case 9:
                    return (Adv_9);
                case 10:
                    return (Adv_10);
                case 11:
                    return (Adv_11);
                default:
                    return (0);
            }
        }
        // Pour retourner la couleur que le joueur avait dans chacune des rondes
        public int Couleur_To_Return(int n_Ronde)
        {
            switch (n_Ronde)
            {
                case 1:
                    return (Couleur_1);
                case 2:
                    return (Couleur_2);
                case 3:
                    return (Couleur_3);
                case 4:
                    return (Couleur_4);
                case 5:
                    return (Couleur_5);
                case 6:
                    return (Couleur_6);
                case 7:
                    return (Couleur_7);
                case 8:
                    return (Couleur_8);
                case 9:
                    return (Couleur_9);
                case 10:
                    return (Couleur_10);
                case 11:
                    return (Couleur_11);
                default:
                    return (0);
            }
        }
        // Pour retourner le résultat que le joueur avait dans chacune des rondes
        public char Resultat_To_Return(int n_Ronde)
        {
            switch (n_Ronde)
            {
                case 1:
                    return (Resultat_1);
                case 2:
                    return (Resultat_2);
                case 3:
                    return (Resultat_3);
                case 4:
                    return (Resultat_4);
                case 5:
                    return (Resultat_5);
                case 6:
                    return (Resultat_6);
                case 7:
                    return (Resultat_7);
                case 8:
                    return (Resultat_8);
                case 9:
                    return (Resultat_9);
                case 10:
                    return (Resultat_10);
                case 11:
                    return (Resultat_11);
                default:
                    return ('0');
            }
        }
        // Pour retourner la position finale (classement ou rang) du joueur
        public int RangFinal()
        {
            return (PositionFinale);
        }
        // Pour mettre à jour la position finale (classement ou rang) du joueur
        public void MAJ_RangFinal(int Rang)
        {
            PositionFinale = Rang;
        }
        public void Stat_Classement()
        {

        }
        // Méthode d'affichage
        public string Nom_Du_Joueur()
        {
            string m_nom;
            m_nom = nom;
            return (m_nom);
        }
        public string Prenom_Du_Joueur()
        {
            string m_prenom;
            m_prenom = prenom;
            return (m_prenom);
        }
        public string Club_Du_Joueur()
        {
            string m_club;
            m_club = club;
            return (m_club);
        }
        public int ELO_Du_Joueur()
        {
            int m_ELO;
            m_ELO = ELO;
            return (m_ELO);
        }
        public int VictoireJoueur()
        {
            int m_Victoire;
            m_Victoire = victoire;
            return (m_Victoire);
        }
        public int NulJoueur()
        {
            int m_Nul;
            m_Nul = matchnul;
            return (m_Nul);
        }
        public int DefaiteJoueur()
        {
            int m_Defaite;
            m_Defaite = defaite;
            return (m_Defaite);
        }
        public float PointsJoueur()
        {
            float m_Points;
            m_Points = points;
            return (m_Points);
        }
        public float BuchhJoueur()
        {
            float m_Buchh;
            m_Buchh = buchholtz;
            return (m_Buchh);
        }
        public float SoBergJoueur()
        {
            float m_SoBerg;
            m_SoBerg = somme_buccholtz;
            return (m_SoBerg);
        }
        public void n_Depart_Du_Joueur(int m_n_depart)
        {
            n_de_depart = m_n_depart;
        }
        public int n_Depart_Du_JoueurLoad()
        {
            int m_n_de_departLoad;
            m_n_de_departLoad = n_de_depart;
            return (m_n_de_departLoad);
        }
        // constructeur
        public Joueur(string n_Nom, string n_Prenom, string n_Club, int n_ELO, string n_Titre)
        {
            nom = n_Nom;
            prenom = n_Prenom;
            club = n_Club;
            ELO = n_ELO;
            Titre = n_Titre;
            victoire = 0;
            matchnul = 0;
            defaite = 0;
            points = 0;
            buchholtz = 0;
            somme_buccholtz = 0;
        }
        // Pour y entrer les noms, prenoms, club, ELO et titres
        public string JoueurName { get; set; }
        public string JoueurSurName { get; set; }
        public string JoueurClub { get; set; }
        public int JoueurELO { get; set; }
        public string JoueutTitre { get; set; }
    }
    // class adversaire
    public class Adversaire
    {
        public static int tete_de_serie_de_l_adversaire;

        public void Adversaire_Save(int n_tete_de_serie_de_l_adversaire)
        {
            tete_de_serie_de_l_adversaire = n_tete_de_serie_de_l_adversaire;
        }
        public int Adversaires_Load()
        {
            int m_Adversaires_Load;
            m_Adversaires_Load = tete_de_serie_de_l_adversaire;
            return (m_Adversaires_Load);
        }
        // Constructeur
        public Adversaire (int n_tete_de_serie_de_l_adversaire)
        {
            tete_de_serie_de_l_adversaire = n_tete_de_serie_de_l_adversaire;
        }
        // Pour créer un adversaire ayant l'attribu de la tête de série
        public int AdversaireTeteDeSerie { get; set; }
    }
    // class adversaire
    public class Couleur
    {
        public int couleur_du_joueur;
        public void Couleur_Save(int n_couleur_du_joueur)
        {
            couleur_du_joueur = n_couleur_du_joueur;
        }
        public int Couleur_Load()
        {
            int m_Couleur_Load;
            m_Couleur_Load = couleur_du_joueur;
            return (m_Couleur_Load);
        }
        // Constructeur
        public Couleur(int n_couleur_du_joueur)
        {
            couleur_du_joueur = n_couleur_du_joueur;
        }
        // Pour créer un adversaire ayant l'attribu de la tête de série
        public int CouleurJoueur { get; set; }
    }
}
