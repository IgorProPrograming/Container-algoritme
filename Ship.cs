using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Container_algoritme
{
    public class Ship
    {
        public List<Row> rows { get; private set; }

        int length;
        int width;

        public Ship(int _width, int _length)
        {
            rows = new List<Row>();

            length = _length;
            width = _width;

            for (int i = 0; i < length; i++)
            {
                rows.Add(new Row(width));
            }
        }

        public string WebStringMaker()
        {
            StringBuilder webString = new StringBuilder("https://i872272.luna.fhict.nl/ContainerVisualizer/index.html?");

            webString.Append("length=").Append(length).Append("&");
            webString.Append("width=").Append(width).Append("&");

            webString.Append("stacks=");

            for (int x = 0; x < rows.Count; x++)
            {
                for (int y = 0; y < rows[x].stacks.Count; y++)
                {
                    if (rows[x].stacks[y].containers.Any())
                    {
                        foreach (var container in rows[x].stacks[y].containers)
                        {
                            if (container.isCooled && container.isValuable)
                            {
                                webString.Append("4");
                            }
                            else if (container.isCooled)
                            {
                                webString.Append("3");
                            }
                            else if (container.isValuable)
                            {
                                webString.Append("2");
                            }
                            else
                            {
                                webString.Append("1");
                            }
                            webString.Append("-");
                        }
                        webString.Length--;
                    }
                    webString.Append(",");
                }
                webString.Length--;
                webString.Append("/");
            }
            webString.Length--;

            webString.Append("&weights=");
            for (int x = 0; x < rows.Count; x++)
            {
                for (int y = 0; y < rows[x].stacks.Count; y++)
                {
                    if (rows[x].stacks[y].containers.Any())
                    {
                        foreach (var container in rows[x].stacks[y].containers)
                        {
                            webString.Append(container.weight).Append("-");
                        }
                        webString.Length--;
                    }
                    webString.Append(",");
                }
                webString.Length--;
                webString.Append("/");
            }
            webString.Length--;

            return webString.ToString();
        }

        /*
        public bool IsMarginCorrect()
        {
            //check of de marge van 20% niet overschreden wordt
            float leftWeight = 0;
            float rightWeight = 0;
            int middleRowWeight = 0;
            float halfOfMiddleRowWeight = 0;

            int leftSide;
            int rightSide;

            if (!(width % 2 == 0))
            {

                int middleRow = (int)Math.Floor(width / 2.0 + 0.5);
                leftSide = middleRow - 1;
                rightSide = middleRow + 1;

                for (int x = 0; x < width; x++)
                {
                    foreach (var container in containerLayout[x, middleRow])
                    {
                        middleRowWeight += container.weight;
                    }
                }

                halfOfMiddleRowWeight = middleRowWeight / 2;
            }
            else
            {
                leftSide = width / 2;
                rightSide = width - 1;
            }

            for (int x = 0; x <= leftSide; x++)
            {
                for (int y = 0; y <= length - 1; y++)
                {
                    foreach (var container in containerLayout[x, y])
                    {
                        leftWeight += container.weight;
                    }
                }

            }

            for (int x = rightSide; x <= width - 1; x++)
            {
                for (int y = 0; y <= length - 1; y++)
                {
                    foreach (var container in containerLayout[x, y])
                    {
                        rightWeight += container.weight;
                    }
                }
            }

            leftWeight += halfOfMiddleRowWeight;
            rightWeight += halfOfMiddleRowWeight;

            if (Math.Abs(leftWeight - rightWeight) > (leftWeight + rightWeight) * 0.2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        */

        private bool ContainerIsAccesible(int rowIndex, int stackIndex, Stack stack)
        {
            int stackHeight = stack.containers.Count;

            int otherStackHeight = 0;

            for (int otherRowIndex = -1; otherRowIndex <= 1; otherRowIndex += 2)
            {
                if (rows[otherRowIndex].stacks.Any())
                {
                    if (rows[otherRowIndex].stacks[stackIndex].containers.Any())
                    {
                        otherStackHeight = rows[otherRowIndex].stacks[stackIndex].containers.Count;
                        if (stackHeight >= otherStackHeight)
                        {
                            return true;
                        }
                    }else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
        
        public void AddContainers(List<Container> containers)
        {
            //eerst coole containers

            int frontRow = 0;

            foreach (var container in containers.Where(x => x.isCooled)) 
            {
                rows[frontRow].AddContainer(container);
            }

            //normale

            foreach(var container in containers.Where(x => !x.isValuable))
            {
                foreach (var row in rows)
                {
                    if (row.CanAddContainer(container))
                    {
                        row.AddContainer(container);
                        break;
                    }
                }
            }

            //waardevolle

            foreach (var container in containers.Where(x => x.isValuable))
            {
                int rowIndex = 0;
                foreach (var row in rows)
                {
                    if (row.CanAddContainer(container))
                    {
                        int stackIndex = 0;
                        foreach (var stack in rows[rowIndex].stacks)
                        {
                            if (ContainerIsAccesible(rowIndex, stackIndex, stack))
                            {
                                row.AddContainer(container, stackIndex);
                            }
                            stackIndex++;
                        }
                    }
                    rowIndex++;
                }
            }
        }
    }
}


