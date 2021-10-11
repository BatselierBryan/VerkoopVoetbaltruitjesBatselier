using System.Collections.Generic;

namespace BusinessLayer.Interface
{
    public interface IKlant
    {
        string Adres { get; }
        int KlantenNummer { get; }
        string Naam { get; }

        bool Equals(object obj);
        int GeefKorting();
        int GetHashCode();
        bool HeeftBestelling(Bestelling bestelling);
        IReadOnlyList<Bestelling> ToonBestelling();
        string ToString();
        void VerwijderBestelling(Bestelling bestelling);
        void VoegBestellingToe(Bestelling bestelling);
        void ZetAdres(string adres);
        void ZetKlantId(int id);
        void ZetNaam(string naam);
    }
}