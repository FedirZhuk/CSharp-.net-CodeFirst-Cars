using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Kolokwium2.Entities.Configurations;

public class PersonEfConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(p => p.IdPerson);
        builder.Property(p => p.IdPerson).UseIdentityColumn();

        builder.Property(p => p.IdPerson).HasMaxLength(30);
        builder.Property(p => p.Surname).HasMaxLength(40);
        builder.Property(p => p.DrivingLicense).HasMaxLength(5);

        builder.ToTable("Person");
        
        builder.HasData(
            new Person { IdPerson = 1, Name = "A", Surname = "B", DrivingLicense = null},
            new Person { IdPerson = 2, Name = "C", Surname = "D", DrivingLicense = "ADSA"}
        );
        
    }
}