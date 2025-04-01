using GameReviews.Domain.Interfaces;
using GameReviews.Domain.Services;
using GameReviews.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace GameReviews.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers(opt => opt.SuppressAsyncSuffixInActionNames = false);

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseNpgsql(builder.Configuration.GetConnectionString("GamesDb"));
        });

        builder.Services.AddScoped<IGameService, GameService>();
        builder.Services.AddScoped<IGameRepository, GameRepository>();

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
