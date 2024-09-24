using PB.Models;
using System.ComponentModel.DataAnnotations;

namespace PB.Models
{
    public class Artista
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Nome do Artista é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Gênero do Artista é obrigatório")]
        public string Genero { get; set; }
        [Required(ErrorMessage = "Descrição do Artista é obrigatório")]
        public string Descricao { get; set; }
        public string PhotoUrl { get; set; }
        public List<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();
    }
}
