using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVGenerator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {

        // Experience

        [HttpPatch("Experience/edit")]
        public void EditExperience()
        {

        }
        [HttpDelete("Experience/delete/{id:guid}")]
        public void DeleteExperience()
        {

        }
        [HttpPost("Experience/add")]
        public void AddExperiences()
        {

        }
    }
}
