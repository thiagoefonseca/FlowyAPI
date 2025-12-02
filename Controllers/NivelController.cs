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
    public class NivelController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        public NivelController(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Nivel> lista = await _context.tbl_nivel.ToListAsync();
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
                Perfil p = await _context.tbl_perfil
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

                List<Pagina> lista = await _context.tbl_pagina
                    .Where(u => u.UsuarioId == id).ToListAsync();

                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(Nivel novoNivel)
        {
            try
            {
                if (novoNivel.idPerfil == 0)
                    throw new System.Exception("Nivel precisa ser atrelado a um perfil");

                //novoNivel.Perfil = await _context.tbl_perfil.FirstOrDefaultAsync(uBusca => uBusca.Id == User.idPerfil());

                await _context.tbl_nivel.AddAsync(novoNivel);
                await _context.SaveChangesAsync();

                return Ok(novoNivel.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}