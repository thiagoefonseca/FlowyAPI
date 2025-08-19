using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using FlowyAPI.Models;

namespace FlowyAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public byte[]? PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime? DataAcesso { get; set; }

        [NotMapped]
        public string PasswordString { get; set; }
        public List<Pagina> Paginas { get; set; } = new List<Pagina>();
        public string? Perfil { get; set; }
        public string? Email { get; set; }
    }
}