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

    [ApiController]
    public class WorkshopsController : ControllerBase
    {
        private readonly IWorkshopService _service;
        public WorkshopsController(IWorkshopService service)
        {
            this._service = service;
        }

        [Route("api/workshops")]
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

        [Route("api/workshops/{workshopId}")]
        [HttpGet]
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

        [Route("api/workshops")]
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

        [Route("api/workshops/{workshopId}")]
        [HttpDelete]
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

        [Route("api/workshops/{workshopId}")]
        [HttpPut]
        public ActionResult<Workshop> UpdateWorkshop([FromRoute] int workshopId,[FromBody] Workshop workshop)
        {
            try
            {
                return Ok(_service.UpdateWorkshop(workshopId, workshop));
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

        [Route("api/workshops/{workshopId}/pospone")]
        [HttpPut]
        public ActionResult<Workshop> PosponeWorkshopById([FromRoute] int workshopId)
        {
            try
            {
                return Ok(_service.PosponeWorkshop(workshopId));
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

        [Route("api/workshops/{workshopId}/cancel")]
        [HttpPut]
        public ActionResult<Workshop> CancelWorkshopById([FromRoute] int workshopId)
        {
            try
            {
                return Ok(_service.CancelWorkshop(workshopId));
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