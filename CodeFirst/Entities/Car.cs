namespace Kolokwium2.Entities;

public class Car
{
    public int IdCar { get; set; }
    public string Make { get; set; }
    public int ProductionYear { get; set; }
    public virtual ICollection<Car_Person>? CarPersons { get; set; } = new List<Car_Person>();
}