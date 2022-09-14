using Confitec.Aplicacao.Interface;
using Confitec.Dominio.Interface;
using Confitec.Dominio.Interface.InterfaceServico;
using Confitec.Entidade.Entidade;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Aplicacao.Aplicacao
{
    public class AplicacaoUsuario : IAplicacaoUsuario
    {
        IUsuario _usuario;
        IUsuarioServico _usuarioServico;

        public AplicacaoUsuario(IUsuario usuario, IUsuarioServico usuarioServico)
        {
            _usuario = usuario;
            _usuarioServico = usuarioServico;
        }
        public async Task Adicionar(Usuario objeto)
        {
            await _usuario.Adicionar(objeto);
        }

        public async Task Atualizar(Usuario objeto)
        {
            await _usuario.Atualizar(objeto);
        }

        public async Task<Usuario> BuscarPorId(int id)
        {
           return await _usuario.BuscarPorId(id);
        }

        public async Task Excluir(Usuario objeto)
        {
            await _usuario.Excluir(objeto);
        }

        public async Task<List<Usuario>> Listar()
        {
            return await _usuario.Listar();
        }
    }
}
