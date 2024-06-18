using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container_algoritme
{
    public class Stack
    {
        public List<Container> Containers;
        //public IReadOnlyList<Container> containers => Containers;

        public Stack()
        {
            Containers = new List<Container>();
        }

        public bool CanAddContainer(Container container)
        {
            // if stack empty
            if (Containers.Count == 0)
            {
                return true;
            }
            int topContainerIndex = Containers.Count - 1;
            if (Containers[topContainerIndex].isValuable == true)
            {
                return false;
            }
            // check of max gewicht niet wordt overschreden
            int stackWeight = 0;
            foreach (Container c in Containers)
            {
                stackWeight += c.weight;
            }

            

            if (stackWeight + container.weight <= 120)
            {
                return true;
            }

            //check of bovenste container niet valuable is

            
            
            return false;
        }

        public void AddContainer(Container container)
        {
            Containers.Add(container);
        }

        public int GetStackHeight()
        {
            return Containers.Count;
        }
    }
}
