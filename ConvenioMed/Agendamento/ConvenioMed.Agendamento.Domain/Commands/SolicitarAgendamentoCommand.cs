using ConvenioMed._Core.Domain.Commands;
using ConvenioMed._Core.Domain.Entities;
using MediatR;
using System;

namespace ConvenioMed.Agendamento.Domain.Commands
{
    public class SolicitarAgendamentoCommand : Command<RequestResult>
    {
        public Guid IdCliente { get; set; } 
        public Guid IdMedico { get; set; } 
        public DateTime DataAgendamento { get; set; } 
    } 
} 
