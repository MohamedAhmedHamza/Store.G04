using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.G04.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Repository.Data.Configurations
{
	public class ProductConfigurations : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.Property(P => P.Name).HasMaxLength(200).IsRequired();
			builder.Property(P => P.Description).IsRequired();
			builder.Property(p => p.Price).HasColumnType("decimal(18,2)");

			builder.HasOne(p => p.Brand)
				.WithMany()
				.HasForeignKey(P => P.BrandId)
				.OnDelete(DeleteBehavior.SetNull);

			builder.HasOne(p => p.Type)
				.WithMany()
				.HasForeignKey(P => P.TypeId)
				.OnDelete(DeleteBehavior.SetNull);

			builder.Property(P => P.BrandId).IsRequired(false);
			builder.Property(P => P.TypeId).IsRequired(false);

		}
	}
}
