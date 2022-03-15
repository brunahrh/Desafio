using DesafioCursos.Enum;
using DesafioCursos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCursos.Repository.Interfaces
{
    public interface ICursoRepository
    {
        IEnumerable<CursosModel> ObterTodosCursos();
        IEnumerable<CursosModel> ObterCursosPorStatus(StatusEnum statusEnum);
    }
}
