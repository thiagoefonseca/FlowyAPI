using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlowyAPI.Models
{
    public class Perfil
    {
        public int Id { get; set; }
        public string infoPerfil { get; set; } = string.Empty;
        public string nomePerfil { get; set; } = string.Empty;
        public int IdNivel { get; set; }
        public int UsuarioId { get; set; }
        public int? IdQuest { get; set; }

        [NotMapped]
        public Usuario? Usuario { get; set; }

        [NotMapped]
        public Nivel? Nivel { get; set; }
       

    }
}