using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolokwium2.Entities.Configurations;

public class CarEfConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(c => c.IdCar);
        builder.Property(c => c.IdCar).UseIdentityColumn();

        builder.Property(c => c.Make).HasMaxLength(15);

        builder.ToTable("Car");
        
        builder.HasData(
            new Car { IdCar = 1, Make = "BMW", ProductionYear = 2004},
            new Car { IdCar = 2, Make = "Fiat", ProductionYear = 2014}
        );
    }
}