using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //pour la gestion de fichiers
using System.Xml; //pour la gestion du xml

namespace VManagment_BDD_V1
{

    public partial class Benevole : Form
    {

        //déclaration des objets
        IList<clVolunteer> lstVolunteer = new List<clVolunteer>();

        //Attributs de la classe bénévole
        private bool FillingStatus = false;
        private bool Cancelled = false;
        private int NbrOfVolunteerAdded = 0;
        private int NbrOfVolunteers;

        //méthodes de la classe bénévoles

        private void Benevole_Shown(object sender, EventArgs e) //1ere méthode lancée au démarrage
        {
            btnAjouter.Enabled = false;
            btnEnd.Enabled = false;

            //test si une base de donnée existe (BaseDeDoneeBenevoles.xml)
            if (File.Exists("BaseDeDoneeBenevoles.xml"))
            {
                //lit le nombre de bénévoles qui existe déjà
                NbrOfVolunteers = ReadBDDnbrOfVolunteer();
            }
            else
            {
                CreateXmlFile();
                NbrOfVolunteers = 0;
            }

            btnAjouter.Enabled = true;
            btnEnd.Enabled = true;
        }

        public Benevole()
        {
            InitializeComponent();
        }

        public bool FillingComplete()
        {
            return(FillingStatus);
        }

        public bool AddingCancelled()
        {
            return (Cancelled);
        }


        public int GetNbrOfVolunteerAdded()
        {
            return (NbrOfVolunteerAdded);
        }

        public void SetNbrOfVolunteerAdded(int number)
        {
            NbrOfVolunteerAdded = number;
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
                NbrOfVolunteerAdded++; //nbr de volontaires ajoutés durant cette session
                NbrOfVolunteers++ ;//nbr de volontaires au total

                //créer un objet bénévole avec les différentes informations des champs
                lstVolunteer.Add(new clVolunteer(txtNom.Text, txtPrenom.Text, txtEmail.Text, txtTel.Text, txtRoute.Text, txtNum.Text, txtVille.Text, txtNPA.Text, NbrOfVolunteers, CBAge.Text));

                //comme le bénévole a bien été inscrit, on vide tous les champs
                txtEmail.Text = "";
                txtNom.Text = "";
                txtNPA.Text = "";
                txtNum.Text = "";
                txtPrenom.Text = "";
                txtRoute.Text = "";
                txtTel.Text = "";
                txtVille.Text = "";
                CBAge.Text = "";

                //on prévient l'utilisateur que le bénévole est bien inscrit
                MessageBox.Show("Bénévole inscrit correctement");

            }
            else
            {
                MessageBox.Show("Erreur de systaxe, vérifiez les informations saisies");
            }
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
                if ((txtNum.Text[i] > 102) || (txtNum.Text[i] < 48)) //Ascii des chiffres
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

        private void btnEnd_Click(object sender, EventArgs e)
        {
            int i; //indexe de boucle

            //met a 1 le flag pour dire que la saisie de nouveaux bénévoles est terminée
            FillingStatus = true;
            //début chargement
            MakeDatabase();
            //clear tous les bénévoles de la list
            if (NbrOfVolunteerAdded > 0)
            {
                lstVolunteer.Clear();
            }
            
            //fin du chargement
            this.Hide();
        }

        void CreateXmlFile()
        {
            XmlDocument docXml = new XmlDocument();

            //Création du noeud de déclaration xml
            XmlDeclaration declarationXml = docXml.CreateXmlDeclaration("1.0", "utf-8", null); //Version 1.0 au format utf-8

            //Création du Doctype du fichier pour pouvoir utiliser la fonciton get By ID
            XmlDocumentType Doctype = docXml.CreateDocumentType("Volunteers",null,null, "<!ELEMENT Volunteers ANY> <!ELEMENT Volunteer ANY> <!ATTLIST Volunteer ID ID #REQUIRED>");


            docXml.AppendChild(declarationXml);

            docXml.AppendChild(Doctype);

            //création du noeud Volunteers (Racine)
            XmlElement Root = docXml.CreateElement("Volunteers");
            docXml.AppendChild(Root);

            docXml.Save("BaseDeDoneeBenevoles.xml");
        }

        int ReadBDDnbrOfVolunteer()
        {
            int NumberOfVolunteer = 0; //nbr of volunteer all ready in the BDD

            XmlDocument docXml = new XmlDocument(); //fichier XML
            //on charge le fichier
            docXml.Load("BaseDeDoneeBenevoles.xml");

            XmlNodeList List_Volunteer = docXml.GetElementsByTagName("Volunteer");

            foreach(XmlNode noeud in List_Volunteer)
            {
                NumberOfVolunteer ++;
            }

            return (NumberOfVolunteer);
        }

