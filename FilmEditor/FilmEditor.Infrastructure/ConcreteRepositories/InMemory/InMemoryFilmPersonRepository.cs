using FilmEditor.Core.Interfaces;
using FilmEditor.Core.Abstractions;
using FilmEditor.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmEditor.Infrastructure.ConcreteRepositories.InMemory
{
    public class InMemoryFilmPersonRepository : AbstractFilmPersonRepository
    {
        private List<FilmPerson> _entities;
        public InMemoryFilmPersonRepository(List<FilmPerson> entities)
        {
            _entities = entities;
        }

        public override FilmPerson Add(FilmPerson entity)
        {
            if (entity == null) throw new Exception("Null Argument");
            if (entity.Id.Equals(Guid.Empty))
            {
                entity.Id = Guid.NewGuid();
                _entities.Add(entity);
            }
            return (FilmPerson)entity.Clone();
        }

        public override void Delete(FilmPerson entity)
        {
            _entities.Remove(entity);
        }

        public override FilmPerson GetById(Guid id)
        {
            FilmPerson entity = _entities.Single(fp => fp.Id.Equals(id));
            return (entity == null) ? null : (FilmPerson)entity.Clone();
        }

        public override IEnumerable<FilmPerson> List()
        {
            return _entities;
        }

        public override List<Guid> ListFilmIdsForPersonIdAndRole(Guid personId, Role role)
        {
            var query = from fp in _entities
                        where fp.PersonId.Equals(personId) && fp.Roles.Contains(role)
                        select fp.FilmId;
            return query.ToList();
        }




        public override List<Guid> ListPersonIdsForilmIdAndRole(Guid filmId, Role role)
        {
            var query = from fp in _entities
                        where fp.FilmId == filmId && fp.Roles.Contains(role)
                        select fp.PersonId;
            return query.ToList();
        }

        public override void Save()
        {
            // noop
        }

        public override void Update(FilmPerson entity)
        {
            FilmPerson storedEntity = _entities.Single(fp => fp.Id.Equals(entity.Id));
            storedEntity.Copy(entity);
        }
    }
}
