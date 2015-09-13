using Microsoft.AspNet.Mvc;

namespace Coupling.Modern.Controllers
{
    public class GarageOwnerBaseController : BaseController
    {
        [HttpGet]
        public IActionResult Create()
        {
            return new EmptyResult();
        }

        [HttpPost]
        public IActionResult Create(GarageOwnerDto garageOwnerDto)
        {
            return new EmptyResult();
        }

        public IActionResult Edit()
        {
            return new EmptyResult();
        }

        public IActionResult Delete()
        {
            return new EmptyResult();
        }

        public IActionResult Details()
        {
            return new EmptyResult();
        }
    }

    public class GarageOwnerDto
    {

    }
}