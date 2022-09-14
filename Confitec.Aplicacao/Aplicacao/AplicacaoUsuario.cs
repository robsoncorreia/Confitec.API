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

        IUsuarioServico _usuarioServico;

        public AplicacaoUsuario(IUsuario usuario, IUsuarioServico usuarioServico)
        {
            //_usuario = usuario;
            _usuarioServico = usuarioServico;
        }
        public async Task Adicionar(Usuario objeto)
        {
            await _usuarioServico.Adicionar(objeto);
        }

        public async Task Atualizar(Usuario objeto)
        {
            await _usuarioServico.Atualizar(objeto);
        }

        public async Task<Usuario> BuscarPorId(int id)
        {
           return await _usuarioServico.BuscarPorId(id);
        }

        public async Task Excluir(Usuario objeto)
        {
            await _usuarioServico.Excluir(objeto);
        }

        public async Task<List<Usuario>> Listar()
        {
            return await _usuarioServico.Listar();
        }
    }
}
