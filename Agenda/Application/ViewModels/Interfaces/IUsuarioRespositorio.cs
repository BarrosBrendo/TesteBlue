using Agenda.Domain.DTOs;
using Agenda.Domain.Model;

namespace Agenda.Application.ViewModels.Interfaces
{
    public interface IUsuarioRespositorio
    {
        Task<List<UsuarioDTO>> BuscarTodosUsuarios(int paginaNumero, int quantidadePaginas);
        Task<UsuarioModel> BuscarPorId(int id);
        Task<UsuarioModel> Adicionar(UsuarioModel usuario);
        Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id);
        Task<bool> Apagar(int id);
    }
}
