using Kolokwium2.DTO;
using Kolokwium2.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using PrzykladowyKolok2.Exceptions;

namespace Kolokwium2.Services;

public class WorkshopDbServices : IWorkshopDbService
{
    private readonly WorkshopDbContext _context;

    public WorkshopDbServices(WorkshopDbContext context)
    {
        _context = context;
    }

    public async Task<CarGetDTO> GetCarAsync(int id, CancellationToken cancellationToken = default)
    {
        var car = await _context.Cars
            .Where(c => c.IdCar == id)
            .Select(c => new CarGetDTO()
            {
                Make = c.Make,
                ProductionYear = c.ProductionYear,
                Owners = _context.Persons
                    .Where(p => c.CarPersons.Any(cp => cp.IdPerson == p.IdPerson))
                    .Select(p=>new PersonDTO()
                    {
                        Name = p.Name,
                        Surname = p.Surname,
                        DrivingLicense = p.DrivingLicense,
                        IsOwner = _context.CarPersons
                            .Where(cp => cp.IdPerson == p.IdPerson)
                            .Where(cp => cp.IdCar == id)
                            .Select(cp => cp.MainOwner).FirstOrDefault()
                    }).ToList(),
            }).FirstOrDefaultAsync(cancellationToken);
        
        if (car == null)
        {
            throw new NotFoundInDatabase($"Samochodu o id {id} nie znałezniono!");
        }
        
        if (car.Owners.Count > 0)
        {
            if (car.Owners.FirstOrDefault().DrivingLicense == null)
            {
                car.Ubezpieczenie = car.ProductionYear + 200;
            }
            else
            {
                car.Ubezpieczenie = car.ProductionYear - 300;
            }
        }
        
        return car;
    }

    public async Task AddCar(CarAddDTO car, CancellationToken cancellationToken = default)
    {
        Car newCar = new Car()
        {
            Make = car.Make,
            ProductionYear = car.ProductionYear
        };

        int ownersCount = 0;
        foreach (var carOwner in car.Owners)
        {
            var person = _context.Persons.FirstOrDefault(p => p.IdPerson == carOwner.IdPerson);

            if (person == null)
            {
                throw new NotFoundInDatabase($"Persony o id {carOwner.IdPerson} nie znałezniono!");
            }

            if (carOwner.IsOwner)
            {
                ownersCount++;
            }
        }

        if (ownersCount > 1)
        {
            throw new MoreThanOneOwner("We wprowadzonych personach więcej niż 1 właściciel");
        }
        
        await _context.Cars.AddAsync(newCar);

        await _context.SaveChangesAsync(cancellationToken);
        
        foreach (var carOwner in car.Owners)
        {
            var person = _context.Persons.FirstOrDefault(p => p.IdPerson == carOwner.IdPerson);
            
            await _context.CarPersons.AddAsync(new Car_Person()
            {
                IdCar = newCar.IdCar,
                IdPerson = person.IdPerson,
                MainOwner = carOwner.IsOwner
            });
        }
        
        await _context.SaveChangesAsync(cancellationToken);
    }
}