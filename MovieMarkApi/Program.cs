using Microsoft.EntityFrameworkCore;

namespace MovieMarkApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(
                  "Any",
                  cors =>
                  {
                      cors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                  });
            });

            builder.Services.AddControllers();

            //SQL DB 
            builder.Services.AddDbContext<MovieMarkContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MovieMarkContext")));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseCors("Any");
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
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