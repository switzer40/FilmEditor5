using FilmEditor.Core.Interfaces;
using FilmEditor.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmEditor.Core.Abstractions
{
    public abstract class AbstractPersonRepository : IRepository<Person>, IPersonRepository
    {
        public abstract Person Add(Person entity);
        public void AddRange(List<Person> list)
        {
            foreach (Person p in list) Add(p);
            Save();
        }
        public abstract void Delete(Person t);
        public abstract Person GetByFullName(string fullName);
        public abstract Person GetById(Guid id);
        public abstract IEnumerable<Person> List();
        public abstract List<Person> ListByLastName(string lastName);
        public abstract void Save();
        public abstract void Update(Person t);
    }
}
