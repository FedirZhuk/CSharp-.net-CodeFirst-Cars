namespace Kolokwium2.Entities;

public class Person
{
    public int IdPerson { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? DrivingLicense { get; set; }
    public virtual ICollection<Car_Person>? CarPersons { get; set; } = new List<Car_Person>();
}