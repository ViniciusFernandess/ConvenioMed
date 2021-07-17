using System;

namespace ConvenioMed.Core.Domain.Contracts
{
    public interface AgendamentoRegistradoContract
    {
        public Guid IdCliente { get; set; } 
        public Guid IdMedico { get; set; }  
    } 
} 
