using FilmEditor.Core.Interfaces;
using FilmEditor.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmEditor.Core.Interfaces;

namespace FilmEditor.Core.Abstractions
{
    public abstract class AbstractCountryRepository : IRepository<Country>, ICountryRepository
    {
        public abstract Country Add(Country entity);


        public void AddRange(List<Country> list)
        {
            foreach (Country c in list)
            {
                Add(c);
            }
        }

        public abstract void Delete(Country t);


        public abstract Country GetByAbbreviation(string abbreviation);


        public abstract Country GetById(Guid id);


        public abstract IEnumerable<Country> List();


        public abstract void Save();

        public abstract void Update(Country t);

    }
}
