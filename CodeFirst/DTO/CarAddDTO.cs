namespace Kolokwium2.DTO;

public class CarAddDTO
{
    public string Make { get; set; }
    public int ProductionYear { get; set; }
    public ICollection<PersonCarAddDTO>? Owners { get; set; } = new List<PersonCarAddDTO>();
}