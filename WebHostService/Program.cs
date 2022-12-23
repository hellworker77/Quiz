using DataAccessLayer.Abstraction.Interfaces;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace WebHostService;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var migrationFolder = typeof(Program).Assembly.FullName;
        builder.Services.AddDbContext<ApplicationContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDatabaseConnection"),
                migration => migration.MigrationsAssembly(migrationFolder));
            options.UseLazyLoadingProxies();
        });

        builder.Services.AddTransient<IDbInitializer, DbInitializer>();
        builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();


        var app = builder.Build();


        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.DbInitialize();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
    
}