using ConvenioMed._Core.Domain.Entities;
using ConvenioMed.Core.Domain.Contracts;
using ConvenioMed.Financeiro.Domain.Commands;
using ConvenioMed.Financeiro.Domain.Entities;
using ConvenioMed.Financeiro.Domain.Interfaces;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConvenioMed.Financeiro.Domain.CommandHandlers
{
    public class BaixarBoletoCommandHandler : IRequestHandler<BaixarBoletoCommand, RequestResult>
    {
        private readonly IBoletoService _service;
        private readonly IBus _bus;

        public BaixarBoletoCommandHandler(IBoletoService service, IBus bus)
        {
            _service = service;
            _bus = bus;
        }

        public async Task<RequestResult> Handle(BaixarBoletoCommand request, CancellationToken cancellationToken)
        {
            var boleto = _service.BaixarBoleto(request.IdBoleto);

            if (boleto.DataPagamento == null)
                return new RequestResult(false, "Erro ao tentar baixar o boleto.", new List<string> { "Erro ao baixar boleto." });

            await _bus.Publish<BoletoBaixadoContract>(new { boleto.IdCliente, boleto.Valor });

            return new RequestResult(true, "Boleto baixado com sucesso.", new List<string> { });
        }
    }
}
