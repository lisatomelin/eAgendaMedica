namespace eAgendaMedica.WebApi.ViewModels
{

    public class InserirMedicoViewModel
    {
        public Guid Id { get; set; }
        public string CRM { get; set; }
        public string Nome { get; set; }

        public string Telefone { get; set; }

        public bool Disponivel { get; set; }
    }

    public class EditarMedicoViewModel
    {
        public Guid Id { get; set; }
        public string CRM { get; set; }
        public string Nome { get; set; }

        public string Telefone { get; set; }

        public bool Disponivel { get; set; }
    }

    public class ListarMedicoViewModel
    {
        public Guid Id { get; set; }
        public string CRM { get; set; }
        public string Nome { get; set; }

        public bool Disponivel { get; set; }

    }

    public class VisualizarMedicoViewModel
    {
        public Guid Id { get; set; }
        public string CRM { get; set; }
        public string Nome { get; set; }

        public string Telefone { get; set; }

        public bool Disponivel { get; set; }


    }



}
