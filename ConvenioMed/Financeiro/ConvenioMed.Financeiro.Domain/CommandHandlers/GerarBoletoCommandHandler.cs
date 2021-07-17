using ConvenioMed._Core.Domain.Entities;
using ConvenioMed.Financeiro.Domain.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConvenioMed.Financeiro.Domain.CommandHandlers
{
    public class GerarBoletoCommandHandler : IRequestHandler<GerarBoletoCommand, RequestResult>
    {
        public async Task<RequestResult> Handle(GerarBoletoCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Boleto Gerado - IdClient:  {request.IdCliente}  - IdMedico: {request.IdMedico} ");

            return await Task.FromResult(new RequestResult(true, new List<string> { "Boleto Gerado" } ));
        } 
    } 
} 
