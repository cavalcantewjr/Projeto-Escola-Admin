using System;
using System.Threading.Tasks;
using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{
    public interface IEscolaRepository : IRepository<Escola>
    {
        Task<Escola> ObterEscolaEndereco(Guid id);
        Task<Escola> ObterEscolaTurmasEndereco(Guid id);
    }
}