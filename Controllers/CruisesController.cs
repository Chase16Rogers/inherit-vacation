using System;
using System.Collections.Generic;
using Ivacation.Models;
using Ivacation.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ivacation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CruisesController : ControllerBase
    {
        private readonly CruisesService _CS;

    public CruisesController(CruisesService cS)
    {
      _CS = cS;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Cruise>> Get()
    {
        try
        {
            return Ok(_CS.GetAll());
        }
        catch (Exception err)
        {
            return BadRequest(err.Message);
        }
    }
    [HttpGet("{id}")]
    public ActionResult<Cruise> Get(string id)
    {
        try
        {
            return Ok(_CS.GetOne(id));
        }
        catch (Exception err)
        {
            return BadRequest(err.Message);
        }
    }
    [HttpPost]
    public ActionResult<Cruise> Create([FromBody] Cruise newCruise)
    {
        try
        {
            return Ok(_CS.Create(newCruise));
        }
        catch (Exception err)
        {
            return BadRequest(err.Message);
        }
    }
    [HttpPut("{id}")]
    public ActionResult<Cruise> Edit(string id, [FromBody] Cruise editCruise)
    {
        try
        {
            return Ok(_CS.Edit(id, editCruise));
        }
        catch (Exception err)
        {
            return BadRequest(err.Message);
        }
    }
    [HttpDelete("{id}")]
    public ActionResult<String> Delete(string id)
    {
        try
        {
            return Ok(_CS.Delete(id));
        }
        catch (Exception err)
        {
            return BadRequest(err.Message);
        }
    }

    }
}