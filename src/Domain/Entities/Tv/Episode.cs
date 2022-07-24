using Domain.Contracts;

namespace Domain.Entities.Tv;
public class Episode : EntityBase
{
    public int FileId { get; set; }
    public bool HasFile => FileId > 0;
    public int SeasonId { get; set; }
    public int EpisodeNumber { get; set; }
    public string Title { get; set; }
    public string AirDate { get; set; }
    public bool Monitored { get; set; }
    public string SeriesTitle { get; set; }
}
