using Demo.Data;
using Demo.Domain.Areas.Stock.Models.Units;
using Demo.Domain.Areas.Stock.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace DemoAPI.Areas.Companies.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UnitsController : ControllerBase
    {
        private readonly ILogger<UnitsController> _logger;
        private readonly UnitsService service;

        public UnitsController(DataContext dbContext, ILogger<UnitsController> logger)
        {
            _logger = logger;
            service = new UnitsService(dbContext);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ShowUnitModel>> Index([FromQuery] UnitSearchModel search)
        {
            var response = service.GetIndexModel(search);

            return Ok(response);
        }

        [HttpGet("{id:long}")]
        public ActionResult<ShowUnitModel> Show(long id)
        {
            var response = service.GetShowModel(id);

            if (response == null)
            {
                return BadRequest();
            }
            else
            {
                return response;
            }
        }

        [HttpGet("New")]
        public ActionResult<CreateUnitModel> New()
        {
            var response = service.GetCreateModel();
            return response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<ShowUnitModel> Create(CreateUnitModel model)
        {
            try
            {
                var response = service.SaveCreateModel(model);
                return CreatedAtAction(nameof(UnitsController.Show), new { id = response.UnitId }, response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("{id:long}/Edit")]
        public ActionResult<UpdateUnitModel> Edit(long id)
        {
            var response = service.GetUpdateModel(id);

            if (response == null)
            {
                return BadRequest();
            }
            else
            {
                return response;
            }
        }

        [HttpPut("{id:long}")]
        public ActionResult Update(long id, UpdateUnitModel model)
        {
            try
            {
                service.SaveUpdateModel(id, model);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id:long}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Delete(long id)
        {
            try
            {
                service.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}