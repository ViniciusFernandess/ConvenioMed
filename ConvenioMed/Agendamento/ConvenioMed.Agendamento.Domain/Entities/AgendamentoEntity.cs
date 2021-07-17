using ConvenioMed._Core.Domain.Entities;
using System;

namespace ConvenioMed.Agendamento.Domain.Entities
{
    public class AgendamentoEntity : Entity
    {
        public AgendamentoEntity(Guid idCliente, Guid idMedico, DateTime dataAgendamento)
        {
            IdCliente = idCliente;
            IdMedico = idMedico;
            DataAgendamento = dataAgendamento;
        } 

        public Guid IdCliente { get; private set; } 
        public Guid IdMedico { get; private set; } 
        public DateTime DataAgendamento { get; private set; } 
    } 
} 
