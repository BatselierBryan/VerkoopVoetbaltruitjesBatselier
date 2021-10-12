using BusinessLayer.Exceptions;
using BusinessLayer.Interface;
using BusinessLayer.Model;

namespace BusinessLayer.Model
{
    public class Trui: ITrui
    {
        public Trui(Club club, string seizoen, double prijs, Maat kledingmaat, ClubSet clubset)
        {
            ZetClub(club);
            ZetPrijs(prijs);
            Seizoen = seizoen;
            Kledingmaat = kledingmaat;
            ZetClubSet(clubset);
        }
        public Trui(int id, Club club, string seizoen, double prijs, Maat kledingmaat, ClubSet clubset)
        {
            ZetId(id);
            ZetClub(club);
            ZetPrijs(prijs);
            Seizoen = seizoen;
            Kledingmaat = kledingmaat;
            ZetClubSet(clubset);
        }
        
        public int Id { get; private set; }

        public Club Club { get; private set; }

        public string Seizoen { get; private set; }

        public double Prijs { get; private set; }

        public Maat Kledingmaat { get; set; }

        public ClubSet ClubSet { get; private set; }

        public void ZetId(int id)
        {
            if (id <= 0) throw new TruiException("Trui - invalid id");
            this.Id = id;
        }

        public void ZetPrijs(double prijs)
        {
            if (prijs <= 0) throw new TruiException("Trui - invalid prijs");
            this.Prijs = prijs;
        }

        public void ZetSeizoen(string seizoen)
        {
            if (seizoen == null) throw new TruiException("Seizoen klopt niet");
            this.Seizoen = seizoen;
        }

        public void ZetClub(Club club)
        {
            if (club == null) throw new TruiException("ZetClub = null");
            this.Club = club;
        }

        public void ZetClubSet(ClubSet clubset)
        {
            if (clubset == null) throw new TruiException("ZetClub = null");
            this.ClubSet = clubset;
        }
    }
}
