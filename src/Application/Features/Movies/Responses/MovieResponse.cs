using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Movies.Responses;

public class MovieResponse
{
    public string ImdbId { get; set; }
    public string Title { get; set; }
    public string CleanTitle { get; set; }
    public string Overview { get; set; }
    public bool Monitored { get; set; }
    public int Year { get; set; }
    public List<string> Genres { get; set; }
    public DateTime Added { get; set; }
}
