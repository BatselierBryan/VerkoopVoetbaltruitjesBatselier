using System;
using System.Collections.Generic;
using BusinessLayer.Exceptions;
using BusinessLayer.Interface;

namespace BusinessLayer.Model
{
    public class Klant : IKlant
    {

        public int KlantenNummer { get; private set; }

        public string Naam { get; private set; }

        public string Adres { get; private set; }

        private List<Bestelling> _bestellingen = new List<Bestelling>();

        public Klant(int klantid, string naam, string adres, List<Bestelling> _bestellingen)
        {
            this.KlantenNummer = klantid;
            this.Naam = naam;
            this.Adres = adres;
            this._bestellingen = _bestellingen;
        }

        public Klant(int nummer, string naam, string adres) : this(naam, adres)
        {
            ZetKlantId(nummer);
            ZetNaam(naam);
            ZetAdres(adres);
        }


        public Klant(string naam, string adres)
        {
            ZetNaam(naam);
            ZetAdres(adres);
        }

        public int GeefKorting()
        {
            if (_bestellingen.Count < 5) return 0;
            if (_bestellingen.Count < 10) return 10;
            else return 20;
        }

        public void ZetKlantId(int id)
        {
            if (id <= 0) throw new KlantException("Klant: KlantId is onder 1");
            this.KlantenNummer = id;
        }

        public void ZetAdres(string adres)
        {
            if (string.IsNullOrWhiteSpace(adres)) throw new KlantException("Klant: Adres is leeg!");
            this.Adres = adres;
        }

        public void ZetNaam(string naam)
        {
            if (string.IsNullOrWhiteSpace(naam)) throw new KlantException("Klant: Naam moet langer dan 1 letter zijn!");
            Naam = naam;
        }

        public IReadOnlyList<Bestelling> ToonBestelling()
        {
            return _bestellingen;
        }

        public void VoegBestellingToe(Bestelling bestelling)
        {
            if (bestelling == null) throw new KlantException("Klant: VerwijderBestelling - bestelling is null");
            if (_bestellingen.Contains(bestelling))
            {
                throw new KlantException("Klant: AddBestelling - bestelling allready exists");
            }
            else
            {
                _bestellingen.Add(bestelling);
                if (bestelling.Klant != this)
                {
                    bestelling.ZetKlant(this);
                }
            }
        }

        public void VerwijderBestelling(Bestelling bestelling)
        {
            if (bestelling == null) throw new KlantException("Klant: BestellingVerwijderen - geen bestelling gevonden");
            if (_bestellingen.Contains(bestelling))
            {
                _bestellingen.Remove(bestelling);
            }
        }

        public bool HeeftBestelling(Bestelling bestelling)
        {
            if (_bestellingen.Contains(bestelling)) return true;
            else return false;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is Klant klant &&
                   KlantenNummer == klant.KlantenNummer &&
                   Naam == klant.Naam &&
                   Adres == klant.Adres &&
                   EqualityComparer<List<Bestelling>>.Default.Equals(_bestellingen, klant._bestellingen);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(KlantenNummer, Naam, Adres, _bestellingen);
        }
    }
}
