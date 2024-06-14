using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container_algoritme
{
    public class Row
    {
        public List<Stack> stacks { get; private set; }

        public Row(int width)
        {
            stacks = new List<Stack>();
            for (int i = 0; i < width; i++)
            {
                stacks.Add(new Stack());
            }
        }

        public bool CanAddContainer(Container container)
        {
            foreach (Stack stack in stacks)
            {
                if (stack.CanAddContainer(container))
                {
                    return true;
                }
            }
            return false;
        }



        public void AddContainer(Container container)
        {
            foreach (Stack stack in stacks)
            {
                if (stack.CanAddContainer(container))
                {
                    stack.AddContainer(container);
                    break;
                }
            }
        }

        public void AddContainer(Container container, int stackIndex)
        {
            stacks[stackIndex].AddContainer(container);
        }
    }
}
