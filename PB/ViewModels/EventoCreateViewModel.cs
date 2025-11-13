using PB.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

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
        [ValidateNever]
        public List<Artista> Artistas { get; set; }
    }
}
