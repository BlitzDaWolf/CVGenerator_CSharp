using CVGenerator.API.Context;
using CVGenerator.API.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVGenerator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        readonly CVDbContext database;

        public SkillController(CVDbContext database)
        {
            this.database = database;
        }

        // Skill

        [HttpPatch("edit")]
        public void EditSkill()
        {

        }
        [HttpDelete("delete/{id:guid}")]
        public void DeleteSkill()
        {

        }
        [HttpPost("add/{personId:guid}")]
        public void AddSkills(Skill skill, Guid personId)
        {
            SkillEntity skillEntity = new SkillEntity(skill.Name, skill.Level) { PersonId = personId };
            database.Skills.Add(skillEntity);
            database.SaveChanges();
        }
    }
}
