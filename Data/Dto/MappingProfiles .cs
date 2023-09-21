using AutoMapper;
using brandlessBar.Data.Models;

namespace brandlessBar.Data.Dto;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Ingredient, IngredientDto>();
		CreateMap<IngredientDto, Ingredient>();

        CreateMap<Alternative, AlternativeDto>(); 
        CreateMap<AlternativeDto, AlternativeDto>();

		CreateMap<Cocktail, CocktailDto>();
		CreateMap<CocktailDto, Cocktail>();
	}
}
