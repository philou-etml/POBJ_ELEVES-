using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Xml.Linq;

namespace VManagment_BDD_V1
{

    public partial class dgvDataBase : Form
    {
        //définition des différentes classes du programme

        public class clTask
        {
            //Attribut

            //Methodes
        }

        //déclaration des objets
        Benevole AddBenevole = new Benevole();
        ChangeBenevole CBenevole = new ChangeBenevole();
        ChangeTask CTask = new ChangeTask();

        Task AddTask = new Task();




        //déclaration des variables globales


        public dgvDataBase()
        {
            InitializeComponent();
        }

        private void dgvDataBase_Shown(object sender, EventArgs e)
        {
            RefreshDGVB();
            RefreshDGVT();
        }


        private void btnAjouter_Click(object sender, EventArgs e)
        {

            AddBenevole.ShowDialog();

            //met le programme en pause tant que tous les bénévoles n'ont pas été entrés
            //problème : reste dans la boucle si on ferme la page avec la croix
            while ((AddBenevole.FillingComplete() == false) && (AddBenevole.AddingCancelled() == false))
            {
                //wait
            }


            //test si les information entrées sont valides

            if (AddBenevole.FillingComplete() == true)
            {
                if (AddBenevole.GetNbrOfVolunteerAdded() > 1)
                {
                    MessageBox.Show(AddBenevole.GetNbrOfVolunteerAdded().ToString() + " Bénévoles ajoutés");
                }
                else
                {
                    MessageBox.Show("1 Bénévole ajouté");
                }

            }
            else
            {
                MessageBox.Show("l'ajout de bénévoles a été annulée");
            }

            //remet à 0 le nombre de volontaires ajoutés
            AddBenevole.SetNbrOfVolunteerAdded(0);

            RefreshDGVB();
        }

        private void RefreshDGVB()
        {
            if (File.Exists("BaseDeDoneeBenevoles.xml"))
            {
                //fichier XML
                XmlDocument docXml = new XmlDocument();
                XmlNode CurrentNode;

                int i;
                int CurrentRow = 0;

                //ligne à mettre dans le DGV
                string[] row = new string[7];

                //on charge le fichier                                       
                docXml.Load("BaseDeDoneeBenevoles.xml");

                XmlNodeList List_Volunteer = docXml.GetElementsByTagName("Volunteer");

                //clear le dataGridView
                DGVBenevoles.Rows.Clear();

                //remplis le dataGridView
                foreach (XmlNode noeud in List_Volunteer)
                {
                    CurrentRow++;

                    row[0] = (noeud.Attributes["ID"].Value).ToString();
                    CurrentNode = noeud.FirstChild;
                    row[2] = (CurrentNode).InnerText;
                    CurrentNode = CurrentNode.NextSibling;
                    row[1] = (CurrentNode).InnerText;
                    CurrentNode = CurrentNode.NextSibling;
                    row[4] = (CurrentNode).InnerText;
                    CurrentNode = CurrentNode.NextSibling;
                    row[3] = (CurrentNode).InnerText;
                    CurrentNode = CurrentNode.NextSibling;
                    row[5] = (CurrentNode).InnerText;

                    CurrentNode = CurrentNode.NextSibling;
                    CurrentNode = CurrentNode.FirstChild;
                    row[6] = (CurrentNode).InnerText + " ";

                    if (CurrentNode.InnerText != "-")
                    {
                        for (i = 0; i < 3; i++)
                        {
                            CurrentNode = CurrentNode.NextSibling;
                            row[6] = row[6] + ((CurrentNode).InnerText + " ");
                        }
                    }
                    else
                    {
                        row[6] = "-";
                    }

                    DGVBenevoles.Rows.Add(row);

                }
            }
            else
            {
                MessageBox.Show("Aucune base de donnée de bénévoles détectée");
            }//end of if file exist
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDGVB();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //déclaration des variables
            String Resultats = "Correspondance trouvée dans le(s) Bénévole(s) N° :";
            bool Result = false;
            int FirstRow = 0;  //first Row in the DGV with correspondance


            if (DGVBenevoles.RowCount != 0)
            {
                //on ouvre le fichier si il existe 
                if (File.Exists("BaseDeDoneeBenevoles.xml") == true)
                {
                    //déclaration du document
                    XmlDocument docXml = new XmlDocument(); //fichier XML

                    //on charge le fichier
                    docXml.Load("BaseDeDoneeBenevoles.xml");

                    //crée une list de noeud qui comprend tous les bénévoles
                    XmlNodeList List_Volunteer = docXml.GetElementsByTagName("Volunteer");
                    //boucle qui lit tous les champs de texte de la BDD
                    foreach (XmlNode noeud in List_Volunteer)
                    {
                        foreach (XmlNode sousNoeud in noeud)
                        {
                            if (sousNoeud.InnerText.Contains(txtSearch.Text))
                            {
                                if (Result)
                                {
                                    Resultats = Resultats + "," + noeud.Attributes["ID"].Value;
                                }
                                else
                                {
                                    Resultats = Resultats + " " + noeud.Attributes["ID"].Value;
                                    FirstRow = int.Parse(noeud.Attributes["ID"].Value)-101;                                 
                                    Result = true;
                                }

                                //pour chaque correspondance on hightlite la ligne
                                DGVBenevoles.Rows[int.Parse(noeud.Attributes["ID"].Value) - 101].DefaultCellStyle.BackColor = Color.LightBlue;

                                break;
                            }
                        }

                    }

                    if (Result)
                    {
                        MessageBox.Show(Resultats);
                        DGVBenevoles.CurrentCell = DGVBenevoles[0,FirstRow];
                    }
                    else
                    {
                        MessageBox.Show("Aucune correspondance trouvée");
                    }


                    
                }
                else
                {
                    MessageBox.Show("Aucune base de donnée trouvée");
                }//end if file exist
            }
            else
            {
                MessageBox.Show("aucun bénévoles trouvés. Cliquer sur Rafraichir et réessayer");
            }//end if DGVBenevoles .Rowcount != 0
        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            if (DGVBenevoles.RowCount != 0)
            {
                CBenevole.VolunteerNumber = (DGVBenevoles.CurrentCell.RowIndex + 101).ToString();
                CBenevole.ShowDialog();

                //met le programme en pause tant que tous les bénévoles n'ont pas été entrés
                while ((CBenevole.ModificationComplete() == false) && (CBenevole.ModificationCancelled() == false))
                {
                    //wait
                }

                if (CBenevole.ModificationCancelled() == true)
                {
                    MessageBox.Show("Modification annulée");
                }
            }
            else
            {
                MessageBox.Show("aucun bénévoles trouvés. Cliquer sur Rafraichir et réessayer");
            }

            RefreshDGVB();
        }

