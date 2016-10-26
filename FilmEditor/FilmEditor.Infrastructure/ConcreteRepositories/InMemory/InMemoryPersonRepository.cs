using FilmEditor.Core.Interfaces;
using FilmEditor.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmEditor.Core.Abstractions;

namespace FilmEditor.Infrastructure.ConcreteRepositories.InMemory
{
    public class InMemoryPersonRepository : AbstractPersonRepository
    {
        private readonly List<Person> _entities;
        public InMemoryPersonRepository(List<Person> entities)
        {
            _entities = entities;
        }

        public override Person Add(Person entity)
        {
            if (entity == null) throw new Exception("Null argument");
            if (entity.Id.Equals(Guid.Empty))
            {
                entity.Id = Guid.NewGuid();
                _entities.Add(entity);
            }
            return (Person)entity.Clone();
        }

        public override void Delete(Person t)
        {
            _entities.Remove(t);
        }


        public override Person GetByFullName(string fullName)
        {
            Person result = _entities.Single(p => p.FullName.Contains(fullName));
            return (result == null) ? null : (Person)result.Clone();
        }

        public override Person GetById(Guid id)
        {
            var query = from p in _entities
                        where p.Id.Equals(id)
                        select p;
            Person entity = query.SingleOrDefault();
            return (entity == null) ? null : (Person)entity.Clone();
        }

        public override IEnumerable<Person> List()
        {
            return _entities;
        }



        public override List<Person> ListByLastName(string lastName)
        {
            var query = from p in _entities
                        where p.LastName.Contains(lastName)
                        select p;            
            List<Person> candidates = (List<Person>)query.ToList();
            return ListClone(candidates);
        }

        public override void Save()
        {
            // noop
        }

        public override void Update(Person t)
        {
            Person entity = _entities.Single(p => p.Id.Equals(t.Id));
            entity.Copy(t);
        }

        private List<Person> ListClone(List<Person> list)
        {
            List<Person> result = new List<Person>();
            foreach (Person p in list) result.Add((Person)p.Clone());
            return result;
        }
    }
}
