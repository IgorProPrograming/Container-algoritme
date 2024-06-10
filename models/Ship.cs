using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container_algoritme.models
{
    internal class Ship
    {
        List<Container> containerList = new List<Container>();
        List<Container> shipSlot = new List<Container>();
        List<Container>[,] containerLayout;

        public Ship(int x, int y)
        {
            containerLayout = new List<Container>[x, y];
        }

        public void AddContainer(Container container, int x, int y)
        {
            containerLayout[x, y].Add(container);
        }

        public void AddContainer(Container container)
        {
            containerList.Add(container);
        }

        public void FillShip()
        {
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
            new Container { id = 12, isValuable = true, isCooled = false, weight = 20 }
            });
        }

        public void fillShip()
        {
            //start with cooled containers
            
        }
    }
}
