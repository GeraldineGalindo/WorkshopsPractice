using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workshops.BusinessLogic;
using Workshops.Exceptions;
using Workshops.Models;

namespace Workshops.Controllers
{
    [Route("api/workshops")]
    [ApiController]
    public class WorkshopsController : ControllerBase
    {
        private readonly IWorkshopService _service;
        public WorkshopsController(IWorkshopService service)
        {
            this._service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Workshop>> GetAllWorkshops()
        {
            try
            {
                return Ok(_service.GetAllWorkshops());
            }
            catch (EmptyCollectionException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"Something bad happened: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something bad happened: {ex.Message}");
            }
        }

     
        [HttpGet("{workshopId}")]
        public ActionResult<Workshop> GetWorkshopById([FromRoute] int workshopId)
        {
            try
            {
                return Ok(_service.GetWorkshopById(workshopId));
            }
            catch (NotFoundItemException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"Something bad happened: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something bad happened: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<Workshop> CreateWorkshop([FromBody] Workshop workshop)
        {
            try
            {
                var createdWorkshop = _service.CreateWorkshop(workshop);
                return Created("api/workshops/" + createdWorkshop.Id, createdWorkshop);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something bad happened: {ex.Message}");
            }
        }

       
        [HttpDelete("{workshopId}")]
        public ActionResult<bool> DeleteWorkshopById([FromRoute] int workshopId)
        {
            try
            {
                return Ok(_service.DeleteWorkshop(workshopId));
            }
            catch (NotFoundItemException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"Something bad happened: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something bad happened: {ex.Message}");
            }
        }

        [HttpPut("{workshopId}")]
        public ActionResult<Workshop> UpdateWorkshop([FromRoute] int workshopId,[FromBody] Workshop workshop, [FromQuery] string action)
        {
            try
            {
                return Ok(_service.UpdateWorkshop(workshopId, workshop, action));
            }
            catch (DataMismatchException ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, $"Something bad happened: {ex.Message}");
            }
            catch (NotFoundItemException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"Something bad happened: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something bad happened: {ex.Message}");
            }
        }

    }
}