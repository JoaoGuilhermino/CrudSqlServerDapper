using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudSqlServerDapper.Entities;
using FluentValidation;

namespace CrudSqlServerDapper.Validators
{
    /// <summary>
    /// Classe para validação de dados da entidade Cliente.
    /// </summary>
    public class ClientValidator : AbstractValidator<Client>
    {
        //Método construtor da classe
        public ClientValidator()
        {
            //Validação do nome do cliente
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Por favor, preencha o nome do cliente.")
                .MinimumLength(6).WithMessage("Por favor, informe o nome do cliente com pelo menos 6 caracteres.");

            //Validação do email do cliente
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Por favor, preencha o email do cliente.")
                .EmailAddress().WithMessage("Por favor, informe um email válido.");

            //Validação da data de nascimento do cliente
            RuleFor(c => c.BirthDate)
                .LessThan(DateTime.Today).WithMessage("A data de nascimento deve ser anterior a hoje.");


        }

    }
}
