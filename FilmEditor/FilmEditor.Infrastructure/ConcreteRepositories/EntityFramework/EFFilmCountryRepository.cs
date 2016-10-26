using FilmEditor.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using FilmEditor.Core.Abstractions;
using FilmEditor.Infrastructure.DAL;
using System.Data.Entity;

namespace FilmEditor.Infrastructure.ConcreteRepositories.EntityFramework
{
    public class EFFilmCountryRepository : AbstractFilmCountryRepository
    {
        private readonly IFilmContext _context;
        public EFFilmCountryRepository(IFilmContext context)
        {
            _context = context;
        }

        public override FilmCountry Add(FilmCountry entity)
        {
            if (entity.Id.Equals(Guid.Empty))
                _context.FilmCountries().Add(entity);
            return (entity == null) ? null : (FilmCountry)entity.Clone();
        }


        public override void Delete(FilmCountry entity)
        {
            _context.FilmCountries().Remove(entity);
        }

        public override FilmCountry GetById(Guid id)
        {
            FilmCountry entity = _context.FilmCountries().Single(fc => fc.Id.Equals(id));
            return (entity == null) ? null : (FilmCountry)entity.Clone();
        }

        public override IEnumerable<FilmCountry> List()
        {
            return _context.FilmCountries();
        }

        public override List<Guid> ListCountryIdsForFilmId(Guid filmId)
        {
            var query = from fc in _context.FilmCountries()
                        where fc.FilmId.Equals(filmId)
                        select fc.CountryId;
            return query.ToList();
        }

        public override List<Guid> ListFilmIdsForCountryId(Guid countryId)
        {
            var query = from fc in _context.FilmCountries()
                        where fc.CountryId.Equals(countryId)
                        select fc.FilmId;
            return query.ToList();
        }

        public override void Save()
        {
            _context.Save();
        }

        public override void Update(FilmCountry entity)
        {
            _context.StateChanged(entity);
            _context.Save();
        }
    }
}
