using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmEditor.Core.Model
{
    public class FilmCountry : Entity
    {
        private Guid filmId;

        public Guid FilmId
        {
            get { return filmId; }
            set
            {
                filmId = value;
                OnPropertyChanged("FilmId");
            }
        }
        private Guid countryId;

        public Guid CountryId
        {
            get { return countryId; }
            set
            {
                countryId = value;
                OnPropertyChanged("CountryId");
            }
        }


        public Film Film { get; set; }
        public Country Country { get; set; }

        public override Entity Clone()
        {
            return this.MemberwiseClone() as FilmCountry;
        }
    }
}
