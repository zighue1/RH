

using System.ComponentModel.DataAnnotations;

namespace RH.Enums
{
    public enum Permissoes : int
    {
        [Display(Name = "Funcionário")]
        Funcionario = 0,
        [Display(Name = "Gerente")]
        Gerente = 1,
        [Display(Name = "Administrador")]
        Administrador = 2
    }
}
