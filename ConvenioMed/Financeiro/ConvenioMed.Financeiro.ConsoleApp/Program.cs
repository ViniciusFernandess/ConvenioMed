using ConvenioMed.Financeiro.ConsoleApp.Consumers;
using ConvenioMed.Financeiro.Domain.Commands;
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

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(GerarBoletoCommand).GetTypeInfo().Assembly);

            services.AddMassTransit(x =>
            {
                x.AddConsumer<GerarBoletoConsumer>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    // consumir um alerta (Publish)
                    cfg.ReceiveEndpoint(e =>
                    {
                        e.Consumer<GerarBoletoConsumer>(context);
                    } );

                    // consumir da fila (Send)
                    //cfg.ReceiveEndpoint("agendamento-realizado", e =>
                    //{
                    //    e.Consumer<GerarBoletoConsumer>(context);
                    //} );
                } );
            } );

            var provider = services.BuildServiceProvider();

            var busControl = provider.GetRequiredService<IBusControl>();


            var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            await busControl.StartAsync(source.Token);
            try
            {
                Console.WriteLine("Press enter to exit");

                await Task.Run(() => Console.ReadLine());
            } 
            finally
            {
                await busControl.StopAsync();
            } 
        } 
    } 
} 
