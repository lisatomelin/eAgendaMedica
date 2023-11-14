using FluentValidation;

namespace eAgendaMedica.Dominio.ModuloConsulta
{
    public class ValidadorConsulta : AbstractValidator<Consulta>
    {
        public ValidadorConsulta()
        {
            RuleFor(x => x.Medico).NotNull().NotEmpty();
        }
    }
}
