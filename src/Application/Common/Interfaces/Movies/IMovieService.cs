﻿using Domain.Entities.Movies;
using Shared.Wrappers;

namespace Application.Common.Interfaces.Movies;
public interface IMovieService
{
    Task AddAsync(string imdbId);
    Task AddAsync(Movie movie);
    Task<Movie> GetAsync(int id);
    Task DeleteAsync(int id);
    Task UpdateAsync(int id);
    Task<List<Movie>> GetAllAsync();
    Task<PagedList<Movie>> GetAllPaged(int pageNumber, int pageSize);
}
