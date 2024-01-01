using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVGenerator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {

        // Skill

        [HttpPatch("edit")]
        public void EditSkill()
        {

        }
        [HttpDelete("delete/{id:guid}")]
        public void DeleteSkill()
        {

        }
        [HttpPost("add")]
        public void AddSkills()
        {

        }
    }
}
