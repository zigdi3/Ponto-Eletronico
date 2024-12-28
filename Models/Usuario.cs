using Microsoft.AspNetCore.Identity;

namespace PontoEletronico.Models
{
    public class Usuario : IdentityUser
    {
        public string Nome { get; set; } = string.Empty;
        public ICollection<RegistroPonto> RegistrosPonto { get; set; }
    }
}
