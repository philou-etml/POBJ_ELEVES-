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
    public partial class Task : Form
    {
        //déclaration des objets
        IList<clTask> lstTasks = new List<clTask>();

        //Attributs de la classe bénévole
        private bool FillingStatus = false;
        private bool Cancelled = false;
        private int NbrOfTasksAdded = 0;
        private int NbrOfTasks;

        //méthodes de la classe bénévoles

        public Task()
        {
            InitializeComponent();
        }

        public bool FillingComplete()
        {
            return (FillingStatus);
        }

        public bool AddingCancelled()
        {
            return (Cancelled);
        }


        public int GetNbrOfTasksAdded()
        {
            return (NbrOfTasksAdded);
        }

        public void SetNbrOfTasksAdded(int number)
        {
            NbrOfTasksAdded = number;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        //évenement face avant
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Task_Shown(object sender, EventArgs e)
        {
            btnAjouter.Enabled = false;
            btnEnd.Enabled = false;

            //test si une base de donnée existe (BaseDeDoneeTaches.xml)
            if (File.Exists("BaseDeDoneeTaches.xml"))
            {
                //lit le nombre de bénévoles qui existe déjà
                NbrOfTasks = ReadBDDnbrOfTasks();
            }
            else
            {
                CreateXmlFile();
                NbrOfTasks = 0;
            }

            btnAjouter.Enabled = true;
            btnEnd.Enabled = true;
        }

        void CreateXmlFile()
        {
            XmlDocument docXml = new XmlDocument();

            //Création du noeud de déclaration xml
            XmlDeclaration declarationXml = docXml.CreateXmlDeclaration("1.0", "utf-8", null); //Version 1.0 au format utf-8

            //Création du Doctype du fichier pour pouvoir utiliser la fonciton get By ID
            XmlDocumentType Doctype = docXml.CreateDocumentType("Tasks", null, null, "<!ELEMENT Tasks ANY> <!ELEMENT Task ANY> <!ATTLIST Task ID ID #REQUIRED>");

            docXml.AppendChild(declarationXml);
            docXml.AppendChild(Doctype);
            //création du noeud Volunteers (Racine)
            XmlElement Root = docXml.CreateElement("Tasks");
            docXml.AppendChild(Root);

            docXml.Save("BaseDeDoneeTaches.xml");
        }

        int ReadBDDnbrOfTasks()
        {
            int NbrOfTasks = 0; //nbr of volunteer all ready in the BDD

            XmlDocument docXml = new XmlDocument(); //fichier XML
            //on charge le fichier
            docXml.Load("BaseDeDoneeTaches.xml");

            XmlNodeList List_Tasks = docXml.GetElementsByTagName("Task");

            foreach (XmlNode noeud in List_Tasks)
            {
                NbrOfTasks++;
            }

            return (NbrOfTasks);
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            //test si les information entrées sont valides certaines inforamtions sont de toute façons OK (caste dans les numérique up-down)
            //on autorise l'utilisateur a saisire des numéros et des caractères spéciaux dans le nom et la descritpion

            txtNom.ForeColor = Color.Black;
            txtNom.BackColor = Color.White;
            txtDescritpion.ForeColor = Color.Black;
            txtDescritpion.BackColor = Color.White;
            CBType.ForeColor = Color.Black;
            CBType.BackColor = Color.White;
            cbDay.ForeColor = Color.Black;
            cbDay.BackColor = Color.White;

            if (TaskEntryIsCorrect())
            {
                NbrOfTasksAdded++; //nbr de volontaires ajoutés durant cette session
                NbrOfTasks++;//nbr de volontaires au total

                //créer un objet bénévole avec les différentes informations des champs
                lstTasks.Add(new clTask(txtNom.Text, txtDescritpion.Text, CBType.Text, int.Parse(NudHstart.Text), int.Parse(NudmStart.Text), int.Parse(NudHEnd.Text), int.Parse(NudmEnd.Text), int.Parse(NudVolNeeded.Text), NbrOfTasks,cbDay.Text));

                //comme le bénévole a bien été inscrit, on vide tous les champs
                txtNom.Text = "";
                txtDescritpion.Text = "";
                CBType.Text = "";

                //on ne réinitialise pas les champs correspondant aux heures et au nombres de bénévoles car l'entrée des tache se fera a la suite et le heures seront certainement proche 
                //on gagne donc du temps à l'inscription de la tâche

                //on prévient l'utilisateur que le bénévole est bien inscrit
                MessageBox.Show("Tâche enregistrée correctement");
            }
            else
            {
                MessageBox.Show("Erreur de systaxe, vérifiez les informations saisies");
            }

        }

        private bool TaskEntryIsCorrect()
        {
            bool Error = false;
            int i;

            //Test si le Nom et la définition ont été saisis
            //////////////////////////////////////////////////////////////////////////////////////
            if (txtNom.Text.Length < 1)
            {
                Error = true;
                txtNom.BackColor = Color.Red;
            }

            //////////////////////////////////////////////////////////////////////////////////////
            if (txtDescritpion.Text.Length < 1)
            {
                Error = true;
                txtDescritpion.BackColor = Color.Red;
            }

            if (CBType.Text.Length < 1)
            {
                Error = true;
                CBType.BackColor = Color.Red;
            }

            if (cbDay.Text.Length <1)
            {
                Error = true;
                cbDay.BackColor = Color.Red;
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
            if (NbrOfTasksAdded > 0)
            {
                lstTasks.Clear();
            }

            //fin du chargement
            this.Hide();
        }

        private void Task_FormClosed(object sender, FormClosedEventArgs e)
        {
            int i; //indexe de boucle

            //clear tous les bénévoles de la list
            if (NbrOfTasksAdded > 0)
            {
                for (i = 0; i <= NbrOfTasksAdded; i++)
                {
                    lstTasks.Remove(lstTasks[i]);
                }
            }

            Cancelled = true;
        }

        void MakeDatabase()
        {
            int i;
            string TaskID = "0000";

            XmlDocument docXml = new XmlDocument();

            docXml.Load("BaseDeDoneeTaches.xml");

            for (i = 0; i < NbrOfTasksAdded; i++)
            {
                TaskID = (lstTasks[i].GetNbroftheTask()).ToString();

                XmlElement Task = docXml.CreateElement("Task");

                docXml.DocumentElement.AppendChild(Task);

                Task.SetAttribute("ID", TaskID);

                XmlElement Name = docXml.CreateElement("Name");
                XmlText NameOfTask = docXml.CreateTextNode(lstTasks[i].GetName());
                Task.AppendChild(Name);
                Name.AppendChild(NameOfTask);

                XmlElement Description = docXml.CreateElement("Descripion");
                XmlText DescriptionOfTask = docXml.CreateTextNode(lstTasks[i].GetDescription());
                Task.AppendChild(Description);
                Description.AppendChild(DescriptionOfTask);

                XmlElement Type = docXml.CreateElement("Type");
                XmlText TypeOfTask = docXml.CreateTextNode(lstTasks[i].GetType());
                Task.AppendChild(Type);
                Type.AppendChild(TypeOfTask);

                XmlElement NbrVolunteerNeeded = docXml.CreateElement("NbrVolunteerNeeded");
                XmlText NbrVolunteer = docXml.CreateTextNode((lstTasks[i].GetVolNeeded()).ToString());
                Task.AppendChild(NbrVolunteerNeeded);
                NbrVolunteerNeeded.AppendChild(NbrVolunteer);

                XmlElement StartTime = docXml.CreateElement("StartTime");
                XmlText StartTimeOfTask = docXml.CreateTextNode(lstTasks[i].GetStartTime());
                Task.AppendChild(StartTime);
                StartTime.AppendChild(StartTimeOfTask);

                XmlElement EndTime = docXml.CreateElement("EndTime");
                XmlText EndTimeOfTask = docXml.CreateTextNode(lstTasks[i].GetEndTime());
                Task.AppendChild(EndTime);
                EndTime.AppendChild(EndTimeOfTask);

                XmlElement Day = docXml.CreateElement("Day");
                XmlText DayOfTask = docXml.CreateTextNode(lstTasks[i].GetDay());
                Task.AppendChild(Day);
                Day.AppendChild(DayOfTask);

            }


            docXml.Save("BaseDeDoneeTaches.xml");
        }


        //définition de la classe Volunteer
        public class clTask
        {
            //Attributs
            private String Name;
            private String Description;
            private String Type;
            private double StartTime;
            private double EndTime;
            private String Day;
            private String NbroftheTask;
            private int VolunteerNeeded;

            //Methodes

            public clTask(String InputName, String InputDescription, String InputType, float InputStartTimeH,float InputStartTimeM, float InputEndTimeH, float InputEndTimeM, int InputVolNeeded, int InputTaskNumber,String InputDay)
            {
                Name = InputName;
                Description = InputDescription;
                Type = InputType;
                StartTime = InputStartTimeH + (InputStartTimeM / 60.0);
                EndTime = InputEndTimeH + (InputEndTimeM / 60.0);
                VolunteerNeeded = InputVolNeeded;
                NbroftheTask = (InputTaskNumber + 100).ToString();
                Day = InputDay;
            }
            public String GetName()
            {
                return (Name);
            }
            public String GetDescription()
            {
                return (Description);
            }
            public String GetType()
            {
                return (Type);
            }
            public String GetStartTime()
            {
                double DMinutes = StartTime % 1;
                String SHeure = (StartTime - DMinutes).ToString();
                String SMinutes = ((StartTime % 1) * 60).ToString();

                if (DMinutes == 0)
                {
                    SMinutes = "00";
                }

                return (SHeure + "h" + SMinutes);
            }
            public String GetEndTime()
            {
                double DMinutes = EndTime % 1;
                String SHeure = (EndTime - DMinutes).ToString();
                String SMinutes = ((EndTime % 1) * 60).ToString();

                if (DMinutes == 0)
                {
                    SMinutes = "00";
                }

                return (SHeure + "h" + SMinutes);
            }
            public String GetNbroftheTask()
            {
                return (NbroftheTask);
            }

            public int GetVolNeeded()
            {
                return (VolunteerNeeded);
            }

            public String GetDay()
            {
                return Day;
            }
            
        }


    }
}
