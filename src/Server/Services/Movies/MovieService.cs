using Application.Common.Interfaces.Movies;
using Application.Common.Interfaces.Repository;
using Domain.Entities.Movies;
using Shared.Wrappers;

namespace Server.Services.Movies;

public class MovieService : IMovieService
{
    private readonly IUnitOfWork _unitOfWork;
    public MovieService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Task AddAsync(Movie movie)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(string imdbId)
    {
        throw new NotImplementedException();
    }
    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Movie>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<PagedList<Movie>> GetAllPaged(int pageNumber, int pageSize)
    {
        return await _unitOfWork.Repository<Movie>().GetPagedResponseAsync(pageNumber, pageSize);
    }

    public Task<Movie> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id)
    {
        throw new NotImplementedException();
    }
}
