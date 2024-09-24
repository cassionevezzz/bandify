using System.ComponentModel.DataAnnotations;

namespace PB.Models
{
    public class Avaliacao
    {
        [Key]
        public int Id { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataPublicada { get; set; }
        public Usuario Usuario { get; set; }
        public Evento Evento { get; set; }
    }
}
