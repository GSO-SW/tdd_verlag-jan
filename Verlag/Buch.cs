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
        private ISBN isbn;
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
        public string IsbnSetzen
        {
            set { ISBN isbn = new ISBN(value); this.isbn = isbn; }
        }

        public string Isbn10
        {
            get { return isbn.Isbn10; }
        }

        public string IsbnMitPruefziffer
        {
            get { return isbn.IsbnMitPruefziffer; }
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
