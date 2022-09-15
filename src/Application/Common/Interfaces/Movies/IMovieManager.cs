﻿using Application.Features.Movies.Responses;

namespace Application.Common.Interfaces.Movies;
public interface IMovieManager
{
    Task<GetAllPagedMovieResponse> GetAllPaged(int pageNumber, int pageSize);
    Task AddMovieAsync(string imdbId);
}
