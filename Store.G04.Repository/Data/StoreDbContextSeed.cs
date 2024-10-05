using Store.G04.Core.Entities;
using Store.G04.Repository.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.G04.Repository.Data
{
	public static class StoreDbContextSeed
	{
		public async static Task SeedAsync(StoreDbContext _context)
		{
			if(_context.Brands.Count() == 0)
			{
				//Brand
				//1. Read data from json file 
				//C:\Users\ascom\source\repos\Store.G04\Store.G04.Repository\Data\DataSeed\brands.json
				var brandsData = File.ReadAllText(@"..\Store.G04.Repository\Data\DataSeed\brands.json");

				//2. convert Json String to List<T>

				var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

				//3. Seed data to DB
				if (brands is not null && brands.Count() > 0)
				{
					await _context.Brands.AddRangeAsync(brands);
					await _context.SaveChangesAsync();
				 }
			}

			if (_context.Types.Count() == 0)
			{
				//Types
				//1. Read data from json file 
				//C:\Users\ascom\source\repos\Store.G04\Store.G04.Repository\Data\DataSeed\Types.json
				var typesData = File.ReadAllText(@"..\Store.G04.Repository\Data\DataSeed\Types.json");

				//2. convert Json String to List<T>

				var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

				//3. Seed data to DB
				if (types is not null && types.Count() > 0)
				{
					await _context.Types.AddRangeAsync(types);
					await _context.SaveChangesAsync();
				}
			}

			if (_context.Products.Count() == 0)
			{

				// 1. Read Data From Json File

				var ProductsData = File.ReadAllText(@"..\Store.G04.Repository\Data\DataSeed\products.json");

				// 2. Convert json String to List<T>

				var products = JsonSerializer.Deserialize<List<Product>>(ProductsData);

				// 3. Seed Data to Database

				if (products is not null && products.Count() > 0)
				{
					await _context.Products.AddRangeAsync(products);

					await _context.SaveChangesAsync();
				}

			}

		} 


	}
}
