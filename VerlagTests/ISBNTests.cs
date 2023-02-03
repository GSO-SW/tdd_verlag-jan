using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Verlag;

namespace VerlagTests
{
    [TestClass]
    internal class ISBNTests
    {
        [TestMethod]
        public void ISBN_KannHinzugefuegtWerden()
        {
            //Arrange
            string isbn13 = "927-928574826";

            //Act
            ISBN isbn = new ISBN(isbn13);
            
            //Assert
            Assert.AreEqual(isbn13, isbn.Isbn13);
        }
        [TestMethod]
        public void ISBN_PruefzifferWirdAutomatischBerechnet()
        {
            //Arrange
            string isbn13 = "927-928574826";
            string pruefziffer = "6";
            string isbnMitPruefziffer = isbn13 + pruefziffer;

            //Act
            ISBN isbn = new ISBN(isbn13);

            //Assert
            Assert.AreEqual(isbnMitPruefziffer, isbn.IsbnMitPruefziffer);
        }
        [TestMethod]
        public void ISBN_isbn10KannErstelltWerden()
        {
            //Arrange
            string isbn13 = "927-928574826";
            string isbn10 = "928574826";

            //Act
            ISBN isbn = new ISBN(isbn13);

            //Assert
            Assert.AreEqual(isbn10, isbn.Isbn10);
        }
    }
}
