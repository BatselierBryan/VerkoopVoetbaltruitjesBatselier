using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class Bestelling
    {
        //Constructor
        public int Bestellingsnummer { get; private set;}
        public DateTime Datum { get; private set;}
        public bool IsBetaald { get; private set;}
        public decimal VerkoopPrijs { get; private set;}

        public Dictionary<Bestelling, List<Truitje> > Truitjes = new Dictionary<Bestelling, List<Truitje>>();

        public Bestelling(int bestellingsnummer, DateTime datum, bool isBetaald, decimal verkoopPrijs)
        {
            Bestellingsnummer = bestellingsnummer;
            Datum = datum;
            IsBetaald = isBetaald;
            VerkoopPrijs = verkoopPrijs;
        }

        //Methodes
        public void VoegTruitjeToe(Bestelling bestelling, Truitje toeTeVoegenTruitje)
        {
            List<Truitje> listTruitjes = Truitjes[bestelling];
            listTruitjes.Add(toeTeVoegenTruitje);

            Truitjes[bestelling] = listTruitjes;
        }

        public void VerwijderTruitje(Bestelling bestelling, Truitje teVerwijderenTruitje)
        {
            List<Truitje> listTruitjes = Truitjes[bestelling];
            listTruitjes.Remove(teVerwijderenTruitje);

            Truitjes[bestelling] = listTruitjes;
        }

        public void ZetBetaald()
        {
            IsBetaald = true;
        }
    }
}
