using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Services
{
    public class EscolaService : BaseService, IEscolaService
    {
        private readonly IEscolaRepository _escolaRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public EscolaService(IEscolaRepository escolaRepository, 
                                 IEnderecoRepository enderecoRepository,
                                 INotificador notificador) : base(notificador)
        {
            _escolaRepository = escolaRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task<bool> Adicionar(Escola escola)
        {
            await _escolaRepository.Adicionar(escola);
            return true;
        }

        public async Task<bool> Atualizar(Escola escola)
        {
            await _escolaRepository.Atualizar(escola);
            return true;
        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
            await _enderecoRepository.Atualizar(endereco);
        }

        public async Task<bool> Remover(Guid id)
        {
            var endereco = await _enderecoRepository.ObterEnderecoPorEscola(id);

            if (endereco != null)
            {
                await _enderecoRepository.Remover(endereco.Id);
            }

            await _escolaRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _escolaRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }
    }
}