using HospitalGests.Model;
using HospitalGests.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalGests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosisSecondaryController : ControllerBase
    {
        private readonly IDiagnosisSecondaryService _diagnosisSecondary;

        public DiagnosisSecondaryController(IDiagnosisSecondaryService diagnosisSecondaryService)
        {
            _diagnosisSecondary = diagnosisSecondaryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DiagnosisSecondary>>> GetAllDiagnosisSecondary()
        {
            return Ok(await _diagnosisSecondary.GetAll());
        }
        [HttpGet("{diagnosisId}")]
        public async Task<ActionResult<DiagnosisSecondary>> GetDiagnosisSecondary(int diagnosisId)
        {
            var diagnosis = await _diagnosisSecondary.GetDiagnosisSecondary(diagnosisId);
            if (diagnosis == null)
            {
                return BadRequest("Diagnosis not found");
            }
            return Ok(diagnosis);
        }

        [HttpPost]
        public async Task<ActionResult<DiagnosisSecondary>> CreateDiagnosisSecondary(string diagnosisName, string diagnosisDescription, string diagnosisType, int medicarRecordId)
        {
            var diagnosis = await _diagnosisSecondary.CreateDiagnosisSecondary(diagnosisName, diagnosisDescription, diagnosisType, medicarRecordId);
            if (diagnosis == null)
            {
                return BadRequest("Diagnosis cannot be created");
            }
            return Ok(diagnosis);
        }

        [HttpPut("{diagnosisId}")]
        public async Task<ActionResult<DiagnosisSecondary>> UpdateDiagnosisSecondary(int diagnosisId, string? diagnosisName = null, string? diagnosisDescription = null, string? diagnosisType = null, int? medicarRecordId = null)
        {
            var diagnosis = await _diagnosisSecondary.UpdateDiagnosisSecondary(diagnosisId, diagnosisName, diagnosisDescription, diagnosisType, medicarRecordId);
            if (diagnosis == null)
            {
                return BadRequest("The Diagnosis does not exist");
            }
            return Ok(diagnosis);
        }

        [HttpDelete("{diagnosisId}")]
        public async Task<ActionResult<DiagnosisSecondary>> DeleteDiagnosisSecondary(int DiagnosisId)
        {
            var diagnosis = await _diagnosisSecondary.DeleteDiagnosisSecondary(DiagnosisId);
            if (diagnosis == null)
            {
                return BadRequest("The Diagnosis does not exist");
            }
            return Ok("Diagnosis Deleted");
        }
    }
}
