namespace eAgendaMedica.WebApi.ViewModels
{



    public class InserirMedicoViewModel
    {

        public string CRM { get; set; }
        public string Nome { get; set; }

        public string Telefone { get; set; }
    }

    public class EditarMedicoViewModel
    {

        public string CRM { get; set; }
        public string Nome { get; set; }

        public string Telefone { get; set; }
    }

    public class ListarMedicoViewModel
    {
        public Guid Id { get; set; }
        public string CRM { get; set; }
        public string Nome { get; set; }

    }

    public class VisualizarMedicoViewModel
    {
        public Guid Id { get; set; }
        public string CRM { get; set; }
        public string Nome { get; set; }

        public string Telefone { get; set; }


        public List<ListarCirurgiaViewModel> cirurgias { get; set; }

        public List<ListarConsultaViewModel> consultas { get; set; }
    }



}
