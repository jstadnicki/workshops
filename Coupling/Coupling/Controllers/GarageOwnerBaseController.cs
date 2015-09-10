namespace Coupling.Controllers
{
    using System.Web.Mvc;

    public class GarageOwnerBaseController : BaseController
    {
        [HttpGet]
        public ActionResult Create()
        {
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult Create(GarageOwnerDto garageOwnerDto)
        {
            return new EmptyResult();
        }

        public ActionResult Edit()
        {
            return new EmptyResult();
        }

        public ActionResult Delete()
        {
            return new EmptyResult();
        }

        public ActionResult Details()
        {
            return new EmptyResult();
        }
    }

    public class GarageOwnerDto
    {

    }
}