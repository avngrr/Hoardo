using Application.Features.Movies.Queries;
using Application.Features.Movies.Responses;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Shared.Wrappers;
using MediatR;
using Application.Common.Interfaces.Repository;
using Domain.Entities.Movies;
using AutoMapper;

namespace Server.Endpoints.Movies;

[HttpGet("movies"), AllowAnonymous]
public class GetAllMoviesEndpoint : Endpoint<GetAllPagedMoviesQuery, GetAllPagedMovieResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllMoviesEndpoint(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;   
    }

    public override async Task HandleAsync(GetAllPagedMoviesQuery query, CancellationToken cancellationToken)
    {
        var moviesList = await _unitOfWork.Repository<Movie>().GetPagedResponseAsync(query.PageNumber, query.PageSize);
        var mappedMoviesList = _mapper.Map<List<MovieResponse>>(moviesList);
        GetAllPagedMovieResponse result = new GetAllPagedMovieResponse()
        {
            MovieList = new PagedList<MovieResponse>(mappedMoviesList, mappedMoviesList.Count, query.PageNumber, query.PageSize)
        };
        await SendOkAsync(cancellationToken);
    }
}
