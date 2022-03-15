using DesafioCursos.Data;
using DesafioCursos.Enum;
using DesafioCursos.Model;
using DesafioCursos.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCursos.Repository
{
    public class CursoRepository : ICursoRepository
    {
        private readonly CursosContext _context;

        public CursoRepository(CursosContext context)
        {
            _context=context;
        }

        public IEnumerable<CursosModel> ObterCursosPorStatus(StatusEnum status)
        {
            var retorno = _context.CursosModel.Where(c => c.Status == status);
            return (retorno);
        }

        public IEnumerable<CursosModel> ObterTodosCursos()
        {
            return _context.CursosModel.ToList();
        }
    }
}
