using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService.Impl;
using PetShop.Core.Entities;

namespace Tizz.PetRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : Controller
    {
        private readonly IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        // GET api/owner - READ ALL
        /*[Authorize]*/
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return _ownerService.GetAllOwners();
        }

        // GET api/owners/5 - READ BY ID
        /*[Authorize(Roles = "Administrator")]*/
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            if (id < 1) return BadRequest("ID must be greater than 0");
            return _ownerService.FindOwnerByIdIncludePets(id);
        }

        // POST api/owners
        /*[Authorize(Roles = "Administrator")]*/
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            try
            {
                return Ok(_ownerService.CreateOwner(owner));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/owners/5 - UPDATE
        /*[Authorize(Roles = "Administrator")]*/
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            if (id < 1 || id != owner.OwnerId)
            {
                return BadRequest("Parameter Id and Owner Id must be the same");
            }
            return Ok(_ownerService.EditOwner(owner));
        }

        // DELETE api/owners/5
        /*[Authorize(Roles = "Administrator")]*/
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            _ownerService.DeleteOwner(id);
            return _ownerService.FindOwnerById(id);
        }
    }
}
