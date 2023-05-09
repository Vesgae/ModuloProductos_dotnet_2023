using Microsoft.EntityFrameworkCore;
using Modulo_Productos.Entities;

internal class Program
{
    private const string stringConnection = "server=34.125.38.244;port=9090;user=root;password=Codecraft2023*;database=productos_servicios_vehiculos";
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // Add services to the container.
        IServiceCollection serviceCollection = builder.Services.AddDbContext<ProductosServiciosVehiculosContext>(
            options =>
            { options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.11.2-mariadb")); });
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}