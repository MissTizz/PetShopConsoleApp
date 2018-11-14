using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entities;

namespace Tizz.PetRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        // GET api/pets - READ ALL
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return _petService.GetAllPets();
        }

        // GET api/pets/5 - READ BY ID
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            if (id < 1) return BadRequest("ID must be greater than 0");
            return _petService.FindPetById(id);
        }

        // POST api/pets
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            
            if (pet.PetId != 0)
            {
                return BadRequest("You can't enter a pet ID");
            }
            if (string.IsNullOrEmpty(pet.Name))
            {
                return BadRequest("Pets name is required");
            }

            return _petService.CreatePet(pet);
        }

        // PUT api/pets/5 - UPDATE
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            if (id < 1 || id != pet.PetId)
            {
                return BadRequest("The parameter ID and the pet ID must be the same");
            }

            return Ok(_petService.EditPet(pet));
        }

        // DELETE api/pets/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _petService.DeletePet(id);
        }
    }
}
