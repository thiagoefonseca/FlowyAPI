using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlowyAPI.Models
{
    public class Nivel
    {
        public int Id { get; set; }         
        public int nivelUsuario { get; set; }
        public int qtdXp { get; set; }
        public int idPerfil { get; set; }

        [NotMapped]
        public Perfil? Perfil { get; set; }
        
    }
}