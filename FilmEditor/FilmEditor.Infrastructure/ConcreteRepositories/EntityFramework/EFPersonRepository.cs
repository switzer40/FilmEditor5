
using System;
using FilmEditor.Core.Model;
using System.Collections.Generic;
using System.Linq;
using FilmEditor.Infrastructure.DAL;
using FilmEditor.Core.Abstractions;
using System.Data.Entity;

namespace FilmEditor.Infrastructure.ConcreteRepositories.EntityFramework
{
    public class EFPersonRepository : AbstractPersonRepository
    {

        private readonly IFilmContext _context;
        public EFPersonRepository(IFilmContext context)
        {
            _context = context;
        }

        public override Person Add(Person entity)
        {
            if (entity.Id.Equals(Guid.Empty))
                _context.People().Add(entity);
            return (entity == null) ? null : (Person)entity.Clone();
        }

        public override void Delete(Person entity)
        {
            _context.People().Remove(entity);
        }



        public override Person GetByFullName(string fullName)
        {
            Person result = _context.People().Single(p => p.FullName.Contains(fullName));
            return (result == null) ? null : (Person)result.Clone();
        }

        public override Person GetById(Guid id)
        {
            Person entity = _context.People().Single(p => p.Id.Equals(id));
            return (entity == null) ? null : (Person)entity.Clone();
        }

        public override IEnumerable<Person> List()
        {
            return _context.People();
        }



        public override List<Person> ListByLastName(string lastName)
        {
            List<Person> result = (List<Person>)_context.People().Where(p => p.LastName.Contains(lastName));
            return (result == null) ? null : ListClone(result);
        }

        public override void Save()
        {
            _context.Save();
        }

        public override void Update(Person entity)
        {
            _context.StateChanged(entity);
            _context.Save();
        }

        private List<Person> ListClone(List<Person> list)
        {
            List<Person> result = new List<Person>();
            foreach (Person p in list) result.Add((Person)p.Clone());
            return result;
        }
    }
}
