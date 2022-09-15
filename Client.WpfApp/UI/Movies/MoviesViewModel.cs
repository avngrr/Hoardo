using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Common.Interfaces.Movies;
using Application.Features.Movies.Responses;
using Client.WpfApp.UI.Base;

namespace Client.WpfApp.UI.Movies;
public class MoviesViewModel : ViewModelBase
{
    private readonly IMovieManager _movieManager;
    private GetAllPagedMovieResponse _allPagedMovies;
    public int CurrentPage => _allPagedMovies.CurrentPage;
    public int PageSize => _allPagedMovies.PageSize;
    public List<MovieResponse> Movies => _allPagedMovies?.MovieList != null ? _allPagedMovies.MovieList : new List<MovieResponse>();
    public bool HasNext => _allPagedMovies.HasNext;
    public bool HasPrevious => _allPagedMovies.HasPrevious;
    public MoviesViewModel(IMovieManager movieManager)
    {
        _movieManager = movieManager;
        Refresh();
    }
    private async void Refresh()
    {
        await LoadData(1, 10);
    }
    public async Task LoadData(int pageNumber, int pageSize)
    {
        _allPagedMovies = await _movieManager.GetAllPaged(pageNumber, pageSize);
        OnPropertyChanged(nameof(Movies));
        OnPropertyChanged(nameof(CurrentPage));
        OnPropertyChanged(nameof(PageSize));
        OnPropertyChanged(nameof(HasNext));
        OnPropertyChanged(nameof(HasPrevious));
    }
}
