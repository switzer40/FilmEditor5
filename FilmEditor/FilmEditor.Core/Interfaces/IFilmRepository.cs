using FilmEditor.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmEditor.Core.Interfaces
{
    public interface IFilmRepository
    {
        Film GetFilmByTitleAndType(string title, bool bluray);
    }
}
