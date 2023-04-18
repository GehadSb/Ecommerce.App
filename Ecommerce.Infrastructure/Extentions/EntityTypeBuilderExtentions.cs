using Ecommerce.Domain.Common;
using Ecommerce.Domain.ValueObjects.Auditables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Extentions
{
    public static class EntityTypeBuilderExtentions
    {
        public static EntityTypeBuilder OwnsNameEN<TEntity>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : BaseEntity, ILookupNameEn
        {
            return builder.OwnsOne(c => c.NameEn,
                c =>
                {
                    c.Property(x => x.Value)
                    .HasColumnType("nvarchar")
                    .HasColumnName("NameEn")
                    .HasMaxLength(LookupNameEn.MAX_ALLOWED_CHAR)
                    .IsRequired();

                });
        }
    }
}
