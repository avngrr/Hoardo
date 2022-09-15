namespace Application.Features.Movies.Responses;
public class MovieSearchResponse
{
    public string ImdbId { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public bool Added { get; set; }
}
