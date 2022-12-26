using Core.Domain.Services.DependencyInject;
using DataAccessLayer.Abstraction.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Repository.DependencyInject;
using Mapping.Mappers.DependencyInject;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace WebHostService;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();


        builder.Services.AddSwaggerGenWithAuth(builder.Configuration);
        builder.Services.ConfigureAuthService(builder.Configuration);


        var migrationFolder = typeof(Program).Assembly.FullName;
        builder.Services.AddDbContext<ApplicationContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDatabaseConnection"),
                migration => migration.MigrationsAssembly(migrationFolder));
            options.UseLazyLoadingProxies();
        });

        builder.Services.AddTransient<IDbInitializer, DbInitializer>();
        builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        builder.Services.ServicesProvide();
        builder.Services.RepositoriesProvide();
        builder.Services.MappersProvide();

        var app = builder.Build();


        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger QUIZ");
                options.DocExpansion(DocExpansion.List);
                options.OAuthClientId("Api");
                options.OAuthClientSecret("client_secret");
            });
            app.DbInitialize();
        }

        app.UseRouting();

        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

}