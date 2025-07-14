namespace Biogenom.Model.Entity;

public class UserNutrientLog
{
    public int Id { get; set; }
    public int NutritionSourceId { get; set; }
    public NutritionSource NutritionSource { get; set; }
    public int NutrientId { get; set; }
    public Nutrient Nutrient { get; set; }
    public string UserId { get; set; }
    public DateTime? CreateDate { get; set; }
}