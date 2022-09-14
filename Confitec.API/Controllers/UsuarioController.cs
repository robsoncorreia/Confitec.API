using Confitec.Aplicacao.Aplicacao;
using Confitec.Aplicacao.Interface;
using Confitec.Entidade.Entidade;
using Confitec.Infraestrutura.Configuracao;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confitec.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IAplicacaoUsuario _aplicacaoUsuario;

        public UsuarioController(IAplicacaoUsuario aplicacaoUsuario)
        {
            _aplicacaoUsuario = aplicacaoUsuario;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            var list = await _aplicacaoUsuario.Listar();
            return list;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            Usuario usuario = await _aplicacaoUsuario.BuscarPorId(id);

            return usuario == null ? (ActionResult<Usuario>)NotFound() : (ActionResult<Usuario>)usuario;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            try
            {
                 await _aplicacaoUsuario.Atualizar(usuario);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            await _aplicacaoUsuario.Adicionar(usuario);

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            Usuario usuario = await _aplicacaoUsuario.BuscarPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }

            await  _aplicacaoUsuario.Excluir(usuario);

            return usuario;
        }

        private async Task<bool> UsuarioExists(int id)
        {
            return await _aplicacaoUsuario.BuscarPorId(id) is Usuario;
        }
    }
}
