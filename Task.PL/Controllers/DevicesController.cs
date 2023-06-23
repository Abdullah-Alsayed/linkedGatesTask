using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Task.BL.Services;
using Task.CommonDefinitions.BaseRequest;
using Task.CommonDefinitions.DTOs;
using Task.DAL.DB;
namespace Task.Controllers
{
    public class DevicesController : Controller
    {

        public readonly TaskDbContext _Context;
        public DevicesController(TaskDbContext context)
        {
            _Context = context;
        }
        public IActionResult Main()
        {
            var Response = DevicesServices.GetDevices(new BaseRequest<DeviceDTO>() { Context = _Context });
            if (Response.Success)
                return View(Response.EntityDTOs);
            else
                return View();
        }
        public IActionResult Create()
        {
            ViewBag.DeviceCategory = CategoryServices.GetCategoryes(new BaseRequest<CategoryDTO>() { Context = _Context }).EntityDTOs;
            ViewBag.Properties = PropertyServices.GetProperties(new BaseRequest<PropertyDTO> { Context = _Context}).EntityDTOs;

            return View();
        }
        [HttpPost]  
        public IActionResult Create(DeviceDTO DTO)
        {            
            var Response = DevicesServices.CreateDevice(new BaseRequest<DeviceDTO>() { Context = _Context, EntityDTO = DTO });
                return Json(Response);
        }
        public IActionResult Edit(int ID)
        {
            ViewBag.DeviceCategory = CategoryServices.GetCategoryes(new BaseRequest<CategoryDTO>() { Context = _Context }).EntityDTOs;
            ViewBag.Properties = PropertyServices.GetProperties(new BaseRequest<PropertyDTO> { Context = _Context }).EntityDTOs;

            var Response = DevicesServices.GetDevice(new BaseRequest<DeviceDTO>()
            {
                Context = _Context,
                ID = ID,
            });
            if (Response.Success)
                return View(Response.EntityDTO);
            else
                return RedirectToAction(nameof(Main));
        }
        [HttpPost]
        public IActionResult Edit(DeviceDTO DTO)
        {
            var Response = DevicesServices.EditDevice(new BaseRequest<DeviceDTO>() { Context = _Context, EntityDTO = DTO });
            return Json(Response);
        }

        public IActionResult GetProperties(int ID)
        {
            var Response = PropertyServices.GetProperties(new BaseRequest<PropertyDTO> { Context = _Context, ID = ID });

            return Json(Response);
        }
    }
}
