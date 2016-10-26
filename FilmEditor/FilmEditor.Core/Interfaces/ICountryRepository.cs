using FilmEditor.Core.Model;

namespace FilmEditor.Core.Interfaces
{
    public interface ICountryRepository : IRepository<Country>
    {
        Country GetByAbbreviation(string abbreviation);
    }
}
