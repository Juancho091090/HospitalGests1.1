using HospitalGests.Model;
using HospitalGests.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalGests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsibleFamilyMemberController : ControllerBase
    {
        private readonly IRFamilyMemberService _rFamilyMemberService;

        public ResponsibleFamilyMemberController(IRFamilyMemberService rFamilyMemberService)
        {
            _rFamilyMemberService = rFamilyMemberService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Beds>>> GetAllResponsibleFamilyMembers()
        {
            return Ok(await _rFamilyMemberService.GetAll());
        }

        [HttpGet("{ResponsibleFamilyMemberId}")]
        public async Task<ActionResult<Beds>> GetResponsibleFamilyMember(int ResponsibleFamilyMemberId)
        {
            var responsibleFamilyMember = await _rFamilyMemberService.GetResponsibleFamilyMember(ResponsibleFamilyMemberId);
            if (responsibleFamilyMember == null)
            {
                return BadRequest("Responsible Family Member not found");
            }
            return Ok(responsibleFamilyMember);
        }

        [HttpPost]
        public async Task<ActionResult<Beds>> CreateResponsibleFamilyMember(int idPerson, string relationship, bool isPatient)
        {
            var responsibleFamilyMember = await _rFamilyMemberService.CreateResponsibleFamilyMember(idPerson, relationship, isPatient);
            if (responsibleFamilyMember == null)
            {
                return BadRequest("Responsible Family Member cannot be created");
            }
            return Ok(responsibleFamilyMember);
        }

        [HttpPut("{ResponsibleFamilyMemberId}")]
        public async Task<ActionResult<Appointment>> UpdateResponsibleFamilyMember(int responsibleFamilyMemberId, int idPerson, string? relationship = null, bool? isPatient = null)
        {
            var responsibleFamilyMember = await _rFamilyMemberService.UpdateResponsibleFamilyMember(responsibleFamilyMemberId, idPerson, relationship, isPatient);
            if (responsibleFamilyMember == null)
            {
                return BadRequest("The ResponsibleFamilyMember does not exist");
            }
            return Ok(responsibleFamilyMember);
        }

        [HttpDelete("{ResponsibleFamilyMemberId}")]
        public async Task<ActionResult<Beds>> DeleteResponsibleFamilyMember(int ResponsibleFamilyMemberId)
        {
            var responsibleFamilyMember = await _rFamilyMemberService.DeleteResponsibleFamilyMember(ResponsibleFamilyMemberId);
            if (responsibleFamilyMember == null)
            {
                return BadRequest("The Responsible Family Member does not exist");
            }
            return Ok("Responsible Family Member Deleted");
        }
    }
}
