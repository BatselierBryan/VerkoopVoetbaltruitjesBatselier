using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Model.Exceptions;

namespace BusinessLayer.Model
{
    public class Truitje
    {
        // Constructors
        public Kledingmaat Kledingmaat { get; private set; }
        public double Prijs { get; private set; }
        public int Id { get; private set; }
        public string Seizoen { get; private set; }
        public Club Club { get; private set; }
        public Clubset Clubset { get; private set; }

        internal Truitje(int id, Kledingmaat kledingmaat, double prijs, string seizoen, Club club, Clubset clubset)
        {
            Id = id;
            Kledingmaat = kledingmaat;
            Prijs = prijs;
            Seizoen = seizoen;
            Club = club;
            Clubset = clubset;
        }
        internal Truitje(Kledingmaat kledingmaat, double prijs, string seizoen, Club club, Clubset clubset)
        {
            Kledingmaat = kledingmaat;
            Prijs = prijs;
            Seizoen = seizoen;
            Club = club;
            Clubset = clubset;
        }

        public void ZetId(int id)
        {
            if (id <= 0) throw new VoetbaltruitjesException("Voetbaltruitje - invalid id");
            Id = id;
        }
        public void ZetPrijs(double prijs)
        {
            if (prijs <= 0) throw new VoetbaltruitjesException("Voetbaltruitje - invalid prijs");
            Prijs = prijs;
        }
        public void ZetClub(Club club)
        {
            if (club == null) throw new VoetbaltruitjesException("Club == null");
            Club = club;
        }
        public void ZetClubset(Clubset clubset)
        {
            if (clubset == null) throw new VoetbaltruitjesException("Clubset == null");
            Clubset = clubset;
        }
        // Hoeft niet
        //public void ZetSeizoen(string seizoen)
        //{

        //}


        //Alles geven van variabelen
        public override string ToString()
        {
            return ($"{Id}, {Kledingmaat}, {Seizoen}, {Club}, {Clubset}, {Prijs}");
        }

        public override bool Equals(object obj)
        {
            return obj is Truitje truitje &&
                   Kledingmaat == truitje.Kledingmaat &&
                   Prijs == truitje.Prijs &&
                   Id == truitje.Id &&
                   Seizoen == truitje.Seizoen &&
                   EqualityComparer<Club>.Default.Equals(Club, truitje.Club) &&
                   EqualityComparer<Clubset>.Default.Equals(Clubset, truitje.Clubset);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Kledingmaat, Prijs, Id, Seizoen, Club, Clubset);
        }
    }
}
