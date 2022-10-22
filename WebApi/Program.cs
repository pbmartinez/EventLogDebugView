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
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //builder.Host.UseSerilog((ctx, lc) => lc
            //.ReadFrom.Configuration(builder.Configuration));

            builder.Services.AddLogging(a => { 
                a.AddEventLog(b => { 
                    //b.LogName = "WebApi-LogName";
                    b.SourceName = builder.Configuration.GetSection("Logging:EventLog:SourceName").Value;
                }); 
            }) ;

            //builder.Services.AddLogging(a => { 
            //    a.AddEventLog(builder.Configuration.GetSe<EventLogSettings>()); 
            //}) ;
        
            var app = builder.Build();

            
            
            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}