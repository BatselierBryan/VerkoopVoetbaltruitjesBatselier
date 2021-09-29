using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class Klant
    {
        //Constructor
        public int KlantenId { get; private set;}
        public string Naam { get; private set;}
        public string Adres { get; private set;}

        public Dictionary<Klant, List<Bestelling>> Bestellingen = new Dictionary<Klant, List<Bestelling>>();

        public Klant(int klantenId, string naam, string adres)
        {
            KlantenId = klantenId;
            Naam = naam;
            Adres = adres;
        }

        //Methodes
        public int Korting(Klant klant)
        {
            int percentage = 0;
            List<Bestelling> bestellingenKlant = Bestellingen[klant];

            if (bestellingenKlant.Count() >= 5)
            {
                percentage = 10;
            }else if(bestellingenKlant.Count() >= 10)
            {
                percentage = 20;
            }

            return percentage;
        }

        public void VoegBestellingToe(Klant klant, Bestelling bestelling)
        {
            List<Bestelling> bestellingen = Bestellingen[klant];
            bestellingen.Add(bestelling);

            Bestellingen[klant] = bestellingen;
        }
        
        public void VerwijderBestelling(Klant klant, Bestelling bestelling)
        {
            List<Bestelling> bestellingen = Bestellingen[klant];
            bestellingen.Remove(bestelling);

            Bestellingen[klant] = bestellingen;
        }

        public List<Bestelling> GeefBestellingen(Klant klant)
        {
            List<Bestelling> bestellingen = Bestellingen[klant];

            return bestellingen;
        }
    }
}
