using System;
using System.Collections.Generic;
using System.Text;

namespace projekt_z_asd
{
    public class connectionData
    {
        public int begid_station;
        public int endid_station;
        public string date;
        public double velocity;
        public int distance;
        public connectionData(int begid_station, int endid_station, string date, int distance, double velocity)
        {
            this.begid_station = begid_station;
            this.endid_station = endid_station;
            this.date = date;
            this.velocity = velocity;
            this.distance = distance;
        }
    }
}
