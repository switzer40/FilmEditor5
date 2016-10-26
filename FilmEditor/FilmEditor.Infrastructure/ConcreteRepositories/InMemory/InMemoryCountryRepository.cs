using FilmEditor.Core.Abstractions;
using FilmEditor.Core.Interfaces;
using FilmEditor.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmEditor.Infrastructure.ConcreteRepositories.InMemory
{
    public class InMemoryCountryRepository : AbstractCountryRepository
    {
        private readonly List<Country> _entities;
        public InMemoryCountryRepository(List<Country> entities)
        {
            _entities = entities;
        }

        public override Country Add(Country entity)
        {
            if (entity.Id.Equals(Guid.Empty))
            {
                entity.Id = Guid.NewGuid();
                _entities.Add(entity);
            }
            return (entity == null) ? null : (Country)entity.Clone();
        }

        public override void Delete(Country entity)
        {
            _entities.Remove(entity);
        }



        public override Country GetByAbbreviation(string abbreviation)
        {
            Country result = _entities.Single(c => c.Abbreviation == abbreviation);
            return (result == null) ? null : (Country)result.Clone();
        }

        public override Country GetById(Guid id)
        {
            Country entity = _entities.Single(c => c.Id.Equals(id));
            return (entity == null) ? null : (Country)entity.Clone();
        }

        public override IEnumerable<Country> List()
        {
            return _entities;
        }

        public override void Save()
        {
            // noop
        }

        public override void Update(Country t)
        {
            Country entity = _entities.Single(c => c.Id.Equals(t.Id));
            entity.Copy(t);
        }
    }
}
