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

        [Route("api/workshops")]
        [HttpPost]
        public ActionResult<Workshop> CreateWorkshop([FromBody] Workshop workshop)
        {
            try
            {
                var createdWorkshop = service.CreateWorkshop(workshop);
                return Created("api/workshops/" + createdWorkshop.Id, createdWorkshop);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Route("api/workshops/{workshopId}")]
        [HttpDelete]
        public ActionResult<bool> DeleteWorkshopById([FromRoute] int workshopId)
        {
            try
            {
                return Ok(service.DeleteWorkshop(workshopId));
            }
            catch (Exception)
            {

                return NotFound();
            }
        }

        [Route("api/workshops/{workshopId}")]
        [HttpPut]
        public ActionResult<Workshop> UpdateWorkshop([FromRoute] int workshopId,[FromBody] Workshop workshop)
        {
            try
            {
                return Ok(service.UpdateWorkshop(workshopId, workshop));
            }
            catch (Exception)
            {

                return NotFound();
            }
        }

        [Route("api/workshops/{workshopId}/pospone")]
        [HttpPut]
        public ActionResult<Workshop> PosponeWorkshopById([FromRoute] int workshopId)
        {
            try
            {
                return Ok(service.PosponeWorkshop(workshopId));
            }
            catch (Exception)
            {

                return NotFound();
            }
        }
    }
}