using Microsoft.Extensions.Logging.EventLog;
using Serilog;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddLogging(a => 
            { 
                a.AddEventLog(b => b.SourceName = builder.Configuration.GetSection("Logging:EventLog:SourceName").Value);
            }) ;

            var app = builder.Build();

            
            
            // HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}