using System;
using System.Threading.Tasks;
using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{
    public interface IEscolaService : IDisposable
    {
        Task<bool> Adicionar(Escola escola);
        Task<bool> Atualizar(Escola escola);
        Task<bool> Remover(Guid id);

        Task AtualizarEndereco(Endereco endereco);
    }
}