using System;
using System.Collections.Generic;
using System.Text;

namespace projekt_z_asd
{

    class Edge
    {
        public string target;
        public int data;
        public int czas;

        public Edge(string target, int data, int czas)
        {
            this.target = target;
            this.data = data;
            this.czas = czas;
        }

    }
}
