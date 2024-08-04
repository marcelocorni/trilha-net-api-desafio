using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TarefasCommon.Models;

namespace TarefasBlazor.Client.Services
{

    public class TarefaService : ITarefaService
    {
        private readonly HttpClient _httpClient;

        public TarefaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Tarefa>> ObterTodos()
        {
            try
            {
                var retorno = await _httpClient.GetStringAsync("/Tarefa/ObterTodos");
                var tarefas = JsonConvert.DeserializeObject<List<Tarefa>>(retorno);
                return tarefas == null ? new List<Tarefa>() : tarefas;
            }catch
            {
                return new List<Tarefa>();
            }
        }

        public async Task<Tarefa?> ObterPorId(int id)
        {
            try
            {
                var retorno = await _httpClient.GetStringAsync($"/Tarefa/{id}");
                var tarefa = JsonConvert.DeserializeObject<Tarefa>(retorno);
                return tarefa!;
            }catch
            {
                return null;
            }
        }

        public async Task<List<Tarefa>> ObterPorTitulo(string titulo)
        {
            try
            {
                var retorno = await _httpClient.GetStringAsync($"/Tarefa/ObterPorTitulo?titulo={titulo}");
                var tarefas = JsonConvert.DeserializeObject<List<Tarefa>>(retorno);
                return tarefas == null ? new List<Tarefa>() : tarefas;
            }
            catch
            {
                return new List<Tarefa>();
            }
        }

        public async Task<List<Tarefa>> ObterPorStatus(EnumStatusTarefa status)
        {
            try
            {
                var retorno = await _httpClient.GetStringAsync($"/Tarefa/ObterPorStatus?status={status}");
                var tarefas = JsonConvert.DeserializeObject<List<Tarefa>>(retorno);
                return tarefas == null ? new List<Tarefa>() : tarefas;
            }
            catch
            {
                return new List<Tarefa>();
            }
        }

        public async Task<List<Tarefa>> ObterPorData(DateTime data)
        {
            try 
            { 
                var retorno = await _httpClient.GetStringAsync($"/Tarefa/ObterPorData?data={data:yyyy-MM-dd}");
                var tarefas = JsonConvert.DeserializeObject<List<Tarefa>>(retorno);
                return tarefas == null ? new List<Tarefa>() : tarefas;
            }
            catch
            {
                return new List<Tarefa>();
            }
        }

        public async Task Adicionar(Tarefa tarefa)
        {
            try
            {
                await _httpClient.PostAsJsonAsync($"/Tarefa", tarefa);
            }
            catch
            {
                
            }
        }

        public async Task Atualizar(Tarefa tarefa)
        {
            try 
            { 
                await _httpClient.PutAsJsonAsync($"/Tarefa/{tarefa.Id}", tarefa);
            }
            catch
            {
                
            }
        }

        public async Task Excluir(int id)
        {
            try
            {
                await _httpClient.DeleteAsync($"/Tarefa/{id}");
            }
            catch
            {
                
            }
        }
    }

}
