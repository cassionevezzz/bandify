using System.ComponentModel.DataAnnotations;

namespace PB.Models
{
    public class Recomendacao
    {
        [Key]
        public int Id { get; set; }
        public string TipoRecomendacao { get; set; }
        public string Genero { get; set; }
        public string Nome { get; set; } 
    }
}
