namespace Biogenom.Model.Entity;

public class NutrientStandard
{
    public int Id { get; set; }
    public decimal? MinNorm { get; set; }
    public decimal? MaxNorm { get; set; }
    public decimal? RecommendedValue { get; set; }
    public bool IsInRange { get; set; }

    public ICollection<Nutrient> Nutrients { get; set; }
}