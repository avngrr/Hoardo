namespace Application.Routes.Searchers;
public class SearchEndpoints
{
    public static string SearchMovie(string expression) => $"search/movie?expression={expression}";
}
