using FilmEditor.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using FilmEditor.Core.Model;
using FilmEditor.Infrastructure.DAL;
using System.Data.Entity;

namespace FilmEditor.Infrastructure.ConcreteRepositories.EntityFramework
{
    public class EFFilmRepository : AbstractFilmRepository
    {
        private readonly IFilmContext _context;
        public EFFilmRepository(IFilmContext context)
        {
            _context = context;
        }
        public override Film Add(Film entity)
        {
            if (entity.Id.Equals(Guid.Empty))
                _context.Films().Add(entity);
            return (entity == null) ? null : (Film)entity.Clone();
        }

        public override void Delete(Film entity)
        {
            _context.Films().Remove(entity);
        }

        public override Film GetById(Guid id)
        {
            Film entity = _context.Films().Single(f => f.Id.Equals(id));
            return (entity == null) ? null : (Film)entity.Clone();
        }

        public override Film GetFilmByTitleAndType(string title, bool bluray)
        {
            Film entity = _context.Films().Single(f => (f.Title.Contains(title) && f.IsBluray == bluray));
            return (entity == null) ? null : (Film)entity.Clone();
        }

        public override IEnumerable<Film> List()
        {
            return _context.Films();
        }

        public override void Save()
        {
            _context.Save();
        }

        public override void Update(Film entity)
        {
            _context.StateChanged(entity);
            _context.Save();
        }
    }
}
