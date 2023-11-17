namespace eAgendaMedica.WebApi.ViewModels.MedicoViewModel
{
    public class ListarMedicoViewModel
    {
        public Guid Id { get; set; }
        public string CRM { get; set; }
        public string Nome { get; set; }

        public bool Disponivel { get; set; }

    }



}
