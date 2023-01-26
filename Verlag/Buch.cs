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
        private char[] unerlaubteSymbole = {'#', ';', '§', '%'};


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
            int[] isbnZahlErsteDreiStellen = new int[3];
            int[] isbnZahlLetztenNeunStellen = new int[9];
            string isbnRueckgabe = "";
            for (int i = 0; i < 3; i++)
            {
                isbnZahlErsteDreiStellen[i] = (int)isbn[i];
                isbnRueckgabe += isbnZahlErsteDreiStellen[i];
            }
            isbnRueckgabe += "-";
            for (int i = 0; i < 9; i++)
            {
                isbnZahlLetztenNeunStellen[i] = (int)isbn[i + 4];
                isbnRueckgabe += isbnZahlLetztenNeunStellen[i];
            }
            return (isbnRueckgabe+"9");
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
    }
}
