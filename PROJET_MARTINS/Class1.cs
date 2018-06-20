using System;

public class Bateau
{
    public struct XY
    {
        public string X;
        public String Y;
    }

    public string BoatName;
    public bool orientation = true; //true -> horizontal // false -> Vertical// 
    public string Position_X;
    public int Coord_X;
    public string Position_Y;
    public int Coord_Y;
    public int Taille;
    public int Vie;
    public bool IsPlaced;

    public XY PosXY;
    public Bateau(int X, int Y, int taille, string Name)
	{
        BoatName = Name;
        orientation = true; //true -> horizontal // false -> Vertical// 
        Taille = taille;
        Vie = Taille;
        IsPlaced = false;
	}

}