        private void btnSupr_Click(object sender, EventArgs e)
        {
            int i = 0; //index de boucle

            if (DGVBenevoles.RowCount != 0)
            {
                string DeletedVolunteerNbr = (DGVBenevoles.CurrentCell.RowIndex + 101).ToString();

                DialogResult Confirmation = MessageBox.Show("Êtes-vous sûr de vouloir supprimer le bénévole ?", "!! Attention !!", MessageBoxButtons.YesNo);

                if (Confirmation == DialogResult.Yes)
                {

                    if (File.Exists("BaseDeDoneeBenevoles.xml"))
                    {
                        //ouverture du fichier pour écriture des informations du bénévole
                        XmlDocument docXml = new XmlDocument(); //fichier XML

                        //on charge le fichier
                        docXml.Load("BaseDeDoneeBenevoles.xml");

                        //on lit les valeures contenue dans le bénévole N° value
                        XmlNode Volunteer = docXml.GetElementById(DeletedVolunteerNbr);

                        //aucune réorganisation n'est effectuée on vide juste les champs alloués et on marque dans nom : Désiscrit
                        foreach (XmlNode Node in Volunteer)
                        {
                            Node.InnerText = "-";
                        }

                        //sauvegarde de la base de donnée
                        docXml.Save("BaseDeDoneeBenevoles.xml");
                    }
                    else
                    {
                        MessageBox.Show("aucune base de donnée trouvée");
                    }

                }
            }
            else
            {
                MessageBox.Show("aucun bénévoles à supprimer. Cliquer sur Rafraichir et réessayer");
            }
            RefreshDGVB();
        }

        private void btnDelShadowVolunteer_Click(object sender, EventArgs e)
        {
            int VolunteerDeletedNbr = 0;
            int i = 0; //index de boucle
            DialogResult Confirmation = MessageBox.Show("Cette Action entrainera la suppression des bénévoles désinscrit mais Attention :\nLes numéros de chaque bénévoles pourront être modifiers de manière irréversible", "!! Attention !!", MessageBoxButtons.YesNo);

            if (Confirmation == DialogResult.Yes)
            {
                //ouverture du fichier pour écriture des informations du bénévole
                XmlDocument docXml = new XmlDocument(); //fichier XML

                //on charge le fichier
                docXml.Load("BaseDeDoneeBenevoles.xml");

                foreach (XmlNode Volunteer in docXml.DocumentElement)
                {
                    if (Volunteer.FirstChild.InnerText == "-")
                    {
                        VolunteerDeletedNbr = int.Parse(Volunteer.Attributes["ID"].Value);
                        Volunteer.RemoveAll();
                        docXml.DocumentElement.RemoveChild(Volunteer);

                        i = 0;
                        foreach (XmlNode Benevoles in docXml.DocumentElement)
                        {
                            if (int.Parse(Benevoles.Attributes["ID"].Value) >= VolunteerDeletedNbr)
                            {
                                Benevoles.Attributes["ID"].Value = (VolunteerDeletedNbr + i).ToString();
                                i++;
                            }
                        }
                    }
                }

                //sauvegarde de la base de donnée
                docXml.Save("BaseDeDoneeBenevoles.xml");
            }

            RefreshDGVB();
        }




        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        ///                         Partie de gestion de la Base de données des Tâches
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            AddTask.ShowDialog();

