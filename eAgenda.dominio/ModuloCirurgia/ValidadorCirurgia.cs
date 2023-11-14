using FluentValidation;


namespace eAgendaMedica.Dominio.ModuloCirurgia
{
    public class ValidadorCirurgia : AbstractValidator<Cirurgia>
    {

        public ValidadorCirurgia()
        {
            RuleFor(x => x.Titulo).NotNull().NotEmpty();
        }
    }
}
