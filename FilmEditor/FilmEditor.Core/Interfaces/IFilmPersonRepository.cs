using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmEditor.Core.Model;

namespace FilmEditor.Core.Interfaces
{
    public interface IFilmPersonRepository
    {
        List<Guid> ListFilmIdsForPersonIdAndRole(Guid personId, Role role);
        List<Guid> ListPersonIdsForilmIdAndRole(Guid filmId, Role role);
    }
}
