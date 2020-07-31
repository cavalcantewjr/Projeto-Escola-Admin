using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{
    public interface ITurmaRepository : IRepository<Turma>
    {
        Task<IEnumerable<Turma>> ObterTurmaPorEscola(Guid id);
        Task<IEnumerable<Turma>> ObterTurmasEscola();
        Task<Turma> ObterTurmaEscola(Guid id);
    }
}