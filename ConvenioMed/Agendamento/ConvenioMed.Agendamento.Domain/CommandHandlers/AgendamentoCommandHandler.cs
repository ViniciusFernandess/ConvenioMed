using ConvenioMed._Core.Domain.Entities;
using ConvenioMed.Agendamento.Domain.Commands;
using ConvenioMed.Agendamento.Domain.Entities;
using ConvenioMed.Agendamento.Domain.Interfaces.Repository;
using ConvenioMed.Core.Domain.Contracts;
using MassTransit;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConvenioMed.Agendamento.Domain.CommandHandlers
{
    public class AgendamentoCommandHandler : IRequestHandler<SolicitarAgendamentoCommand, RequestResult>
    {
        private readonly IAgendamentoRepository _repo;
        private readonly IBus _bus;

        public AgendamentoCommandHandler(IAgendamentoRepository repo, IBus bus)
        {
            _repo = repo;
            _bus = bus;
        } 

        public async Task<RequestResult> Handle(SolicitarAgendamentoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return new RequestResult(request.IsValid(), "Erro ao solicitar agendamento.", (request.GetErros()));

            var agendamento = new AgendamentoEntity(request.IdCliente, request.IdMedico, request.DataAgendamento);

            var result = await _repo.Insert(agendamento);

            var endpoint = await _bus.GetSendEndpoint(new Uri("queue:agendamento-solicitado"));
            await endpoint.Send<AgendamentoRegistradoContract>(new { IdCliente = result.IdCliente, IdMedico = result.IdMedico });

            return new RequestResult(request.IsValid(), "Agendamento Solicitado com sucesso.", (request.GetErros()));
        } 
    } 
} 
