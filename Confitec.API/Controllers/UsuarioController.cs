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
        private readonly ConfitecAPIContext _context;

        public UsuarioController(ConfitecAPIContext context, IAplicacaoUsuario aplicacaoUsuario)
        {
            _aplicacaoUsuario = aplicacaoUsuario;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _aplicacaoUsuario.Listar();
        }

        // GET: api/Usuarios/5
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

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                _ = await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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
            //_ = await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            Usuario usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _ = _context.Usuario.Remove(usuario);
            _ = await _context.SaveChangesAsync();

            return usuario;
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.Id == id);
        }
    }
}
