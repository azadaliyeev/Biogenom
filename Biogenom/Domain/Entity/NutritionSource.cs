namespace Biogenom.Model.Entity;

public class NutritionSource
{
    public int Id { get; set; }
    public decimal? CurrentNutrition { get; set; }
    public decimal? SupplementNutrition { get; set; }
    public decimal? FoodNutrition { get; set; }
    public bool IsDelete { get; set; }

    public ICollection<UserNutrientLog> UserNutrientLogs { get; set; }
}