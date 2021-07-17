using ConvenioMed.Core.Domain.Consumers;
using ConvenioMed.Core.Domain.Contracts;
using ConvenioMed.Financeiro.Domain.Commands;
using MassTransit;
using MediatR;
using System.Threading.Tasks;

namespace ConvenioMed.Financeiro.ConsoleApp.Consumers
{
    public class GerarBoletoConsumer : ConsumerBase, IConsumer<AgendamentoRegistradoContract>
    {
        public GerarBoletoConsumer(IMediator mediator) : base(mediator) { } 

        public async Task Consume(ConsumeContext<AgendamentoRegistradoContract> context)
        {
            var command = new GerarBoletoCommand(context.Message.IdCliente, context.Message.IdMedico);

            await _mediator.Send(command);
        } 
    } 
} 
