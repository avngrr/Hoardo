using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces.Repository;
using Application.Features.Movies.Responses;
using AutoMapper;
using Domain.Entities.Movies;
using MediatR;
using Shared.Wrappers;

namespace Application.Features.Movies.Queries;
public class GetAllPagedMoviesQuery : IRequest<PagedList<MovieResponse>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public GetAllPagedMoviesQuery(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
internal class GetAllPagedMoviesQueryHandler : IRequestHandler<GetAllPagedMoviesQuery, PagedList<MovieResponse>>
{
    private readonly IUnitOfWork<int> _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllPagedMoviesQueryHandler(IUnitOfWork<int> unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PagedList<MovieResponse>> Handle(GetAllPagedMoviesQuery request, CancellationToken cancellationToken)
    {
        var movieList = await _unitOfWork.Repository<Movie>().GetPagedResponseAsync(request.PageNumber, request.PageSize);
        var mappedMovies = _mapper.Map<PagedList<MovieResponse>>(movieList);
        return mappedMovies;
    }
}
