using ListDevice.Application.Features.DeviceR.Commands.Models.DeviceQuery;
using ListDevice.Application.Features.DeviceR.Query.Models;
using ListDevice.Application.Features.DeviceR.Query.Models.UserQuery;
using ListDevice.Application.Features.DeviceR.Query.Models.CategoryQuery;
using ListDevice.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ListDevice.Web.Controllers
{
    public class DeviceController : Controller
    {

        private readonly IMediator mediator;

        public DeviceController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        public async Task<IActionResult> Index()
        {
            var respons = await mediator.Send(new GetAllDeviceQuery());



            if (!respons.Succeeded)
            {

                return View("Error", respons.Errors);
            }

            var categories = await mediator.Send(new GetAllCategoriesQuery());


            ViewBag.Categories = new SelectList(categories.Data, "CategoryName", "CategoryName");

            return View(respons.Data);

        }



        //=================================================================


        [HttpGet]
        public async Task<IActionResult> Create(string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName))
            {

                return RedirectToAction("Index");
            }

            //------------------------------------------------------
            var properties = await mediator.Send(new GetAllCategoryPropertiesQuery(categoryName));
            //------------------------------------------------------




            //------------------------------------------------------
            var usersResponse = await mediator.Send(new GetAllUserQuery());
            ViewBag.Users = new SelectList(usersResponse.Data, "FullName", "FullName");
            //------------------------------------------------------



            //------------------------------------------------------
            var categories = await mediator.Send(new GetAllCategoriesQuery());
            ViewBag.Categories = new SelectList(categories.Data, "Id", "CategoryName",
                                                categories.Data.FirstOrDefault(c => c.CategoryName == categoryName)?.Id);
            //------------------------------------------------------



            var model = new DeviceCreateViewModel
            {
               

                Properties = properties.Data.ToList()
            };


            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> Create(DeviceCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }



            var response = await mediator.Send(new AddDeviceQuery(model));

            if (!response.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while saving the device. Please try again.");
                return View(model);
            }


            return RedirectToAction("Index");
        }
    }
}
