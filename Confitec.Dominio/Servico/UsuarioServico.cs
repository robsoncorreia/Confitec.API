using Confitec.Dominio.Interface;
using Confitec.Dominio.Interface.InterfaceServico;
using Confitec.Entidade.Entidade;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Confitec.Dominio.Servico
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly IUsuario _usuario;


        public UsuarioServico(IUsuario usuario)
        {
            _usuario = usuario;
        }

        public async Task Adicionar(Usuario usuario)
        {
            if (!usuario.ValidaEmail(usuario.Email))
            {
                return;
            }
            if (!usuario.ValidaData(usuario.DataNascimento))
            {
                return;
            }
            await _usuario.Adicionar(usuario);
        }



        public async Task Atualizar(Usuario usuario)
        {
            if (!usuario.ValidaEmail(usuario.Email))
            {
                return;
            }
            if (!usuario.ValidaData(usuario.DataNascimento))
            {
                return;
            }
            await _usuario.Atualizar(usuario);
        }


        public async Task<Usuario> BuscarPorId(int id)
        {
            return await _usuario.BuscarPorId(id);
        }



        public async Task Excluir(Usuario usuario)
        {
            await _usuario.Excluir(usuario);
        }


        public async Task<List<Usuario>> Listar()
        {
            return await _usuario.ListarUsuarios(u => u.Id != 0);
        }

    }
}
