using ConvenioMed.Core.Domain.Contracts;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace ConvenioMed.Agendamento.Domain.Consumers
{
    public class EfetivarAgendamentoConsumer : IConsumer<BoletoBaixadoContract>
    {
        public Task Consume(ConsumeContext<BoletoBaixadoContract> context)
        {
            Console.WriteLine("Agendamento Efetivado na base.");
            Console.WriteLine($"------------------------------------");

            return Task.CompletedTask;
        }
    }
}
