using System.Collections.Generic;
using Application.Common.Interfaces.Movies;
using Application.Features.Movies.Responses;

namespace Client.Wpf.ViewModels;
public class MoviesViewModel : ViewModelBase
{
    private readonly IMovieManager _movieManager;
    private GetAllPagedMovieResponse _allPagedMovies;
    public List<MovieResponse> Movies => _allPagedMovies?.MovieList != null ? _allPagedMovies.MovieList : new List<MovieResponse>();
    public MoviesViewModel(IMovieManager movieManager)
    {
        _movieManager = movieManager;
        LoadData(1, 10);
    }
    public async void LoadData(int pageNumber, int pageSize)
    {
        _allPagedMovies = await _movieManager.GetAllPaged(pageNumber, pageSize);
        OnPropertyChanged(nameof(Movies));
    }
}
