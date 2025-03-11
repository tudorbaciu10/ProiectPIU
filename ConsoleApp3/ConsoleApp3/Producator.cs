using System;
using System.Text.RegularExpressions;

namespace GestiuneFarmacie
{
	public class Producator
	{
		public string Nume { get; set; }
		public string Prenume { get; set; }
		public string Email { get; set; }
		public string Companie { get; set; }

		public Producator(string nume, string prenume, string email, string companie)
		{
			Nume = !string.IsNullOrWhiteSpace(nume) ? nume : throw new ArgumentException("Numele nu poate fi gol.");
			Prenume = !string.IsNullOrWhiteSpace(prenume) ? prenume : throw new ArgumentException("Prenumele nu poate fi gol.");
			Companie = !string.IsNullOrWhiteSpace(companie) ? companie : throw new ArgumentException("Compania nu poate fi goală.");

			if (IsValidEmail(email))
				Email = email;
			else
				throw new ArgumentException("Email invalid.");
		}

		private bool IsValidEmail(string email)
		{
			return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
		}

		public override string ToString()
		{
			return $"{Nume} {Prenume}, {Companie}, Email: {Email}";
		}
	}
}
