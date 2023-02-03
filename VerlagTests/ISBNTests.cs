using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Verlag;

namespace VerlagTests
{
    [TestClass]
    internal class ISBNTests
    {
        [TestMethod]
        public void ISBN_KannErstelltWerden()
        {
            //Arrange
            string isbn13 = "927-9285748266";

            //Act
            ISBN isbn = new ISBN(isbn13);
            
            //Assert
            Assert.AreEqual(isbn13, isbn.Isbn13);
        }
        [TestMethod]
        public void ISBN_PruefzifferWirdAutomatischBerechnet()
        {
            //Arrange
            string isbnOhnePruefziffer = "927-928574826";
            string pruefziffer = "6";
            string isbn13 = isbnOhnePruefziffer + pruefziffer;

            //Act
            ISBN isbn = new ISBN(isbnOhnePruefziffer);

            //Assert
            Assert.AreEqual(isbn13, isbn.Isbn13);
        }
        [TestMethod]
        public void ISBN_isbn10KannAusIsbn13BerechnetWerden()
        {
            //Arrange
            string isbn13 = "927-9285748266";
            string isbn10 = "9285748266";

            //Act
            ISBN isbn = new ISBN(isbn13);

            //Assert
            Assert.AreEqual(isbn10, isbn.Isbn10);
        }
    }
}
