using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace Server.Endpoints.Movies;

[HttpGet("movies"), AllowAnonymous]
public class GetAllMoviesEndpoint
{

}
