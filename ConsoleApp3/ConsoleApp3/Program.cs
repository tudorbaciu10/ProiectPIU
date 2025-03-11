using System;
using System.Collections.Generic;

namespace GestiuneFarmacie
{
    class Program
    {
        static Farmacie farmacie = new Farmacie();

        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Gestiune Farmacie ===");
                Console.WriteLine("1. Adaugă Medicament");
                Console.WriteLine("2. Afișează Medicamente");
                Console.WriteLine("3. Caută Medicament");
                Console.WriteLine("4. Ieșire");
                Console.Write("Alege o opțiune: ");

                string optiune = Console.ReadLine();
                switch (optiune)
                {
                    case "1":
                        AdaugaMedicamentTastatura();
                        break;
                    case "2":
                        farmacie.AfiseazaMedicamente();
                        break;
                    case "3":
                        CautaMedicamentTastatura();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Opțiune invalidă! Apasă ENTER pentru a încerca din nou.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AdaugaMedicamentTastatura()
        {
            Console.Write("Introdu numele medicamentului: ");
            string nume = Console.ReadLine();

            Console.Write("Introdu numele producătorului: ");
            string numeProd = Console.ReadLine();

            Console.Write("Introdu prenumele producătorului: ");
            string prenumeProd = Console.ReadLine();

            Console.Write("Introdu emailul producătorului: ");
            string emailProd = Console.ReadLine();

            Console.Write("Introdu compania producătorului: ");
            string companie = Console.ReadLine();

            Console.Write("Introdu prețul medicamentului: ");
            double pret;
            while (!double.TryParse(Console.ReadLine(), out pret) || pret < 0)
            {
                Console.Write("Preț invalid! Introdu din nou: ");
            }

            Console.Write("Introdu stocul medicamentului: ");
            int stoc;
            while (!int.TryParse(Console.ReadLine(), out stoc) || stoc < 0)
            {
                Console.Write("Stoc invalid! Introdu din nou: ");
            }

            Producator producator = new Producator(numeProd, prenumeProd, emailProd, companie);
            Medicament medicament = new Medicament(nume, producator, pret, stoc);
            farmacie.AdaugaMedicament(medicament);

            Console.WriteLine("Medicament adăugat cu succes! Apasă ENTER pentru a continua.");
            Console.ReadKey();
        }

        static void CautaMedicamentTastatura()
        {
            Console.Write("Introdu numele medicamentului căutat: ");
            string numeCautat = Console.ReadLine();

            Medicament gasit = farmacie.CautaMedicament(numeCautat);
            if (gasit != null)
            {
                Console.WriteLine("Medicament găsit: ");
                Console.WriteLine(gasit);
            }
            else
            {
                Console.WriteLine("Medicamentul nu există.");
            }

            Console.WriteLine("Apasă ENTER pentru a continua.");
            Console.ReadKey();
        }
    }
}
