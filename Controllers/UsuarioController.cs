using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PontoEletronico.Data;
using PontoEletronico.Helpers;
using PontoEletronico.Models;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;

namespace PontoEletronico.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly IConfiguration _configuration;
        public UsuarioController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string nome, string email, string senha)
        {
            var usuario = new Usuario
            {
                UserName = email,
                Email = email,
                Nome = nome
            };

            var result = await _userManager.CreateAsync(usuario, senha);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok("Usuário registrado com sucesso.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string senha)
        {
            var result = await _signInManager.PasswordSignInAsync(email, senha, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
                return Unauthorized("Credenciais inválidas.");

            var normalizedEmail = _userManager.NormalizeEmail(email);
            var usuario = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedUserName == normalizedEmail);
            if (usuario == null)
            {
                return Unauthorized("Usuário não encontrado.");
            }

            var roles = await _userManager.GetRolesAsync(usuario);

            var token = JwtTokenHelper.GenerateToken(
                usuario.Id,
                usuario.Email,
                roles,
                _configuration["Jwt:Key"] ?? "pontoEl&troniC0"
            );

            return Ok(new
            {
                access_token = token,
                exp = DateTime.UtcNow.AddHours(1)
            });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok("Logout realizado com sucesso.");
        }
    }
}