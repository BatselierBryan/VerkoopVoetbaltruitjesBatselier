using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    class Truitje
    {
        // Constructors
        public Kledingmaat Kledingmaat { get; private set;}
        public decimal Prijs { get; private set;}
        public int Id { get; private set;}
        public string Seizoen { get; private set;}
    }
}