            //met le programme en pause tant que tous les bénévoles n'ont pas été entrés
            //problème : reste dans la boucle si on ferme la page avec la croix
            while ((AddTask.FillingComplete() == false) && (AddTask.AddingCancelled() == false))
            {
                //wait
            }


            //test si les information entrées sont valides

            if (AddTask.FillingComplete() == true)
            {
                if (AddTask.GetNbrOfTasksAdded() > 1)
                {
                    MessageBox.Show(AddTask.GetNbrOfTasksAdded().ToString() + " Tâches ajoutés");
                }
                else
                {
                    MessageBox.Show("Tâche ajouté");
                }

            }
            else
            {
                MessageBox.Show("l'ajout de tâches a été annulée");
            }

            //remet à 0 le nombre de volontaires ajoutés
            AddTask.SetNbrOfTasksAdded(0);

            RefreshDGVT();
        }

        private void RefreshDGVT()
        {
            if (File.Exists("BaseDeDoneeTaches.xml"))
            {
                //fichier XML
                XmlDocument docXml = new XmlDocument();
                XmlNode CurrentNode;

                int i;
                int CurrentRow = 0;

                //ligne à mettre dans le DGV
                string[] row = new string[7];

                //on charge le fichier                                       
                docXml.Load("BaseDeDoneeTaches.xml");

                XmlNodeList List_Volunteer = docXml.GetElementsByTagName("Task");

                //clear le dataGridView
                DGVTask.Rows.Clear();

                //remplis le dataGridView
                foreach (XmlNode noeud in List_Volunteer)
                {
                    CurrentRow++;

                    row[0] = (noeud.Attributes["ID"].Value).ToString();
                    CurrentNode = noeud.FirstChild;
                    row[1] = (CurrentNode).InnerText;
                    CurrentNode = CurrentNode.NextSibling;
                    row[6] = (CurrentNode).InnerText;
                    CurrentNode = CurrentNode.NextSibling;
                    row[2] = (CurrentNode).InnerText;
                    CurrentNode = CurrentNode.NextSibling;
                    row[3] = (CurrentNode).InnerText;
                    CurrentNode = CurrentNode.NextSibling;
                    row[5] = (CurrentNode).InnerText;
                    CurrentNode = CurrentNode.NextSibling;
                    row[5] = row[5] + "/" + (CurrentNode).InnerText;
                    CurrentNode = CurrentNode.NextSibling;
                    row[4] = (CurrentNode).InnerText;

                    DGVTask.Rows.Add(row);

                }
            }
            else
            {
                MessageBox.Show("Aucune base de donnée de Tâches détectée");
            }//end of if file exist
        }

        private void btnRefreshTask_Click(object sender, EventArgs e)
        {
            RefreshDGVT();
        }

        private void btnChangeTask_Click(object sender, EventArgs e)
        {
            if (DGVTask.RowCount != 0)
            {
                //A completer
                
                CTask.TaskNumber = (DGVTask.CurrentCell.RowIndex + 101).ToString();
                CTask.ShowDialog();

                //met le programme en pause tant que tous les bénévoles n'ont pas été entrés
                while ((CTask.ModificationComplete() == false) && (CTask.ModificationCancelled() == false))
                {
                    //wait
                }

                if (CTask.ModificationCancelled() == true)
                {
                    MessageBox.Show("Modification annulée");
                }
            }
            else
            {
                MessageBox.Show("aucune Tâches trouvées. Cliquer sur Rafraichir et réessayer");
            }

            RefreshDGVT();
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            int i = 0; //index de boucle

            if (DGVTask.RowCount != 0)
            {
                string DeletedTaskrNbr = (DGVTask.CurrentCell.RowIndex + 101).ToString();

                DialogResult Confirmation = MessageBox.Show("Êtes-vous sûr de vouloir supprimer la Tâche ?", "!! Attention !!", MessageBoxButtons.YesNo);

                if (Confirmation == DialogResult.Yes)
                {

                    if (File.Exists("BaseDeDoneeTaches.xml"))
                    {
                        //ouverture du fichier pour écriture des informations du bénévole
                        XmlDocument docXml = new XmlDocument(); //fichier XML

                        //on charge le fichier
                        docXml.Load("BaseDeDoneeTaches.xml");

                        //on lit les valeures contenue dans le bénévole N° value
                        XmlNode Task = docXml.GetElementById(DeletedTaskrNbr);

                        //aucune réorganisation n'est effectuée on vide juste les champs alloués et on marque dans nom : Désiscrit
                        foreach (XmlNode Node in Task)
                        {
                            Node.InnerText = "-";
                        }

                        //sauvegarde de la base de donnée
                        docXml.Save("BaseDeDoneeTaches.xml");
                    }
                    else
                    {
                        MessageBox.Show("aucune base de donnée trouvée");
                    }

                }
            }
            else
            {
                MessageBox.Show("aucune Tâches à supprimer. Cliquez sur Rafraichir et réessayer");
            }
            RefreshDGVT();
        }

