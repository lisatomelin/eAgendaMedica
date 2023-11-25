using eAgendaMedica.Domínio.Compartilhado;
using FluentValidation;


namespace eAgendaMedica.Dominio.ModuloMedico
{
    public class ValidadorMedico : AbstractValidator<Medico>
    {
        public ValidadorMedico()
        {
            RuleFor(x => x.Nome)
                .NotNull().NotEmpty().Length(2).Matches("^[A-Za-zÀ-ÿ ]+$");

            RuleFor(x => x.Telefone)
               .Telefone();

            RuleFor(x => x.Crm)
                    .CrmMedico().NotNull().NotEmpty();
        }
    }
}
