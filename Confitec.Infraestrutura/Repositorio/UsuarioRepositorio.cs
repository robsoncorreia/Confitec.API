using Confitec.Dominio.Interface;
using Confitec.Entidade.Entidade;
using Confitec.Infraestrutura.Configuracao;
using Confitec.Infraestrutura.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Infraestrutura.Repositorio
{
    public class UsuarioRepositorio : GenericoRepositorio<Usuario>, IUsuario
    {
        private readonly DbContextOptions<ConfitecAPIContext> _dbContextOptions;

        public UsuarioRepositorio()
        {
            _dbContextOptions = new DbContextOptions<ConfitecAPIContext>();
        }
        public async Task<List<Usuario>> ListarUsuarios(Expression<Func<Usuario, bool>> expression)
        {
            using var data = new ConfitecAPIContext(_dbContextOptions);
            return await data.Usuario.Where(expression).AsNoTracking().ToListAsync();
        }
    }
}
