using Confitec.Dominio.Interface.Generico;
using Confitec.Entidade.Entidade;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Confitec.Dominio.Interface
{
    public interface IUsuario : IGenerico<Usuario>
    {
        Task<List<Usuario>> ListarUsuarios(Expression<Func<Usuario, bool>> expression);
    }
}
