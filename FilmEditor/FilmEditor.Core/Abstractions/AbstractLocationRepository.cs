using FilmEditor.Core.Interfaces;
using FilmEditor.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmEditor.Core.Abstractions
{
    public abstract class AbstractLocationRepository : IRepository<Location>, ILocationRepository
    {
        public abstract Location Add(Location entity);
        public void AddRange(List<Location> list)
        {
            foreach (Location l in list) Add(l);
            Save();
        }
        public abstract void Delete(Location t);
        public abstract Location GetByDescription(string description);
        public abstract Location GetById(Guid id);
        public abstract IEnumerable<Location> List();
        public abstract void Save();
        public abstract void Update(Location t);
    }
}
