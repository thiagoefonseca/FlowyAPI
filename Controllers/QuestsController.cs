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

namespace FlowyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestsController : ControllerBase
    {
        private readonly DataContext _context;

        public QuestsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Quest> lista = await _context.tbl_quest.ToListAsync();
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
                Quest q = await _context.tbl_quest
                    .FirstOrDefaultAsync(qBusca => qBusca.Id == id);

                return Ok(q);
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

                List<Quest> lista = await _context.tbl_quest
                    .Where(u => u.idPerfil == id).ToListAsync();

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
                List<Quest> quest = new List<Quest>();

                if (User.UsuarioPerfil() == "Admin")
                    quest = await _context.tbl_quest.ToListAsync();
                else
                    quest = await _context.tbl_quest
                            .Where(q => q.Perfil.Id == User.UsuarioId()).ToListAsync();
                return Ok(quest);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Quest novaQuest)
        {
            try
            {
                if (string.IsNullOrEmpty(novaQuest.descricao))
                {
                    throw new Exception("A quest precisa ter uma descrição!");
                }
                else if (novaQuest.idDificuldade <= 0)
                {
                    throw new Exception("A quest precisa ter uma dificuldade valida");
                }
                else if (novaQuest.qtdXpResgatavel <= 0)
                {
                    throw new Exception("A quest precisa ter uma quantidade de xp resgatável maior que 0");
                }

                novaQuest.Perfil = await _context.tbl_perfil.FirstOrDefaultAsync(uBusca => uBusca.Id == User.UsuarioId());

                
                await _context.tbl_quest.AddAsync(novaQuest);
                await _context.SaveChangesAsync();

                return Ok(novaQuest.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Quest novaQuest)
        {
            try
            {
                if (string.IsNullOrEmpty(novaQuest.descricao))
                {
                    throw new Exception("A quest precisa ter uma descrição!");
                }
                else if (novaQuest.idDificuldade <= 0)
                {
                    throw new Exception("A quest precisa ter uma dificuldade");
                }
                else if (novaQuest.qtdXpResgatavel <= 0)
                {
                    throw new Exception("A quest precisa ter uma quantidade de xp resgatável maior que 0");
                }

                novaQuest.Perfil = await _context.tbl_perfil.FirstOrDefaultAsync(uBusca => uBusca.Id == User.UsuarioId());

                _context.tbl_quest.Update(novaQuest);
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
                Quest qRemover = await _context.tbl_quest.FirstOrDefaultAsync(p => p.Id == id);

                _context.tbl_quest.Remove(qRemover);
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