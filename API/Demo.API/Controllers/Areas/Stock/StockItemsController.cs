﻿using Demo.Data;
using Demo.Domain.Areas.Stock.Models.StockItems;
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
    public class StockItemsController : ControllerBase
    {
        private readonly ILogger<StockItemsController> _logger;
        private readonly StockItemsService service;

        public StockItemsController(DataContext dbContext, ILogger<StockItemsController> logger)
        {
            _logger = logger;
            service = new StockItemsService(dbContext);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ShowStockItemModel>> Index([FromQuery] StockItemSearchModel search)
        {
            var response = service.GetIndexModel(search);

            return Ok(response);
        }

        [HttpGet("{id:long}")]
        public ActionResult<ShowStockItemModel> Show(long id)
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
        public ActionResult<CreateStockItemModel> New()
        {
            var response = service.GetCreateModel();
            return response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<ShowStockItemModel> Create(CreateStockItemModel model)
        {
            try
            {
                var response = service.SaveCreateModel(model);
                return CreatedAtAction(nameof(StockItemsController.Show), new { id = response.StockItemId }, response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("{id:long}/Edit")]
        public ActionResult<UpdateStockItemModel> Edit(long id)
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
        public ActionResult Update(long id, UpdateStockItemModel model)
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