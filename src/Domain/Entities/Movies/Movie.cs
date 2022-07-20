namespace Domain.Entities.Movies;
public class Movie : MediaInfo
{
    public int FileId { get; set; }
    public bool HasFile => FileId > 0;
}
