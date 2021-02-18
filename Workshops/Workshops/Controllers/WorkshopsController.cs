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
    public class WorkshopsController : ControllerBase
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

        [Route("api/workshops/{workshopId}")]
        [HttpGet]
        public ActionResult<Workshop> GetWorkshopById([FromRoute] int workshopId)
        {
            try
            {
                return Ok(service.GetWorkshopById(workshopId));
            }
            catch (Exception)
            {

                return NotFound();
            }
        }
    }
}