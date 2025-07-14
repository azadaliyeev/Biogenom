namespace Biogenum.Domain.Models;

public class NutrientInfoDto
{
    public string NutrientName { get; set; }
    public string ScientificName { get; set; }
    public string Unit { get; set; }
    public decimal MinNorm { get; set; }
    public decimal MaxNorm { get; set; }
    public decimal RecommendedValue { get; set; }
    public bool IsInRange { get; set; }
    public decimal CurrentNutrition { get; set; }
    public decimal FoodNutrition { get; set; }
    public decimal SupplementNutrition { get; set; }
}