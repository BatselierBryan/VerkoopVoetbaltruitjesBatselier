using System;
using BusinessLayer.Exceptions;

namespace BusinessLayer.Model
{
    public class ClubSet
    {
        // Constructors
        public bool Thuis { get; private set;} // vs uit
        public int Versie { get; private set;}

        public ClubSet(bool thuis, int versie)
        {
            Thuis = thuis;
            if (versie < 1) throw new ClubSetException("ClubSet - versie less than one");
            Versie = versie;
        }

        public override bool Equals(object obj)
        {
            return obj is ClubSet clubset &&
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
