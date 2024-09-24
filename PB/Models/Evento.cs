using PB.Models;
using System.ComponentModel.DataAnnotations;

namespace PB.Models
{
    public class Evento
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Localizacao { get; set; }
        public DateTime Data { get; set; }
        public Artista Artista { get; set; }
        public List<Avaliacao> Avalicoes { get; set; } = new List<Avaliacao>();
    }
}
