using DesafioCursos.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCursos.DTO
{
    public class CadastrarCursoDTO
    {
        public string NomeDoCurso { get; set; }
        public int DuracaoEmMeses { get; set; }
        public StatusEnum Status { get; set; }
    }
}