        private void btnSearchTask_Click(object sender, EventArgs e)
        {
            //déclaration des variables
            String Resultats = "Correspondance trouvée dans le(s) Tâche(s) N° :";
            bool Result = false;
            int FirstRow = 0;  //first Row in the DGV with correspondance


            if (DGVTask.RowCount != 0)
            {
                //on ouvre le fichier si il existe 
                if (File.Exists("BaseDeDoneeTaches.xml") == true)
                {
                    //déclaration du document
                    XmlDocument docXml = new XmlDocument(); //fichier XML

                    //on charge le fichier
                    docXml.Load("BaseDeDoneeTaches.xml");

                    //crée une list de noeud qui comprend tous les bénévoles
                    XmlNodeList List_Tasks = docXml.GetElementsByTagName("Task");
                    //boucle qui lit tous les champs de texte de la BDD
                    foreach (XmlNode noeud in List_Tasks)
                    {
                        foreach (XmlNode sousNoeud in noeud)
                        {
                            if (sousNoeud.InnerText.Contains(txtSearchTask.Text))
                            {
                                if (Result)
                                {
                                    Resultats = Resultats + "," + noeud.Attributes["ID"].Value;
                                }
                                else
                                {
                                    Resultats = Resultats + " " + noeud.Attributes["ID"].Value;
                                    FirstRow = int.Parse(noeud.Attributes["ID"].Value) - 101;
                                    Result = true;
                                }

                                //pour chaque correspondance on hightlite la ligne
                                DGVTask.Rows[int.Parse(noeud.Attributes["ID"].Value) - 101].DefaultCellStyle.BackColor = Color.LightBlue;

                                break;
                            }
                        }

                    }

                    if (Result)
                    {
                        MessageBox.Show(Resultats);
                        DGVTask.CurrentCell = DGVTask[0, FirstRow];
                    }
                    else
                    {
                        MessageBox.Show("Aucune correspondance trouvée");
                    }



                }
                else
                {
                    MessageBox.Show("Aucune base de donnée trouvée");
                }//end if file exist
            }
            else
            {
                MessageBox.Show("aucun bénévoles trouvés. Cliquer sur Rafraichir et réessayer");
            }//end if DGVBenevoles .Rowcount != 0
        }

        private void btnDelShadowTask_Click(object sender, EventArgs e)
        {
            int TaskDeletedNbr = 0;
            int i = 0; //index de boucle
            DialogResult Confirmation = MessageBox.Show("Cette Action entrainera la suppression des Tâches suprimées mais Attention :\nLes numéros de chaque Tâches pourront être modifiés de manière irréversible", "!! Attention !!", MessageBoxButtons.YesNo);

            if (Confirmation == DialogResult.Yes)
            {
                //ouverture du fichier pour écriture des informations du bénévole
                XmlDocument docXml = new XmlDocument(); //fichier XML

                //on charge le fichier
                docXml.Load("BaseDeDoneeTaches.xml");

                foreach (XmlNode Task in docXml.DocumentElement)
                {
                    if (Task.FirstChild.InnerText == "-")
                    {
                        TaskDeletedNbr = int.Parse(Task.Attributes["ID"].Value);
                        Task.RemoveAll();
                        docXml.DocumentElement.RemoveChild(Task);

                        i = 0;
                        foreach (XmlNode Tache in docXml.DocumentElement)
                        {
                            if (int.Parse(Tache.Attributes["ID"].Value) >= TaskDeletedNbr)
                            {
                                Tache.Attributes["ID"].Value = (TaskDeletedNbr + i).ToString();
                                i++;
                            }
                        }
                    }
                }

                //sauvegarde de la base de donnée
                docXml.Save("BaseDeDoneeTaches.xml");
            }

            RefreshDGVT();
        }
    }
}


