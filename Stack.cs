using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container_algoritme
{
    public class Stack
    {
        public List<Container> containers { get; private set; }

        public Stack()
        {
            containers = new List<Container>();
        }

        public bool CanAddContainer(Container container)
        {
            // if stack empty
            if (containers.Count == 0)
            {
                return true;
            }
            
            // check of max gewicht niet wordt overschreden
            int stackWeight = 0;
            foreach (Container c in containers)
            {
                stackWeight += c.weight;
            }

            if (stackWeight + container.weight <= 120)
            {
                return true;
            }

            //check of bovenste container niet valuable is

            int topContainerIndex = containers.Count - 1;
            if (!containers[topContainerIndex].isValuable == true)
            {
                return true;
            }
            
            return false;
        }


        public void AddContainer(Container container)
        {
            containers.Add(container);
        }

    }
}
