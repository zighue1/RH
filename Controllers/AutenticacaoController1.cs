using autenticacao.Models;
using autenticacao.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RH.Repositories;

namespace RH.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public IActionResult login([FromBody] User user)
        {
            var func = FuncionarioRepository.ObterPorUsuarioESenha(user.Username, user.Password);
            if (func == null)
                return NotFound();
            var token = TokenService.GenerateToken(func);
            return Ok(new { token});
            
        }
    }
}
