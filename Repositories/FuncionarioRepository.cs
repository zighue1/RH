using RH.Enums;
using RH.Models;

namespace RH.Repositories
{
    public static class FuncionarioRepository
    {
     
        private static readonly List<Funcionario> funcionariosList = new List<Funcionario>() { new Funcionario { Id = 0, Nome = "Joao", Senha = "123", Permissao = Enums.Permissoes.Administrador } };
        private static int _id = 1;

        public static List<Funcionario> Obter() { 
        
            return funcionariosList;
        }

        public static Funcionario ObterPorUsuarioESenha(string nome, string senha)
        {
            Funcionario funcionario = null;
            funcionario = funcionariosList.FirstOrDefault(x => x.Nome == nome && x.Senha == senha);
            

            return funcionario;
        }

        public static void Adicionar(string nome, string senha, Permissoes permissao )
        {
            funcionariosList.Add(new Funcionario { Id = _id++, Nome = nome, Senha = senha, Permissao = permissao });
        }
        public static void Adicionar(Funcionario f)
        {
            f.Id = _id++;
            funcionariosList.Add(f);
        }

        public static void Editar(Funcionario f, int id)
        {
            Funcionario funcionario = funcionariosList.Find(x => x.Id == id);
            funcionario.Nome = f.Nome;
            funcionario.Senha = f.Senha;
            funcionario.Permissao = f.Permissao;
            funcionario.Salario = f.Salario;
        }

        public static void Remover(Funcionario f)
        {
            funcionariosList.Remove(f);
        }
    }
}
