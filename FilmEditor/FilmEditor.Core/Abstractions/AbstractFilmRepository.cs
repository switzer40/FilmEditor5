using FilmEditor.Core.Interfaces;
using FilmEditor.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmEditor.Core.Abstractions
{
    public abstract class AbstractFilmRepository : IRepository<Film>, IFilmRepository
    {
        public abstract Film Add(Film entity);
        public void AddRange(List<Film> list)
        {
            foreach (Film f in list) Add(f);
            Save();
        }
        public abstract void Delete(Film t);
        public abstract Film GetById(Guid id);

        public abstract Film GetFilmByTitleAndType(string title, bool bluray);

        public abstract IEnumerable<Film> List();
        public abstract void Save();
        public abstract void Update(Film t);


    }
}

