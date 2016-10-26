using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FilmEditor.Core.Model;

namespace FilmEditor.Infrastructure.DAL
{
    public interface IFilmContext
    {
        IDbSet<Film> Films();
        IDbSet<Person> People();
        IDbSet<Country> Countries();
        IDbSet<Location> Locations();
        IDbSet<FilmCountry> FilmCountries();
        IDbSet<FilmPerson> FilmPeople();
        void Save();
        void StateChanged(Entity entity);
    }
}
