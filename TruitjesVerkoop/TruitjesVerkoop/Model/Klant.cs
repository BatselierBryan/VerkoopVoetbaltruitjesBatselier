using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Model.Exceptions;

namespace BusinessLayer.Model
{
    public class Klant
    {
        //Constructor
        public int KlantId { get; private set;}
        public string Naam { get; private set;}
        public string Adres { get; private set;}

        private List<Bestelling> _bestellingen = new List<Bestelling>();

        public Klant(int klantId, string naam, string adres)
        {
            KlantId = klantId;
            Naam = naam;
            Adres = adres;
        }

        //Methodes -> overerven van interface
        //zetklantid
        //zetnaam
        //zetadres
        //heeftbestelling
        //tostring
        //totext kan als debug
        //show
        //altijd exceptions gebruiken
        public IReadOnlyList<Bestelling> GetBestellingen()
        {
            return _bestellingen.AsReadOnly();
        }
        public int Korting()
        {
            if(_bestellingen.Count < 5) return 0;
            if(_bestellingen.Count > 10) return 10;
            else return 20;
        }

        public void VoegBestellingToe(Bestelling bestelling) //Check of bestelling niet null is, check of bestelling niet in list zit, anders toevoegen
        {
            if (bestelling == null) throw new KlantException("Klant : Verwijderbestelling - bestelling is null");
            if (_bestellingen.Contains(bestelling))
            {
                throw new KlantException("Klant : AddBestelling - bestelling already exists");
            } else
            {
                _bestellingen.Add(bestelling);
                if (bestelling.Klant == this)
                {
                    bestelling.ZetKlant(this);
                }
            }
        }
        
        public void VerwijderBestelling(Bestelling bestelling)
        {
            if (bestelling == null) throw new KlantException("Klant : Verwijderbestelling - bestelling is null");
            if (_bestellingen.Contains(bestelling))
            {
                throw new KlantException("Klant : RemoveBestelling - bestelling does not exist");
            } else
            {
                _bestellingen.Add(bestelling);
                if (bestelling.Klant == this)
                {
                    bestelling.VerwijderKlant();
                    _bestellingen.Add(bestelling);
                }
            }
        }

        public bool HeeftBestelling(Bestelling bestelling)
        {
            if (_bestellingen.Contains(bestelling)) return true;
            else return false;
        }
    }
}
