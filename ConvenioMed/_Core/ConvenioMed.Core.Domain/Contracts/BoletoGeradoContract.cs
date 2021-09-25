using System;

namespace ConvenioMed.Core.Domain.Contracts
{
    public interface BoletoGeradoContract
    {
        public Guid IdCliente { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
    }
}
