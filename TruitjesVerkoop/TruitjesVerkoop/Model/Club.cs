using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Model.Exceptions;

namespace BusinessLayer.Model
{
    public class Club
    {
        // Constructors
        public string Competitie { get; private set;}
        public string Ploegnaam { get; private set;}

        internal Club(string competitie, string ploegnaam)
        {
            if (string.IsNullOrWhiteSpace(competitie) || string.IsNullOrWhiteSpace(ploegnaam))
            {
                throw new ClubException("Club - null or empty");               
            }
            Competitie = competitie;
            Ploegnaam = ploegnaam;
        }
    }
}
