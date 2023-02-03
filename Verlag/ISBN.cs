using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verlag
{
    internal class ISBN
    {
        private string isbnMitPruefziffer;
        private string isbn10;
        public ISBN(string isbn)
        {
            isbnMitPruefziffer = PruefzifferHinzufuegen(isbn);
            isbn10 = IsbnInIsbn10(isbn);
        }

        private string PruefzifferHinzufuegen(string isbn)
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
        private string IsbnInIsbn10(string isbn)
        {
            string isbn10 = "";
            for(int i = 3; i < isbn.Length; i++)
            {
                isbn10 += isbn[i];
            }
            return isbn10;
        }

        public string IsbnMitPruefziffer
        {
            get { return isbnMitPruefziffer; }
        }
        public string Isbn10
        {
            get { return isbn10;}
        }
    }
}
