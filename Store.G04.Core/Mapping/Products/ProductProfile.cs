using AutoMapper;
using Store.G04.Core.DTOs.Products;
using Store.G04.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.Mapping.Products
{
	public class ProductProfile : Profile
	{
        public ProductProfile()
        {
            CreateMap<Product , ProductDto>()
				.ForMember(d => d.BrandName , option => option.MapFrom(s => s.Brand.Name))
				.ForMember(d => d.TypeName, option => option.MapFrom(s => s.Type.Name));

			CreateMap<ProductBrand, TypeBrandDto>();
			CreateMap<ProductType, TypeBrandDto>();


		}
	}
}
