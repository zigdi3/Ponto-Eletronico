namespace PontoEletronico.Models
{

    public class RegistroPonto
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public string Tipo { get; set; }
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }

}
