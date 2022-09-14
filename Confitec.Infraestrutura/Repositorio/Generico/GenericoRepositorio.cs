using Confitec.Dominio.Interface.Generico;
using Confitec.Infraestrutura.Configuracao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Confitec.Infraestrutura.Repositorio.Generico
{
    public class GenericoRepositorio<T> : IGenerico<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<Contexto> _dbContextOptions;

        public GenericoRepositorio()
        {
            _dbContextOptions = new DbContextOptions<Contexto>();
        }

        public async Task Adicionar(T objeto)
        {
            using var data = new Contexto(_dbContextOptions);
            await data.Set<T>().AddAsync(objeto);
            await data.SaveChangesAsync();
        }

        public async Task Atualizar(T objeto)
        {
            using var data = new Contexto(_dbContextOptions);
            data.Set<T>().Update(objeto);
            await data.SaveChangesAsync();
        }

        public async Task<T> BuscarPorId(int id)
        {
            using var data = new Contexto(_dbContextOptions);
            return await data.Set<T>().FindAsync(id);
        }

        public async void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task Excluir(T objeto)
        {
            using var data = new Contexto(_dbContextOptions);
            data.Set<T>().Remove(objeto);
            await data.SaveChangesAsync();
        }

        public async Task<List<T>> Listar()
        {
            using var data = new Contexto(_dbContextOptions);
            return await data.Set<T>().AsNoTracking().ToListAsync();
        }
    }
}
