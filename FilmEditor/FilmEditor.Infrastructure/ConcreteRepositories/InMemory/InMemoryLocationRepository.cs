using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmEditor.Core.Abstractions;
using FilmEditor.Core.Model;

namespace FilmEditor.Infrastructure.ConcreteRepositories.InMemory
{
    public class InMemoryLocationRepository : AbstractLocationRepository
    {
        private readonly List<Location> _entities;
        public InMemoryLocationRepository(List<Location> entities)
        {
            _entities = entities;
        }
        public override Location Add(Location entity)
        {
            if (entity == null) throw new Exception("Nuöö Argument");
            if (entity.Id.Equals(Guid.Empty))
            {
                entity.Id = Guid.NewGuid();
                _entities.Add(entity);
            }
            return (Location)entity.Clone();
        }

        public override void Delete(Location t)
        {
            _entities.Remove(t);
        }

        public override Location GetByDescription(string description)
        {
            Location loc = _entities.Single(l => l.Description.Contains(description));
            return (loc == null) ? null : (Location)loc.Clone();
        }

        public override Location GetById(Guid id)
        {
            Location loc = _entities.Single(l => l.Id.Equals(id));
            return (loc == null) ? null : (Location)loc.Clone();
        }

        public override IEnumerable<Location> List()
        {
            return _entities;
        }

        public override void Save()
        {
            // noop
        }

        public override void Update(Location t)
        {
            Location loc = _entities.Single(l => l.Id.Equals(t.Id));
            loc.Copy(t);
        }
    }
}
