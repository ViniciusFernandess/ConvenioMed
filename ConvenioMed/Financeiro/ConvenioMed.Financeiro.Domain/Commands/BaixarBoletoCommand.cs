using ConvenioMed._Core.Domain.Commands;
using ConvenioMed._Core.Domain.Entities;
using MediatR;
using System;

namespace ConvenioMed.Financeiro.Domain.Commands
{
    public class BaixarBoletoCommand : Command<RequestResult>
    {
        public Guid IdBoleto { get; set; }
    }
}
