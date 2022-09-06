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
    public async Task AddAsync(Movie movie)
    {
        await _unitOfWork.Repository<Movie>().AddAsync(movie);
        await _unitOfWork.Save(CancellationToken.None);
    }
    public Task AddAsync(string imdbId)
    {
        //Search IMDB for the movie and fill all the metadata and add it to db.
        throw new NotImplementedException();
    }
    public async Task DeleteAsync(int id)
    {
        Movie m = await GetAsync(id);
        await _unitOfWork.Repository<Movie>().DeleteAsync(m);
        await _unitOfWork.Save(CancellationToken.None);
    }

    public async Task<List<Movie>> GetAllAsync()
    {
        return await _unitOfWork.Repository<Movie>().GetAllAsync();
    }

    public async Task<PagedList<Movie>> GetAllPaged(int pageNumber, int pageSize)
    {
        return await _unitOfWork.Repository<Movie>().GetPagedResponseAsync(pageNumber, pageSize);
    }

    public async Task<Movie> GetAsync(int id)
    {
        return await _unitOfWork.Repository<Movie>().GetByIdAsync(id);
    }

    public async Task UpdateAsync(Movie movie)
    {
        await _unitOfWork.Repository<Movie>().UpdateAsync(movie);
        await _unitOfWork.Save(CancellationToken.None);
    }
}
