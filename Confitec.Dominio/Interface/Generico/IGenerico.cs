using System.Collections.Generic;
using System.Threading.Tasks;

namespace Confitec.Dominio.Interface.Generico
{
    public interface IGenerico<T> where T : class
    {
        Task Adicionar(T @objeto);
        Task Atualizar(T @objeto);
        Task Excluir(T @objeto);
        Task<T> BuscarPorId(int id);
        Task<List<T>> Listar();
    }
}
