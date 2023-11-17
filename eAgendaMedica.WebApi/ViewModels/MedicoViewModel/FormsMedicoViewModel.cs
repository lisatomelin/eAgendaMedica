namespace eAgendaMedica.WebApi.ViewModels.MedicoViewModel
{
    public class FormsMedicoViewModel
    {
        public Guid Id { get; set; }
        public string CRM { get; set; }
        public string Nome { get; set; }

        public string Telefone { get; set; }

        public bool Disponivel { get; set; }
    }



}
