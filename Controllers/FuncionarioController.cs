using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using RH.DTO;
using RH.Enums;
using RH.Models;
using RH.Repositories;

namespace RH.Controllers
{
    [Route("[controller]")]
    [ApiController]
 
    public class FuncionarioController : ControllerBase
    {
        [HttpPost]
        [Route("cadastrar-novo-funcionario")]
        [Authorize(Roles = "Administrador")]
        public IActionResult CadastrarNovoFuncionario([FromBody]FuncionarioDTO Funcionario)
        {
            FuncionarioRepository.Adicionar(new Funcionario { Nome = Funcionario.Nome, Salario = Funcionario.Salario, Senha = Funcionario.Senha, Permissao = (Permissoes) Funcionario.Permissao});
            return Created("", Funcionario);
        }

        [HttpDelete]
        [Route("excluir-funcionario/{id}")]
        [Authorize(Roles = "Administrador,Gerente")]
        public IActionResult ExcluirFuncionario([FromRoute]int id)
        {
            var f = FuncionarioRepository.Obter().Find(x=> x.Id == id);
           if(f.Permissao == Enums.Permissoes.Funcionario)
            {
                FuncionarioRepository.Remover(f);
                return Ok();
            }
            if (f == null)
                return NotFound("Funcionário Não Encontrado");
           
            return BadRequest($"Não foi possivel excluir este funcionário, pois ele possue permissão de {f.NomePermissao}");
        }

        [HttpDelete]
        [Route("excluir-gerente/{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult ExcluirGerente([FromRoute] int id)
        {
            var f = FuncionarioRepository.Obter().Find(x => x.Id == id);
            if (f.Permissao == Enums.Permissoes.Gerente)
            {
                FuncionarioRepository.Remover(f);
                return Ok();
            }
            if (f == null)
                return NotFound("Funcionário Não Encontrado");

            return BadRequest($"Não foi possivel excluir este funcionário, pois ele possue permissão de {f.NomePermissao}");
        }

        [HttpPatch]
        [Route("alterar-salario")]
        [Authorize(Roles = "Gerente")]
        public IActionResult AlterarSalario([FromBody] Funcionario f)
        {
            FuncionarioRepository.Editar(f, f.Id);
            return Ok();
        }

        [HttpGet]
        [Route("listar")]
        [Authorize]
        public IActionResult Listar()
        =>User.IsInRole(Permissoes.Funcionario.GetDisplayName())
            ? Ok(FuncionarioRepository.Obter().Select(x=>new {x.Nome, x.NomePermissao}))
            : Ok(FuncionarioRepository.Obter());


          

        
    }
}
