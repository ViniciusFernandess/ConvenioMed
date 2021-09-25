using ConvenioMed.Agendamento.Domain.Consumers;
using MassTransit;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace ConvenioMed.Agendamento.ConsoleApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddMassTransit(x => {

                x.AddConsumer<EfetivarAgendamentoConsumer>();
                x.UsingRabbitMq((context, cfg) => {

                    cfg.ReceiveEndpoint(e =>
                    {
                        e.Consumer<EfetivarAgendamentoConsumer>();
                    });
                });
            });

            var provider = services.BuildServiceProvider();

            var busControl = provider.GetRequiredService<IBusControl>();

            var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            await busControl.StartAsync(source.Token);
            try
            {
                Console.WriteLine("Console Agendamento");
                Console.WriteLine("Press enter to exit");
                Console.WriteLine($"------------------------------------");

                await Task.Run(() => Console.ReadLine());
            }
            finally
            {
                await busControl.StopAsync();
            }
        }
    }
}
