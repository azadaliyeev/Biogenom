namespace Biogenom.Model.Entity;

public class Unit
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Nutrient> Nutrients { get; set; }
}