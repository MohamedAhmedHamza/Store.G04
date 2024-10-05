using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Store.G04.Core.DTOs.Products;
using Store.G04.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.Services.Contract
{
	public interface IProductService
	{
		Task<IEnumerable<ProductDto>> GetAllProductsAsync();
		Task<IEnumerable<TypeBrandDto>> GetAllTypesAsync();
		Task<IEnumerable<TypeBrandDto>> GetAllBrandsAsync();

		Task<ProductDto> GetProductById(int id);



	}
}
