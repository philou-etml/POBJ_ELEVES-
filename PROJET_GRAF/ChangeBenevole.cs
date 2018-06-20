using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace VManagment_BDD_V1
{
    public partial class ChangeBenevole : Form
    {
        //Attributs de la classe ChangeBenevole
        private bool ModificationStatus = false;
        private bool Cancelled = false;

        public string Name;
        public string Subname;
        public string Email;
        public string Tel;
        public string Age;
        public string Road;
        public string Num;
        public string NPA;
        public string City;

        public string VolunteerNumber;
 
        private void ChangeBenevole_Shown(object sender, EventArgs e)
        {

            if (File.Exists("BaseDeDoneeBenevoles.xml") != true)
            {
                MessageBox.Show("Aucune base de donnée trouvée");
                Cancelled = true;
                this.Hide();

            }
            else
            {
                //lecture des informations du bénévole

                XmlDocument docXml = new XmlDocument(); //fichier XML

                //on charge le fichier
                docXml.Load("BaseDeDoneeBenevoles.xml");

                //on lit les valeures contenue dans le bénévole N° value
                XmlElement Volunteer = docXml.GetElementById(VolunteerNumber);
                XmlNode CurrentNode;

                CurrentNode = Volunteer.FirstChild;

                Name = (CurrentNode).InnerText;
                CurrentNode = CurrentNode.NextSibling;
                Subname = (CurrentNode).InnerText;
                CurrentNode = CurrentNode.NextSibling;
                Email = (CurrentNode).InnerText;
                CurrentNode = CurrentNode.NextSibling;
                Tel = (CurrentNode).InnerText;
                CurrentNode = CurrentNode.NextSibling;
                Age = (DateTime.Now.Year - (int.Parse((CurrentNode).InnerText))).ToString();
                CurrentNode = CurrentNode.NextSibling;
                CurrentNode = CurrentNode.FirstChild;
                Road = (CurrentNode).InnerText;
                CurrentNode = CurrentNode.NextSibling;
                Num = (CurrentNode).InnerText;
                CurrentNode = CurrentNode.NextSibling;
                NPA = (CurrentNode).InnerText;
                CurrentNode = CurrentNode.NextSibling;
                City = (CurrentNode).InnerText;

                //Affichage
                txtNom.Text = Name;
                txtPrenom.Text = Subname;
                txtEmail.Text = Email;
                txtTel.Text = Tel;
                CBAge.Text = Age;
                txtRoute.Text = Road;
                txtNum.Text = Num;
                txtNPA.Text = NPA;
                txtVille.Text = City;


            }//end if file exist

        }

        public ChangeBenevole()
        {
            InitializeComponent();
        }

        public bool ModificationComplete()
        {
            return (ModificationStatus);
        }

        public bool ModificationCancelled()
        {
            return (Cancelled);
        }


        private void btnAjouter_Click(object sender, EventArgs e)
        {
            //initialisation 
            txtEmail.ForeColor = Color.Black;
            txtEmail.BackColor = Color.White;
            txtNom.ForeColor = Color.Black;
            txtNom.BackColor = Color.White;
            txtNPA.ForeColor = Color.Black;
            txtNPA.BackColor = Color.White;
            txtNum.ForeColor = Color.Black;
            txtNum.BackColor = Color.White;
            txtPrenom.ForeColor = Color.Black;
            txtPrenom.BackColor = Color.White;
            txtRoute.ForeColor = Color.Black;
            txtRoute.BackColor = Color.White;
            txtTel.ForeColor = Color.Black;
            txtTel.BackColor = Color.White;
            txtVille.ForeColor = Color.Black;
            txtVille.BackColor = Color.White;
            CBAge.BackColor = Color.White;
            CBAge.ForeColor = Color.Black;



            //test si les information entrées sont valides

            if (VolunteerEntryIsCorrect())
            {
                //ouverture du fichier pour écriture des informations du bénévole

                XmlDocument docXml = new XmlDocument(); //fichier XML

                //on charge le fichier
                docXml.Load("BaseDeDoneeBenevoles.xml");

                //on lit les valeures contenue dans le bénévole N° value
                XmlNode Volunteer = docXml.GetElementById(VolunteerNumber);
                XmlNode CurrentNode;

                CurrentNode = Volunteer.FirstChild;


                //on effectue les modification
                if (txtNom.Text != Name)
                {
                    XmlText NameOfVolunteer = docXml.CreateTextNode(txtNom.Text);
                    CurrentNode.ReplaceChild(NameOfVolunteer, CurrentNode.FirstChild);         
                }
                CurrentNode = CurrentNode.NextSibling;
                if (txtPrenom.Text != Subname)
                {
                    XmlText SubnameOfVolunteer = docXml.CreateTextNode(txtPrenom.Text);
                    CurrentNode.ReplaceChild(SubnameOfVolunteer, CurrentNode.FirstChild);
                }
                CurrentNode = CurrentNode.NextSibling;
                if (txtEmail.Text != Email)
                {
                    XmlText EmailOfVolunteer = docXml.CreateTextNode(txtEmail.Text);
                    CurrentNode.ReplaceChild(EmailOfVolunteer, CurrentNode.FirstChild);
                }
                CurrentNode = CurrentNode.NextSibling;
                if (txtTel.Text != Tel)
                {
                    XmlText TelOfVolunteer = docXml.CreateTextNode(txtTel.Text);
                    CurrentNode.ReplaceChild(TelOfVolunteer, CurrentNode.FirstChild);
                }
                CurrentNode = CurrentNode.NextSibling;
                if (CBAge.Text != Age)
                {
                    XmlText AgeOfVolunteer = docXml.CreateTextNode((DateTime.Now.Year - (int.Parse(CBAge.Text))).ToString());
                    CurrentNode.ReplaceChild(AgeOfVolunteer, CurrentNode.FirstChild);
                }
                CurrentNode = CurrentNode.NextSibling;
                CurrentNode = CurrentNode.FirstChild;
                if (txtRoute.Text != Road)
                {
                    XmlText RoadOfVolunteer = docXml.CreateTextNode(txtRoute.Text);
                    CurrentNode.ReplaceChild(RoadOfVolunteer,CurrentNode.FirstChild);
                }
                CurrentNode = CurrentNode.NextSibling;
                if (txtNum.Text != Num)
                {
                    XmlText NumOfVolunteer = docXml.CreateTextNode(txtNum.Text);
                    CurrentNode.ReplaceChild(NumOfVolunteer, CurrentNode.FirstChild);
                }
                CurrentNode = CurrentNode.NextSibling;
                if (txtNPA.Text != NPA)
                {
                    XmlText NPAOfVolunteer = docXml.CreateTextNode(txtNPA.Text);
                    CurrentNode.ReplaceChild(NPAOfVolunteer, CurrentNode.FirstChild);
                }
                CurrentNode = CurrentNode.NextSibling;
                if (txtVille.Text != City)
                {
                    XmlText CityOfVolunteer = docXml.CreateTextNode(txtVille.Text);
                    CurrentNode.ReplaceChild(CityOfVolunteer, CurrentNode.FirstChild);
                }

                //sauvegarde de la base de donnée
                docXml.Save("BaseDeDoneeBenevoles.xml");

                //on prévient l'utilisateur que le bénévole est bien inscrit
                MessageBox.Show("Bénévole modifié correctement");

                //on ferme le form
                this.Hide();

                //on indique que la modification est terminée
                ModificationStatus = true;

            }
            else
            {
                MessageBox.Show("Erreur de systaxe, vérifiez les informations saisies");
            }
        }

        private void ChangeBenevole_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cancelled = true;
        }

        private bool VolunteerEntryIsCorrect()
        {
            bool Error = false;
            int i;

            //Test si le Nom et le prénom sont uniquement des lettre et pas des chiffres
            //////////////////////////////////////////////////////////////////////////////////////
            if (txtNom.Text.Length < 1)
            {
                Error = true;
                txtNom.BackColor = Color.Red;
            }

            for (i = 0; i < txtNom.Text.Length; i++)
            {
                if ((txtNom.Text[i] > 126) || (txtNom.Text[i] < 65)) //Ascii des lettres maj et min
                {
                    if (txtNom.Text[i] != 32) //vérifie que le caractère spéciale ne soit pas un espace
                    {
                        Error = true;
                        txtNom.ForeColor = Color.Red;
                    }
                }
            }
            //////////////////////////////////////////////////////////////////////////////////////
            if (txtPrenom.Text.Length < 1)
            {
                Error = true;
                txtPrenom.BackColor = Color.Red;
            }

            for (i = 0; i < txtPrenom.Text.Length; i++)
            {
                if ((txtPrenom.Text[i] > 126) || (txtPrenom.Text[i] < 65)) //Ascii des lettres maj et min
                {
                    if (txtPrenom.Text[i] != 45) //vérifie que le caractère spéciale ne soit pas un tiret pour les nom composés
                    {
                        Error = true;
                        txtPrenom.ForeColor = Color.Red;
                    }
                }
            }
            //////////////////////////////////////////////////////////////////////////////////////
            if (CBAge.Text.Length < 1)
            {
                Error = true;
                CBAge.BackColor = Color.Red;
            }
            //////////////////////////////////////////////////////////////////////////////////////

            if (txtEmail.Text.Length < 7)
            {
                if (txtEmail.Text.Length < 1)
                {
                    Error = true;
                    txtEmail.BackColor = Color.Red;
                }
                else
                {
                    Error = true;
                    txtEmail.ForeColor = Color.Red;
                }
            }
            else if ((!txtEmail.Text.Contains('@')) || (!txtEmail.Text.Contains('.')))
            {
                Error = true;
                txtEmail.ForeColor = Color.Red;
            }

            //////////////////////////////////////////////////////////////////////////////////////
            if (txtTel.Text.Length == 13)
            {

                //vérifie si la syntaxe est correcte
                if ((txtTel.Text[3] != '/') || (txtTel.Text[7] != '.') || (txtTel.Text[10] != '.'))
                {
                    Error = true;
                    txtTel.ForeColor = Color.Red;
                }

                for (i = 0; i < 3; i++)
                {
                    if ((txtTel.Text[i] > 57) || (txtTel.Text[i] < 48)) //Ascii des chiffres
                    {
                        Error = true;
                        txtTel.ForeColor = Color.Red;
                    }
                }

                for (i = 4; i < 7; i++)
                {
                    if ((txtTel.Text[i] > 57) || (txtTel.Text[i] < 48)) //Ascii des chiffres
                    {
                        Error = true;
                        txtTel.ForeColor = Color.Red;
                    }
                }

                for (i = 8; i < 10; i++)
                {
                    if ((txtTel.Text[i] > 57) || (txtTel.Text[i] < 48)) //Ascii des chiffres
                    {
                        Error = true;
                        txtTel.ForeColor = Color.Red;
                    }
                }

                for (i = 11; i < 13; i++)
                {
                    if ((txtTel.Text[i] > 57) || (txtTel.Text[i] < 48)) //Ascii des chiffres
                    {
                        Error = true;
                        txtTel.ForeColor = Color.Red;
                    }
                }
            }
            else
            {
                Error = true;
                txtTel.BackColor = Color.Red;
            }

            //////////////////////////////////////////////////////////////////////////////////////
            if (txtRoute.Text.Length < 1)
            {
                Error = true;
                txtRoute.BackColor = Color.Red;
            }

            for (i = 0; i < txtRoute.Text.Length; i++)
            {
                if ((txtRoute.Text[i] > 126) || (txtRoute.Text[i] < 65)) //Ascii des lettres maj et min
                {
                    if (txtRoute.Text[i] != 32) //vérifie que le caractère spéciale ne soit pas un espace
                    {
                        Error = true;
                        txtRoute.ForeColor = Color.Red;
                    }

                }
            }
            //////////////////////////////////////////////////////////////////////////////////////
            if (txtNum.Text.Length < 1)
            {
                Error = true;
                txtNum.BackColor = Color.Red;
            }

            for (i = 0; i < txtNum.Text.Length; i++)
            {
                if ((txtNum.Text[i] > 57) || (txtNum.Text[i] < 48)) //Ascii des chiffres
                {
                    Error = true;
                    txtNum.ForeColor = Color.Red;
                }
            }
            //////////////////////////////////////////////////////////////////////////////////////
            if (txtVille.Text.Length < 1)
            {
                Error = true;
                txtVille.BackColor = Color.Red;
            }

            for (i = 0; i < txtVille.Text.Length; i++)
            {
                if ((txtVille.Text[i] > 126) || (txtVille.Text[i] < 65)) //Ascii des lettres maj et min
                {
                    if ((txtVille.Text[i] == 39) || (txtVille.Text[i] == 45) || (txtVille.Text[i] == 32))//lève l'exception des espaces des tirets et des apostrophes
                    {
                        //c'est correct
                    }
                    else
                    {
                        Error = true;
                        txtVille.ForeColor = Color.Red;
                    }

                }

            }
            //////////////////////////////////////////////////////////////////////////////////////
            if (txtNPA.Text.Length != 4)
            {
                if (txtNPA.Text.Length < 1)
                {
                    Error = true;
                    txtNPA.BackColor = Color.Red;
                }
                else
                {
                    Error = true;
                    txtNPA.ForeColor = Color.Red;
                }
            }

            for (i = 0; i < txtNPA.Text.Length; i++)
            {
                if ((txtNPA.Text[i] > 57) || (txtNPA.Text[i] < 48)) //Ascii des chiffres
                {
                    Error = true;
                    txtNPA.ForeColor = Color.Red;
                }
            }

            if (Error)
            {
                return (false);
            }
            else
            {
                return (true);
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cancelled = true;
        }
    }
}
