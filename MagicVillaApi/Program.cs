
using MagicVillaApi.Data;
using MagicVillaApi.Logging;
using MagicVillaApi.Repository;
using MagicVillaApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace MagicVillaApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(option =>
            {
                //option.ReturnHttpNotAcceptable = true;
            }).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters(); //accept xml format

            //register new loggerConfig
            //Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File("Log/VillaLogs.txt",rollingInterval:RollingInterval.Day).CreateLogger();

            //builder.Host.UseSerilog();

            //Custom service:
            builder.Services.AddSingleton<Logging.ILoggerMyOwn, LoggerMyOwn>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DfaultSqlConnec"));
            });

            builder.Services.AddScoped<IVillaRepo, VillaRepository>();

            builder.Services.AddAutoMapper(typeof(MappingProfile));




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
}