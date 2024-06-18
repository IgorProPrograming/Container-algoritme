using Container_algoritme;

Ship ship;

List<Container> containerList = new List<Container>();

containerList.AddRange(new List<Container> {
            new Container { id = 1, isValuable = false, isCooled = false, weight = 30 },
            new Container { id = 2, isValuable = false, isCooled = false, weight = 25 },
            new Container { id = 3, isValuable = false, isCooled = false, weight = 10 },
            new Container { id = 4, isValuable = false, isCooled = false, weight = 5 },
            new Container { id = 5, isValuable = false, isCooled = false, weight = 10 },
            new Container { id = 6, isValuable = false, isCooled = true, weight = 15 },
            new Container { id = 7, isValuable = false, isCooled = true, weight = 20 },
            new Container { id = 8, isValuable = false, isCooled = true, weight = 25 },
            new Container { id = 9, isValuable = false, isCooled = true, weight = 30 },
            new Container { id = 10, isValuable = true, isCooled = false, weight = 10 },
            new Container { id = 11, isValuable = true, isCooled = false, weight = 15 },
            new Container { id = 12, isValuable = true, isCooled = false, weight = 20 },
            new Container { id = 1, isValuable = false, isCooled = false, weight = 30 },
            new Container { id = 2, isValuable = false, isCooled = false, weight = 25 },
            new Container { id = 3, isValuable = false, isCooled = false, weight = 10 },
            new Container { id = 4, isValuable = false, isCooled = false, weight = 5 },
            new Container { id = 5, isValuable = false, isCooled = false, weight = 10 },
            new Container { id = 6, isValuable = false, isCooled = true, weight = 15 },
            new Container { id = 7, isValuable = false, isCooled = true, weight = 20 },
            new Container { id = 8, isValuable = false, isCooled = true, weight = 25 },
            new Container { id = 9, isValuable = false, isCooled = true, weight = 30 },
            new Container { id = 10, isValuable = true, isCooled = false, weight = 10 },
            new Container { id = 11, isValuable = true, isCooled = false, weight = 15 },
            new Container { id = 12, isValuable = true, isCooled = false, weight = 20 },
            new Container { id = 1, isValuable = false, isCooled = false, weight = 30 },
            new Container { id = 2, isValuable = false, isCooled = false, weight = 25 },
            new Container { id = 3, isValuable = false, isCooled = false, weight = 10 },
            new Container { id = 4, isValuable = false, isCooled = false, weight = 5 },
            new Container { id = 5, isValuable = false, isCooled = false, weight = 10 },
            new Container { id = 6, isValuable = false, isCooled = true, weight = 15 },
            new Container { id = 7, isValuable = false, isCooled = true, weight = 20 },
            new Container { id = 8, isValuable = false, isCooled = true, weight = 25 },
            new Container { id = 9, isValuable = false, isCooled = true, weight = 30 },
            new Container { id = 10, isValuable = true, isCooled = false, weight = 10 },
            new Container { id = 11, isValuable = true, isCooled = false, weight = 15 },
            new Container { id = 12, isValuable = true, isCooled = false, weight = 20 }
            });

Console.WriteLine("------------------------------------");
Console.WriteLine("ship x:");
int shipX = int.Parse(Console.ReadLine());
Console.WriteLine("ship y:");
int shipY = int.Parse(Console.ReadLine());
Console.WriteLine("------------------------------------");

ship = new Ship(shipX, shipY);

ship.AddContainers(containerList);

string webString = ship.GetWebString();
System.Diagnostics.Process.Start("C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe", webString);
Console.WriteLine(webString);
