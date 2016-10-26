using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmEditor.Core.Model
{
    public class Country : Entity
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        private string abbreviation;

        public string Abbreviation
        {
            get { return abbreviation; }
            set
            {
                abbreviation = value;
                OnPropertyChanged("Abbreviation");
            }
        }
        public virtual ICollection<Film> Films { get; set; }

        public override Entity Clone()
        {

            Country result = new Country();
            result.Id = this.Id;
            result.Name = this.Name;
            result.Abbreviation = this.Abbreviation;
            return result;
        }
    }
}
