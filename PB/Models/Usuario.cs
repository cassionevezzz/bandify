using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PB.Models
{
    public class Usuario
    {
        [Key]
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Localizacao { get; set; }
        public List<Artista> ArtistasFavoritos { get; set; } = new List<Artista>();
        public List<Evento> EventosComparecidos { get; set; } = new List<Evento>();
    }
}
