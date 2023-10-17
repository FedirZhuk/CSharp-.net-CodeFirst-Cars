using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolokwium2.Entities.Configurations;

public class Car_PersonEfConfiguration : IEntityTypeConfiguration<Car_Person>
{
    public void Configure(EntityTypeBuilder<Car_Person> builder)
    {
        builder.HasKey(cp => new { cp.IdCar, cp.IdPerson });

        builder.ToTable("Car_Person");
        
        builder
            .HasOne(cp => cp.Car)
            .WithMany(c => c.CarPersons)
            .HasForeignKey(cp => cp.IdCar);
        
        builder
            .HasOne(cp => cp.Person)
            .WithMany(p => p.CarPersons)
            .HasForeignKey(cp => cp.IdPerson);
        
        builder.HasData(
            new Car_Person { IdCar = 1, IdPerson = 1, MainOwner = true},
            new Car_Person { IdCar = 2, IdPerson = 2, MainOwner = false}
        );
    }
}