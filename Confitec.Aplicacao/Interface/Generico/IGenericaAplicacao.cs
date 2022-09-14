using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Aplicacao.Interface.Generico
{
    public interface IGenericaAplicacao <T> where T : class
    {
        Task Adicionar(T @objeto);
        Task Atualizar(T @objeto);
        Task Excluir(T @objeto);
        Task<T> BuscarPorId(int id);
        Task<List<T>> Listar();
    }
}
