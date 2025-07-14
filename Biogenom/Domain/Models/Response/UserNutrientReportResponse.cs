namespace Biogenum.Domain.Models;

public class UserNutritionReportDto
{
    public string UserId { get; set; }
    public NutritionEvaluationDto Evaluation { get; set; }
    public List<NutrientInfoDto> Nutrients { get; set; }
}