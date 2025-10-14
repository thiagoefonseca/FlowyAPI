using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlowyAPI.Models
{
    public class Quest
    {
        public int Id { get; set; }
        public string descricao { get; set; } = string.Empty;
        public int qtdXpResgatavel { get; set; }
        public int idDificuldade { get; set; }
        public int idPerfil { get; set; }

        [NotMapped]
        public Perfil? Perfil { get; set; }
    }
}