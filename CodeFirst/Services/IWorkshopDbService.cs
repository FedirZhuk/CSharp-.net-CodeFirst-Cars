using Kolokwium2.DTO;

namespace Kolokwium2.Services;

public interface IWorkshopDbService
{
    Task<CarGetDTO> GetCarAsync(int id, CancellationToken cancellationToken = default);
    Task AddCar(CarAddDTO car, CancellationToken cancellationToken = default);
}