using FilmEditor.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmEditor.Core.Model;
using FilmEditor.Core.Abstractions;
using FilmEditor.Infrastructure.DAL;
using System.Data.Entity;

namespace FilmEditor.Infrastructure.ConcreteRepositories.EntityFramework
{


    public class EFCountryRepository : AbstractCountryRepository
    {
        private readonly IFilmContext _context;
        public EFCountryRepository(IFilmContext context)
        {
            _context = context;
        }
        public override Country Add(Country entity)
        {
            if (entity.Id.Equals(Guid.Empty))
            {
                _context.Countries().Add(entity);
            }
            return (entity == null) ? null : (Country)entity.Clone();
        }

        public override void Delete(Country entity)
        {
            _context.Countries().Remove(entity);
        }

        public override Country GetByAbbreviation(string abbreviation)
        {
            Country result = _context.Countries().Single(c => c.Abbreviation == abbreviation);
            return (result == null) ? null : (Country)result.Clone();

        }

        public override Country GetById(Guid id)
        {
            Country result = _context.Countries().Single(c => c.Id.Equals(id));
            return (result == null) ? null : (Country)result.Clone();
        }

        public override IEnumerable<Country> List()
        {
            return _context.Countries();
        }

        public override void Save()
        {
            _context.Save();
        }

        public override void Update(Country entity)
        {
            _context.StateChanged(entity);
            _context.Save();
        }
    }
}
