using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Model;
using BusinessLayer.Model.Exceptions;

namespace BusinessLayer.Model
{
    public class Bestelling
    {
        //Constructor
        public int Bestellingsnummer { get; private set;}
        public DateTime Datum { get; private set;}
        public bool IsBetaald { get; private set;}
        public decimal VerkoopPrijs { get; private set;}
        public Klant Klant { get; private set; }

        private Dictionary<Truitje, int> _producten = new Dictionary<Truitje, int>();

        //id en tijdstip / id, klant en tijdstip / id, klant, tijdstip, dictionary producten // id, klant, tijdstip, prijs, betaald, dictionary producten -> allemaal internal constructors
        public Bestelling(int bestellingsnummer, DateTime datum, bool isBetaald, decimal verkoopPrijs, Klant klant)
        {
            Bestellingsnummer = bestellingsnummer;
            Datum = datum;
            IsBetaald = isBetaald;
            VerkoopPrijs = verkoopPrijs;
            Klant = klant;
        }

        //Methodes
        //zetTijdstip, zetbetaald, zetid, kostprijs (korting van klant gebruiken)
        public void VoegTruitjeToe(Truitje truitje, int aantal)
        {
            if (aantal <= 0) throw new BestellingException("Voegtruitje toe - aantal");
            if (_producten.ContainsKey(truitje))
            {
                _producten[truitje] += aantal;
            } else
            {
                _producten.Add(truitje, aantal);
            }
        }

        public void VerwijderTruitje(Truitje truitje, int aantal)
        {
            //aantal == verwijderen uit lijst, aantal > exception, aantal < verminderen van lijst
        }

        public void ZetBetaald()
        {
            IsBetaald = true;
        }
    }
}
