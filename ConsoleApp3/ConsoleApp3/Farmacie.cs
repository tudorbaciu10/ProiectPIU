using System;
using System.Collections.Generic;
using System.Linq;

namespace GestiuneFarmacie
{
    public class Farmacie
    {
        public List<Medicament> Medicamente { get; private set; } = new List<Medicament>();

        public void AdaugaMedicament(Medicament medicament)
        {
            var existent = Medicamente.FirstOrDefault(m => m.Nume.Equals(medicament.Nume, StringComparison.OrdinalIgnoreCase));

            if (existent != null)
            {
                Console.WriteLine($"Medicamentul '{medicament.Nume}' există deja. Se actualizează stocul.");
                existent.Stoc += medicament.Stoc;
            }
            else
            {
                Medicamente.Add(medicament);
                Console.WriteLine($"Medicamentul '{medicament.Nume}' a fost adăugat.");
            }
        }

        public Medicament CautaMedicament(string nume)
        {
            return Medicamente.FirstOrDefault(m => m.Nume.Equals(nume, StringComparison.OrdinalIgnoreCase));
        }

        public void AfiseazaMedicamente()
        {
            if (!Medicamente.Any())
            {
                Console.WriteLine("Nu există medicamente în farmacie.");
            }
            else
            {
                Console.WriteLine("Lista medicamentelor disponibile:");
                foreach (var medicament in Medicamente)
                {
                    Console.WriteLine(medicament);
                }
            }
            Console.WriteLine("Apasă ENTER pentru a continua.");
            Console.ReadKey();
        }
    }
}
