namespace Domain.Entities.Tv;
public class Serie : MediaInfo
{
    public int TvdbId { get; set; }
    public DateTime? FirstAired { get; set; }
    public string AirTime { get; set; }
    public int Runtime { get; set; }
    public virtual List<Season> Seasons { get; set; }
}
