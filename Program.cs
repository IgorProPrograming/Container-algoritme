using Container_algoritme.models;
using System.Diagnostics;

Main M = new Main();

M.SetShipDimensions();
M.Sort();
M.GetResults();

public class Main()
{
    Ship ship;
    public void SetShipDimensions()
    {
        Console.WriteLine("------------------------------------");
        Console.WriteLine("ship x:");
        string shipX = Console.ReadLine();
        Console.WriteLine("ship y:");
        string shipY = Console.ReadLine();
        Console.WriteLine("------------------------------------");

        ship = new Ship( Convert.ToInt32(shipX), Convert.ToInt32(shipY));
    }

    public void Sort()
    {
        ship.FillShip();
    }

    public void GetResults()
    {
        string webString = ship.WebStringMaker();
        //System.Diagnostics.Process.Start("C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe", webString);
        Console.WriteLine(webString);
    }
}