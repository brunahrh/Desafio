using AutoMapper;
using DesafioCursos.DTO;
using DesafioCursos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCursos.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CursosModel, CadastrarCursoDTO>()
                .ReverseMap();
        }
    }
}
