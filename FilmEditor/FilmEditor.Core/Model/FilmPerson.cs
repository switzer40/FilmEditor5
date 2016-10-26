using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmEditor.Core.Model
{
    public enum Role
    {
        None = 0,
        Actor = 1,
        Composer = 2,
        Director = 3,
        Scripwiter = 4
    }
    public class FilmPerson : Entity
    {
        public FilmPerson()
        {
            Roles = new ObservableCollection<Role>(new List<Role>());
        }
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
        private Guid personId;

        public Guid PersonId
        {
            get { return personId; }
            set
            {
                personId = value;
                OnPropertyChanged("PersonId");
            }
        }
        private ObservableCollection<Role> roles;

        public ObservableCollection<Role> Roles
        {
            get { return roles; }
            set
            {
                roles = value;
                OnPropertyChanged("Roles");
            }
        }



        public Film Film { get; set; }
        public Person Person { get; set; }

        public override Entity Clone()
        {
            return this.MemberwiseClone() as FilmPerson;
        }

    }
}
