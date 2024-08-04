using TarefasCommon.Models;

namespace TarefasBlazor.Client.Services
{
    public interface ITarefaService
    {
        Task<List<Tarefa>> ObterTodos();
        Task<Tarefa?> ObterPorId(int id);
        Task<List<Tarefa>> ObterPorTitulo(string titulo);
        Task<List<Tarefa>> ObterPorStatus(EnumStatusTarefa status);
        Task<List<Tarefa>> ObterPorData(DateTime data);
        Task Adicionar(Tarefa tarefa);
        Task Atualizar(Tarefa tarefa);
        Task Excluir(int id);
    }
}
