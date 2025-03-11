using GestiuneFarmacie;
using System;



namespace GestiuneFarmacie
{
    public class Medicament
    {
        public string Nume { get; set; }
        public Producator Producator { get; set; }

        private double pret;
        public double Pret
        {
            get => pret;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Prețul nu poate fi negativ.");
                pret = value;
            }
        }

        private int stoc;
        public int Stoc
        {
            get => stoc;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Stocul nu poate fi negativ.");
                stoc = value;
            }
        }

        public Medicament(string nume, Producator producator, double pret, int stoc)
        {
            Nume = !string.IsNullOrWhiteSpace(nume) ? nume : throw new ArgumentException("Numele medicamentului nu poate fi gol.");
            Producator = producator ?? throw new ArgumentNullException("Producătorul nu poate fi null.");
            Pret = pret;
            Stoc = stoc;
        }

        public override string ToString()
        {
            return $"Medicament: {Nume}, Producător: {Producator}, Preț: {Pret:F2} RON, Stoc: {Stoc} buc.";
        }
    }
}
