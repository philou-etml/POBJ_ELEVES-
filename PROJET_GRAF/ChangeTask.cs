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
    public partial class ChangeTask : Form
    {
        //Attributs de la classe Change Bénévole
        private bool ModificationStatus = false;
        private bool Cancelled = false;

        public string Name;
        public string Description;
        public string Type;
        public string NbrofVolNeeded;
        public string StartTime;
        public int StartTimeH;
        public int StartTimem;
        public string EndTime;
        public int EndTimeH;
        public int EndTimem;
        public string Day;
        


        public string TaskNumber;

        private void ChangeTask_Shown(object sender, EventArgs e)
        {


            if (File.Exists("BaseDeDoneeTaches.xml") != true)
            {
                MessageBox.Show("Aucune base de donnée trouvée");
                Cancelled = true;
                this.Hide();

            }
            else
            {
                //lecture des informations de la Tache

                XmlDocument docXml = new XmlDocument(); //fichier XML

                //on charge le fichier
                docXml.Load("BaseDeDoneeTaches.xml");

                //on lit les valeures contenue dans le bénévole N° value
                XmlElement Task = docXml.GetElementById(TaskNumber);
                XmlNode CurrentNode;

                CurrentNode = Task.FirstChild;

                Name = (CurrentNode).InnerText;
                CurrentNode = CurrentNode.NextSibling;
                Description = (CurrentNode).InnerText;
                CurrentNode = CurrentNode.NextSibling;
                Type = (CurrentNode).InnerText;
                CurrentNode = CurrentNode.NextSibling;
                NbrofVolNeeded = (CurrentNode).InnerText;
                CurrentNode = CurrentNode.NextSibling;
                StartTime = (CurrentNode).InnerText;
                CurrentNode = CurrentNode.NextSibling;
                EndTime = (CurrentNode).InnerText;
                CurrentNode = CurrentNode.NextSibling;
                Day = (CurrentNode).InnerText;

                //Affichage
                txtNom.Text = Name;
                txtDescritpion.Text = Description;
                CBType.Text = Type;

                if(StartTime.Length == 5)
                {
                    StartTimeH = int.Parse(StartTime.Substring(0, 1)) + int.Parse(StartTime.Substring(1, 1));
                    StartTimem = int.Parse(StartTime.Substring(3, 1)) + int.Parse(StartTime.Substring(4, 1));
                    NudHstart.Value = StartTimeH;
                    NudmStart.Value = StartTimem;
                }
                else
                {
                    StartTimeH = int.Parse(StartTime.Substring(0, 1));
                    StartTimem = int.Parse(StartTime.Substring(2, 1)) + int.Parse(StartTime.Substring(3, 1));
                    NudHstart.Value = StartTimeH;
                }

                if (EndTime.Length == 5)
                {
                    EndTimeH = int.Parse(EndTime.Substring(0, 1)) + int.Parse(EndTime.Substring(0, 1));
                    EndTimem = int.Parse(EndTime.Substring(3, 1)) + int.Parse(EndTime.Substring(4, 1));
                    NudHEnd.Value = EndTimeH;
                    NudmEnd.Value = EndTimem;
                }
                else
                {
                    EndTimeH = int.Parse(EndTime.Substring(0, 1));
                    EndTimem = int.Parse(EndTime.Substring(2, 1)) + int.Parse(EndTime.Substring(3, 1));
                    NudHEnd.Value = EndTimeH;
                    NudmEnd.Value = EndTimem;
                }

                cbDay.Text = Day;
                NudVolNeeded.Value = int.Parse(NbrofVolNeeded);



            }//end if file exist
        }

        public ChangeTask()
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

        private void btnModifier_Click(object sender, EventArgs e)
        {
            //initialisation 
            txtNom.ForeColor = Color.Black;
            txtNom.BackColor = Color.White;
            txtDescritpion.ForeColor = Color.Black;
            txtDescritpion.BackColor = Color.White;
            CBType.ForeColor = Color.Black;
            CBType.BackColor = Color.White;
            cbDay.ForeColor = Color.Black;
            cbDay.BackColor = Color.White;



            //test si les information entrées sont valides

            if (TaskEntryIsCorrect())
            {
                //ouverture du fichier pour écriture des informations du bénévole

                XmlDocument docXml = new XmlDocument(); //fichier XML

                //on charge le fichier
                docXml.Load("BaseDeDoneeTaches.xml");

                //on lit les valeures contenue dans le bénévole N° value
                XmlNode Task = docXml.GetElementById(TaskNumber);
                XmlNode CurrentNode;

                CurrentNode = Task.FirstChild;


                //on effectue les modification
                if (txtNom.Text != Name)
                {
                    XmlText NameOfTask = docXml.CreateTextNode(txtNom.Text);
                    CurrentNode.ReplaceChild(NameOfTask, CurrentNode.FirstChild);
                }
                CurrentNode = CurrentNode.NextSibling;
                if (txtDescritpion.Text != Description)
                {
                    XmlText DescriptionOfTask = docXml.CreateTextNode(txtDescritpion.Text);
                    CurrentNode.ReplaceChild(DescriptionOfTask, CurrentNode.FirstChild);
                }
                CurrentNode = CurrentNode.NextSibling;
                if (CBType.Text != Type)
                {
                    XmlText TypeOfTask = docXml.CreateTextNode(CBType.Text);
                    CurrentNode.ReplaceChild(TypeOfTask, CurrentNode.FirstChild);
                }
                CurrentNode = CurrentNode.NextSibling;
                if (NudVolNeeded.Value != int.Parse(NbrofVolNeeded))
                {
                    XmlText NbrofVOfTask = docXml.CreateTextNode((NudVolNeeded.Value).ToString());
                    CurrentNode.ReplaceChild(NbrofVOfTask, CurrentNode.FirstChild);
                }
                CurrentNode = CurrentNode.NextSibling;
                
                if((NudHstart.Value != StartTimeH)||(NudmStart.Value != StartTimem))
                {
                    XmlText StartTimeOfTask;

                    if (NudmStart.Value == 0)
                    {
                        StartTimeOfTask = docXml.CreateTextNode(((NudHstart.Value).ToString()) + "h00");
                    }
                    else
                    {
                        StartTimeOfTask = docXml.CreateTextNode(((NudHstart.Value).ToString()) + "h" + ((NudmStart.Value).ToString()));
                    }

                    CurrentNode.ReplaceChild(StartTimeOfTask, CurrentNode.FirstChild);
                }
                CurrentNode = CurrentNode.NextSibling;

                if ((NudHstart.Value != EndTimeH) || (NudmEnd.Value != EndTimem))
                {
                    XmlText EndTimeOfTask;

                    if (NudmEnd.Value == 0)
                    {
                        EndTimeOfTask = docXml.CreateTextNode(((NudHEnd.Value).ToString()) + "h00");
                    }
                    else
                    {
                        EndTimeOfTask = docXml.CreateTextNode(((NudHEnd.Value).ToString()) + "h" + ((NudmEnd.Value).ToString()));
                    }

                    CurrentNode.ReplaceChild(EndTimeOfTask, CurrentNode.FirstChild);
                }

                CurrentNode = CurrentNode.NextSibling;
                if (cbDay.Text != Day)
                {
                    XmlText DayOfTask = docXml.CreateTextNode(cbDay.Text);
                    CurrentNode.ReplaceChild(DayOfTask, CurrentNode.FirstChild);
                }

                //sauvegarde de la base de donnée
                docXml.Save("BaseDeDoneeTaches.xml");

                //on prévient l'utilisateur que le bénévole est bien inscrit
                MessageBox.Show("Tâche modifié correctement");

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

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            Cancelled = true;
        }

        private void ChangeTask_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cancelled = true;
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

            if (cbDay.Text.Length < 1)
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
    }

}
