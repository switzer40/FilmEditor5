using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmEditor.Core.Interfaces;
using FilmEditor.Infrastructure.DAL;
using FilmEditor.Core.Model;
using FilmEditor.Core.Abstractions;
using System.Data.Entity;

namespace FilmEditor.Infrastructure.ConcreteRepositories.EntityFramework
{
    public class EFLocationRepository : AbstractLocationRepository
    {
        private readonly IFilmContext _context;
        public EFLocationRepository(IFilmContext context)
        {
            _context = context;
        }

        public override Location Add(Location entity)
        {
            if (entity.Id.Equals(Guid.Empty))
                _context.Locations().Add(entity);
            return (entity == null) ? null : (Location)entity.Clone();
        }

        public override void Delete(Location entity)
        {
            _context.Locations().Remove(entity);
        }



        public override Location GetByDescription(string description)
        {
            Location result = _context.Locations().Single(l => l.Description.Contains(description));
            return (result == null) ? null : (Location)result.Clone();
        }

        public override Location GetById(Guid id)
        {
            Location entity = _context.Locations().Single(l => l.Id.Equals(id));
            return (entity == null) ? null : (Location)entity.Clone();
        }

        public override IEnumerable<Location> List()
        {
            return _context.Locations();
        }

        public override void Save()
        {
            _context.Save();
        }

        public override void Update(Location entity)
        {
            _context.StateChanged(entity);
            _context.Save();
        }
    }
}
