namespace Kolokwium2.Entities;

public class Car_Person
{
    public int IdCar { get; set; }
    public int IdPerson { get; set; }
    public bool MainOwner { get; set; }
    public virtual Car Car { get; set; }
    public virtual Person Person { get; set; }
}