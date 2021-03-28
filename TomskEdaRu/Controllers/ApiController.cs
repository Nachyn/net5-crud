using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace TomskEdaRu.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        private ISender _mediator;

        protected ISender Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<ISender>();
    }
}