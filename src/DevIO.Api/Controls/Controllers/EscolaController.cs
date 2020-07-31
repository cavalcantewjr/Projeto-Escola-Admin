using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DevIO.Api.Controllers;
using DevIO.Api.Extensions;
using DevIO.Api.ViewModels;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/escolas")]
    public class EscolaController : MainController
    {
        private readonly IEscolaRepository _escolaRepository;
        private readonly IEscolaService _escolaService;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;

        public EscolaController(IEscolaRepository escolaRepository, 
                                      IMapper mapper, 
                                      IEscolaService escolaService,
                                      INotificador notificador, 
                                      IEnderecoRepository enderecoRepository,
                                      IUser user) : base(notificador, user)
        {
            _escolaRepository = escolaRepository;
            _mapper = mapper;
            _escolaService = escolaService;
            _enderecoRepository = enderecoRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<EscolaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<EscolaViewModel>>(await _escolaRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<EscolaViewModel>> ObterPorId(Guid id)
        {
            var escola = await ObterEscolarTurmaEndereco(id);

            if (escola == null) return NotFound();

            return escola;
        }

        [ClaimsAuthorize("Escola","Adicionar")]
        [HttpPost]
        public async Task<ActionResult<EscolaViewModel>> Adicionar(EscolaViewModel escolaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _escolaService.Adicionar(_mapper.Map<Escola>(escolaViewModel));

            return CustomResponse(escolaViewModel);
        }

        [ClaimsAuthorize("Escola", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<EscolaViewModel>> Atualizar(Guid id,[FromBody]EscolaViewModel escolaViewModel)
        {
            if (id != escolaViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(escolaViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _escolaService.Atualizar(_mapper.Map<Escola>(escolaViewModel));

            return CustomResponse(escolaViewModel);
        }

        [ClaimsAuthorize("Escola", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<EscolaViewModel>> Excluir(Guid id)
        {
            var escolaViewModel = await ObterEscolaEndereco(id);

            if (escolaViewModel == null) return NotFound();

            await _escolaService.Remover(id);

            return CustomResponse(escolaViewModel);
        }

        [HttpGet("endereco/{id:guid}")]
        public async Task<EnderecoViewModel> ObterEnderecoPorId(Guid id)
        {
            return _mapper.Map<EnderecoViewModel>(await _enderecoRepository.ObterPorId(id));
        }

        [ClaimsAuthorize("Escola", "Atualizar")]
        [HttpPut("endereco/{id:guid}")]
        public async Task<IActionResult> AtualizarEndereco(Guid id, EnderecoViewModel enderecoViewModel)
        {
            if (id != enderecoViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(enderecoViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _escolaService.AtualizarEndereco(_mapper.Map<Endereco>(enderecoViewModel));

            return CustomResponse(enderecoViewModel);
        }

        private async Task<EscolaViewModel> ObterEscolarTurmaEndereco(Guid id)
        {
            return _mapper.Map<EscolaViewModel>(await _escolaRepository.ObterEscolaTurmasEndereco(id));
        }
        

        private async Task<EscolaViewModel> ObterEscolaEndereco(Guid id)
        {
            return _mapper.Map<EscolaViewModel>(await _escolaRepository.ObterEscolaEndereco(id));
        }
    }
}