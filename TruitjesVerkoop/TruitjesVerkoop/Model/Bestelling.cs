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
        public double VerkoopPrijs { get; private set;}
        public Klant Klant { get; private set; }

        private Dictionary<Truitje, int> _producten = new Dictionary<Truitje, int>();

        //id en tijdstip / id, klant en tijdstip / id, klant, tijdstip, dictionary producten // id, klant, tijdstip, prijs, betaald, dictionary producten -> allemaal internal constructors
        public Bestelling(int bestellingsnummer, DateTime datum, bool isBetaald, double verkoopPrijs, Klant klant)
        {
            Bestellingsnummer = bestellingsnummer;
            Datum = datum;
            IsBetaald = isBetaald;
            VerkoopPrijs = verkoopPrijs;
            Klant = klant;
        }

        //Methodes
        //zetTijdstip, zetbetaald, zetid, kostprijs (korting van klant gebruiken), zetklant (Klant = newKlant, verwijderklant (Klant = null), zetbestellingid, zettijdstip, 
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

        public void ZetBetaald(bool betaald = true)
        {
            IsBetaald = betaald;
            if (betaald)
            {
               // VerkoopPrijs = kostPrijs();
            } else
            {
                VerkoopPrijs = 0.0;
            }
        }

        public void ZetTijdstip(DateTime tijdstip)
        {
            if (tijdstip == null) throw new BestellingException("Bestelling - invalid tijdstip");
            Datum = tijdstip;
        }

        public void VerwijderKlant()
        {
            Klant = null;
        }
        public void ZetKlant(Klant newKlant)
        {
            if (newKlant == null) throw new BestellingException("Bestelling - invalid klant");
            if (newKlant == Klant) throw new BestellingException("Bestelling - ZetKlant - now new");
            if (Klant != null)
            {
                if (Klant.HeeftBestelling(this))
                {
                    Klant.VerwijderBestelling(this);
                }
            }
            if (!newKlant.HeeftBestelling(this))
            {
                newKlant.VoegBestellingToe(this);
            }
            Klant = newKlant;
        }

        public override bool Equals(object obj)
        {
            return obj is Bestelling bestelling &&
                   Bestellingsnummer == bestelling.Bestellingsnummer &&
                   Datum == bestelling.Datum &&
                   IsBetaald == bestelling.IsBetaald &&
                   VerkoopPrijs == bestelling.VerkoopPrijs &&
                   EqualityComparer<Klant>.Default.Equals(Klant, bestelling.Klant) &&
                   EqualityComparer<Dictionary<Truitje, int>>.Default.Equals(_producten, bestelling._producten);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Bestellingsnummer, Datum, IsBetaald, VerkoopPrijs, Klant, _producten);
        }
    }
}
