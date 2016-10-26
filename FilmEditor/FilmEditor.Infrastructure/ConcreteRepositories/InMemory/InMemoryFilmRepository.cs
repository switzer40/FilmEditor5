using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmEditor.Core.Abstractions;
using FilmEditor.Core.Model;

namespace FilmEditor.Infrastructure.ConcreteRepositories.InMemory
{
    public class InMemoryFilmRepository : AbstractFilmRepository
    {
        private readonly List<Film> _entities;
        public InMemoryFilmRepository(List<Film> entities)
        {
            _entities = entities; 
        }
        public override Film Add(Film entity)
        {
            if (entity == null) throw new Exception("Null Argument");
            if (entity.Id.Equals(Guid.Empty))
            {
                entity.Id = Guid.NewGuid();
                _entities.Add(entity);
            }
            return (Film)entity.Clone();
        }

        public override void Delete(Film t)
        {
            _entities.Remove(t);
        }

        public override Film GetById(Guid id)
        {
            Film entity = _entities.Single(f => f.Id.Equals(id));
            return (Film)entity.Clone();
        }

        public override Film GetFilmByTitleAndType(string title, bool bluray)
        {
            Film entity = _entities.Single(f => (f.Title.Contains(title) && f.IsBluray == bluray));
            return (Film)entity.Clone();
        }

        public override IEnumerable<Film> List()
        {
            return _entities;
        }

        public override void Save()
        {
            // noop
        }

        public override void Update(Film t)
        {
            Film entity = _entities.Single(f => f.Id.Equals(t.Id));
            entity.Copy(t);
        }
    }
}