using FilmEditor.Core.Interfaces;
using FilmEditor.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmEditor.Core.Abstractions
{
    public abstract class AbstractFilmCountryRepository : IRepository<FilmCountry>, IFilmCountryRepository
    {
        public abstract FilmCountry Add(FilmCountry entity);
        public void AddRange(List<FilmCountry> list)
        {
            foreach (FilmCountry fc in list) Add(fc);
            Save();
        }
        public abstract void Delete(FilmCountry t);
        public abstract FilmCountry GetById(Guid id);
        public abstract IEnumerable<FilmCountry> List();
        public abstract List<Guid> ListCountryIdsForFilmId(Guid filmId);
        public abstract List<Guid> ListFilmIdsForCountryId(Guid countryId);
        public abstract void Save();
        public abstract void Update(FilmCountry t);
    }
}
