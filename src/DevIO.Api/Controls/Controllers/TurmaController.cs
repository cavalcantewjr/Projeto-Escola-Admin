using AutoMapper;
using DevIO.Api.Controllers;
using DevIO.Api.Extensions;
using DevIO.Api.ViewModels;
using DevIO.Business.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/turmas")]
    public class TurmaController : MainController
    {
        private readonly ITurmaRepository _turmaRepository;
        private readonly ITurmaService _turmaService;
        private readonly IMapper _mapper;

        public TurmaController(INotificador notificador, 
                                  ITurmaRepository turmaRepository, 
                                  ITurmaService turmaService, 
                                  IMapper mapper,
                                  IUser user) : base(notificador, user)
        {
            _turmaRepository = turmaRepository;
            _turmaService = turmaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TurmaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<TurmaViewModel>>(await _turmaRepository.ObterTurmasEscola());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TurmaViewModel>> ObterPorId(Guid id)
        {
            var turmaViewModel = await ObterEscola(id);

            if (turmaViewModel == null) return NotFound();

            return turmaViewModel;
        }

        [ClaimsAuthorize("Turma", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<TurmaViewModel>> Adicionar(TurmaViewModel turmaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _turmaService.Adicionar(_mapper.Map<Business.Models.Turma>(turmaViewModel));

            return CustomResponse(turmaViewModel);
        }

        [ClaimsAuthorize("Turma", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<TurmaViewModel>> Excluir(Guid id)
        {
            var escola = await ObterEscola(id);

            if (escola == null) return NotFound();

            await _turmaService.Remover(id);

            return CustomResponse(escola);
        }

 
        private async Task<TurmaViewModel> ObterEscola(Guid id)
        {
            return _mapper.Map<TurmaViewModel>(await _turmaRepository.ObterTurmaEscola(id));
        }
    }
}