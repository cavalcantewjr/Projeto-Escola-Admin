using System;
using System.Threading.Tasks;
using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{
    public interface ITurmaService : IDisposable
    {
        Task Adicionar(Turma turma);
        Task Atualizar(Turma turma);
        Task Remover(Guid id);
    }
}