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
        public List<Stack> stacks;
       // public IReadOnlyList<Stack> stacks => Stacks;

        public Row(int width)
        {
            stacks = new List<Stack>();
            for (int i = 0; i < width; i++)
            {
                stacks.Add(new Stack());
            }
        }

        public bool TryAddContainer(Container container)
        {
            foreach (Stack stack in stacks)
            {
                if (stack.CanAddContainer(container))
                {
                    stack.AddContainer(container);
                    return true;
                }
            }
            return false;
        }

        public bool TryAddContainer(Container container, int stackIndex)
        {
            if (stacks[stackIndex].CanAddContainer(container))
            {
                stacks[stackIndex].AddContainer(container);
                return true;
            }
            return false;
        }

        public int GetStackHeight(int stackIndex)
        {
            return stacks[stackIndex].GetStackHeight();
        }
    }
}
