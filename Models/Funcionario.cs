using Microsoft.OpenApi.Extensions;
using RH.Enums;

namespace RH.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public decimal Salario { get; set; }
        public Permissoes Permissao { get; set; }
        public string NomePermissao => Permissao.GetDisplayName();

        public Funcionario()
        {

        }

    }
}
