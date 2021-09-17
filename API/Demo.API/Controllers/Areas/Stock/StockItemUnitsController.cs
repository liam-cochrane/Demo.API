using Demo.Domain.Areas.Stock.Models.StockItemUnits;
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
    public class StockItemUnitsController : ControllerBase
    {
        private readonly ILogger<StockItemUnitsController> _logger;
        private readonly IStockItemUnitsService _service;

        public StockItemUnitsController(IStockItemUnitsService service, ILogger<StockItemUnitsController> logger)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ShowStockItemUnitModel>> Index([FromQuery] StockItemUnitSearchModel search)
        {
            var response = _service.GetIndexModel(search);

            return Ok(response);
        }

        [HttpGet("{id:long}")]
        public ActionResult<ShowStockItemUnitModel> Show(long id)
        {
            var response = _service.GetShowModel(id);

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
        public ActionResult<CreateStockItemUnitModel> New()
        {
            var response = _service.GetCreateModel();
            return response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<ShowStockItemUnitModel> Create(CreateStockItemUnitModel model)
        {
            try
            {
                var response = _service.SaveCreateModel(model);
                return CreatedAtAction(nameof(StockItemUnitsController.Show), new { id = response.StockItemUnitId }, response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("{id:long}/Edit")]
        public ActionResult<UpdateStockItemUnitModel> Edit(long id)
        {
            var response = _service.GetUpdateModel(id);

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
        public ActionResult Update(long id, UpdateStockItemUnitModel model)
        {
            try
            {
                _service.SaveUpdateModel(id, model);
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
                _service.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}