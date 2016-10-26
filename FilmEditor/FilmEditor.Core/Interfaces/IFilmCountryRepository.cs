using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmEditor.Core.Interfaces
{
    public interface IFilmCountryRepository
    {
        List<Guid> ListCountryIdsForFilmId(Guid filmId);
        List<Guid> ListFilmIdsForCountryId(Guid countryId);
    }
}
