using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bevasarlolistat
{
    internal class Bevasarlolista
    {
        public string termekneve { get; set; }
        private string _termekneve => termekneve;
        public double egysegar { get; set; }
        private double _egysegar => egysegar;
        public int mennyiseg { get; set; }
        private int _mennyiseg => mennyiseg;

        public Bevasarlolista(string line) {

            string[] data = line.Split(';');
            termekneve = data[0];
            egysegar = Convert.ToDouble(data[1]);
            mennyiseg = Convert.ToInt32(data[2]);

        }
    }
}
