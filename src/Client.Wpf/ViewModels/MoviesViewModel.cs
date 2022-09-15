using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Application.Common.Interfaces.Movies;
using Application.Common.Interfaces.Searchers;
using Application.Features.Movies.Responses;
using CommunityToolkit.Mvvm.Input;

namespace Client.Wpf.ViewModels;
public class MoviesViewModel : ViewModelBase
{
    private readonly IMovieManager _movieManager;
    private readonly ISearchManager _searchManager;
    private GetAllPagedMovieResponse _allPagedMovies;
    private GetMovieSearchResults _allSearchResults;
    public List<MovieResponse> Movies => _allPagedMovies?.MovieList != null ? _allPagedMovies.MovieList : new List<MovieResponse>();
    public List<MovieSearchResponse> SearchMoviesList => _allSearchResults?.MovieList != null ? _allSearchResults.MovieList : new List<MovieSearchResponse>();
    public bool HasNext => _allPagedMovies?.HasNext != null ? _allPagedMovies.HasNext : false;
    public bool HasPrevious => _allPagedMovies?.HasPrevious != null ? _allPagedMovies.HasPrevious : false;
    public int CurrentPage => _allPagedMovies.CurrentPage;
    public int PageSize => _allPagedMovies.PageSize;
    public string SearchString { get; set; }
    public Visibility SearchVisible => SearchString != "" ? Visibility.Visible : Visibility.Collapsed;
    public Visibility SearchNotVisible => SearchVisible != Visibility.Visible ? Visibility.Visible : Visibility.Collapsed;
    public ICommand CmdAddMovie { get; private set; }
    public MoviesViewModel(IMovieManager movieManager, ISearchManager searchManager)
    {
        _movieManager = movieManager;
        _searchManager = searchManager;
        SearchString = "";
        LoadData(1, 10);
        CmdAddMovie = new RelayCommand<string>(s => AddMovie(s));
    }
    public async void LoadData(int pageNumber, int pageSize)
    {
        _allPagedMovies = await _movieManager.GetAllPaged(pageNumber, pageSize);
        OnPropertyChanged(nameof(Movies));
    }
    public async Task SearchData(string expression)
    {
        SearchString = expression;
        if (!string.IsNullOrEmpty(SearchString))
        {
            _allSearchResults = await _searchManager.GetSearchResults(expression);
        }
        OnPropertyChanged(nameof(SearchMoviesList));
        OnPropertyChanged(nameof(SearchString));
        OnPropertyChanged(nameof(SearchVisible));
        OnPropertyChanged(nameof(SearchNotVisible));
    }
    private async void AddMovie(string imdbId)
    {
        await _movieManager.AddMovieAsync(imdbId);
        LoadData(CurrentPage, PageSize);
        OnPropertyChanged(nameof(SearchString));
        OnPropertyChanged(nameof(SearchVisible));
        OnPropertyChanged(nameof(SearchNotVisible));
        OnPropertyChanged(nameof(Movies));
    }
}
