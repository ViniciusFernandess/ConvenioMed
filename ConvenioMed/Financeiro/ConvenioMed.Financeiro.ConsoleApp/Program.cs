using ConvenioMed.Financeiro.ConsoleApp.Consumers;
using ConvenioMed.Financeiro.Domain.CommandHandlers;
using ConvenioMed.Financeiro.Domain.Commands;
using ConvenioMed.Financeiro.Domain.Interfaces;
using ConvenioMed.Financeiro.Domain.Interfaces.Repository;
using ConvenioMed.Financeiro.Domain.Services;
using ConvenioMed.Financeiro.Infra.Data.Repository;
using MassTransit;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace ConvenioMed.Financeiro.ConsoleApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var services = new ServiceCollection();

            // Injeção serviços e repositorios
            services.AddScoped<IBoletoRepository, BoletoRepository>();
            services.AddScoped<IBoletoService, BoletoService>();

            // Injeção MediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddMediatR(typeof(GerarBoletoCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(BaixarBoletoCommand).GetTypeInfo().Assembly);


            // COnfiguração MassTransit
            services.AddMassTransit(x =>
            {
                x.AddConsumer<GerarBoletoConsumer>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    // consumir da fila (Send)
                    cfg.ReceiveEndpoint("agendamento-solicitado", e =>
                    {
                        e.Consumer<GerarBoletoConsumer>(context);
                    });
                });
            });

            var provider = services.BuildServiceProvider();

            var busControl = provider.GetRequiredService<IBusControl>();

            var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            await busControl.StartAsync(source.Token);
            try
            {
                Console.WriteLine("Console Financeiro");
                Console.WriteLine("Press enter to exit");
                Console.WriteLine($"------------------------------------");

                await Task.Run(() => Console.ReadLine());
            }
            finally
            {
                //await busControl.StopAsync();
            }
        }

        public void GerarHandler(IBoletoService serv)
        {
        }
    }
}
