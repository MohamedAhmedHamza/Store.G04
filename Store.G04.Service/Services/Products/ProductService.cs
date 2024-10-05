using AutoMapper;
using Store.G04.Core;
using Store.G04.Core.DTOs.Products;
using Store.G04.Core.Entities;
using Store.G04.Core.Services.Contract;
using Store.G04.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Service.Services.Products
{
	public class ProductService : IProductService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ProductService(IUnitOfWork unitOfWork , IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()=>
			 _mapper.Map<IEnumerable<ProductDto>>(await _unitOfWork.Repository<Product, int>().GetAllAsync());
			/*return await _unitOfWork.Repository<Product, int>().GetAllAsync;*/


		public async Task<IEnumerable<TypeBrandDto>> GetAllBrandsAsync()
		{
			var brands = await _unitOfWork.Repository<ProductType, int>().GetAllAsync();
			var mappedbrands = _mapper.Map<IEnumerable<TypeBrandDto>>(brands);
			return mappedbrands;
		}

		public async Task<IEnumerable<TypeBrandDto>> GetAllTypesAsync() =>
			 _mapper.Map<IEnumerable<TypeBrandDto>>(await _unitOfWork.Repository<ProductType, int>().GetAllAsync());

		

		public async Task<ProductDto> GetProductById(int id)
		{
			var product = await _unitOfWork.Repository<Product, int>().GetAsync(id);
			var mappedproduct = _mapper.Map<ProductDto>(product);
			return mappedproduct;

		}
		
	}
}
