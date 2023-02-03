using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Verlag;

namespace VerlagTests
{
	[TestClass]
	public class BuchTests
	{
		[TestMethod]
		public void Buch_KannErstelltWerden()
		{
			//Arrange
			string autor = "J.K. Rowling";
			string titel = "Harry Potter und der Gefangene von Askaban";
			int auflage = 1;

			//Act 
			Buch b = new Buch(autor, titel, auflage);

			//Assert
			Assert.AreEqual(autor, b.Autor);
			Assert.AreEqual(titel, b.Titel);
			Assert.AreEqual(auflage, b.Auflage);
		}

		[TestMethod]
		public void Buch_KeineAuflageEntsprichtErsterAuflage()
		{
			//Arrange

			//Act 
			Buch b = new Buch("autor", "titel");

			//Assert
			Assert.AreEqual(1, b.Auflage);
		}

		[TestMethod]
		public void Autor_DarfVeraendertWerden()
		{
			//Arrange
			string autor = "Abdullah";
			string autorNeu = "Thomas";

			//Act
			Buch b = new Buch(autor, "titel");
			b.Autor = autorNeu;

			//Assert
			Assert.AreEqual(autorNeu, b.Autor);

		}

		[TestMethod]
		public void Auflage_DarfVeraendertWerden()
		{
			//Arrange
			int auflage = 15;
			int auflageNeu = 42;

			//Act
			Buch b = new Buch("autor", "titel", auflage);
			b.Auflage = auflageNeu;

			//Assert
			Assert.AreEqual(auflageNeu, b.Auflage);

		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void Buch_AuflageDarfNichtZuKleinSein()
		{
			//Arrange
			int auflage = 0;

			//Act
			Buch b = new Buch("autor", "titel", auflage);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void Auflage_DarfNichtZuKleinSein()
		{
			//Arrange
			Buch b = new Buch("autor", "titel");
			int auflageNeu = 0;

			//Act
			b.Auflage = auflageNeu;
		}

		[TestMethod]
		[DataRow("#")]
		[DataRow(";")]
		[DataRow("§")]
		[DataRow("%")]
		[ExpectedException(typeof(ArgumentException))]
		public void Autor_NurSinnvolleEingabenErlaubt(string unerlaubtesZeichen)		
		{
			//Arrange 
			string name = "Jan Wagner";
			name = name + unerlaubtesZeichen;

			//Act
			Buch b = new Buch(name, "titel");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Autor_NameKannNichtNullSein()
        {
			//Arrange 
			string autor = null;

			//Act
			Buch b = new Buch(autor, "titel");
        }

		[TestMethod]
		public void Buch_KannAufeBookUndOderAufNormalGestelltWerden()
        {
			//Arrange 
			bool eBook = true;
			Buch b = new Buch("autor", "titel");

			//Act 
			b.EBook = eBook;

			//Assert
			Assert.AreEqual(eBook, b.EBook);
        }

		[TestMethod]
		public void Buch_KannPreisZugeteiltBekommen()
        {
			//Arrange 
			double preis = 14.99;
			Buch b = new Buch("autor", "titel");

			//Act 
			b.Preis = preis;

			//Assert
			Assert.AreEqual(preis, b.Preis);
        }

		[TestMethod]
		public void Buch_KannErscheinungsjahrZugeteiltWerden()
        {
			//Arrange 
			DateOnly date = new DateOnly(2008, 6, 1);
			Buch b = new Buch("autor", "titel");

			//Act
			b.Date = date;

			//Assert
			Assert.AreEqual(date, b.Date);
        }

		[TestMethod]
		public void Buch_KannSeitenzahlZugeteiltWerden()
        {
			//Arrange 
			int seitenzahl = 289;
			Buch b = new Buch("autor", "titel");

			//Act
			b.Seitenanzahl = seitenzahl;

			//Assert
			Assert.AreEqual(seitenzahl, b.Seitenanzahl);
        }
	}
}
