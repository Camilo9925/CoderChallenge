using CoderChallenge.Api.SwaggerConfig;
using CoderChallenge.Application.Interfaces;
using CoderChallenge.Application.Interfaces.Services;
using CoderChallenge.Application.Services;
using CoderChallenge.Application.Validators;
using CoderChallenge.Infrastructure.Repository;
using CoderChallenge.Infrastructure.Repository.Context;
using CoderChallenge.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoderChallenge.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                var connectionString = builder.Configuration["DbConfig:ConnectionString"];
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            builder.Services.AddScoped<IDroneService, DroneService>();
            builder.Services.AddScoped<IDroneRepository, DroneRepository>();            
            builder.Services.AddScoped<IConversaoUnidadeService, ConversaoUnidadeService>();            
            builder.Services.AddScoped<IDroneValidator, DroneValidator>();
            builder.Services.AddScoped<IPatoService, PatoService>();
            builder.Services.AddScoped<IPatoRepository, PatoRepository>();
            builder.Services.AddScoped<IPatoValidator, PatoValidator>();
            builder.Services.AddScoped<IDroneValidator, DroneValidator>();
            builder.Services.AddScoped<IBuscaPatoService, BuscaPatoService>();
            builder.Services.AddScoped<IBuscaPatoRepository, BuscaPatoRepository>();
            builder.Services.AddScoped<ISimuladorProvocacaoService, SimuladorProvocacaoService>();
            builder.Services.AddScoped<ISuperpoderService, SuperpoderService>();
            builder.Services.AddScoped<IDroneService, DroneService>();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SchemaFilter<EnumSchemaFilter>();
            });
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "CoderChallenge API",
                    Version = "v1",
                    Description = "API para cataloga��o de Patos Primordiais"                    
                });
                c.SchemaFilter<EnumSchemaFilter>();
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
