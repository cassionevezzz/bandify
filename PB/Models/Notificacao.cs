using Microsoft.EntityFrameworkCore.Query;
using System.ComponentModel.DataAnnotations;

namespace PB.Models
{
    public class Notificacao
    {
        [Key]
        public int Id {  get; set; } 
        public string TipoNotificao { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataEnvio { get; set; }
    }
}
