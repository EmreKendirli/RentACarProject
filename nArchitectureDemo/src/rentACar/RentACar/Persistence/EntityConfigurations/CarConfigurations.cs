using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CarConfigurations : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Cars").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.ModelId).HasColumnName("ModelId").IsRequired();
        builder.Property(b => b.Kilometer).HasColumnName("Kilometer").IsRequired();
        builder.Property(b => b.Plate).HasColumnName("Plate").IsRequired();
        builder.Property(b => b.MinFindexScore).HasColumnName("MinFindexScore").IsRequired();
        builder.Property(b => b.CarState).HasColumnName("State");
        builder.Property(b => b.ModelYear).HasColumnName("ModelYear");


        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");


        builder.HasOne(b => b.Model);//models alanı ile bire çok ilişki var

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
