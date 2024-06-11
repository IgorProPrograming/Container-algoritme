using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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

        int length;
        int width;

        public Ship(int x, int y)
        {
            containerLayout = new List<Container>[x, y];
            length = y;
            width = x;
            FillShipList();
            InitializeShipGrid();
        }

        public void AddContainer(Container container, int x, int y)
        {
            containerLayout[x, y].Add(container);
        }

        public void InitializeShipGrid()
        {
            for (int i = 0; i < containerLayout.GetLength(0); i++)
            {
                for (int j = 0; j < containerLayout.GetLength(1); j++)
                {
                    containerLayout[i, j] = new List<Container>();
                }
            }

        }

        public void AddContainer(Container container)
        {
            containerList.Add(container);
        }

        public void FillShipList()
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

        public Container GetContainer(int id)
        {
            return containerList.Find(x => x.id == id);
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

        private bool CanPutContainerOnTop(int x, int y, Container container = null)
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

        public void FillShip()
        {
            while (containerList.Any())
            {

                // eerst gekoelde containers

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
                                if (CanPutContainerOnTop(x, y, container))
                                    containerLayout[x, y].Add(container);
                                containerList.Remove(container);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}


