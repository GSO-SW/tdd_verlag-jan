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
            string isbn = "927-928574826";
            string autor = "autor";
            string titel = "titel";
            Buch b = new Buch(autor, titel);

            //Act
            b.Isbn = isbn;

            //Assert
            Assert.AreEqual(isbn+"9", b.Isbn);
        }
    }
}
