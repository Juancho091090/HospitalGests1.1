using HospitalGests.Model;
using HospitalGests.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalGests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordsController : ControllerBase
    {
        private readonly IMedicalRecordsServices _medicalRecordsServices;

        public MedicalRecordsController(IMedicalRecordsServices medicalRecordsServices)
        {
            _medicalRecordsServices = medicalRecordsServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<MedicalRecords>>> GetMedicalRecords()
        {
            return Ok(await _medicalRecordsServices.GetAll());
        }
        [HttpGet("{medicalRecordId}")]
        public async Task<ActionResult<MedicalRecords>> GetMedicalRecords(int medicalRecordId)
        {
            var medicalRecords = await _medicalRecordsServices.GetMedicalRecords(medicalRecordId);
            if (medicalRecords == null)
            {
                return BadRequest("MedicalRecords not found");
            }
            return Ok(medicalRecords);
        }

        [HttpPost]
        public async Task<ActionResult<MedicalRecords>> CreateMedicalRecords(int patientID, DateTime? admissionDate, DateTime? dischargeDate, string diagnosisPrincipal)
        {
            var medicalRecords = await _medicalRecordsServices.CreateMedicalRecords(patientID, admissionDate, dischargeDate, diagnosisPrincipal);
            {
                return BadRequest("MedicalRecords cannot be created");
            }
            return Ok(medicalRecords);
        }

        [HttpPut("{medicalRecordId}")]
        public async Task<ActionResult<MedicalRecords>> UpdateMedicalRecords(int medicalRecordId, int patientID, DateTime? admissionDate = null, DateTime? dischargeDate = null, string? diagnosisPrincipal = null)
        {
            {
                var medicalRecords = await _medicalRecordsServices.UpdateMedicalRecords(medicalRecordId,patientID,admissionDate,dischargeDate,diagnosisPrincipal);
                if (medicalRecords == null)
                {
                    return BadRequest("The MedicalRecords does not exist");
                }
                return Ok(medicalRecords);
            }
        }
        [HttpDelete("{medicalRecordId}")]

        public async Task<ActionResult<MedicalRecords>> DeleteMedicalRecords(int medicalRecordId)
        {
            var medicalRecords = await _medicalRecordsServices.GetMedicalRecords(medicalRecordId);
            if (medicalRecords == null)
            {
                return BadRequest("The MedicalRecords does not exist");
            }
            return Ok("MedicalRecords Deleted");
        }
    }
}
