using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    class Bestellingen
    {
        //Constructor
        public int Bestellingsnummer { get; private set;}
        public DateTime Datum { get; private set;}
        public bool isBetaald { get; private set;}
        public double VerkoopPrijs { get; private set;}
    }
}
