using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmEditor.Core.Abstractions;
using FilmEditor.Core.Model;

namespace FilmEditor.Infrastructure.ConcreteRepositories.InMemory
{
    public class InMemoryFilmCountryRepository : AbstractFilmCountryRepository
    {
        private readonly List<FilmCountry> _entities;
        public InMemoryFilmCountryRepository(List<FilmCountry> entities)
        {
            _entities = entities;
        }
        public override FilmCountry Add(FilmCountry entity)
        {
            if (entity == null) throw new Exception("Null argument");
            if (entity.Id.Equals(Guid.Empty))
            {
                entity.Id = Guid.NewGuid();
                _entities.Add(entity);
            }
            return (FilmCountry)entity.Clone();
        }


        public override void Delete(FilmCountry entity)
        {
            _entities.Remove(entity);
        }

        public override FilmCountry GetById(Guid id)
        {
            FilmCountry entity = _entities.Single(fc => fc.Id.Equals(id));
            return (entity == null) ? null : (FilmCountry)entity.Clone();
        }

        public override IEnumerable<FilmCountry> List()
        {
            return _entities;
        }

        public override List<Guid> ListCountryIdsForFilmId(Guid filmId)
        {
            var query = from fc in _entities
                        where fc.FilmId.Equals(filmId)
                        select fc.CountryId;
            return query.ToList();
        }


        public override List<Guid> ListFilmIdsForCountryId(Guid countryId)
        {
            var query = from fc in _entities
                        where fc.CountryId.Equals(countryId)
                        select fc.FilmId;
            return query.ToList();
        }

        public override void Save()
        {
            // noop
        }

        public override void Update(FilmCountry entity)
        {
            FilmCountry storedEntity = _entities.Single(fc => fc.Id.Equals(entity.Id));
            storedEntity.Copy(entity);
        }
    }
}
