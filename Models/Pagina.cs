using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using FlowyAPI.Models;
using FlowyAPI.Models.Enuns;

namespace FlowyAPI.Models
{
    public class Pagina
    {
        public int Id { get; set; }
        public int codDiario { get; set; }
        public HumorEnum Humor { get; set; }
        public string tituloPagina { get; set; } = string.Empty;
        public string temaPagina { get; set; } = string.Empty;
        public string contPagina { get; set; } = string.Empty;
        public int qtdCaracteresPagina { get; set; }
        public DateTime dtCriacaoPagina { get; set; }
        public DateTime dtExclusaoPagina { get; set; }
        public DateTime dtModificacaoPagina { get; set; }
        public int? UsuarioId { get; set; }

        [NotMapped]
        public Usuario? Usuario { get; set; }
       
    }
}