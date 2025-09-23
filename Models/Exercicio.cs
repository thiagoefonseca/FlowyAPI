using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace FlowyAPI.Models
{
    public class Exercicio
    {
        public int Id { get; set; }
        public string atividade { get; set; } = string.Empty;
        public string descricao { get; set; } = string.Empty;
        public DateTime dataTermino { get; set; }
        public TimeSpan tempo { get; set; }
        public int quantidade { get; set; }
        public double relogio { get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}