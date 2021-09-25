using ConvenioMed.Core.Domain.Consumers;
using ConvenioMed.Core.Domain.Contracts;
using MassTransit;
using MediatR;
using System;
using System.Threading.Tasks;

namespace ConvenioMed.Marketing.Domain.Consumers
{
    public class EnviarEmailBoletoBaixadoParaClienteConsumer : ConsumerBase, IConsumer<BoletoBaixadoContract>
    {
        public EnviarEmailBoletoBaixadoParaClienteConsumer(IMediator mediator) : base(mediator) { }

        public Task Consume(ConsumeContext<BoletoBaixadoContract> context)
        {
            Console.WriteLine($"Email enviado: Cliente: {context.Message.IdCliente} - Boleto Baixado no valor: R$ {context.Message.Valor.ToString("n")}");
            Console.WriteLine($"Agendamento foi efetuado");
            Console.WriteLine($"------------------------------------");

            return Task.CompletedTask;
        }
    }
}
