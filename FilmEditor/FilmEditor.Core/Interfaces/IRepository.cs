using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmEditor.Core.Interfaces
{
    public interface IRepository<T> where T : Model.Entity
    {
        IEnumerable<T> List();

        T Add(T entity);
        void AddRange(List<T> list);
        void Delete(T t);
        void Update(T t);
        T GetById(Guid id);
        void Save();
    }
}
