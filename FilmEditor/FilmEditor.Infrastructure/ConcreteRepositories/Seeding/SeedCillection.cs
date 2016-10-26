using FilmEditor.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmEditor.Infrastructure.ConcreteRepositories
{
    public class SeedCollection
    {
        public static List<Country> _baseCountryList = new List<Country>
        {
            new Country {Name = "United States of America", Abbreviation = "USA" },
            new Country {Name = "Great Britain", Abbreviation = "GB" },
            new Country {Name = "Germany", Abbreviation = "D" },
            new Country {Name = "France", Abbreviation = "F" },
            new Country {Name = "Italy", Abbreviation = "I" },
            new Country {Name = "Spain", Abbreviation = "E" }
        };
        public static List<Film> _baseFilmList = new List<Film>
        {
            new Film {Barcode = 4010884500042, Title = "Frühstück bei Tiffany", Year = 1961, Length = 110,  HasGermanSubtitles = true, IsBluray = false },
            new Film {Barcode = 4011846004585, Title= "Pretty Woman", Year = 1990, Length = 119, HasGermanSubtitles = true, IsBluray = false }
        };
        public static List<Location> _baseLocationList = new List<Location>
        {
            new Location {Description = "Left drawer of TV cabinet" },
            new Location {Description = "Right drawer of TV cabinet" },
            new Location {Description = "DVD rack level 1" },
            new Location {Description = "DVD rack level 2" },
            new Location {Description = "DVD rack level 3" },
            new Location {Description = "DVD rack level 4" },
            new Location {Description = "White commode top drawer" },
            new Location {Description = "White commode middle drawer" },
            new Location {Description = "White commode bottom drawer" },
            new Location {Description = "Blu-ray rack level 1" },
            new Location {Description = "Blu-ray rack level 2" },
            new Location {Description = "Blu-ray rack level 3" },
            new Location {Description = "Blu-ray rack level 4" },
            new Location {Description = "Bedroom Bookshelf" }
        };
        public static List<Person> _basePersonList = new List<Person>
        {
            new Person {FirstMidName = "Audrey", LastName = "Hepburn", BirthdateString = "1929-05-04" },
            new Person {FirstMidName = "George", LastName = "Peppard", BirthdateString = "1928-10-01" },
            new Person {FirstMidName = "Blake", LastName = "Edwards", BirthdateString = "1922-07-26" },
            new Person {FirstMidName = "Henry", LastName = "Mancini", BirthdateString = "1924-04-16" },
            new Person {FirstMidName = "Julia", LastName = "Roberts", BirthdateString = "1967-10-28" },
            new Person {FirstMidName = "Richard", LastName = "Gere", BirthdateString = "1949-08-31" },
            new Person {FirstMidName = "Garry", LastName = "Marshall", BirthdateString = "1934-11-13" },
            new Person {FirstMidName = "James Newton", LastName = "Howard", BirthdateString = "1951-06-09" }
        };
    }
}
