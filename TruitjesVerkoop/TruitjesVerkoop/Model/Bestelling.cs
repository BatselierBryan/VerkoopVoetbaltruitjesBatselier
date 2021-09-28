using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    class Bestelling
    {
        //Constructor
        public int Bestellingsnummer { get; private set;}
        public DateTime Datum { get; private set;}
        public bool IsBetaald { get; private set;}
        public decimal VerkoopPrijs { get; private set;}

        public Bestelling(int bestellingsnummer, DateTime datum, bool isBetaald, decimal verkoopPrijs)
        {
            Bestellingsnummer = bestellingsnummer;
            Datum = datum;
            IsBetaald = isBetaald;
            VerkoopPrijs = verkoopPrijs;
        }

        //Methodes
        public void VoegTruitjeToe()
        {

        }

        public void VerwijderTruitje()
        {

        }

        public void ZetBetaald()
        {

        }
    }
}
