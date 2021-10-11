using BusinessLayer.Model;

namespace BusinessLayer.Interface
{
    public interface ITrui
    {
        Club Club { get; }
        ClubSet ClubSet { get; }
        int Id { get; }
        Maat Kledingmaat { get; set; }
        double Prijs { get; }
        string Seizoen { get; }

        void ZetClub(Club club);
        void ZetClubSet(ClubSet clubSet);
        void ZetId(int id);
        void ZetPrijs(double prijs);
        void ZetSeizoen(string seizoen);
    }
}
