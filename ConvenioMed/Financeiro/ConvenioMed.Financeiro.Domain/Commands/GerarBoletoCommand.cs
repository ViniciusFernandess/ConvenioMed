using ConvenioMed._Core.Domain.Entities;
using MediatR;
using System;

namespace ConvenioMed.Financeiro.Domain.Commands
{
    public class GerarBoletoCommand : IRequest<RequestResult>
    {
        public GerarBoletoCommand(Guid idCliente, Guid idMedico)
        {
            IdCliente = idCliente;
            IdMedico = idMedico;
        } 

        public Guid IdCliente { get; set; } 
        public Guid IdMedico { get; set; } 
    } 
} 
