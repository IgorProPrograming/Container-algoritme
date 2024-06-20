using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            if (Containers.Count == 0)
            {
                return true;
            }
           
            if (TopContainerIsValuable(container))
            {
                return false;
            }

            return WeightCheckResult(container);
        }

        private bool TopContainerIsValuable(Container container)
        {
            int topContainerIndex = Containers.Count - 1;
            if (Containers[topContainerIndex].isValuable)
            {
                return true;
            } else
            {
                return false;
            }
        }

        private bool WeightCheckResult(Container container)
        {
            int stackWeight = 0;
            foreach (Container c in Containers)
            {
                stackWeight += c.weight;
            }

            if (stackWeight + container.weight <= 120)
            {
                return true;
            } else
            {
                return false;
            }
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
