using PB.Models;
using System.ComponentModel.DataAnnotations;

namespace PB.ViewModels
{
    public class EventoCreateViewModel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Localizacao { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public int ArtistaId { get; set; }
        public List<Artista> Artistas { get; set; }
    }
}
