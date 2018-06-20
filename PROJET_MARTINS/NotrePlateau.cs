using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Projet_Bataille_Navale
{
    public partial class NotrePlateau : Form
    {
        public enum States
        {
            Movingboat = 0,
            Wait = 1
        }

        public enum Boat
        {
            PorteAvion = 0,
            Croiseur = 1,
            ContreTorpilleur = 2,
            SousMarin = 3,
            Torpilleur = 4,
            None = 5
        }
        public struct XY
        {
            public string X;
            public String Y;
        }

        Point ClientOrigin = new Point ();
        Point OriginePorteAvion = new Point();
        Point OrigineCroisseur = new Point();
        Point OrigineContreTorpilleur = new Point();
        Point OrigineSousMarin = new Point();
        Point OrigineTorpilleur = new Point();

        Form_Connection Connect_Form = new Form_Connection();

        Form_Plateau_ennemi Plateau_Ennemi = new Form_Plateau_ennemi();

        bool MouseIsDown = false;
        bool Rotate = false;
        bool BateauRetour = false;

        string Loc_PorteAvion_Vertical = @"H:\H\POBJ\Ex\Nouveau dossier\Porte-Avion_Vertical.png";
        string Loc_PorteAvion_Horizontal = @"H:\H\POBJ\Ex\Nouveau dossier\Porte-Avion.png";
        string Loc_Croiseur_Vertical = @"H:\H\POBJ\Ex\Nouveau dossier\Croiseur_Vertical.png";
        string Loc_Croiseur_Horizontal = @"H:\H\POBJ\Ex\Nouveau dossier\Croiseur.png";
        string Loc_ContreTorpilleur_Vertical = @"H:\H\POBJ\Ex\Nouveau dossier\Torpilleur_Vertical.png";
        string Loc_ContreTorpilleur_Horizontal = @"H:\H\POBJ\Ex\Nouveau dossier\Torpilleur.png";
        string Loc_SousMarin_Vertical = @"H:\H\POBJ\Ex\Nouveau dossier\SousMarin_Vertical.png";
        string Loc_SousMarin_Horizontal = @"H:\H\POBJ\Ex\Nouveau dossier\SousMarin.png";
        string Loc_torpilleur_Vertical = @"H:\H\POBJ\Ex\Nouveau dossier\PetitTorpilleur_Vertical.png";
        string Loc_torpilleur_Horizontal = @"H:\H\POBJ\Ex\Nouveau dossier\PetitTorpilleur.png";

        Boat Selected_Boat = Boat.None;

        States MachinState;

        private bool[,] Grille = new bool[10, 10];

        double TailleCaseX = 42.18;
        double TailleCaseY = 44;

        public NotrePlateau()
        {
            InitializeComponent();
            Connect_Form.ShowDialog();
            timer1.Start();
            MachinState = States.Wait;           
            OriginePorteAvion = PorteAvion.Location;
            OrigineCroisseur = Croiseur.Location;
            OrigineContreTorpilleur = ContreTorpilleur.Location;
            OrigineSousMarin = SousMarin.Location;
            OrigineTorpilleur = Torpilleur.Location;
            PorteAvion.BringToFront();
            lbl1.Text = "vos Bateaux";
            btnLock.Text = "Lock";
        }

        Bateau Bateau_PorteAvion = new Bateau(0,0,5,"Porte Avion");
        Bateau Bateau_Croiseur = new Bateau(0, 0, 4, "Croiseur");
        Bateau Bateau_ContreTropilleur = new Bateau(0, 0, 3, "ContrTropilleur");
        Bateau Bateau_SousMarin = new Bateau(0, 0, 3, "Sous Marin");
        Bateau Bateau_Torpilleur = new Bateau(0, 0, 2, "Torpilleur");

        private void PorteAvion_DragDrop(object sender, DragEventArgs e)
        {
        }

        private void PorteAvion_Click(object sender, EventArgs e)
        {
        }
        private void PorteAvion_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void PorteAvion_MouseDown(object sender, MouseEventArgs e)
        {
            MouseIsDown = true;
            MachinState = States.Movingboat;
            Selected_Boat = Boat.PorteAvion;
        }

        private void Croiseur_MouseDown(object sender, MouseEventArgs e)
        {
            MouseIsDown = true;
            MachinState = States.Movingboat;
            Selected_Boat = Boat.Croiseur;
        }

        private void ContreTorpilleur_MouseDown(object sender, MouseEventArgs e)
        {
            MouseIsDown = true;
            MachinState = States.Movingboat;
            Selected_Boat = Boat.ContreTorpilleur;
        }

        private void SousMarin_MouseDown(object sender, MouseEventArgs e)
        {
            MouseIsDown = true;
            MachinState = States.Movingboat;
            Selected_Boat = Boat.SousMarin;
        }

        private void Torpilleur_MouseDown(object sender, MouseEventArgs e)
        {
            MouseIsDown = true;
            MachinState = States.Movingboat;
            Selected_Boat = Boat.Torpilleur;
        }

        private void Croiseur_MouseUp(object sender, MouseEventArgs e)
        {
            MouseIsDown = false;
        }

        private void ContreTorpilleur_MouseUp(object sender, MouseEventArgs e)
        {
            MouseIsDown = false;
        }

        private void SousMarin_MouseUp(object sender, MouseEventArgs e)
        {
            MouseIsDown = false;
        }

        private void Torpilleur_MouseUp(object sender, MouseEventArgs e)
        {
            MouseIsDown = false;
        }
        private void PorteAvion_MouseUp(object sender, MouseEventArgs e)
        {
            MouseIsDown = false;
        }
        private void NotrePlateau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == ' ') && (MouseIsDown))
            {
                Rotate = true;
            }

            if ((e.KeyChar == (char)Keys.Escape) && (MouseIsDown))
            {
                MouseIsDown = false;
                BateauRetour = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int DebutZoneEnX = 0;
            int FinZoneEnX = 0;
            int DebutZoneEnY = 0;
            int FinZoneEnY = 0;
            int VariableScanX = 0;
            int VariableScanY = 0;
            int I;


            //variables de debug
            int a;
            int b;

            XY PosBateau;
            switch (MachinState)
            {
                case States.Wait:
                    {
                        break;
                    }
                case States.Movingboat:
                    {
                        if ((MouseIsDown) && (!BateauRetour))
                        {
                            Point tmp = new Point((Cursor.Position.X - ((int)TailleCaseX / 2)), (Cursor.Position.Y - ((int)TailleCaseY / 2)));
                            switch (Selected_Boat)
                            {
                                case Boat.PorteAvion:
                                    {
                                        if(Bateau_PorteAvion.IsPlaced)
                                        {
                                            if(Bateau_PorteAvion.orientation)
                                            {
                                                for(I = Bateau_PorteAvion.Coord_X; I < (Bateau_PorteAvion.Taille+Bateau_PorteAvion.Coord_X); I++)
                                                {
                                                    Grille[I, Bateau_PorteAvion.Coord_Y] = false;
                                                }
                                            }
                                            else
                                            {
                                                for (I = Bateau_PorteAvion.Coord_Y; I < (Bateau_PorteAvion.Taille+ Bateau_PorteAvion.Coord_Y); I++)
                                                {
                                                    Grille[Bateau_PorteAvion.Coord_X, I] = false;
                                                }
                                            }
                                        }
                                        Bateau_PorteAvion.IsPlaced = false;
                                        PorteAvion.Location = this.PointToClient(tmp);
                                        if (Rotate)
                                        {
                                            Rotation();
                                            PorteAvion.Refresh();
                                            Rotate = false;
                                        }
                                        break;
                                    }
                                case Boat.Croiseur:
                                    {
                                        if (Bateau_Croiseur.IsPlaced)
                                        {
                                            if (Bateau_Croiseur.orientation)
                                            {
                                                for (I = Bateau_Croiseur.Coord_X; I < (Bateau_Croiseur.Taille+ Bateau_Croiseur.Coord_X); I++)
                                                {
                                                    Grille[I, Bateau_Croiseur.Coord_Y] = false;
                                                }
                                            }
                                            else
                                            {
                                                for (I = Bateau_Croiseur.Coord_Y; I < (Bateau_Croiseur.Taille+ Bateau_Croiseur.Coord_Y); I++)
                                                {
                                                    Grille[Bateau_Croiseur.Coord_X , I] = false;
                                                }
                                            }
                                        }
                                        Bateau_Croiseur.IsPlaced = false;
                                        Croiseur.Location = this.PointToClient(tmp);
                                        if (Rotate)
                                        {
                                            Rotation();
                                            Croiseur.Refresh();
                                            Rotate = false;
                                        }
                                        break;
                                    }
                                case Boat.ContreTorpilleur:
                                    {
                                        if (Bateau_ContreTropilleur.IsPlaced)
                                        {
                                            if (Bateau_ContreTropilleur.orientation)
                                            {
                                                for (I = Bateau_ContreTropilleur.Coord_X; I < (Bateau_ContreTropilleur.Taille+ Bateau_ContreTropilleur.Coord_X); I++)
                                                {
                                                    Grille[I, Bateau_ContreTropilleur.Coord_Y] = false;
                                                }
                                            }
                                            else
                                            {
                                                for (I = Bateau_ContreTropilleur.Coord_Y; I < (Bateau_ContreTropilleur.Taille+ Bateau_ContreTropilleur.Coord_Y); I++)
                                                {
                                                    Grille[Bateau_ContreTropilleur.Coord_X ,I] = false;
                                                }
                                            }
                                        }
                                        Bateau_ContreTropilleur.IsPlaced = false;
                                        ContreTorpilleur.Location = this.PointToClient(tmp);
                                        if (Rotate)
                                        {
                                            Rotation();
                                            PorteAvion.Refresh();
                                            Rotate = false;
                                        }
                                        break;
                                    }
                                case Boat.SousMarin:
                                    {
                                        if (Bateau_SousMarin.IsPlaced)
                                        {
                                            if (Bateau_SousMarin.orientation)
                                            {
                                                for (I = Bateau_SousMarin.Coord_X; I < (Bateau_SousMarin.Taille + Bateau_SousMarin.Coord_X); I++)
                                                {
                                                    Grille[I, Bateau_SousMarin.Coord_Y] = false;
                                                }
                                            }
                                            else
                                            {
                                                for (I = Bateau_SousMarin.Coord_Y; I < (Bateau_SousMarin.Taille+Bateau_SousMarin.Coord_Y); I++)
                                                {
                                                    Grille[Bateau_SousMarin.Coord_X, I] = false;
                                                }
                                            }
                                        }
                                        Bateau_SousMarin.IsPlaced = false;
                                        SousMarin.Location = this.PointToClient(tmp);
                                        if (Rotate)
                                        {
                                            Rotation();
                                            SousMarin.Refresh();
                                            Rotate = false;
                                        }
                                        break;
                                    }
                                case Boat.Torpilleur:
                                    {
                                        if (Bateau_Torpilleur.IsPlaced)
                                        {
                                            if (Bateau_Torpilleur.orientation)
                                            {
                                                for (I = Bateau_Torpilleur.Coord_X; I < (Bateau_Torpilleur.Taille+ Bateau_Torpilleur.Coord_X); I++)
                                                {
                                                    Grille[I, Bateau_Torpilleur.Coord_Y] = false;
                                                }
                                            }
                                            else
                                            {
                                                for (I = Bateau_Torpilleur.Coord_Y; I < (Bateau_Torpilleur.Taille+ Bateau_Torpilleur.Coord_Y); I++)
                                                {
                                                    Grille[Bateau_Torpilleur.Coord_X,I] = false;
                                                }
                                            }
                                        }
                                        Bateau_Torpilleur.IsPlaced = false;
                                        Torpilleur.Location = this.PointToClient(tmp);
                                        if (Rotate)
                                        {
                                            Rotation();
                                            Torpilleur.Refresh();
                                            Rotate = false;
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            if(!BateauRetour)
                            {
                                switch (Selected_Boat)
                                {
                                    case Boat.PorteAvion:
                                        {
                                            PosBateau = GetPosition(PorteAvion.Location);
                                            GetGrilleCoords(PosBateau);
                                            if ((PosBateau.X == "OUT") || (PosBateau.Y == "OUT"))
                                            {
                                                BateauRetour = true;
                                            }
                                            else if(Bateau_PorteAvion.orientation)
                                            {
                                                if((PosBateau.X == "7") || (PosBateau.X == "8") || (PosBateau.X == "9") || (PosBateau.X == "10"))
                                                {
                                                    BateauRetour = true;
                                                }
                                            }
                                            else if(!Bateau_PorteAvion.orientation)
                                            {
                                                if ((PosBateau.Y == "G") || (PosBateau.Y == "H") || (PosBateau.Y == "I") || (PosBateau.Y == "J"))
                                                {
                                                    BateauRetour = true;
                                                }
                                            }

                                            if(!BateauRetour)
                                            {
                                                if (Bateau_PorteAvion.Coord_X - 1 < 0)
                                                {
                                                    DebutZoneEnX = 0;
                                                }
                                                else
                                                {
                                                    DebutZoneEnX = Bateau_PorteAvion.Coord_X - 1;
                                                }

                                                if (Bateau_PorteAvion.Coord_Y - 1 < 0)
                                                {
                                                    DebutZoneEnY = 0;
                                                }
                                                else
                                                {
                                                    DebutZoneEnY = Bateau_PorteAvion.Coord_Y - 1;
                                                }
                                                if (Bateau_PorteAvion.Coord_X + 1 > 9)
                                                {
                                                    FinZoneEnX = 9;
                                                }
                                                else
                                                {
                                                    FinZoneEnX = Bateau_PorteAvion.Coord_X + 1;
                                                }

                                                if (Bateau_PorteAvion.Coord_Y + 1 > 9)
                                                {
                                                    FinZoneEnY = 9;
                                                }
                                                else
                                                {
                                                    FinZoneEnY = Bateau_PorteAvion.Coord_Y + 1;
                                                }
                                                VariableScanX = DebutZoneEnX;                                                
                                                do
                                                {
                                                    VariableScanY = DebutZoneEnY;
                                                    do
                                                    {
                                                        if (Grille[VariableScanX, VariableScanY])
                                                        {
                                                            BateauRetour = true;
                                                        }
                                                        VariableScanY++;
                                                    } while ((VariableScanY != (FinZoneEnY + 1)) && (!BateauRetour));
                                                    VariableScanX++;
                                                } while ((VariableScanX != (FinZoneEnX + 1)) && (!BateauRetour));
                                            }

                                            if(!BateauRetour)
                                            {
                                                PorteAvion.Location = GetCoords(PosBateau);
                                                Bateau_PorteAvion.IsPlaced = true;
                                                Bateau_PorteAvion.Position_X = PosBateau.X;
                                                Bateau_PorteAvion.Position_Y = PosBateau.Y;
                                                if (Bateau_PorteAvion.orientation)
                                                {
                                                    for (I = Bateau_PorteAvion.Coord_X; I < (Bateau_PorteAvion.Taille + Bateau_PorteAvion.Coord_X); I++)
                                                    {
                                                        Grille[I, Bateau_PorteAvion.Coord_Y] = true;
                                                    }
                                                }
                                                else
                                                {
                                                    for (I = Bateau_PorteAvion.Coord_Y; I < (Bateau_PorteAvion.Taille + Bateau_PorteAvion.Coord_Y); I++)
                                                    {
                                                        Grille[Bateau_PorteAvion.Coord_X , I] = true;
                                                    }
                                                }
                                            }
                                            break;
                                        }
                                    case Boat.Croiseur:
                                        {
                                            PosBateau = GetPosition(Croiseur.Location);
                                            GetGrilleCoords(PosBateau);
                                            if ((PosBateau.X == "OUT") || (PosBateau.Y == "OUT"))
                                            {
                                                BateauRetour = true;
                                            }
                                            else if (Bateau_Croiseur.orientation)
                                            {
                                                if ((PosBateau.X == "8") || (PosBateau.X == "9") || (PosBateau.X == "10"))
                                                {
                                                    BateauRetour = true;
                                                }
                                            }
                                            else if (!Bateau_Croiseur.orientation)
                                            {
                                                if ((PosBateau.Y == "H") || (PosBateau.Y == "I") || (PosBateau.Y == "J"))
                                                {
                                                    BateauRetour = true;
                                                }
                                            }

                                            if (!BateauRetour)
                                            {
                                                if (Bateau_Croiseur.Coord_X - 1 < 0)
                                                {
                                                    DebutZoneEnX = 0;
                                                }
                                                else
                                                {
                                                    DebutZoneEnX = Bateau_Croiseur.Coord_X - 1;
                                                }

                                                if (Bateau_Croiseur.Coord_Y - 1 < 0)
                                                {
                                                    DebutZoneEnY = 0;
                                                }
                                                else
                                                {
                                                    DebutZoneEnY = Bateau_Croiseur.Coord_Y - 1;
                                                }
                                                if (Bateau_Croiseur.Coord_X + 1 > 9)
                                                {
                                                    FinZoneEnX = 9;
                                                }
                                                else
                                                {
                                                    FinZoneEnX = Bateau_Croiseur.Coord_X + 1;
                                                }

                                                if (Bateau_Croiseur.Coord_Y + 1 > 9)
                                                {
                                                    FinZoneEnY = 9;
                                                }
                                                else
                                                {
                                                    FinZoneEnY = Bateau_Croiseur.Coord_Y + 1;
                                                }
                                                VariableScanX = DebutZoneEnX;                                                
                                                do
                                                {
                                                    VariableScanY = DebutZoneEnY;
                                                    do
                                                    {
                                                        if (Grille[VariableScanX, VariableScanY])
                                                        {
                                                            BateauRetour = true;
                                                        }
                                                        VariableScanY++;
                                                    } while ((VariableScanY != (FinZoneEnY + 1)) && (!BateauRetour));
                                                    VariableScanX++;
                                                } while ((VariableScanX != (FinZoneEnX + 1)) && (!BateauRetour));
                                            }

                                            if (!BateauRetour)
                                            {
                                                Croiseur.Location = GetCoords(PosBateau);
                                                Bateau_Croiseur.IsPlaced = true;
                                                Bateau_Croiseur.Position_X = PosBateau.X;
                                                Bateau_Croiseur.Position_Y = PosBateau.Y;
                                                if (Bateau_Croiseur.orientation)
                                                {
                                                    for (I = Bateau_Croiseur.Coord_X; I < (Bateau_Croiseur.Taille + Bateau_Croiseur.Coord_X); I++)
                                                    {
                                                        Grille[I, Bateau_Croiseur.Coord_Y] = true;
                                                    }
                                                }
                                                else
                                                {
                                                    for (I = Bateau_Croiseur.Coord_Y; I < (Bateau_Croiseur.Taille + Bateau_Croiseur.Coord_Y); I++)
                                                    {
                                                        Grille[Bateau_Croiseur.Coord_X, I] = true;
                                                    }
                                                }
                                            }
                                            break;
                                        }
                                    case Boat.ContreTorpilleur:
                                        {
                                            PosBateau = GetPosition(ContreTorpilleur.Location);
                                            GetGrilleCoords(PosBateau);
                                            if ((PosBateau.X == "OUT") || (PosBateau.Y == "OUT"))
                                            {
                                                BateauRetour = true;
                                            }
                                            else if (Bateau_ContreTropilleur.orientation)
                                            {
                                                if ((PosBateau.X == "9") || (PosBateau.X == "10"))
                                                {
                                                    BateauRetour = true;
                                                }
                                            }
                                            else if (!Bateau_ContreTropilleur.orientation)
                                            {
                                                if ((PosBateau.Y == "I") || (PosBateau.Y == "J"))
                                                {
                                                    BateauRetour = true;
                                                }
                                            }

                                            if (!BateauRetour)
                                            {
                                                if (Bateau_ContreTropilleur.Coord_X - 1 < 0)
                                                {
                                                    DebutZoneEnX = 0;
                                                }
                                                else
                                                {
                                                    DebutZoneEnX = Bateau_ContreTropilleur.Coord_X - 1;
                                                }

                                                if (Bateau_ContreTropilleur.Coord_Y - 1 < 0)
                                                {
                                                    DebutZoneEnY = 0;
                                                }
                                                else
                                                {
                                                    DebutZoneEnY = Bateau_ContreTropilleur.Coord_Y - 1;
                                                }
                                                if (Bateau_ContreTropilleur.Coord_X + 1 > 9)
                                                {
                                                    FinZoneEnX = 9;
                                                }
                                                else
                                                {
                                                    FinZoneEnX = Bateau_ContreTropilleur.Coord_X + 1;
                                                }

                                                if (Bateau_ContreTropilleur.Coord_Y + 1 > 9)
                                                {
                                                    FinZoneEnY = 9;
                                                }
                                                else
                                                {
                                                    FinZoneEnY = Bateau_ContreTropilleur.Coord_Y + 1;
                                                }
                                                VariableScanX = DebutZoneEnX;                                                
                                                do
                                                {
                                                    VariableScanY = DebutZoneEnY;
                                                    do
                                                    {
                                                        if (Grille[VariableScanX, VariableScanY])
                                                        {
                                                            BateauRetour = true;
                                                        }
                                                        VariableScanY++;
                                                    } while ((VariableScanY != (FinZoneEnY + 1)) && (!BateauRetour));
                                                    VariableScanX++;
                                                } while ((VariableScanX != (FinZoneEnX + 1)) && (!BateauRetour));
                                            }

                                            if (!BateauRetour)
                                            {
                                                ContreTorpilleur.Location = GetCoords(PosBateau);
                                                Bateau_ContreTropilleur.IsPlaced = true;
                                                Bateau_ContreTropilleur.Position_X = PosBateau.X;
                                                Bateau_ContreTropilleur.Position_Y = PosBateau.Y;
                                                if (Bateau_ContreTropilleur.orientation)
                                                {
                                                    for (I = Bateau_ContreTropilleur.Coord_X; I < (Bateau_ContreTropilleur.Taille + Bateau_ContreTropilleur.Coord_X); I++)
                                                    {
                                                        Grille[I, Bateau_ContreTropilleur.Coord_Y] = true;
                                                    }
                                                }
                                                else
                                                {
                                                    for (I = Bateau_ContreTropilleur.Coord_Y; I < (Bateau_ContreTropilleur.Taille + Bateau_ContreTropilleur.Coord_Y); I++)
                                                    {
                                                        Grille[Bateau_ContreTropilleur.Coord_X,I] = true;
                                                    }
                                                }
                                            }
                                            break;
                                        }
                                    case Boat.SousMarin:
                                        {
                                            PosBateau = GetPosition(SousMarin.Location);
                                            GetGrilleCoords(PosBateau);
                                            if ((PosBateau.X == "OUT") || (PosBateau.Y == "OUT"))
                                            {
                                                BateauRetour = true;
                                            }
                                            else if (Bateau_SousMarin.orientation)
                                            {
                                                if ((PosBateau.X == "9") || (PosBateau.X == "10"))
                                                {
                                                    BateauRetour = true;
                                                }
                                            }
                                            else if (!Bateau_SousMarin.orientation)
                                            {
                                                if ((PosBateau.Y == "I") || (PosBateau.Y == "J"))
                                                {
                                                    BateauRetour = true;
                                                }
                                            }

                                            if (!BateauRetour)
                                            {
                                                if (Bateau_SousMarin.Coord_X - 1 < 0)
                                                {
                                                    DebutZoneEnX = 0;
                                                }
                                                else
                                                {
                                                    DebutZoneEnX = Bateau_SousMarin.Coord_X - 1;
                                                }

                                                if (Bateau_SousMarin.Coord_Y - 1 < 0)
                                                {
                                                    DebutZoneEnY = 0;
                                                }
                                                else
                                                {
                                                    DebutZoneEnY = Bateau_SousMarin.Coord_Y - 1;
                                                }
                                                if (Bateau_SousMarin.Coord_X + 1 > 9)
                                                {
                                                    FinZoneEnX = 9;
                                                }
                                                else
                                                {
                                                    FinZoneEnX = Bateau_SousMarin.Coord_X + 1;
                                                }

                                                if (Bateau_SousMarin.Coord_Y + 1 > 9)
                                                {
                                                    FinZoneEnY = 9;
                                                }
                                                else
                                                {
                                                    FinZoneEnY = Bateau_SousMarin.Coord_Y + 1;
                                                }
                                                VariableScanX = DebutZoneEnX;                                         
                                                do
                                                {
                                                    VariableScanY = DebutZoneEnY;
                                                    do
                                                    {
                                                        if (Grille[VariableScanX, VariableScanY])
                                                        {
                                                            BateauRetour = true;
                                                        }
                                                        VariableScanY++;
                                                    } while ((VariableScanY != (FinZoneEnY + 1)) && (!BateauRetour));
                                                    VariableScanX++;
                                                } while ((VariableScanX != (FinZoneEnX + 1)) && (!BateauRetour));
                                            }

                                            if (!BateauRetour)
                                            {
                                                SousMarin.Location = GetCoords(PosBateau);
                                                Bateau_SousMarin.IsPlaced = true;
                                                Bateau_SousMarin.Position_X = PosBateau.X;
                                                Bateau_SousMarin.Position_Y = PosBateau.Y;
                                                if (Bateau_SousMarin.orientation)
                                                {
                                                    for (I = Bateau_SousMarin.Coord_X; I < (Bateau_SousMarin.Coord_X + Bateau_SousMarin.Taille); I++)
                                                    {
                                                        Grille[I, Bateau_SousMarin.Coord_Y] = true;
                                                    }
                                                }
                                                else
                                                {
                                                    for (I = Bateau_SousMarin.Coord_Y; I < (Bateau_SousMarin.Coord_Y + Bateau_SousMarin.Taille); I++)
                                                    {
                                                        Grille[Bateau_SousMarin.Coord_X, I] = true;
                                                    }
                                                }
                                            }
                                            break;
                                        }
                                    case Boat.Torpilleur:
                                        {
                                            PosBateau = GetPosition(Torpilleur.Location);
                                            GetGrilleCoords(PosBateau);
                                            if ((PosBateau.X == "OUT") || (PosBateau.Y == "OUT"))
                                            {
                                                BateauRetour = true;
                                            }
                                            else if (Bateau_Torpilleur.orientation)
                                            {
                                                if (PosBateau.X == "10")
                                                {
                                                    BateauRetour = true;
                                                }
                                            }
                                            else if (!Bateau_Torpilleur.orientation)
                                            {
                                                if (PosBateau.Y == "J")
                                                {
                                                    BateauRetour = true;
                                                }
                                            }

                                            if (!BateauRetour)
                                            {
                                                if (Bateau_Torpilleur.Coord_X - 1 < 0)
                                                {
                                                    DebutZoneEnX = 0;
                                                }
                                                else
                                                {
                                                    DebutZoneEnX = Bateau_Torpilleur.Coord_X - 1;
                                                }

                                                if (Bateau_Torpilleur.Coord_Y - 1 < 0)
                                                {
                                                    DebutZoneEnY = 0;
                                                }
                                                else
                                                {
                                                    DebutZoneEnY = Bateau_Torpilleur.Coord_Y - 1;
                                                }
                                                if (Bateau_Torpilleur.Coord_X + 1 > 9)
                                                {
                                                    FinZoneEnX = 9;
                                                }
                                                else
                                                {
                                                    FinZoneEnX = Bateau_Torpilleur.Coord_X + 1;
                                                }

                                                if (Bateau_Torpilleur.Coord_Y + 1 > 9)
                                                {
                                                    FinZoneEnY = 9;
                                                }
                                                else
                                                {
                                                    FinZoneEnY = Bateau_Torpilleur.Coord_Y + 1;
                                                }
                                                VariableScanX = DebutZoneEnX;                                                
                                                do
                                                {
                                                    VariableScanY = DebutZoneEnY;
                                                    do
                                                    {
                                                        if (Grille[VariableScanX, VariableScanY])
                                                        {
                                                            BateauRetour = true;
                                                        }
                                                        VariableScanY++;
                                                    } while ((VariableScanY != (FinZoneEnY + 1)) && (!BateauRetour));
                                                    VariableScanX++;
                                                } while ((VariableScanX != (FinZoneEnX + 1)) && (!BateauRetour));
                                            }

                                            if (!BateauRetour)
                                            {
                                                Torpilleur.Location = GetCoords(PosBateau);
                                                Bateau_Torpilleur.IsPlaced = true;
                                                Bateau_Torpilleur.Position_X = PosBateau.X;
                                                Bateau_Torpilleur.Position_Y = PosBateau.Y;
                                                if (Bateau_Torpilleur.orientation)
                                                {
                                                    for (I = Bateau_Torpilleur.Coord_X; I < (Bateau_Torpilleur.Taille + Bateau_Torpilleur.Coord_X); I++)
                                                    {
                                                        Grille[I, Bateau_Torpilleur.Coord_Y] = true;
                                                    }
                                                }
                                                else
                                                {
                                                    for (I = Bateau_Torpilleur.Coord_Y; I < (Bateau_Torpilleur.Taille + Bateau_Torpilleur.Coord_Y); I++)
                                                    {
                                                        Grille[Bateau_Torpilleur.Coord_X , I] = true;
                                                    }
                                                }
                                            }                                   
                                                break;
                                        }
                                }
                            }

                            Console.WriteLine("---------------------------------");
                            for(a = 0; a < 10; a ++)
                            {
                                for(b = 0; b < 10; b++)
                                {
                                    Console.Write(" | ");
                                    Console.Write(Grille[b,a]);
                                    if (Grille[b, a])
                                    {
                                        Console.Write(" ");
                                    }
                                }
                                Console.WriteLine();
                            }                          

                            if (BateauRetour)
                            {
                                switch (Selected_Boat)
                                {
                                    case Boat.PorteAvion:
                                        {
                                            if(!Bateau_PorteAvion.orientation)
                                            {
                                                Rotation();
                                            }
                                            PorteAvion.Location = OriginePorteAvion;
                                            break;
                                        }
                                    case Boat.Croiseur:
                                        {
                                            if (!Bateau_Croiseur.orientation)
                                            {
                                                Rotation();
                                            }
                                            Croiseur.Location = OrigineCroisseur;
                                            break;
                                        }
                                    case Boat.ContreTorpilleur:
                                        {
                                            if (!Bateau_ContreTropilleur.orientation)
                                            {
                                                Rotation();
                                            }
                                            ContreTorpilleur.Location = OrigineContreTorpilleur;
                                            break;
                                        }
                                    case Boat.SousMarin:
                                        {
                                            if (!Bateau_SousMarin.orientation)
                                            {
                                                Rotation();
                                            }
                                            SousMarin.Location = OrigineSousMarin;
                                            break;
                                        }
                                    case Boat.Torpilleur:
                                        {
                                            if (!Bateau_Torpilleur.orientation)
                                            {
                                                Rotation();
                                            }
                                            Torpilleur.Location = OrigineTorpilleur;
                                            break;
                                        }
                                }
                                BateauRetour = false;
                            }

                            MachinState = States.Wait;
                            Selected_Boat = Boat.None;
                        }
                        break;
                    }
            }

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private XY GetPosition (Point tmp)
        {
            XY Position;
            string PosX = "0";
            string PosY = "0";

            Position.X = "0";
            Position.Y = "0";

            if ((tmp.X < (TailleCaseX + TailleCaseX / 2)) || (tmp.X > ((TailleCaseX * 11) + TailleCaseX / 2)))
            {
                PosX = "OUT";
            }
            else if (tmp.X < ((TailleCaseX * 2)+TailleCaseX/2))
            {
                PosX = "1";
            }
            else if (tmp.X < ((TailleCaseX * 3) + TailleCaseX / 2))
            {
                PosX = "2";
            }
            else if (tmp.X < ((TailleCaseX * 4) + TailleCaseX / 2))
            {
                PosX = "3";
            }
            else if (tmp.X < ((TailleCaseX * 5) + TailleCaseX / 2))
            {
                PosX = "4";
            }
            else if (tmp.X < ((TailleCaseX * 6) + TailleCaseX / 2))
            {
                PosX = "5";
            }
            else if (tmp.X < ((TailleCaseX * 7) + TailleCaseX / 2))
            {
                PosX = "6";
            }
            else if (tmp.X < ((TailleCaseX * 8) + TailleCaseX / 2))
            {
                PosX = "7";
            }
            else if (tmp.X < ((TailleCaseX * 9) + TailleCaseX / 2))
            {
                PosX = "8";
            }
            else if (tmp.X < ((TailleCaseX * 10) + TailleCaseX / 2))
            {
                PosX = "9";
            }
            else if (tmp.X < ((TailleCaseX * 11) + TailleCaseX / 2))
            {
                PosX = "10";
            }

            if ((tmp.Y < (TailleCaseY+TailleCaseY/2)) || (tmp.Y > (TailleCaseY * 11)+TailleCaseY / 2))
            {
                PosY = "OUT";
            }
            else if (tmp.Y < ((TailleCaseY * 2)+TailleCaseY / 2))
            {
                PosY = "A";
            }
            else if (tmp.Y < ((TailleCaseY * 3)+TailleCaseY / 2))
            {
                PosY = "B";
            }
            else if (tmp.Y < ((TailleCaseY * 4)+TailleCaseY / 2))
            {
                PosY = "C";
            }
            else if (tmp.Y < ((TailleCaseY * 5)+TailleCaseY / 2))
            {
                PosY = "D";
            }
            else if (tmp.Y < ((TailleCaseY * 6)+TailleCaseY / 2))
            {
                PosY = "E";
            }
            else if (tmp.Y < ((TailleCaseY * 7)+TailleCaseY / 2))
            {
                PosY = "F";
            }
            else if (tmp.Y < ((TailleCaseY * 8)+TailleCaseY / 2))
            {
                PosY = "G";
            }
            else if (tmp.Y < ((TailleCaseY * 9)+TailleCaseY / 2))
            {
                PosY = "H";
            }
            else if (tmp.Y < ((TailleCaseY * 10)+TailleCaseY / 2))
            {
                PosY = "I";
            }
            else if (tmp.Y < ((TailleCaseY * 11)+TailleCaseY / 2))
            {
                PosY = "J";
            }

            Position.X = PosX;
            Position.Y = PosY;

            return Position; 
        }

        private Point GetCoords (XY Position)
        {
            int tmpX = 0;
            int tmpY = 0;
            switch(Position.X)
            {
                case "1":
                    tmpX = (int)(TailleCaseX * 2);
                    break;
                case "2":
                    tmpX = (int)(TailleCaseX * 3);
                    break;
                case "3":
                    tmpX = (int)(TailleCaseX * 4);
                    break;
                case "4":
                    tmpX = (int)(TailleCaseX * 5);
                    break;
                case "5":
                    tmpX = (int)(TailleCaseX * 6);
                    break;
                case "6":
                    tmpX = (int)(TailleCaseX * 7);
                    break;
                case "7":
                    tmpX = (int)(TailleCaseX * 8);
                    break;
                case "8":
                    tmpX = (int)(TailleCaseX * 9);
                    break;
                case "9":
                    tmpX = (int)(TailleCaseX * 10);
                    break;
                case "10":
                    tmpX = (int)(TailleCaseX * 11);
                    break;
            }
            switch (Position.Y)
            {
                case "A":
                    tmpY = (int)(TailleCaseY * 2);
                    break;
                case "B":
                    tmpY = (int)(TailleCaseY * 3);
                    break;
                case "C":
                    tmpY = (int)(TailleCaseY * 4);
                    break;
                case "D":
                    tmpY = (int)(TailleCaseY * 5);
                    break;
                case "E":
                    tmpY = (int)(TailleCaseY * 6);
                    break;
                case "F":
                    tmpY = (int)(TailleCaseY * 7);
                    break;
                case "G":
                    tmpY = (int)(TailleCaseY * 8);
                    break;
                case "H":
                    tmpY = (int)(TailleCaseY * 9);
                    break;
                case "I":
                    tmpY = (int)(TailleCaseY * 10);
                    break;
                case "J":
                    tmpY = (int)(TailleCaseY * 11);
                    break;
            }
            Point PointToReturn = new Point(tmpX,tmpY);
            return PointToReturn;
        }

        private void GetGrilleCoords (XY Position)
        {
            switch (Selected_Boat)
            {
                case Boat.PorteAvion:
                    switch(Position.X)
                    {
                        case "1":
                            Bateau_PorteAvion.Coord_X = 0;
                            break;
                        case "2":
                            Bateau_PorteAvion.Coord_X = 1;
                            break;
                        case "3":
                            Bateau_PorteAvion.Coord_X = 2;
                            break;
                        case "4":
                            Bateau_PorteAvion.Coord_X = 3;
                            break;
                        case "5":
                            Bateau_PorteAvion.Coord_X = 4;
                            break;
                        case "6":
                            Bateau_PorteAvion.Coord_X = 5;
                            break;
                        case "7":
                            Bateau_PorteAvion.Coord_X = 6;
                            break;
                        case "8":
                            Bateau_PorteAvion.Coord_X = 7;
                            break;
                        case "9":
                            Bateau_PorteAvion.Coord_X = 8;
                            break;
                        case "10":
                            Bateau_PorteAvion.Coord_X = 9;
                            break;                       
                    }
                    switch(Position.Y)
                    {
                        case "A":
                            Bateau_PorteAvion.Coord_Y = 0;
                            break;
                        case "B":
                            Bateau_PorteAvion.Coord_Y = 1;
                            break;
                        case "C":
                            Bateau_PorteAvion.Coord_Y = 2;
                            break;
                        case "D":
                            Bateau_PorteAvion.Coord_Y = 3;
                            break;
                        case "E":
                            Bateau_PorteAvion.Coord_Y = 4;
                            break;
                        case "F":
                            Bateau_PorteAvion.Coord_Y = 5;
                            break;
                        case "G":
                            Bateau_PorteAvion.Coord_Y = 6;
                            break;
                        case "H":
                            Bateau_PorteAvion.Coord_Y = 7;
                            break;
                        case "Y":
                            Bateau_PorteAvion.Coord_Y = 8;
                            break;
                        case "J":
                            Bateau_PorteAvion.Coord_Y = 9;
                            break;
                    }
                    break;
                case Boat.Croiseur:
                    switch (Position.X)
                    {
                        case "1":
                            Bateau_Croiseur.Coord_X = 0;
                            break;
                        case "2":
                            Bateau_Croiseur.Coord_X = 1;
                            break;
                        case "3":
                            Bateau_Croiseur.Coord_X = 2;
                            break;
                        case "4":
                            Bateau_Croiseur.Coord_X = 3;
                            break;
                        case "5":
                            Bateau_Croiseur.Coord_X = 4;
                            break;
                        case "6":
                            Bateau_Croiseur.Coord_X = 5;
                            break;
                        case "7":
                            Bateau_Croiseur.Coord_X = 6;
                            break;
                        case "8":
                            Bateau_Croiseur.Coord_X = 7;
                            break;
                        case "9":
                            Bateau_Croiseur.Coord_X = 8;
                            break;
                        case "10":
                            Bateau_Croiseur.Coord_X = 9;
                            break;
                    }
                    switch (Position.Y)
                    {
                        case "A":
                            Bateau_Croiseur.Coord_Y = 0;
                            break;
                        case "B":
                            Bateau_Croiseur.Coord_Y = 1;
                            break;
                        case "C":
                            Bateau_Croiseur.Coord_Y = 2;
                            break;
                        case "D":
                            Bateau_Croiseur.Coord_Y = 3;
                            break;
                        case "E":
                            Bateau_Croiseur.Coord_Y = 4;
                            break;
                        case "F":
                            Bateau_Croiseur.Coord_Y = 5;
                            break;
                        case "G":
                            Bateau_Croiseur.Coord_Y = 6;
                            break;
                        case "H":
                            Bateau_Croiseur.Coord_Y = 7;
                            break;
                        case "Y":
                            Bateau_Croiseur.Coord_Y = 8;
                            break;
                        case "J":
                            Bateau_Croiseur.Coord_Y = 9;
                            break;
                    }
                    break;
                case Boat.ContreTorpilleur:
                    switch (Position.X)
                    {
                        case "1":
                            Bateau_ContreTropilleur.Coord_X = 0;
                            break;
                        case "2":
                            Bateau_ContreTropilleur.Coord_X = 1;
                            break;
                        case "3":
                            Bateau_ContreTropilleur.Coord_X = 2;
                            break;
                        case "4":
                            Bateau_ContreTropilleur.Coord_X = 3;
                            break;
                        case "5":
                            Bateau_ContreTropilleur.Coord_X = 4;
                            break;
                        case "6":
                            Bateau_ContreTropilleur.Coord_X = 5;
                            break;
                        case "7":
                            Bateau_ContreTropilleur.Coord_X = 6;
                            break;
                        case "8":
                            Bateau_ContreTropilleur.Coord_X = 7;
                            break;
                        case "9":
                            Bateau_ContreTropilleur.Coord_X = 8;
                            break;
                        case "10":
                            Bateau_ContreTropilleur.Coord_X = 9;
                            break;
                    }
                    switch (Position.Y)
                    {
                        case "A":
                            Bateau_ContreTropilleur.Coord_Y = 0;
                            break;
                        case "B":
                            Bateau_ContreTropilleur.Coord_Y = 1;
                            break;
                        case "C":
                            Bateau_ContreTropilleur.Coord_Y = 2;
                            break;
                        case "D":
                            Bateau_ContreTropilleur.Coord_Y = 3;
                            break;
                        case "E":
                            Bateau_ContreTropilleur.Coord_Y = 4;
                            break;
                        case "F":
                            Bateau_ContreTropilleur.Coord_Y = 5;
                            break;
                        case "G":
                            Bateau_ContreTropilleur.Coord_Y = 6;
                            break;
                        case "H":
                            Bateau_ContreTropilleur.Coord_Y = 7;
                            break;
                        case "Y":
                            Bateau_ContreTropilleur.Coord_Y = 8;
                            break;
                        case "J":
                            Bateau_ContreTropilleur.Coord_Y = 9;
                            break;
                    }
                    break;
                case Boat.SousMarin:
                    switch (Position.X)
                    {
                        case "1":
                            Bateau_SousMarin.Coord_X = 0;
                            break;
                        case "2":
                            Bateau_SousMarin.Coord_X = 1;
                            break;
                        case "3":
                            Bateau_SousMarin.Coord_X = 2;
                            break;
                        case "4":
                            Bateau_SousMarin.Coord_X = 3;
                            break;
                        case "5":
                            Bateau_SousMarin.Coord_X = 4;
                            break;
                        case "6":
                            Bateau_SousMarin.Coord_X = 5;
                            break;
                        case "7":
                            Bateau_SousMarin.Coord_X = 6;
                            break;
                        case "8":
                            Bateau_SousMarin.Coord_X = 7;
                            break;
                        case "9":
                            Bateau_SousMarin.Coord_X = 8;
                            break;
                        case "10":
                            Bateau_SousMarin.Coord_X = 9;
                            break;
                    }
                    switch (Position.Y)
                    {
                        case "A":
                            Bateau_SousMarin.Coord_Y = 0;
                            break;
                        case "B":
                            Bateau_SousMarin.Coord_Y = 1;
                            break;
                        case "C":
                            Bateau_SousMarin.Coord_Y = 2;
                            break;
                        case "D":
                            Bateau_SousMarin.Coord_Y = 3;
                            break;
                        case "E":
                            Bateau_SousMarin.Coord_Y = 4;
                            break;
                        case "F":
                            Bateau_SousMarin.Coord_Y = 5;
                            break;
                        case "G":
                            Bateau_SousMarin.Coord_Y = 6;
                            break;
                        case "H":
                            Bateau_SousMarin.Coord_Y = 7;
                            break;
                        case "Y":
                            Bateau_SousMarin.Coord_Y = 8;
                            break;
                        case "J":
                            Bateau_SousMarin.Coord_Y = 9;
                            break;
                    }
                    break;
                case Boat.Torpilleur:
                    switch (Position.X)
                    {
                        case "1":
                            Bateau_Torpilleur.Coord_X = 0;
                            break;
                        case "2":
                            Bateau_Torpilleur.Coord_X = 1;
                            break;
                        case "3":
                            Bateau_Torpilleur.Coord_X = 2;
                            break;
                        case "4":
                            Bateau_Torpilleur.Coord_X = 3;
                            break;
                        case "5":
                            Bateau_Torpilleur.Coord_X = 4;
                            break;
                        case "6":
                            Bateau_Torpilleur.Coord_X = 5;
                            break;
                        case "7":
                            Bateau_Torpilleur.Coord_X = 6;
                            break;
                        case "8":
                            Bateau_Torpilleur.Coord_X = 7;
                            break;
                        case "9":
                            Bateau_Torpilleur.Coord_X = 8;
                            break;
                        case "10":
                            Bateau_Torpilleur.Coord_X = 9;
                            break;
                    }
                    switch (Position.Y)
                    {
                        case "A":
                            Bateau_Torpilleur.Coord_Y = 0;
                            break;
                        case "B":
                            Bateau_Torpilleur.Coord_Y = 1;
                            break;
                        case "C":
                            Bateau_Torpilleur.Coord_Y = 2;
                            break;
                        case "D":
                            Bateau_Torpilleur.Coord_Y = 3;
                            break;
                        case "E":
                            Bateau_Torpilleur.Coord_Y = 4;
                            break;
                        case "F":
                            Bateau_Torpilleur.Coord_Y = 5;
                            break;
                        case "G":
                            Bateau_Torpilleur.Coord_Y = 6;
                            break;
                        case "H":
                            Bateau_Torpilleur.Coord_Y = 7;
                            break;
                        case "Y":
                            Bateau_Torpilleur.Coord_Y = 8;
                            break;
                        case "J":
                            Bateau_Torpilleur.Coord_Y = 9;
                            break;
                    }
                    break;
            }
        }     
     
        private bool CheckPosition ()
        {
            int I;
            int J;
            switch (Selected_Boat)
            {
                case Boat.PorteAvion:
                    if ((Bateau_Croiseur.IsPlaced)||(Bateau_ContreTropilleur.IsPlaced)||(Bateau_SousMarin.IsPlaced)||(Bateau_Torpilleur.IsPlaced))
                    {

                    }
                    else
                    {
                        if(Bateau_PorteAvion.orientation)
                        {
                            switch (Bateau_PorteAvion.Position_X)
                            {
                                case "A":
                                    J = 1;
                                    break;
                                case "B":
                                    J = 2;
                                    break;
                                case "C":
                                    J = 3;
                                    break;
                                case "D":
                                    J = 4;
                                    break;
                                case "E":
                                    J = 5;
                                    break;
                                case "F":
                                    J = 6;
                                    break;
                                case "G":
                                    J = 7;
                                    break;
                                case "H":
                                    J = 8;
                                    break;
                                case "I":
                                    J = 9;
                                    break;
                                case "J":
                                    J = 10;
                                    break;
                            }
                            
                        }
                        else
                        {

                        }
                    }
                    break;
                case Boat.Croiseur:
                    if ((Bateau_PorteAvion.IsPlaced) || (Bateau_ContreTropilleur.IsPlaced) || (Bateau_SousMarin.IsPlaced) || (Bateau_Torpilleur.IsPlaced))
                    {

                    }
                    else
                    {

                    }
                    break;
                case Boat.ContreTorpilleur:
                    if ((Bateau_Croiseur.IsPlaced) || (Bateau_PorteAvion.IsPlaced) || (Bateau_SousMarin.IsPlaced) || (Bateau_Torpilleur.IsPlaced))
                    {

                    }
                    else
                    {

                    }
                    break;
                case Boat.SousMarin:
                    if ((Bateau_Croiseur.IsPlaced) || (Bateau_ContreTropilleur.IsPlaced) || (Bateau_PorteAvion.IsPlaced) || (Bateau_Torpilleur.IsPlaced))
                    {

                    }
                    else
                    {

                    }
                    break;
                case Boat.Torpilleur:
                    if ((Bateau_Croiseur.IsPlaced) || (Bateau_ContreTropilleur.IsPlaced) || (Bateau_SousMarin.IsPlaced) || (Bateau_PorteAvion.IsPlaced))
                    {

                    }
                    else
                    {

                    }
                    break;

            }
            return true;
        }

        private void Rotation ()
        {
            switch (Selected_Boat)
            {
                case Boat.PorteAvion:
                    if (Bateau_PorteAvion.orientation)
                    {
                        PorteAvion.ImageLocation = Loc_PorteAvion_Vertical;
                        PorteAvion.Width = (int)TailleCaseX;
                        PorteAvion.Height = (int)(TailleCaseY * Bateau_PorteAvion.Taille);
                        Bateau_PorteAvion.orientation = false;
                    }
                    else
                    {
                        PorteAvion.ImageLocation = Loc_PorteAvion_Horizontal;
                        PorteAvion.Width = (int)(TailleCaseX * Bateau_PorteAvion.Taille);
                        PorteAvion.Height = (int)TailleCaseY;
                        Bateau_PorteAvion.orientation = true;
                    }
                    break;
                case Boat.Croiseur:
                    if (Bateau_Croiseur.orientation)
                    {
                        Croiseur.ImageLocation = Loc_Croiseur_Vertical;
                        Croiseur.Width = (int)TailleCaseX;
                        Croiseur.Height = (int)(TailleCaseY * Bateau_Croiseur.Taille);
                        Bateau_Croiseur.orientation = false;
                    }
                    else
                    {
                        Croiseur.ImageLocation = Loc_Croiseur_Horizontal;
                        Croiseur.Width = (int)(TailleCaseX * Bateau_Croiseur.Taille);
                        Croiseur.Height = (int)TailleCaseY;
                        Bateau_Croiseur.orientation = true;
                    }
                    break;
                case Boat.ContreTorpilleur:
                    if (Bateau_ContreTropilleur.orientation)
                    {
                        ContreTorpilleur.ImageLocation = Loc_ContreTorpilleur_Vertical;
                        ContreTorpilleur.Width = (int)TailleCaseX;
                        ContreTorpilleur.Height = (int)(TailleCaseY * Bateau_ContreTropilleur.Taille);
                        Bateau_ContreTropilleur.orientation = false;
                    }
                    else
                    {
                        ContreTorpilleur.ImageLocation = Loc_ContreTorpilleur_Horizontal;
                        ContreTorpilleur.Width = (int)(TailleCaseX * Bateau_ContreTropilleur.Taille);
                        ContreTorpilleur.Height = (int)TailleCaseY;
                        Bateau_ContreTropilleur.orientation = true;
                    }
                    break;
                case Boat.SousMarin:
                    if (Bateau_SousMarin.orientation)
                    {
                        SousMarin.ImageLocation = Loc_SousMarin_Vertical;
                        SousMarin.Width = (int)TailleCaseX;
                        SousMarin.Height = (int)(TailleCaseY * Bateau_SousMarin.Taille);
                        Bateau_SousMarin.orientation = false;
                    }
                    else
                    {
                        SousMarin.ImageLocation = Loc_SousMarin_Horizontal;
                        SousMarin.Width = (int)(TailleCaseX * Bateau_SousMarin.Taille);
                        SousMarin.Height = (int)TailleCaseY;
                        Bateau_SousMarin.orientation = true;
                    }
                    break;
                case Boat.Torpilleur:
                    if (Bateau_Torpilleur.orientation)
                    {
                        Torpilleur.ImageLocation = Loc_torpilleur_Vertical;
                        Torpilleur.Width = (int)TailleCaseX;
                        Torpilleur.Height = (int)(TailleCaseY * Bateau_Torpilleur.Taille);
                        Bateau_Torpilleur.orientation = false;
                    }
                    else
                    {
                        Torpilleur.ImageLocation = Loc_torpilleur_Horizontal;
                        Torpilleur.Width = (int)(TailleCaseX * Bateau_Torpilleur.Taille);
                        Torpilleur.Height = (int)TailleCaseY;
                        Bateau_Torpilleur.orientation = true;
                    }
                    break;
            }
        }

        private void NotrePlateau_MouseMove(object sender, MouseEventArgs e)
        {
            Point PositionFenetre = new Point();
            PositionFenetre = this.Location;
        }

        private void NotrePlateau_LocationChanged(object sender, EventArgs e)
        {
            ClientOrigin = this.Location;
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            if((Bateau_PorteAvion.IsPlaced) && (Bateau_Croiseur.IsPlaced) && (Bateau_ContreTropilleur.IsPlaced) && (Bateau_SousMarin.IsPlaced) && (Bateau_Torpilleur.IsPlaced))
            {
                Plateau_Ennemi.ShowDialog();
                this.BringToFront();
            }
            else
            {
                MessageBox.Show("Tout les bateaux n'ont pas été placé");
            }
        }
    }
}
