using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    class Clubset
    {
        // Constructors
        public string ThuisUit { get; private set;}
        public int Versie { get; private set;}

        public Clubset(string thuisUit, int versie)
        {
            ThuisUit = thuisUit;
            Versie = versie;
        }
    }
}