        /*int ReadBDDnbrOfVolunteer()
        {

        }*/
        void MakeDatabase()
        {
            int i;
            string VolunteerID = "0000";

            XmlDocument docXml = new XmlDocument();

            docXml.Load("BaseDeDoneeBenevoles.xml");

            for (i = 0; i < NbrOfVolunteerAdded; i ++ )
            {
                VolunteerID = lstVolunteer[i].GetVolunteerNumber();

                XmlElement Volunteer = docXml.CreateElement("Volunteer");

                docXml.DocumentElement.AppendChild(Volunteer);
    
                Volunteer.SetAttribute("ID", VolunteerID);

                XmlElement Name = docXml.CreateElement("Name");
                XmlText NameOfVolunteer = docXml.CreateTextNode(lstVolunteer[i].GetName());
                Volunteer.AppendChild(Name);
                Name.AppendChild(NameOfVolunteer);

                XmlElement Subname = docXml.CreateElement("Subname");
                XmlText SubnameOfVolunteer = docXml.CreateTextNode(lstVolunteer[i].GetSubname());
                Volunteer.AppendChild(Subname);
                Subname.AppendChild(SubnameOfVolunteer);

                XmlElement Email = docXml.CreateElement("Email");
                XmlText EmailOfVolunteer = docXml.CreateTextNode(lstVolunteer[i].GetEmail());
                Volunteer.AppendChild(Email);
                Email.AppendChild(EmailOfVolunteer);

                XmlElement Phone = docXml.CreateElement("Phone");
                XmlText PhoneOfVolunteer = docXml.CreateTextNode(lstVolunteer[i].GetPhoneNumber());
                Volunteer.AppendChild(Phone);
                Phone.AppendChild(PhoneOfVolunteer);

                XmlElement Age = docXml.CreateElement("Age");
                XmlText AgeOfVolunteer = docXml.CreateTextNode(lstVolunteer[i].GetAge());
                Volunteer.AppendChild(Age);
                Age.AppendChild(AgeOfVolunteer);

                XmlElement Adress = docXml.CreateElement("Adress");
                XmlElement Road = docXml.CreateElement("Road");
                XmlText RoadOfVolunteer = docXml.CreateTextNode(lstVolunteer[i].GetRoad());
                XmlElement Number = docXml.CreateElement("Number");
                XmlText NumberOfVolunteer = docXml.CreateTextNode(lstVolunteer[i].GetNumber());
                XmlElement PostCode = docXml.CreateElement("PostCode");
                XmlText PostCodeOfVolunteer = docXml.CreateTextNode(lstVolunteer[i].GetNPA());
                XmlElement City = docXml.CreateElement("City");
                XmlText CityOfVolunteer = docXml.CreateTextNode(lstVolunteer[i].GetCity());


                Volunteer.AppendChild(Adress);
                Adress.AppendChild(Road);
                Road.AppendChild(RoadOfVolunteer);
                Adress.AppendChild(Number);
                Number.AppendChild(NumberOfVolunteer);
                Adress.AppendChild(PostCode);
                PostCode.AppendChild(PostCodeOfVolunteer);
                Adress.AppendChild(City);
                City.AppendChild(CityOfVolunteer);


            }


            docXml.Save("BaseDeDoneeBenevoles.xml");
        }

        //gestion des priorités
        private void CBChoix1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CBChoix2.Enabled = true;
            CBChoix2.SelectedValue = 1;
            CBChoix2.SelectedText = "---";
        }





        //définition de la classe Volunteer
        public class clVolunteer
        {
            //Attributs
            private String VolunteerNumber;
            private String Name;
            private String Subname;
            private String Email;
            private String PhoneNumber;
            private String Road;
            private String Number;
            private String City;
            private String NPA;
            private String Age;

            //Methodes

            public clVolunteer(String InputName, String InputSubname, String InputEmail, String InputPhoneNumber, String InputRoad, String InputNumber, String InputCity, String InputNPA, int InputVolunteerNumber, String InputAge)
            {
                Name = InputName;
                Subname = InputSubname;
                Email = InputEmail;
                PhoneNumber = InputPhoneNumber;
                Road = InputRoad;
                Number = InputNumber;
                City = InputCity;
                NPA = InputNPA;
                VolunteerNumber = (InputVolunteerNumber + 100).ToString();
                Age = (DateTime.Now.Year - int.Parse(InputAge)).ToString();

            }
            public String GetName()
            {
                return (Name);
            }
            public String GetSubname()
            {
                return (Subname);
            }
            public String GetEmail()
            {
                return (Email);
            }
            public String GetPhoneNumber()
            {
                return (PhoneNumber);
            }
            public String GetRoad()
            {
                return (Road);
            }
            public String GetNumber()
            {
                return (Number);
            }
            public String GetCity()
            {
                return (City);
            }
            public String GetNPA()
            {
                return (NPA);
            }
            public String GetAge()
            {
                return (Age.ToString());
            }
            public String GetVolunteerNumber()
            {
                return (VolunteerNumber);
            }
        }

        private void Benevole_FormClosed(object sender, FormClosedEventArgs e)
        {
            int i; //indexe de boucle

            //clear tous les bénévoles de la list
            if (NbrOfVolunteerAdded > 0)
            {
                for (i = 0; i <= NbrOfVolunteerAdded; i++)
                {
                    lstVolunteer.Remove(lstVolunteer[i]);
                }
            }

            Cancelled = true;
        }


    }
}




