using Agenda.Application.ViewModels.Interfaces;
using Agenda.Domain.DTOs;
using Agenda.Domain.Model;
using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Controllers.v1
{
    [ApiController]
    [Route("[controller]")]
    [ApiVersion(1.0)]

    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRespositorio _usuarioRespositorio;
        private readonly ILogger<UsuarioController> _logger;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioRespositorio usuarioRespositorio, ILogger<UsuarioController> logger, IMapper mapper)
        {
            _usuarioRespositorio = usuarioRespositorio ?? throw new ArgumentNullException(nameof(usuarioRespositorio));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<UsuarioDTO>>> BuscarTodosUsuarios(int paginaNumero, int quantidadePaginas)
        {
            // throw new Exception("erro de teste");
            List<UsuarioDTO> usuarios = await _usuarioRespositorio.BuscarTodosUsuarios(paginaNumero, quantidadePaginas);
            return Ok(usuarios);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            UsuarioModel usuarios = await _usuarioRespositorio.BuscarPorId(id);
            return Ok(usuarios);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioRespositorio.Adicionar(usuarioModel);
            return Ok(usuario);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.Id = id;
            UsuarioModel usuario = await _usuarioRespositorio.Atualizar(usuarioModel, id);
            return Ok(usuario);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar(int id)
        {
            bool apagado = await _usuarioRespositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
