using DesafioCursos.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCursos.Model
{
    public partial class CursosModel
    {
        public int Id { get; set; }
        public string NomeDoCurso { get; set; }
        public int DuracaoEmMeses { get; set; }
        public StatusEnum Status { get; set; }
        public CursosModel(int id, string nomeDoCurso, int duracaoEmMeses, StatusEnum status)
        {
            Id = id;
            NomeDoCurso = nomeDoCurso;
            DuracaoEmMeses = duracaoEmMeses;
            Status = status;
        }
    }
}
