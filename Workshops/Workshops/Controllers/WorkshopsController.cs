using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workshops.BusinessLogic;
using Workshops.Models;

namespace Workshops.Controllers
{
    
    [ApiController]
    public class WorkshopsController : Controller
    {
        private readonly IWorkshopService service;
        public WorkshopsController(IWorkshopService service)
        {
            this.service = service;
        }

        [Route("api/workshops")]
        [HttpGet]
        public ActionResult<IEnumerable<Workshop>> GetAllWorkshops()
        {
            try
            {
                return Ok(service.GetAllWorkshops());
            }
            catch (Exception)
            {

                return NoContent();
            }
        }
    }
}