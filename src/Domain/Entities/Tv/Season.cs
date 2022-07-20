using Domain.Contracts;

namespace Domain.Entities.Tv;
public class Season : EntityBase<int>
{
    public int SeriesId { get; set; }
    public int SeasonNumber { get; set; }
    public virtual List<Episode> Episodes { get; set; }
}
