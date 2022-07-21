using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces.Repository;
using Application.Features.Movies.Responses;
using AutoMapper;
using Domain.Entities.Movies;
using MediatR;
using Shared.Wrappers;

namespace Application.Features.Movies.Queries;
public class GetAllPagedMoviesQuery
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
