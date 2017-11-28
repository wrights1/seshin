using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    class Program
    {
        static void Main(string[] args)
        {
            var dvdMaker = new DvdMaker();
            var dvdLibrary = new DvdLibrary();

            /*Intialize and create tables if they don't already exist*/
            //dvdMaker.Init();

            /*CREATE*/
            foreach (var dvd in dvdMaker.Dvds)
            {
                dvdLibrary.AddDvd(dvd);
            }

            
            /*Read
            IEnumerable<DVD> savedDvds = dvdLibrary.GetAllDvds();

            foreach (var savedDvd in savedDvds)
            {
                Debug.WriteLine("Items");
                Debug.WriteLine("Title : {0}",savedDvd.Title);
                Debug.WriteLine("ReleaseYear : {0}",savedDvd.ReleaseYear);
                Debug.WriteLine("Director : {0}",savedDvd.Director);
            }
            */

            /*Update*/
            //DVD theDarkKnightDvd = dvdLibrary.SearchDvds("The Dark Knight", 2008).SingleOrDefault();
            //if (theDarkKnightDvd != null)
            //{
            //    theDarkKnightDvd.Director = "Will Smith";
            //    dvdLibrary.ModifyDvd(theDarkKnightDvd);

            //}


            /*Delete
            DVD darkKnightDvd = dvdLibrary.SearchDvds("The Dark Knight", 2008).SingleOrDefault();
            if (darkKnightDvd != null)
            {
                dvdLibrary.DeleteDvd(darkKnightDvd);
            }
            */
        }
    }
}
