using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container_algoritme
{
    internal class WebStringFactory
    {
        public string CreateString(int length, int width, List<Row> rows)
        {
            string webString = "https://i872272.luna.fhict.nl/ContainerVisualizer/index.html?";
            webString += "length=" + length + "&";
            webString += "width=" + width + "&";
            webString += "stacks=";
            //type containers
            for (int y = 0; y < width; y++)
            {
                for (int x = 0; x < length; x++)
                {
                    if (rows[x].stacks[y].Containers.Any())
                    {
                        foreach (var container in rows[x].stacks[y].Containers)
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
            for (int y = 0; y < width; y++)
            {
                for (int x = 0; x < length; x++)
                {

                    if (rows[x].stacks[y].Containers.Any())
                    {
                        foreach (var container in rows[x].stacks[y].Containers)
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
    }
}
