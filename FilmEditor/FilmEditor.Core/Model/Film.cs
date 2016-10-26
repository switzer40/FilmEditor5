using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmEditor.Core.Model
{
    public class Film : Entity
    {
        private long barcode;

        public long Barcode
        {
            get { return barcode; }
            set
            {
                barcode = value;
                OnPropertyChanged("Barcode");
            }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        private short year;

        public short Year
        {
            get { return year; }
            set
            {
                year = value;
                OnPropertyChanged("Year");
            }
        }
        private short length;

        public short Length
        {
            get { return length; }
            set
            {
                length = value;
                OnPropertyChanged("Length");
            }
        }
        private Location location;

        public Location Location
        {
            get { return location; }
            set
            {
                location = value;
                OnPropertyChanged("Location");
            }
        }


        private bool hasGermanSubtitles;


        public bool HasGermanSubtitles
        {
            get { return hasGermanSubtitles; }
            set
            {
                hasGermanSubtitles = value;
                OnPropertyChanged("HasGermanSubtitles");
            }
        }
        private bool isBluray;

        public bool IsBluray
        {
            get { return isBluray; }
            set
            {
                isBluray = value;
                OnPropertyChanged("IsBluray");
            }
        }
        public virtual Country Country { get; set; }

        public override Entity Clone()
        {
            return this.MemberwiseClone() as Film;
        }
    }
}
