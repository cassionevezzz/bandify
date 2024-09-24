namespace PB.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<PB.Models.Artista> Artistas { get; set; }
        public IEnumerable<PB.Models.Evento> Eventos { get; set; }
    }
}
