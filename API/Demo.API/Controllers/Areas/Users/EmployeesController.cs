using Demo.Domain.Areas.Users.Models.Employees;
using Demo.Domain.Areas.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Demo.Domain.Areas.Users.Services.Interfaces;

namespace DemoAPI.Controllers.Areas.Users
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly IEmployeesService _service;

        public EmployeesController(IEmployeesService service, ILogger<EmployeesController> logger)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ShowEmployeeModel>> Index([FromQuery] EmployeeSearchModel search, [FromQuery] PagingModel paging)
        {
            var response = _service.GetIndexModel(search, paging);

            return Ok(response);
        }

        [HttpGet("Count")]
        public ActionResult<int> Count([FromQuery] EmployeeSearchModel search)
        {
            var response = _service.GetCount(search);

            return Ok(response);
        }

        [HttpGet("{id:long}")]
        public ActionResult<ShowEmployeeModel> Show(long id)
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

        [HttpGet("By")]
        public ActionResult<ShowEmployeeModel> ShowByEmail(string email)
        {
            var response = _service.GetShowModelByEmail(email);

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
        public ActionResult<CreateEmployeeModel> New()
        {
            var response = _service.GetCreateModel();
            return response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<ShowEmployeeModel> Create(CreateEmployeeModel model)
        {
            try
            {
                var response = _service.SaveCreateModel(model);
                return CreatedAtAction(nameof(EmployeesController.Show), new { id = response.PersonId }, response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("{id:long}/Edit")]
        public ActionResult<UpdateEmployeeModel> Edit(long id)
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
        public ActionResult Update(long id, UpdateEmployeeModel model)
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