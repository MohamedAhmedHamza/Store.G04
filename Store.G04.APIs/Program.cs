using Microsoft.EntityFrameworkCore;
using Store.G04.Core;
using Store.G04.Core.Mapping.Products;
using Store.G04.Core.Services.Contract;
using Store.G04.Repository;
using Store.G04.Repository.Data;
using Store.G04.Repository.Data.Contexts;
using Store.G04.Service.Services.Products;

namespace Store.G04.APIs
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddDbContext<StoreDbContext>(option =>
			{
					option.UseSqlServer(builder.Configuration.GetConnectionString("QA_Context"));
			});

			builder.Services.AddScoped<IProductService , ProductService>();
			builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
			builder.Services.AddAutoMapper(M => M.AddProfile(new ProductProfile()));

			var app = builder.Build();

			/*StoreDbContext context = new StoreDbContext();
			context.Database.MigrateAsync();*/
			 
			using var Scope = app.Services.CreateScope();
			var services = Scope.ServiceProvider;
			var context = services.GetRequiredService<StoreDbContext>();
			var loggerFactory = services.GetRequiredService<ILoggerFactory>();

			try
			{
				await context.Database.MigrateAsync();
				await StoreDbContextSeed.SeedAsync(context);
			}
			catch (Exception ex)
			{
				var Logger	= loggerFactory.CreateLogger<Program>();
				Logger.LogError(ex , "there are  problems during apply migration");
               /* Console.WriteLine(ex.Message);*/
            }

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
