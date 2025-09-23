using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FlowyAPI.Data;
using FlowyAPI.Extensions;
using FlowyAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace FlowyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciciosController : ControllerBase
    {
        private readonly DataContext _context;

        public ExerciciosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Exercicio> lista = await _context.tbl_exercicios.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Exercicio e = await _context.tbl_exercicios
                    .FirstOrDefaultAsync(eBusca => eBusca.Id == id);

                return Ok(e);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByUser")]
        public async Task<IActionResult> GetByUserAsync()
        {
            try
            {
                int id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

                List<Exercicio> lista = await _context.tbl_exercicios
                    .Where(u => u.UsuarioId == id).ToListAsync();

                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Exercicio novoExercicio)
        {
            try
            {
                if (string.IsNullOrEmpty(novoExercicio.atividade))
                {
                    throw new Exception("Exercicio precisa ter uma atividade!");
                }
                else if (novoExercicio.dataTermino == DateTime.Now || novoExercicio.dataTermino == DateTime.MinValue)
                {
                    throw new Exception("Você precisa digitar um tempo!");
                }
                else if (novoExercicio.quantidade <= 0)
                {
                    throw new Exception("Você precisa adicionar uma quantidade!");
                }

                novoExercicio.Usuario = await _context.tbl_usuario.FirstOrDefaultAsync(uBusca => uBusca.Id == User.UsuarioId());

                novoExercicio.dataTermino = DateTime.Now.AddMinutes(novoExercicio.relogio);
                novoExercicio.tempo = novoExercicio.dataTermino - DateTime.Now;
                await _context.tbl_exercicios.AddAsync(novoExercicio);
                await _context.SaveChangesAsync();

                return Ok(novoExercicio.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Exercicio novoExercicio)
        {
            try
            {
                if (string.IsNullOrEmpty(novoExercicio.atividade))
                {
                    throw new Exception("Exercicio precisa ter uma atividade!");
                }
                else if (novoExercicio.dataTermino == DateTime.Now || novoExercicio.dataTermino == DateTime.MinValue)
                {
                    throw new Exception("Você precisa digitar um tempo!");
                }
                else if (novoExercicio.quantidade <= 0)
                {
                    throw new Exception("Você precisa adicionar uma quantidade!");
                }

                novoExercicio.Usuario = await _context.tbl_usuario.FirstOrDefaultAsync(uBusca => uBusca.Id == User.UsuarioId());

                novoExercicio.dataTermino = DateTime.Now.AddMinutes(novoExercicio.relogio);
                novoExercicio.tempo = novoExercicio.dataTermino - DateTime.Now;
                _context.tbl_exercicios.Update(novoExercicio);
                await _context.SaveChangesAsync();

                return Ok(novoExercicio.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Exercicio eRemover = await _context.tbl_exercicios.FirstOrDefaultAsync(e => e.Id == id);

                _context.tbl_exercicios.Remove(eRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();
                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}