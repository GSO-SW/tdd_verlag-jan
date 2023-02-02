using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace Verlag
{
    public class Buch
    {
        private string autor;
        private string titel;
        private int auflage;
        private string isbn;
        private bool eBook;
        private double preis;
        private DateOnly date = new DateOnly();
        private int seitenanzahl;
        private char[] unerlaubteSymbole = { '#', ';', '§', '%' };


        public Buch(string autor, string titel, int auflage) : this(autor, titel)
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
                else if (autor == "" || autor == null)
                {
                    throw new ArgumentNullException();
                }
            }

            this.titel = titel;
            this.autor = autor;
            this.auflage = 1;
        }

        private string PruefzifferErgaenzen(string isbn)
        {
            int[] isbnInInt = new int[isbn.Length - 1];
            int pruefziffer;
            string isbnString = "";

            for (int i = 0; i < 3; i++)
            {
                isbnInInt[i] = Convert.ToInt32(isbn[i].ToString());
                isbnString += isbnInInt[i].ToString();
            }
            isbnString += "-";
            for (int i = 3; i < isbn.Length - 1; i++)
            {
                isbnInInt[i] = Convert.ToInt32(isbn[i + 1].ToString());
                isbnString += isbnInInt[i].ToString();
            }
            pruefziffer = (isbnInInt[0] + isbnInInt[1] + isbnInInt[2]) / 3;
            isbnString += pruefziffer.ToString();

            return (isbnString);
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
            set { isbn = PruefzifferErgaenzen(value); }
            get { return isbn; }
        }

        public bool EBook
        {
            set { eBook = value; }
            get { return eBook; }
        }

        public double Preis
        {
            set { preis = value; }
            get { return preis; }
        }

        public DateOnly Date
        {
            set { date = value; }
            get { return date; }
        }

        public int Seitenanzahl
        {
            set { seitenanzahl = value; }
            get { return seitenanzahl; }
        }
    }
}
