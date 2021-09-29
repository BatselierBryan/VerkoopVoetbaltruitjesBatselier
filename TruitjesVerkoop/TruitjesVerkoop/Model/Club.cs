using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class Club
    {
        // Constructors
        public string Competitie { get; private set;}
        public string Ploegnaam { get; private set;}

        public Club(string competitie, string ploegnaam)
        {
            Competitie = competitie;
            Ploegnaam = ploegnaam;
        }
    }
}
