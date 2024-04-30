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
    public class TreatmentsController : ControllerBase
    {
        private readonly ITreatmentsService _treatmentsService;

        public TreatmentsController(ITreatmentsService treatmentsService)
        {
            _treatmentsService = treatmentsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Beds>>> GetAllTreatments()
        {
            return Ok(await _treatmentsService.GetAll());
        }

        [HttpGet("{TreatmentId}")]
        public async Task<ActionResult<Beds>> GetTreatments(int treatmentId)
        {
            var treatment = await _treatmentsService.GetTreatments(treatmentId);
            if (treatment == null)
            {
                return BadRequest("Treatment not found");
            }
            return Ok(treatment);
        }

        [HttpPost]
        public async Task<ActionResult<Beds>> CreateTreatments(int medicalRecordID, string treatmentType, string dosage)
        {
            var treatment = await _treatmentsService.CreateTreatments(medicalRecordID, treatmentType, dosage);
            if (treatment == null)
            {
                return BadRequest("Treatment cannot be created");
            }
            return Ok(treatment);
        }

        [HttpPut("{TreatmentId}")]
        public async Task<ActionResult<Appointment>> UpdateTreatments(int treatmentId, int medicalRecordID, string? treatmentType = null, string? dosage = null)
        {
            var treatment = await _treatmentsService.UpdateTreatments(treatmentId, medicalRecordID, treatmentType, dosage);
            if (treatment == null)
            {
                return BadRequest("The Treatment does not exist");
            }
            return Ok(treatment);
        }

        [HttpDelete("{TreatmentId}")]
        public async Task<ActionResult<Beds>> DeleteTreatments(int treatmentId)
        {
            var treatment = await _treatmentsService.DeleteTreatments(treatmentId);
            if (treatment == null)
            {
                return BadRequest("The Treatment does not exist");
            }
            return Ok("Treatment Deleted");
        }
    }
}
