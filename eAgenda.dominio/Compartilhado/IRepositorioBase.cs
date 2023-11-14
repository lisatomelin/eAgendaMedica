
namespace eAgendaMedica.Dominio.Compartilhado
{
    public interface IRepositorioBase<TEntidade> where TEntidade : Entidade
    {
        void Editar(TEntidade registro);
        void Excluir(TEntidade registro);
        Task<bool> InserirAsync(TEntidade registro);
        Task<TEntidade> SelecionarPorIdAsync(Guid Id);
        Task<List<TEntidade>> SelecionarTodosAsync();
    }
}
