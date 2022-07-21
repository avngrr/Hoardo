using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Wrappers;

namespace Application.Features.Movies.Responses;
public class GetAllPagedMovieResponse
{
    public PagedList<MovieResponse>? MovieList { get; set; }
}
