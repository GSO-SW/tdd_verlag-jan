using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verlag
{
    public class Buch
    {
        private string autor;
        private string titel;
        private int auflage;
        private string isbn;
        private string isbn10;
        private char[] unerlaubteSymbole = {'1', '2', '3', '4', '5', '6', '7', '8', '9', '#', '_', '!', '?', ';', '§', '%'};



        public Buch(string autor, string titel, int auflage):this(autor, titel)
        {
            if (auflage >= 1)
            {
                this.auflage = auflage;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        public Buch(string autor, string titel)
        {
            for (int i = 0; i < unerlaubteSymbole.Length; i++)
            {
                if (autor.Contains(unerlaubteSymbole[i]))
                {
                    throw new ArgumentException();
                }
            }

            this.titel = titel;
            this.autor = autor;
            this.auflage = 1;
        }

        private string PrüfzifferErgenzen(string isbn)
        {
            string newIsbn;
            int[] isbnZahl = new int[9];
            int pruefnummer = 0;
            int entgueltigePruefnummer = 0;
            if (isbn.Length < 13)
            {
                for (int i = 0; i < 8; i++)
                {
                    isbnZahl[i] = Convert.ToInt32(isbn[i]);
                }
                for (int i = 0; i < 8; i++)
                {
                    pruefnummer = isbnZahl[i] * (i + 1);
                }
                entgueltigePruefnummer = pruefnummer / 11;
            }
            else
            {
                return isbn;
            }
            if (entgueltigePruefnummer == 10)
            {
                newIsbn = "Isbn:" + isbn + "X";
            }
            else
            {
                newIsbn = ("Isbn: " + isbn + entgueltigePruefnummer.ToString());
            }
            this.isbn10 = Isbn10Erstellen(newIsbn);
            return newIsbn;
        }

        private string Isbn10Erstellen(string isbn)
        {
            string isbn10 = "Isbn 10: ";
            for (int i = 3; i < 13; i++)
            {
                isbn10 += isbn[i];
            }
            return isbn10;
        }



        public string Autor
        {
            get { return autor; }
            set { this.autor = value; }
        }
        public string Titel
        {
            get { return titel; }
        }
        public int Auflage
        {
            get { return auflage; }
            set 
            { 
                if (value > 0) this.auflage = value; 
                else throw new ArgumentOutOfRangeException(); 
            }
        }   
        public string Isbn
        {
            set { isbn = PrüfzifferErgenzen(value); }
        }
    }
}
