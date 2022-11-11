using BGlobalCars.Application.Brands.Handlers;
using BGlobalCars.Application.Vehicles.Reponses;
using BGlobalCars.Application.Vehicles.Requests;
using BGlobalCars.Application.Vehicles.Responses.Vehicles;
using BGlobalCars.Application.Vehicles.ViewModels.Vehicles;
using BGlobalCars.Core.VehicleAggregate;
using BGlobalCars.Web.Models;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Diagnostics;

namespace BGlobalCars.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;
        private ICompositeViewEngine _viewEngine;
        public HomeController(ILogger<HomeController> logger, IMediator mediator, ICompositeViewEngine viewEngine)
        {
            _logger = logger;
            _mediator = mediator;
            _viewEngine = viewEngine;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _mediator.Send(new RenderVehicleListRequest(), cancellationToken: default);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromBody] AddVehicleRequest request, CancellationToken ct)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new { Success = false, Errors = ModelState.Values.SelectMany(e=>e.Errors) });
                //var brandList = await _mediator.Send(new GetBrandOptionsRequest(),cancellationToken: ct);
                //var modalModel = new AddVehicleViewModel(brandList, request);
                //return PartialView("~/Views/Shared/_AddVehicleModal.cshtml", modalModel);
                //PartialViewResult partialViewResult = PartialView("_AddVehicleModal", modalModel);
                //string viewBadContent = ConvertViewToString(this.ControllerContext, partialViewResult, _viewEngine);
                ////return Json(new { PartialView = viewContent });
                //return BadRequest(new { PartialView = viewBadContent });
            }
            
            var actionResult = await _mediator
                .Send(request.Adapt<AddVehicleRequest>(), cancellationToken: ct);
            
            var response = actionResult.Match(
                vehicle => new ProcessResponse(true),
                sqlError => new ProcessResponse(false, sqlError.Message)
            );
            
            if (!response.Status)
            {
                return Ok(response.Message);
            }
            
            var vehicles = (await _mediator.Send(new GetAllVehiclesRequest(), cancellationToken: ct))
                .Select(v => v.Adapt<VehicleViewModel>()).ToList();
            PartialViewResult partialViewResult = PartialView("_VehicleList", vehicles);
            string viewContent = ConvertViewToString(this.ControllerContext, partialViewResult, _viewEngine);
            return Ok(new { Success = true, PartialView = viewContent });
            return PartialView("~/Views/Shared/_VehicleList.cshtml", vehicles);
            
        }
        public string ConvertViewToString(ControllerContext controllerContext, PartialViewResult pvr, ICompositeViewEngine _viewEngine)
        {
            using StringWriter writer = new();
            ViewEngineResult vResult = _viewEngine.FindView(controllerContext, pvr.ViewName, false);
            ViewContext viewContext = new(controllerContext, vResult.View, pvr.ViewData, pvr.TempData, writer, new HtmlHelperOptions());

            vResult.View.RenderAsync(viewContext);

            return writer.GetStringBuilder().ToString();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}