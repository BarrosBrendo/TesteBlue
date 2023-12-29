using Agenda.Application.ViewModels.Interfaces;
using Agenda.Data;
using Agenda.Domain.DTOs;
using Agenda.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Application.ViewModels
{
    public class UsuarioRepositorio : IUsuarioRespositorio
    {
        private readonly SistemaAgendaDBContex _dbContext;
        public UsuarioRepositorio(SistemaAgendaDBContex sistemaTarefasDBContex)
            => _dbContext = sistemaTarefasDBContex;

        public async Task<UsuarioModel> BuscarPorId(int id)
            => await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<UsuarioDTO>> BuscarTodosUsuarios(int paginaNumero, int quantidadePaginas)
            => await _dbContext.Usuarios.Skip(paginaNumero * quantidadePaginas)
            .Take(quantidadePaginas)
            .Select( b => 
            new UsuarioDTO()
            {
                Id = b.Id,  
                Nome = b.Nome,
            }).ToListAsync();

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;
            usuarioPorId.Telefone = usuario.Telefone;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }

    }
}
