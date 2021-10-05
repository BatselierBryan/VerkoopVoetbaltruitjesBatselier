using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Model.Exceptions;

namespace BusinessLayer.Model
{
    public class Clubset
    {
        // Constructors
        public bool Thuis { get; private set;} // vs uit
        public int Versie { get; private set;}

        public Clubset(bool thuis, int versie)
        {
            Thuis = thuis;
            if (versie < 1) throw new ClubsetException("Clubset - versie less than one");
            Versie = versie;
        }

        public override bool Equals(object obj)
        {
            return obj is Clubset clubset &&
                   Thuis == clubset.Thuis &&
                   Versie == clubset.Versie;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Thuis, Versie);
        }

        // zoeken (Alles geven van variabelen)
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
