using FilmEditor.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmEditor.Core.Interfaces
{
    public interface ILocationRepository
    {
        Location GetByDescription(string description);
    }
}
