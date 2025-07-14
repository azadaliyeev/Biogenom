using Biogenom.Model.Entity;
using Biogenum.Domain.Models;
using Biogenum.Domain.Models.Request;

namespace Biogenum.Domain.Services;

public interface IUserService
{
    Task<Response<List<UserNutritionReportDto>>> GetUserInfoAsync(UserNutrientReportRequest request);
}