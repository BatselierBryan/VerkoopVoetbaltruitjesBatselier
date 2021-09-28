using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    class Klant
    {
        //Constructor
        public int KlantenId { get; private set;}
        public string Naam { get; private set;}
        public string Adres { get; private set;}

        public Klant(int klantenId, string naam, string adres)
        {
            KlantenId = klantenId;
            Naam = naam;
            Adres = adres;
        }

        //Methodes
        public int Korting(List<Bestellingen> bestellingenKlant)
        {
            int percentage = 0;

            if (bestellingenKlant.Count() >= 5)
            {
                percentage = 10;
            }else if(bestellingenKlant.Count() >= 10)
            {
                percentage = 20;
            }

            return percentage;
        }

        public void VoegBestellingToe()
        {

        }
        
        public void VerwijderBestelling()
        {

        }

        public void GeefBestellingen()
        {

        }
    }
}
