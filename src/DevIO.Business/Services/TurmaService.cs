using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Services
{
    public class TurmaService : BaseService, ITurmaService
    {
        private readonly ITurmaRepository _turmaRepository;
        private readonly IUser _user;

        public TurmaService(ITurmaRepository turmaRepository,
                              INotificador notificador, 
                              IUser user) : base(notificador)
        {
            _turmaRepository = turmaRepository;
            _user = user;
        }

        public async Task Adicionar(Turma produto)
        {
            
            //var user = _user.GetUserId();

            await _turmaRepository.Adicionar(produto);
        }

        public async Task Atualizar(Turma produto)
        {
            
            await _turmaRepository.Atualizar(produto);
        }

        public async Task Remover(Guid id)
        {
            await _turmaRepository.Remover(id);
        }

        public void Dispose()
        {
            _turmaRepository?.Dispose();
        }
    }
}