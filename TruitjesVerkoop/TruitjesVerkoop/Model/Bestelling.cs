using System;
using System.Collections.Generic;
using BusinessLayer.Exceptions;
using BusinessLayer.Interface;

namespace BusinessLayer
{
    public class Bestelling : IBestelling
    {
        public int BestelNummer { get; private set; }

        public bool Betaald { get; private set; }

        public Klant Klant { get; private set; }

        public double Prijs { get; set; }

        public DateTime OrderDatum { get; private set; }

        private Dictionary<Trui, int> _items = new Dictionary<Trui, int>();

        public Bestelling(int bestelid, DateTime tijdstip) : this(tijdstip)
        {
            ZetBestellingId(bestelid);
            ZetTijdstip(tijdstip);
        }

        public Bestelling(int bestelid, Klant klant, DateTime tijdstip)
        {
            ZetBestellingId(bestelid);
            this.Klant = klant;
            ZetTijdstip(tijdstip);
        }

        public Bestelling(int bestelid, Klant klant, DateTime tijdstip, Dictionary<Trui, int> producten)
        {
            ZetBestellingId(bestelid);
            this.Klant = klant;
            ZetTijdstip(tijdstip);
            this._items = producten;
        }


        public Bestelling(int bestelid, Klant klant, DateTime tijdstip, double prijs, bool betaald, Dictionary<Trui, int> producten)
        {
            ZetBestellingId(bestelid);
            this.Klant = klant;
            ZetTijdstip(tijdstip);
            ZetPrijs(prijs);
            ZetBetaald(betaald);
            this._items = producten;
        }

        public Bestelling(DateTime tijdstip)
        {
            ZetTijdstip(tijdstip);
        }


        public void ZetBestellingId(int id)
        {
            if (id <= 0) throw new BestellingException("Bestelling: Id klopt niet!");
            this.BestelNummer = BestelNummer;

        }

        public void ZetPrijs(double prijs)
        {
            if (prijs <= 0) throw new BestellingException("Bestelling - Prijs mag niet kleiner zijn dan 0");
            this.Prijs = prijs;
        }

        public void ZetTijdstip(DateTime tijdstip)
        {
            if (tijdstip == null) throw new BestellingException("Bestelling: Tijdstip klopt niet");
            this.OrderDatum = tijdstip;
        }
        public void ZetKlant(Klant newKlant)
        {
            if (newKlant == null) throw new KlantException("Bestelling - invalid klant");
            if (newKlant == Klant) throw new KlantException("Bestelling- ZetKlant - not new");
            if (Klant != null)
            {
                if (Klant.HeeftBestelling(this))
                    Klant.VerwijderBestelling(this);
                if (!newKlant.HeeftBestelling(this))
                newKlant.VoegBestellingToe(this);
                Klant = newKlant;
            }
        }

        public void VerwijderKlant()
        {
            Klant = null;
        }

        public double KostPrijs()
        {
            double prijs = 0.0;
            int korting;
            if (Klant is null)
            {
                korting = 0;
            }
            else
            {
                korting = Klant.GeefKorting();
            }
            foreach (KeyValuePair<Trui, int> kvp in _items)
            {
                prijs += kvp.Key.Prijs * kvp.Value * (100.0 - korting) / 100.0;
            }
            return prijs;
        }

        public IReadOnlyDictionary<Trui, int> GeefProducten()
        {
            foreach (KeyValuePair<Trui, int> kvp in _items)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
            return _items;
        }

        public IReadOnlyDictionary<Trui, int> GeefAantalProducten()
        {
            Console.WriteLine("Count: {0}", _items.Count);
            return _items;
        }

        public void VoegTruitjeToe(Trui trui, int aantal)
        {
            if (aantal <= 0) throw new BestellingException("Geen trui ingegeven");
            else if (!_items.ContainsKey(trui))
            {
                _items.Add(trui, aantal);
            }
            else if (_items.ContainsKey(trui))
            {
                _items[trui] += aantal;
            }
        }

        public void VerwijderTruitje(Trui trui, int aantal)
        {
            if (aantal <= 0) throw new BestellingException("Geen trui ingegeven!");
            if (!_items.ContainsKey(trui)) throw new BestellingException("Er werd geen trui besteld!");
            else
            {
                if (_items[trui] < aantal)
                {
                    throw new BestellingException("VerwijderVoetbalTruitje - beschikbaar aantal te klein");
                }
                else if (_items[trui] == aantal)
                {
                    _items.Remove(trui);
                }
                else
                {
                    _items[trui] -= aantal;
                }
            }

        }
        public bool ZetBetaald(bool betaald)
        {
            if (betaald)
            {
                return Betaald = true;
            }
            else
            {
                return Betaald = false;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}