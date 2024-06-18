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

        public void AddContainer(Container container, int stackIndex)
        {
            stacks[stackIndex].AddContainer(container);
        }

        public int GetStackHeigth(int stackIndex)
        {
            return stacks[stackIndex].GetStackHeight();
        }
    }
}
