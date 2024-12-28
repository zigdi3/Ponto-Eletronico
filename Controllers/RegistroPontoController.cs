using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PontoEletronico.Data;
using PontoEletronico.Models;
using System.Security.Claims;

namespace PontoEletronico.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RegistroPontoController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly UserManager<Usuario> _userManager;

        public RegistroPontoController(DataContext context, UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> RegistrarPonto(string tipo)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var usuario = await _userManager.FindByIdAsync(userId);

            if (usuario == null)
                return Unauthorized();

            var registro = new RegistroPonto
            {
                DataHora = DateTime.Now,
                Tipo = tipo.ToUpper(),
                Usuario = usuario
            };

            _context.RegistrosPonto.Add(registro);
            await _context.SaveChangesAsync();

            return Ok("Ponto registrado com sucesso.");
        }

        [HttpGet("meus-registros")]
        public async Task<IActionResult> MeusRegistros()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            var registros = await _context.RegistrosPonto
                .Where(r => r.UsuarioId == userId)
                .ToListAsync();

            return Ok(registros);
        }
}
}