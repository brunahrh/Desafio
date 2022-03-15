using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DesafioCursos.Data;
using DesafioCursos.Model;
using DesafioCursos.Repository;
using DesafioCursos.Repository.Interfaces;
using DesafioCursos.Enum;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using DesafioCursos.DTO;
using AutoMapper;

namespace DesafioCursos.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly CursosContext _context;
        private readonly ICursoRepository _repository;

        public CursosController(CursosContext context, ICursoRepository repository)
        {
            _context = context;
            _repository = repository;
        }
        // GET: api/Cursos
        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetCursosModel()
        {
            var retorno = _repository.ObterTodosCursos();
            return Ok(retorno);
        }
        // GET: api/Cursos/5
        [AllowAnonymous]
        [HttpGet("CursosPorStatus")]
        public ActionResult Get(StatusEnum statusEnum)
        {
            var retorno = _repository.ObterCursosPorStatus(statusEnum);

            if (!retorno.Any())
            {
                return NotFound($"Não foi encontrado nenhum curso com status " + statusEnum);
            }

            return Ok(retorno);
        }

        // POST: api/Cursos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Gerente, Secretario")]
        [HttpPost]
        public async Task<ActionResult<CursosModel>> PostCursosModel(CursosModel cursos, StatusEnum status)
        {
            cursos.Status = status;

            await _context.CursosModel.AddAsync(cursos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCursosModel", new { id = cursos.Id }, cursos);
        }

        [Authorize(Roles = "Gerente, Secretario")]
        [HttpPut("AtualizarStatus")]
        public ActionResult<CursosModel> AtualizarStatus(int Id, StatusEnum status)
        {
            CursosModel cursos = _context.CursosModel.Find(Id);

            if(cursos == null)
            {
                return NotFound($"Nenhum curso com Id "+ Id + " foi encontrado");
            }
            cursos.Status = status;
            _context.SaveChanges();

            return Ok("Status atualizado com sucesso!");
        }

        // DELETE: api/Cursos/5
        [Authorize(Roles = "Gerente")]
        [HttpDelete("DeletarCurso")]
        public async Task<IActionResult> DeleteCursosModel(int id)
        {
            var cursosModel = await _context.CursosModel.FindAsync(id);
            if (cursosModel == null)
            {
                return NotFound($"Nenhum curso com Id "+ id + " foi encontrado");
            }

            _context.CursosModel.Remove(cursosModel);
            await _context.SaveChangesAsync();

            return Ok("Curso deletado com sucesso!");
        }

        private bool CursosModelExists(int id)
        {
            return _context.CursosModel.Any(e => e.Id == id);
        }
    }
}
