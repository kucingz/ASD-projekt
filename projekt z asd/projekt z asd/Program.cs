using System;
using System.Collections.Generic;
using System.IO;

namespace projekt_z_asd
{
    public enum NodePosition
    {
        left,
        right,
        center
    }
    class Program
    {
        static void Main(string[] args)
        {

            BSTree t = new BSTree();
            Graf g = new Graf();
            StreamReader sr = new StreamReader("C:/Users/Qba/Desktop/projekt asd/projekt2_inX.txt");
            sr.ReadLine();
            while (sr.Peek() >= 0)
            {
                string str = sr.ReadLine();
                string[] arr;
                arr = str.Split(' ');
                if (arr[0] == "DP")
                {
                    int time = (60 * (Convert.ToInt32(arr[4]) / Convert.ToInt32(arr[5]))) + 5;
                    connectionData newobj = new connectionData(Convert.ToInt32(arr[2]), Convert.ToInt32(arr[3]), arr[1], Convert.ToInt32(arr[5]), Convert.ToDouble(arr[4]));
                    t.Insert(newobj);


                    int velocity = int.Parse(arr[4]);
                    int distance = int.Parse(arr[5]);
                    int inputtime = (60 * distance / velocity);
                    int date = int.MinValue;
                    date = BSTree.changeToDate(arr[1]);

                    g.add(arr[2], new Edge(arr[3], date, inputtime));
                    g.add(arr[3], new Edge(arr[2], date, inputtime));
                }

                else if (arr[0] == "UP")
                {
                    t.Remove(arr[1], Convert.ToInt32(arr[2]), Convert.ToInt32(arr[3]));

                  // g.remove(arr[2], arr[3], BSTree.changeToDate(arr[1]));
                   // g.remove(arr[3], arr[2], BSTree.changeToDate(arr[1]));
                }

                else if (arr[0] == "WP")
                {
                    t.Search(arr[1], arr[2], arr[3]);
                }

                else if (arr[0] == "LP")
                {
                    t.CountinRange(arr[1], arr[2]);
                }

                else if (arr[0] == "NP")
                {
                    g.ShortestPath(arr[1], arr[2], 0);

                    if (g.path == null) Console.WriteLine("NIE");

                    else
                    {
                        string output = "NP z " + arr[1] + ": ";
                        int time = g.distancearray[arr[2]];
                        time += g.path.Count * 5 - 5;
                        Console.WriteLine(time);
                    }

                }

                else if (arr[0] == "ND")
                {

                    int n = int.Parse(arr[3]);

                    List<int> dates = g.Daty(arr[1]);
                    dates.AddRange(g.Daty(arr[2]));
                    dates.Sort();

                    bool cfound = false;

                    foreach (int date in dates)
                    {
                        g.ShortestPath(arr[1], arr[2], date);

                        if (g.path != null)
                        {
                            int czas = g.distancearray[arr[2]];

                            czas += g.path.Count * 5 - 5;

                            if (czas <= n)
                            {

                                string[] sdate = new string[5];

                                sdate[0] = Convert.ToString(date / 10000);
                                sdate[1] = Convert.ToString("-");

                                if((date / 100) % 100 < 10 ) sdate[2] = "0" + Convert.ToString((date / 100) % 100);
                                else sdate[2] = Convert.ToString((date / 100) % 100);

                                sdate[3] = Convert.ToString("-");
                                if (date % 100 < 10) sdate[4] = "0" + Convert.ToString(date % 100);
                                else sdate[4] = Convert.ToString(date % 100);

                                for (int i = 0; i < 5; i++) Console.Write(sdate[i]);

                                Console.WriteLine();

                                cfound = true;
                                break;
                            }
                        }
                    }
                }
            }
            t.Print();
        }
    }

}
