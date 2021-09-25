using System;
using System.Collections.Generic;
using System.Text;

namespace ConvenioMed.Core.Domain.Contracts
{
    public interface BoletoBaixadoContract
    {
        Guid IdCliente { get; set; }
        decimal Valor { get; set; }
    }
}
