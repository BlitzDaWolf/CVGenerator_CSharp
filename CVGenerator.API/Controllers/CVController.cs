using CVGenerator.API.Context;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Previewer;

namespace CVGenerator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CVController : ControllerBase
    {
        readonly CVDbContext databse;

        public CVController(CVDbContext databse)
        {
            this.databse = databse;
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetPDF(Guid id)
        {
            var person = databse.Persons.FirstOrDefault(x =>  x.Id == id);
            person.Skills = databse.Skills.Where(x => x.PersonId == id).ToList();
            person.Education = databse.Educations.Where(x => x.PersonId == id).ToList();
            person.Expierences = databse.Expierences.Where(x => x.PersonId == id).ToList();

            PersonDetail pDetail = person.ToDetail();

            CVDocument document = new CVDocument(person.GitHub, pDetail);

            byte[] pdfBytes = document.GeneratePdf();
            return new FileContentResult(pdfBytes, "application/pdf");
        }

        [HttpPost("person/add")]
        public void AddPerson(CreateUser person)
        {
            databse.Persons.Add(new Entity.PersonEntity
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                GitHub = person.GitHub,
                 DriverLicence = person.DriverLicence, Email = person.Email, LinkedIn = person.LinkedIn, Phone = person.Phone,
            });
            databse.SaveChanges();
        }
    }

    public record CreateUser(string FirstName, string LastName, string GitHub, string LinkedIn, string Email, string Phone, string DriverLicence="") { }
}
