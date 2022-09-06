namespace Application.Routes.Movies;
public static class MovieEndpoints
{
    public static string GetAllPagedMovies(int pageNumber, int pageSize) => $"movies?pageNumber={pageNumber}&pageSize={pageSize}";
    public static string AddMovie = "movies";
}
