namespace Application.Features.Movies.Commands;
public class CreateMovieCommand
{
    public string ImdbId { get; set; }
    public string Title { get; set; }
    public string Overview { get; set; }
    public int Year { get; set; }
    public bool Monitored { get; set; }
    public bool Seen { get; set; }
    public List<string> Genres { get; set; }
}
