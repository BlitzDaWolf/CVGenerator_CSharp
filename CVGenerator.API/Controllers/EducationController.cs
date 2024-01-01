using CVGenerator.API.Context;
using CVGenerator.API.Entiy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVGenerator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        readonly CVDbContext database;

        public EducationController(CVDbContext database)
        {
            this.database = database;
        }

        // Education

        [HttpPatch("edit")]
        public void EditEducation(EducationEntity education)
        {

        }
        [HttpDelete("delete/{id:guid}")]
        public void DeleteEducation()
        {

        }
        [HttpPost("add/{personId:guid}")]
        public void AddEducations(Education education, Guid personId)
        {
            EducationEntity entity = new EducationEntity(education);
            entity.PersonId = personId;
            database.Educations.Add(entity);
            database.SaveChanges();
        }
    }
}
