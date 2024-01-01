using CVGenerator.API.Context;
using CVGenerator.API.Entity;
using CVGenerator.API.Entiy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVGenerator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        readonly CVDbContext database;

        public ExperienceController(CVDbContext database)
        {
            this.database = database;
        }

        // Experience

        [HttpPatch("edit")]
        public void EditExperience()
        {

        }
        [HttpDelete("delete/{id:guid}")]
        public void DeleteExperience()
        {

        }

        [HttpPost("add/{personId:guid}")]
        public void AddExperiences(Expierence expierence, Guid personId)
        {
            ExpierenceEntity entity = new ExpierenceEntity(expierence);
            entity.PersonId = personId;
            database.Expierences.Add(entity);
            database.SaveChanges();
        }
    }
}
