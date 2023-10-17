namespace Kolokwium2.DTO;

public class CarGetDTO
{
    public string Make { get; set; }
    public int ProductionYear { get; set; }
    public ICollection<PersonDTO>? Owners { get; set; } = new List<PersonDTO>();
    public int Ubezpieczenie { get; set; }
}