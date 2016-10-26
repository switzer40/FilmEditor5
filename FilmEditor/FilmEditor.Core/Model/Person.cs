using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmEditor.Core.Model
{
    public class Person : Entity
    {
        public Person()
        {
            BirthdateString = DateTime.Now.ToShortDateString();
        }
        private string firstMidName;

        public string FirstMidName
        {
            get { return firstMidName; }
            set
            {
                firstMidName = value;
                OnPropertyChanged("FirstMidName");
            }
        }
        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        private string birthdateString;

        public string BirthdateString
        {
            get { return birthdateString; }
            set
            {
                birthdateString = value;
                OnPropertyChanged("BirthdateString");
            }
        }
        public DateTime Birthdate { get { return DateTime.Parse(BirthdateString); } }
        public string ShortBirthdate
        {
            get { return Birthdate.ToShortDateString(); }
            set { birthdateString = value; }
        }
        public string FullName { get { return String.Format("{0} {1}", FirstMidName, LastName); } }

        public override Entity Clone()
        {
            return this.MemberwiseClone() as Person;
        }

    }
}
