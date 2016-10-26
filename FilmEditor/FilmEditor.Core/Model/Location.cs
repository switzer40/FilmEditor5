using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmEditor.Core.Model
{
    public class Location : Entity
    {
        private string description;

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        public override Entity Clone()
        {
            return this.MemberwiseClone() as Location;
        }
    }
}
