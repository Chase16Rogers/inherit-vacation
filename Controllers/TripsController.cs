using System.Collections.Generic;
using Ivacation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Ivacation.Services;

namespace Ivacation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripsController : ControllerBase
    {
        private readonly TripsService _TS;

    public TripsController(TripsService tS)
    {
      _TS = tS;
    }

    [HttpGet]
        public ActionResult<IEnumerable<Trip>> Get()
        {
            try
            {
                return Ok(_TS.GetAll());
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    [HttpGet("{id}")]
        public ActionResult<Trip> Get(string id)
        {
            try
            {
                return Ok(_TS.GetOne(id));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    [HttpPost]
        public ActionResult<Trip> Create([FromBody] Trip newTrip)
        {
            try
            {
                return Ok(_TS.Create(newTrip));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    [HttpPut("{id}")]
        public ActionResult<Trip> Edit(string id, [FromBody] Trip editTrip)
        {
            try
            {
                return Ok(_TS.Edit(id, editTrip));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    [HttpDelete("{id}")]
        public ActionResult<Trip> Delete(string id)
        {
            try
            {
                return Ok(_TS.Delete(id));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }



    }
}