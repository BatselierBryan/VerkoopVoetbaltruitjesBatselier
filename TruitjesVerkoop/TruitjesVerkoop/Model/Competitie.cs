using System;

namespace BusinessLayer.Model
{
    public class Competitie
    {
        public Competitie(string ploeg)
        {
            Ploeg = ploeg;
        }

        public string Ploeg { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Competitie competitie &&
                   Ploeg == competitie.Ploeg;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Ploeg);
        }
    }
}