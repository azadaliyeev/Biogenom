namespace Biogenom.Model.Entity;

public class Nutrient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ScientificName { get; set; }
    public int UnitId { get; set; }
    public Unit Unit { get; set; }
    public int NutrientsId { get; set; }
    public NutrientStandard NutrientStandard { get; set; }

    public ICollection<UserNutrientLog> UserNutrientLogs { get; set; }
}