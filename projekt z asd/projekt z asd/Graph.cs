using System;
using System.Collections.Generic;
using System.Linq;

namespace projekt_z_asd
{

    class Graf
    {
        
        Dictionary<string, List<Edge>> wezly = new Dictionary<string, List<Edge>>();

        public Dictionary<string, int> distancearray;
        public List<string> path = null;

        public void add(string id1, Edge edge)
        {
            if (wezly.ContainsKey(id1))
            {
                List<Edge> edges = wezly[id1];
                edges.Add(edge);
            }

            else
            {
                wezly[id1] = new List<Edge>() { edge };
            }

            if (!wezly.ContainsKey(edge.target))
            {
                wezly[edge.target] = new List<Edge>();
            }
        }

        public void remove(string id1, string id2, long dt)
        {
            List<Edge> edges = wezly[id1];
                for (int i = 0; i < edges.Count(); i++)
                {

                if (edges[i].target.Equals(id2) && edges[i].data == dt)
                {
                    edges.RemoveAt(i);
                    break;
                }
                else break; 
            }
           
        }


        public bool search(string id1, string id2, long dt)
        {
            List<Edge> edges = wezly[id1];
            for (int i = 0; i < edges.Count(); i++)
            {
                if (edges[i].target.Equals(id2) && edges[i].data == dt)
                {
                    return true;

                }

            }
            return false;
        }

        public List<int> Daty(string name)
        {
            List<int> daty = new List<int>();
            List<Edge> pol = wezly[name];
            foreach (Edge edge in pol)
            {
                daty.Add(edge.data);
            }
            return daty;
        }

        
        public int searchBetween(long dt1, long dt2)
        {
            int n = 0;
            foreach (KeyValuePair<string, List<Edge>> kv in wezly)
            {
                List<Edge> pol = kv.Value;
                foreach (Edge edge in pol)
                {
                    if (edge.data >= dt1 && edge.data <= dt2) n++;
                }
            }
            return n;
        }

        public bool print()
        {
            foreach (KeyValuePair<string, List<Edge>> kv in wezly)
            {
                Console.Write(kv.Key + ": ");
                List<Edge> pol = kv.Value;
                foreach (Edge edge in pol)
                {
                    Console.Write(edge.target + " [" + edge.data + "] ");
                }
                Console.WriteLine();

            }
            return false;
        }


       
        public void ShortestPath(string start, string finish, int minDateTime)
        {

            var previous = new Dictionary<string, string>();
            distancearray = new Dictionary<string, int>();
            path = null;
            var visited = new List<string>();

            foreach (var vertex in wezly)
            {
                if (vertex.Key == start)
                {
                    distancearray[vertex.Key] = 0; 
                }
                else
                {
                    distancearray[vertex.Key] = int.MaxValue; 
                }

                visited.Add(vertex.Key);
            }

            while (visited.Count != 0)
            {

                visited.Sort((x, y) => distancearray[x].CompareTo(distancearray[y]));

                var smallest = visited[0];
                visited.Remove(smallest); 

                if (smallest == finish) 
                {

                    path = new List<string>();
                    while (previous.ContainsKey(smallest))
                    {
                        path.Add(smallest);
                        smallest = previous[smallest];
                    }

                    break;
                }

                if (distancearray[smallest] == int.MaxValue) 
                {
                    break;
                }

                for (int i = 0; i < wezly[smallest].Count; i++)
                {
                    var neighbor = wezly[smallest][i];

                    if (minDateTime > 0)
                    {
                        if (neighbor.data > minDateTime) continue;
                    }        

                    var new_velocity = distancearray[smallest] + neighbor.czas;

                    if (new_velocity < distancearray[neighbor.target])
                    {
                        distancearray[neighbor.target] = new_velocity;
                        previous[neighbor.target] = smallest;
                    }
                }

            }

            if (path != null) path.Reverse();
        }
    }
}


