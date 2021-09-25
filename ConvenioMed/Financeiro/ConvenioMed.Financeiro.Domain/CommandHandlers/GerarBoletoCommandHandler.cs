using ConvenioMed._Core.Domain.Entities;
using ConvenioMed.Core.Domain.Contracts;
using ConvenioMed.Financeiro.Domain.Commands;
using ConvenioMed.Financeiro.Domain.Interfaces;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConvenioMed.Financeiro.Domain.CommandHandlers
{
    public class GerarBoletoCommandHandler : IRequestHandler<GerarBoletoCommand, RequestResult>
    {
        private readonly IBus _bus;
        private readonly IBoletoService _service;

        public GerarBoletoCommandHandler(IBus bus, IBoletoService service)
        {
            _bus = bus;
            _service = service;
        }

        public async Task<RequestResult> Handle(GerarBoletoCommand request, CancellationToken cancellationToken)
        {
            var boleto = _service.GerarBoleto(request.IdCliente, request.IdMedico);

            await _bus.Publish<BoletoGeradoContract>(new { boleto.IdCliente, boleto.Valor, boleto.DataVencimento });

            return await Task.FromResult(new RequestResult(true, $"Boleto Gerado - IdClient:  {request.IdCliente}  - IdMedico: {request.IdMedico} ", new List<string> { "Boleto Gerado" }));
        }
    }
}
