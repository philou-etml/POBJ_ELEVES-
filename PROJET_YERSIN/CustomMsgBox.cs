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
    public partial class CustomMsgBox : Form
    {
        static int Message_Help_A_Afficher = 1;
        public CustomMsgBox()
        {
            InitializeComponent();
            Message_Help_A_Afficher = 1;
        }

        static CustomMsgBox MsgBox;
        static DialogResult result = DialogResult.No;
        public static DialogResult Show(string Text, string Caption, string btnPrecedent, string btnSuivant, string btnCancel)
        {
            MsgBox = new CustomMsgBox();
            MsgBox.label1.Text = Text;
            MsgBox.label2.Text = "HELP 1/5";
            MsgBox.btn_precedent.Text = btnPrecedent;
            MsgBox.btn_suivant.Text = btnSuivant;
            MsgBox.btn_fin.Text = btnCancel;
            result = DialogResult.No;
            MsgBox.ShowDialog();
            return result;
        }
        private void CustomMsgBox_Load(object sender, EventArgs e)
        {

        }

        private void btn_suivant_Click(object sender, EventArgs e)
        {
            // Selon le numéro de Message_Help_A_Afficher (de 1 = 1er message à x = dernier message)
            Message_Help_A_Afficher++;
            if(Message_Help_A_Afficher > 5)
            {
                Message_Help_A_Afficher = 5;
            }
            // Methode pour afficher le message correspondant au numéro de Message_Help_A_Afficher, ainsi que le numéro de feuille
            Msg_To_Show();
        }

        private void btn_precedent_Click(object sender, EventArgs e)
        {
            // Montre le message précédent
            Message_Help_A_Afficher--;
            if (Message_Help_A_Afficher < 1)
            {
                Message_Help_A_Afficher = 1;
            }
            // Methode pour afficher le message correspondant au numéro de Message_Help_A_Afficher, ainsi que le numéro de feuille
            Msg_To_Show();
        }
        // Methode pour afficher le message correspondant au numéro de Message_Help_A_Afficher
        private void Msg_To_Show()
        {
            // Pour le message a afficher
            switch (Message_Help_A_Afficher)
            {
                case 1:
                    MsgBox.label1.Text = ("Bienvenu dans le mode aide de ce programme !");
                    break;
                case 2:
                    MsgBox.label1.Text = ("Ce programme vous permettra de générer les parties d'un tournoi d'échec selon la logique suivante \r\n(courante des tournois d'échecs) :\r\n  1 -> Un joueur ne joue jamais deux fois le même adversaire.\r\n  2 -> Un joueur joue contre un joueur ayant le même nombre de points, ou au plus proche.\r\n  3 -> On évite, dans la mesure du possible, qu'un joueur joue deux fois de suite avec la même couleur.");
                    break;
                case 3:
                    MsgBox.label1.Text = ("Vous pouvez choisir le nombre de rondes, ainsi que vos joueurs en cliquant sur le bouton :\r\n<Liste de départ>.\r\n\r\nPour 5 rondes, il faut au minimum 12 joueurs (comme dans la plupart des tournois d'échecs)\r\n et chaque ronde en plus demandera 4 joueurs en plus.");
                    break;
                case 4:
                    MsgBox.label1.Text = ("A la fin de chaque ronde, vous pourrez afficher le classement intermediaire, \r\nainsi que la ronde suivante.\r\n\r\nLorsque toutes les rondes seront jouées, \r\nvous pourrez afficher le classement final, normal et détaillé.");
                    break;
                case 5:
                    MsgBox.label1.Text = ("Bonne chance à tous les joueurs, et que le meilleur gagne !\r\n Franck Yersin");
                    break;
                default:
                    MessageBox.Show("Une erreur est survenue !");
                    // Pour être sûr de sortir du problème
                    Message_Help_A_Afficher = 5;
                    break;
            }
            // Pour le numéro de page a afficher
            MsgBox.label2.Text = "HELP " + Message_Help_A_Afficher.ToString() + "/5";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
