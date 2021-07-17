using ConvenioMed._Core.Domain.Interfaces.Repository;
using ConvenioMed._Core.Infra.Data.Repository;
using ConvenioMed.Agendamento.Domain.Commands;
using ConvenioMed.Agendamento.Domain.Interfaces.Repository;
using ConvenioMed.Agendamento.Infra.Data.Repository;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace ConvenioMed.Agendamento.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        } 

        public IConfiguration Configuration { get; } 

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup));
            services.AddMediatR(typeof(AgendarCommand).GetTypeInfo().Assembly);

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();

            services.AddControllers();

            services.AddMassTransit(cfg =>
            {
                cfg.SetKebabCaseEndpointNameFormatter();
                cfg.UsingRabbitMq((context, config) =>
                {
                    
                    config.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    } );
                } );
            } );

            services.AddMassTransitHostedService();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();
        } 

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } 

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            } );

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            } );
        } 
    } 
} 
