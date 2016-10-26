using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using FilmEditor.Core.Model;

namespace FilmEditor.Infrastructure.DAL
{
    public class FilmContext : DbContext, IFilmContext
    {
        public FilmContext() : base("FilmContext")
        {
        }
        public DbSet<Film> Films { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<FilmPerson> FilmPeople { get; set; }
        public DbSet<FilmCountry> FilmCountries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        IDbSet<Film> IFilmContext.Films()
        {
            return Films;
        }

        IDbSet<Person> IFilmContext.People()
        {
            return People;
        }

        IDbSet<Country> IFilmContext.Countries()
        {
            return Countries;
        }

        IDbSet<Location> IFilmContext.Locations()
        {
            return Locations;
        }

        IDbSet<FilmCountry> IFilmContext.FilmCountries()
        {
            return FilmCountries;
        }

        IDbSet<FilmPerson> IFilmContext.FilmPeople()
        {
            return FilmPeople;
        }

        public void Save()
        {
            SaveChanges();
        }

        public void StateChanged(Entity entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}
