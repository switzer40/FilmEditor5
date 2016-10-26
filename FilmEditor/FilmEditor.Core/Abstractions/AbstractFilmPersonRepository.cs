using FilmEditor.Core.Interfaces;
using FilmEditor.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmEditor.Core.Abstractions
{
    public abstract class AbstractFilmPersonRepository : IRepository<FilmPerson>, IFilmPersonRepository
    {
        public abstract FilmPerson Add(FilmPerson entity);
        public void AddRange(List<FilmPerson> list)
        {
            foreach (FilmPerson fp in list) Add(fp);
            Save();
        }
        public abstract void Delete(FilmPerson t);
        public abstract FilmPerson GetById(Guid id);
        public abstract IEnumerable<FilmPerson> List();
        public abstract List<Guid> ListFilmIdsForPersonIdAndRole(Guid personId, Role role);
        public abstract List<Guid> ListPersonIdsForilmIdAndRole(Guid filmId, Role role);
        public abstract void Save();
        public abstract void Update(FilmPerson t);
    }
}
