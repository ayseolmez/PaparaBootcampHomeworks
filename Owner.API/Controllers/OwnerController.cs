using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Owner.API.Data;
using Owner.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Owner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        [ProducesResponseType(StatusCodes.Status200OK, Type= typeof(OwnerModel))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Route("Add")]
        [HttpPost]
        public IActionResult AddOwner(OwnerModel model)
        {
            var owner = new List<OwnerModel>();

            if (model.Description.Contains("hack"))
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
            else
            {
                owner.Add(model);
                return Ok(model);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteOwner(int id)
        {
            var owners = new OwnerData().GetAllOwner();

            var owner = owners.FirstOrDefault(x => x.Id == id);

            if (owner == null)
                return NotFound($"Owner number {id} not found");

            owners.Remove(owner);

            return Ok("Owner deleted.");
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOwner(int id, OwnerModel owner)
        {
            if (id != owner.Id)
                return BadRequest("Owner id didnt match");

            var owners = new OwnerData().GetAllOwner();

            var update = owners.FirstOrDefault(x => x.Id == id);

            update.FirstName= owner.FirstName;
            update.LastName = owner.LastName;
            update.Date =owner.Date;
            update.Description = owner.Description;
            update.Type = owner.Type;

            return Ok(update);

        }

        [Route("GetAll")]
        [HttpGet]
        public List<OwnerModel> GetAllOwner()
        {
            return new List<OwnerModel>
            {
                new OwnerModel
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Black",
                    Date = DateTime.Now,
                    Description = "Civil Engineer",
                    Type = "Office"
                },
                new OwnerModel
                {
                    Id = 2,
                    FirstName = "Tony",
                    LastName = "Montana",
                    Date = DateTime.Now,
                    Description = "Business Man",
                    Type = "Office"
                }
            };
        }
    }
}
