using System.Collections.Generic;
using Ivacation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Ivacation.Services;

namespace Ivacation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VacationsController : ControllerBase
    {
      private readonly VacationsService _VS;

    public VacationsController(VacationsService vS)
    {
      _VS = vS;
    }

    [HttpGet]
        public ActionResult<IEnumerable<Vacation>> Get()
        {
            try
            {
                return Ok(_VS.GetAll());
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Vacation> Get(string id)
        {
            try
            {
                return Ok(_VS.GetOne(id));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}