using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Container_algoritme.models
{
    internal class Ship
    {
        private List<Container> containerList = new List<Container>();
        private List<Container>[,] containerLayout;

        private int length;
        private int width;

        public Ship(int x, int y)
        {
            containerLayout = new List<Container>[x, y];
            length = y;
            width = x;
            FillShipList();
            InitializeShipGrid();
        }

        private void InitializeShipGrid()
        {
            for (int i = 0; i < containerLayout.GetLength(0); i++)
            {
                for (int j = 0; j < containerLayout.GetLength(1); j++)
                {
                    containerLayout[i, j] = new List<Container>();
                }
            }

        }

        private void FillShipList()
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

        public string WebStringMaker()
        {
            string webString = "https://i872272.luna.fhict.nl/ContainerVisualizer/index.html?";

            webString += "length=" + length + "&";
            webString += "width=" + width + "&";

            webString += "stacks=";

            //type containers
            for (int x = 0; x < containerLayout.GetLength(0); x++)
            {
                for (int y = 0; y < containerLayout.GetLength(1); y++)
                {
                    if (containerLayout[x, y].Any())
                    {
                        foreach (var container in containerLayout[x, y])
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
            for (int x = 0; x < containerLayout.GetLength(0); x++)
            {
                for (int y = 0; y < containerLayout.GetLength(1); y++)
                {
                
                    if (containerLayout[x, y].Any())
                    {
                        foreach (var container in containerLayout[x, y])
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

        private bool IsContainerAccesible(int x, int y)
        {
            //check of voor of achter container ruimte is
            int z = containerLayout[x, y].Count;

            for (int i = -1; i <= 1; i++)
            {
                int newY = y + i;
                if (newY >= 0 && newY < containerLayout.GetLength(1) && containerLayout[x, newY].Count <= z)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CanPutContainerOnTop(int x, int y, Container container)
        {
            //check of er uberhaupt iets staat
            if (!containerLayout[x, y].Any())
            {
                return true;
            }

            //check of de bovenste waardevol is
            int containerCount = containerLayout[x, y].Count;
            if (containerLayout[x, y][containerCount - 1].isValuable)
            {
                return false;
            }

            //check of de onderste niet geplet wordt
            if (container != null)
            {
                int weightOnBottomContainer = 0;
                foreach (var c in containerLayout[x, y])
                {
                    weightOnBottomContainer += c.weight;
                }
                weightOnBottomContainer += container.weight;
                weightOnBottomContainer -= containerLayout[x, y][0].weight;
                if (weightOnBottomContainer > 120)
                {
                    return false;
                }
            }

            return true;
        }

      private bool isMarginCorrect()
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
                    foreach(var container in containerLayout[x,middleRow])
                    {
                        middleRowWeight += container.weight;
                    }
                }

                halfOfMiddleRowWeight = middleRowWeight / 2;
            } else
            {
                leftSide = width / 2;
                rightSide = width - 1;
            }

            for (int x = 0; x <= leftSide; x++)
            {
                for (int y = 0; y <= length - 1; y++) {
                    foreach (var container in containerLayout[x,y])
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

        public void FillShip()
        {
            while (containerList.Any())
            {
                // eerst gekoelde containers
                while (containerList.Any(container => container.isCooled))
                {
                    for (int x = 0; x < containerLayout.GetLength(0); x++)
                    {
                        foreach (var container in containerList)
                        {
                            if (CanPutContainerOnTop(x, 0, container))
                            {
                                if (container.isCooled)
                                {
                                    containerLayout[x, 0].Add(container);
                                    containerList.Remove(container);
                                    break;
                                }
                            }
                        }
                    }
                }

                // normale containers

                for (int y = 0; y < containerLayout.GetLength(1); y++)
                {
                    for (int x = 0; x < containerLayout.GetLength(0); x++)
                    {
                        foreach (var container in containerList)
                        {
                            if (CanPutContainerOnTop(x, y, container))
                                if (!container.isValuable)
                                {
                                    containerLayout[x, y].Add(container);
                                    containerList.Remove(container);
                                    break;
                                }
                        }
                    }
                }

                // waardevolle containers

                for (int y = 0; y < containerLayout.GetLength(1); y++)
                {
                    for (int x = 0; x < containerLayout.GetLength(0); x++)
                    {
                        foreach (var container in containerList)
                        {
                            if (container.isValuable)
                            {
                                if (CanPutContainerOnTop(x, y, container) & IsContainerAccesible(x,y))
                                    containerLayout[x, y].Add(container);
                                containerList.Remove(container);
                                break;
                            }
                        }
                    }
                }
            }

            if (!isMarginCorrect())
            {

            }
        }
    }
}


