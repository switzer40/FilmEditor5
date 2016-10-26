using FilmEditor.Core.Interfaces;
using FilmEditor.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using FilmEditor.Core.Abstractions;
using FilmEditor.Infrastructure.DAL;
using System.Data.Entity;

namespace FilmEditor.Infrastructure.ConcreteRepositories.EntityFramework
{

    public class EFFilmPersonRepository : AbstractFilmPersonRepository
    {
        private readonly IFilmContext _context;
        public EFFilmPersonRepository(IFilmContext context)
        {
            _context = context;
        }

        public override FilmPerson Add(FilmPerson entity)
        {
            if (entity.Id.Equals(Guid.Empty))
            {
                _context.FilmPeople().Add(entity);
            }
            return (entity == null) ? null : (FilmPerson)entity.Clone();
        }

        public override void Delete(FilmPerson entity)
        {
            _context.FilmPeople().Remove(entity);
        }

        public override FilmPerson GetById(Guid id)
        {
            FilmPerson entity = _context.FilmPeople().Single(fp => fp.Id.Equals(id));
            return (entity == null) ? null : (FilmPerson)entity.Clone();
        }

        public override IEnumerable<FilmPerson> List()
        {
            return _context.FilmPeople();
        }



        public override List<Guid> ListFilmIdsForPersonIdAndRole(Guid personId, Role role)
        {
            var query = from fp in _context.FilmPeople()
                        where fp.PersonId == personId && fp.Roles.Contains(role)
                        select fp.FilmId;
            return query.ToList();
        }



        public override List<Guid> ListPersonIdsForilmIdAndRole(Guid filmId, Role role)
        {
            var query = from fp in _context.FilmPeople()
                        where fp.FilmId == filmId && fp.Roles.Contains(role)
                        select fp.PersonId;
            return query.ToList();
        }

        public override void Save()
        {
            _context.Save();
        }

        public override void Update(FilmPerson entity)
        {
            _context.StateChanged(entity);
            _context.Save();
        }
    }
}
