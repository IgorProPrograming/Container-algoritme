using Container_algoritme.models;

Ship ship;

Console.WriteLine("------------------------------------");
Console.WriteLine("ship x:");
int shipX = int.Parse(Console.ReadLine());
Console.WriteLine("ship y:");
int shipY = int.Parse(Console.ReadLine());
Console.WriteLine("------------------------------------");

ship = new Ship(shipX, shipY);

ship.FillShip();

string webString = ship.WebStringMaker();
System.Diagnostics.Process.Start("C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe", webString);
Console.WriteLine(webString);
