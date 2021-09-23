using Demo.Domain.Areas.Contacts.Models.People;
using Demo.Domain.Areas.Contacts.Services.Interfaces;
using Demo.Domain.Areas.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace DemoAPI.Controllers.Areas.Contacts
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly ILogger<PeopleController> _logger;
        private readonly IPeopleService _service;

        public PeopleController(IPeopleService service, ILogger<PeopleController> logger)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ShowPersonModel>> Index([FromQuery] PersonSearchModel search, [FromQuery] PagingModel paging)
        {
            var response = _service.GetIndexModel(search, paging);

            return Ok(response);
        }

        [HttpGet("Count")]
        public ActionResult<int> Count([FromQuery] PersonSearchModel search)
        {
            var response = _service.GetCount(search);

            return Ok(response);
        }

        [HttpGet("{id:long}")]
        public ActionResult<ShowPersonModel> Show(long id)
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
        public ActionResult<ShowPersonModel> ShowByEmail(string email)
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
        public ActionResult<CreatePersonModel> New()
        {
            var response = _service.GetCreateModel();
            return response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<ShowPersonModel> Create(CreatePersonModel model)
        {
            try
            {
                var response = _service.SaveCreateModel(model);
                return CreatedAtAction(nameof(PeopleController.Show), new { id = response.PersonId }, response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("{id:long}/Edit")]
        public ActionResult<UpdatePersonModel> Edit(long id)
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
        public ActionResult Update(long id, UpdatePersonModel model)
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