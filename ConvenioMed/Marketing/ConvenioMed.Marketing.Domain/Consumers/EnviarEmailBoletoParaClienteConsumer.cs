using ConvenioMed.Core.Domain.Consumers;
using ConvenioMed.Core.Domain.Contracts;
using MassTransit;
using MediatR;
using System;
using System.Threading.Tasks;

namespace ConvenioMed.Marketing.Domain.Consumers
{
    public class EnviarEmailBoletoParaClienteConsumer : ConsumerBase, IConsumer<BoletoGeradoContract>
    {
        public EnviarEmailBoletoParaClienteConsumer(IMediator mediator) : base(mediator) { }

        public Task Consume(ConsumeContext<BoletoGeradoContract> context)
        {
            Console.WriteLine($"Email enviado: Anexo boleto para pagamento: Cliente: {context.Message.IdCliente} - valor: R$ {context.Message.Valor.ToString("n")} - vencimento: {context.Message.DataVencimento.ToShortDateString()}");
            Console.WriteLine($"------------------------------------");

            return Task.CompletedTask;
        }
    }
}
