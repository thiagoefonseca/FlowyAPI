using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using FlowyAPI.Models;
using FlowyAPI.Models.Enuns;
using FlowyAPI.Data;
using Microsoft.EntityFrameworkCore;
using FlowyAPI.Extensions;

namespace FlowyAPI.Controllers
{
//  [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PaginaController : ControllerBase
    {
        private readonly DataContext _context;

        public PaginaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Pagina> lista = await _context.TB_PAGINAS.ToListAsync();
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
                Pagina p = await _context.TB_PAGINAS
                    .FirstOrDefaultAsync(pBusca => pBusca.Id == id);

                return Ok(p);
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

                List<Pagina> lista = await _context.TB_PAGINAS
                    .Where(u => u.UsuarioId == id).ToListAsync();

                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByPerfil")]
        public async Task<IActionResult> GetByPerfilAsync()
        {
            try
            {
                List<Pagina> lista = new List<Pagina>();

                if (User.UsuarioPerfil() == "Admin")
                    lista = await _context.TB_PAGINAS.ToListAsync();
                else
                    lista = await _context.TB_PAGINAS
                            .Where(p => p.Usuario.Id == User.UsuarioId()).ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Pagina novaPagina)
        {
            try
            {
                if (string.IsNullOrEmpty(novaPagina.tituloPagina))
                {
                    throw new Exception("Pagina precisa ter um titulo!");
                }
                else if (HumorEnum.IsDefined(novaPagina.Humor) == false)
                {
                    throw new Exception("Você não tem humor não!?");
                }

                novaPagina.Usuario = await _context.TB_USUARIOS.FirstOrDefaultAsync(uBusca => uBusca.Id == User.UsuarioId());

                novaPagina.qtdCaracteresPagina = novaPagina.contPagina.Length;
                novaPagina.dtCriacaoPagina = DateTime.Now;
                await _context.TB_PAGINAS.AddAsync(novaPagina);
                await _context.SaveChangesAsync();

                return Ok(novaPagina.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Pagina novaPagina)
        {
            try
            {
                if (string.IsNullOrEmpty(novaPagina.tituloPagina))
                {
                    throw new Exception("Pagina precisa ter um titulo!");
                }
                else if (HumorEnum.IsDefined(novaPagina.Humor) == false)
                {
                    throw new Exception("Você não tem humor não!?");
                }

                novaPagina.Usuario = await _context.TB_USUARIOS.FirstOrDefaultAsync(uBusca => uBusca.Id == User.UsuarioId());

                _context.TB_PAGINAS.Update(novaPagina);
                novaPagina.qtdCaracteresPagina = novaPagina.contPagina.Length;
                novaPagina.dtModificacaoPagina = DateTime.Now;
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
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
                Pagina pRemover = await _context.TB_PAGINAS.FirstOrDefaultAsync(p => p.Id == id);

                _context.TB_PAGINAS.Remove(pRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();
                pRemover.dtExclusaoPagina = DateTime.Now;
                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}