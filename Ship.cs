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
        /*
        public string WebStringMaker()
        {
            string webString = "https://i872272.luna.fhict.nl/ContainerVisualizer/index.html?";
            webString += "length=" + length + "&";
            webString += "width=" + width + "&";
            webString += "stacks=";
            //type containers
            for (int x = 0; x < length; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    if (rows[x].stacks[y].containers.Any())
                    {
                        foreach (var container in rows[x].stacks[y].containers)
                        {
                            if (container.isCooled & container.isValuable)
                            {
                                webString += "4";
                            }
                            else
                            {
                                if (container.isCooled)
                                {
                                    webString += "3";
                                }
                                else
                                {
                                    if (container.isValuable)
                                    {
                                        webString += "2";
                                    }
                                    else
                                    {
                                        webString += "1";
                                    }
                                }
                            }
                            webString += "-";
                        }
                        webString = webString.Remove(webString.Length - 1);
                    }
                    webString += ",";
                }
                webString = webString.Remove(webString.Length - 1);
                webString += "/";
            }
            webString = webString.Remove(webString.Length - 1);
            //gewichten containers
            webString += "&weights=";
            for (int x = 0; x < length; x++)
            {
                for (int y = 0; y < width; y++)
                {

                    if (rows[x].stacks[y].containers.Any())
                    {
                        foreach (var container in rows[x].stacks[y].containers)
                        {
                            webString += container.weight.ToString();
                            webString += "-";
                        }
                        webString = webString.Remove(webString.Length - 1);
                    }
                    webString += ",";
                }
                webString = webString.Remove(webString.Length - 1);
                webString += "/";
            }
            webString = webString.Remove(webString.Length - 1);
            return webString;
        }
        */
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
                    if (rows[x].stacks[y].Containers.Any())
                    {
                        foreach (var container in rows[x].stacks[y].Containers)
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
                    if (rows[x].stacks[y].Containers.Any())
                    {
                        foreach (var container in rows[x].stacks[y].Containers)
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

        private bool TryAddValuableContainer(Row row, Container container)
        {
            int rowIndex = rows.IndexOf(row);
            int stackIndex = 0;

            foreach (var stack in rows[rowIndex].stacks)
            {
                int stackHeight = rows[rowIndex].GetStackHeigth(stackIndex);

                Row rowBeforeCurrentRow = GetPreviousRow(rowIndex);
                if (rowBeforeCurrentRow == null)
                {
                    rows[rowIndex].AddContainer(container, stackIndex);
                    return true;
                }
                
                int stackHeightBefore = rowBeforeCurrentRow.GetStackHeigth(stackIndex);
                if (stackHeight >= stackHeightBefore)
                {
                    rows[rowIndex].AddContainer(container, stackIndex);
                    return true;
                }

                Row rowAfterCurrentRow = GetNextRow(rowIndex);
                if (rowAfterCurrentRow == null)
                {
                    rows[rowIndex].AddContainer(container, stackIndex);
                    return true;
                }

                int stackHeightAfter = rowAfterCurrentRow.GetStackHeigth(stackIndex);
                if (stackHeight >= stackHeightAfter)
                {
                    rows[rowIndex].AddContainer(container, stackIndex);
                    return true;
                }
                stackIndex++;
            }
            return false;
        }

        private Row GetPreviousRow(int currentRowIndex)
        {
            if (currentRowIndex > 0)
            {
                return rows[currentRowIndex - 1];
            }
            else
            {
                return null;
            }
        }

        private Row GetNextRow(int currentRowIndex)
        {
            if (currentRowIndex < rows.Count - 1)
            {
                return rows[currentRowIndex + 1];
            }
            else
            {
                return null;
            }
        }

        public void AddContainers(List<Container> containers)
        {
            //eerst coole containers

            int frontRow = 0;

            foreach (var container in containers.Where(x => x.isCooled)) 
            {
                rows[frontRow].TryAddContainer(container);
            }

            //normale
            /*
            foreach(var container in containers.Where(x => !x.isValuable))
            {
                foreach (var row in rows)
                {
                    if(row.TryAddContainer(container))
                    {
                        break;
                    }
                }
            }

            //waardevolle
            /*
            foreach (var container in containers.Where(x => x.isValuable))
            {
               
                foreach (var row in rows)
                {
                    if(TryAddValuableContainer(row, container))
                    {
                        break;
                    }
                }
                
            }*/
        }
    }
}


