using System;
using Mediator;
using MovieProject.Application.Models;

namespace MovieProject.Application.Features.PublisherCompanies;

public class ListPublisherCompanyQuery : IRequest<ResponseModel<List<ListPublisherCompanyResponse>>>
{

}


