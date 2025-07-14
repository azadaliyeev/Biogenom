using System.Net;
using AutoMapper;
using Biogenom.Model.Entity;
using Biogenom.Repository.UnitOfWork;
using Biogenum.Domain.Models;
using Biogenum.Domain.Models.Request;
using Biogenum.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Biogenum.Application.Services;

public class UserService(IUnitOfWork unitOfWork, IMapper mapper) : IUserService
{
    public async Task<Response<List<UserNutritionReportDto>>> GetUserInfoAsync(UserNutrientReportRequest request)
    {
        var userNutrientLogs = await unitOfWork.UserNutrientLogRepository
            .CustomWhere(x => x.UserId == request.UserId && !x.NutritionSource.IsDelete)
            .Include(unl => unl.NutritionSource)
            .Include(unl => unl.Nutrient)
            .ThenInclude(n => n.Unit)
            .Include(unl => unl.Nutrient)
            .ThenInclude(n => n.NutrientStandard)
            .ToListAsync();

        var rawList = userNutrientLogs
            .Select(unl => new
            {
                unl.UserId,
                unl.CreateDate,
                Nutrient = mapper.Map<NutrientInfoDto>(unl)
            })
            .ToList();

        var grouped = rawList
            .GroupBy(x => new { x.UserId, x.CreateDate })
            .Select(g => new UserNutritionReportDto
            {
                UserId = g.Key.UserId,
                Nutrients = g.Select(x => x.Nutrient).ToList()
            })
            .ToList();

        grouped[0].Evaluation = EvaluateNutritionStatus(grouped);

        return Response<List<UserNutritionReportDto>>.Success(grouped, HttpStatusCode.Accepted.GetHashCode());
    }

    private NutritionEvaluationDto EvaluateNutritionStatus(List<UserNutritionReportDto> reports)
    {
        int adequate = 0;
        int inadequate = 0;
        int excessive = 0;

        foreach (var report in reports)
        {
            foreach (var nutrient in report.Nutrients)
            {
                var value = nutrient.CurrentNutrition;

                if (nutrient.IsInRange)
                {
                    if (value >= nutrient.MinNorm && value <= nutrient.MaxNorm)
                        adequate++;
                    else if (value < nutrient.MinNorm)
                        inadequate++;
                    else
                        excessive++;
                }
                else
                {
                    if (decimal.Abs(value - nutrient.RecommendedValue) <= 0.01m)
                        adequate++;
                    else if (value < nutrient.RecommendedValue)
                        inadequate++;
                    else
                        excessive++;
                }
            }
        }

        return new NutritionEvaluationDto
        {
            AdequateCount = adequate,
            InadequateCount = inadequate,
            ExcessiveCount = excessive
        };
    }
}