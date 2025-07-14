using AutoMapper;
using Biogenom.Model.Entity;
using Biogenum.Domain.Models;

namespace Biogenum.Application.Mapping;

public class UserNutrientProfile : Profile
{
    public UserNutrientProfile()
    {
        CreateMap<UserNutrientLog, NutrientInfoDto>()
            .ForMember(dest => dest.NutrientName, opt => opt.MapFrom(src => src.Nutrient.Name))
            .ForMember(dest => dest.ScientificName, opt => opt.MapFrom(src => src.Nutrient.ScientificName))
            .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.Nutrient.Unit.Name))
            .ForMember(dest => dest.MinNorm, opt => opt.MapFrom(src => src.Nutrient.NutrientStandard.MinNorm))
            .ForMember(dest => dest.MaxNorm, opt => opt.MapFrom(src => src.Nutrient.NutrientStandard.MaxNorm))
            .ForMember(dest => dest.RecommendedValue,
                opt => opt.MapFrom(src => src.Nutrient.NutrientStandard.RecommendedValue))
            .ForMember(dest => dest.IsInRange, opt => opt.MapFrom(src => src.Nutrient.NutrientStandard.IsInRange))
            .ForMember(dest => dest.CurrentNutrition,
                opt => opt.MapFrom(src => src.NutritionSource.CurrentNutrition ?? 0))
            .ForMember(dest => dest.FoodNutrition, opt => opt.MapFrom(src => src.NutritionSource.FoodNutrition ?? 0))
            .ForMember(dest => dest.SupplementNutrition,
                opt => opt.MapFrom(src => src.NutritionSource.SupplementNutrition ?? 0));
    }
}