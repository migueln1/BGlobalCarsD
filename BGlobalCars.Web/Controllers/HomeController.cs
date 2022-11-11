using BGlobalCars.Application.Vehicles.Reponses;
using BGlobalCars.Application.Vehicles.Requests;
using BGlobalCars.Application.Vehicles.ViewModels.Vehicles;
using BGlobalCars.Web.Models;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BGlobalCars.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;
        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _mediator.Send(new RenderVehicleListRequest(), cancellationToken: default);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index([FromBody] AddVehicleRequest request)
        {
            if (ModelState.IsValid)
            {
                var actionResult = await _mediator
                    .Send(request.Adapt<AddVehicleRequest>(), cancellationToken: default);
                var response = actionResult.Match(
                    vehicle => new ProcessResponse(true),
                    sqlError => new ProcessResponse(false, sqlError.Message)
                );
                if (!response.Status)
                {
                    return Ok(response.Message);
                }
                var vehicles = (await _mediator.Send(new GetAllVehiclesRequest(), cancellationToken: default))
                    .Select(v => v.Adapt<VehicleViewModel>()).ToList();

                return PartialView("~/Views/Shared/_VehicleList.cshtml", vehicles);
            }
            else
            {
                return null;
            }
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}