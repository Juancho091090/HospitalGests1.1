using HospitalGests.Model;
using HospitalGests.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalGests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Persons>>> GetAllPersons()
        {
            return Ok(await _personService.GetAll());
        }
        [HttpGet("{idPerson}")]
        public async Task<ActionResult<Persons>> GetPersons(int idPerson)
        {
            var persons = await _personService.GetPerson(idPerson);
            if (persons == null)
            {
                return BadRequest("Persons not found");
            }
            return Ok(persons);
        }

        [HttpPost]
        public async Task<ActionResult<Persons>> CreatePersons(int idPerson, string typeDocument, int document, string firstName, string secondName, string lastName, string secondLastName, string bloodType, DateTime birthDate, string direcction, string emailAddress, string phoneNumber, int patientId, int doctorId, int responsibleFamilyMemberId, byte[] passwordHash, byte[] passwordSalt)
        {
            var persons = await _personService.CreatePerson(idPerson, typeDocument, document, firstName, secondName, lastName, secondLastName, bloodType, birthDate, direcction, emailAddress, phoneNumber, patientId, doctorId, responsibleFamilyMemberId, passwordHash, passwordSalt);
            if (persons == null)
            {
                return BadRequest("Persons cannot be created");
            }
            return Ok(persons);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(Persons person, string password)
        {
            // Crear la persona con la contraseña
            var createdPerson = await _personService.CreatePerson(person, password);
            return Ok(createdPerson);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(string userNumber, string password)
        {
            // Autenticar al usuario
            var isAuthenticated = await _personService.Authenticate(userNumber, password);

            if (!isAuthenticated)
                return Unauthorized();

            return Ok("Login successful");
        }
        [HttpPut("{idPerson}")]
        public async Task<ActionResult<Persons>> UpdatePersons(int idPerson, int patientId, int doctorId, int responsibleFamilyMemberId, string? typeDocument = null, int? document = null, string? firstName = null, string? secondName = null, string? lastName = null, string? secondLastName = null, string? bloodType = null, DateTime? birthDate = null, string? direcction = null, string? emailAddress = null, string? phoneNumber = null)
        {
            var persons = await _personService.UpdatePerson(idPerson,patientId,doctorId, responsibleFamilyMemberId, typeDocument , document ,firstName , secondName , lastName , secondLastName , bloodType , birthDate , direcction , emailAddress ,phoneNumber);
            if (persons == null)
            {
                return BadRequest("The Persons does not exist");
            }
            return Ok(persons);
        }

        [HttpDelete("{idPerson}")]
        public async Task<ActionResult<Persons>> DeleteOperatingRooms(int operatingRoomId)
        {
            var persons = await _personService.DeletePerson(operatingRoomId);
            if (persons == null)
            {
                return BadRequest("The Persons does not exist");
            }
            return Ok("Persons Deleted");
        }
    }
}
