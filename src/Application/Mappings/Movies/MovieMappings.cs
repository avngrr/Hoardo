using Application.Features.Movies.Responses;
using AutoMapper;
using Domain.Entities.Movies;

namespace Application.Mappings.Movies;
public class MovieMappings : Profile
{
    public MovieMappings()
    {
        CreateMap<Movie, MovieResponse>();
    }
}
