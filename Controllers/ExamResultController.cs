using HospitalGests.Model;
using HospitalGests.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalGests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamResultController : ControllerBase
    {
        private readonly IExamResultsServices _examResultsServices;

        public ExamResultController(IExamResultsServices examResultsServices)
        {
            _examResultsServices = examResultsServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<ExamResults>>> GetExamResults()
        {
            return Ok(await _examResultsServices.GetAll());
        }
        [HttpGet("{examId}")]
        public async Task<ActionResult<ExamResults>> GetExamResults(int examId)
        {
            var examResults = await _examResultsServices.GetExamResults(examId);
            if (examResults == null)
            {
                return BadRequest("ExamResults not found");
            }
            return Ok(examResults);
        }

        [HttpPost]
        public async Task<ActionResult<ExamResults>> CreateExamResults(int medicalRecordId, string examType, string results, string observations)
        {
            var examResults = await _examResultsServices.CreateExamResults(medicalRecordId, examType, results, observations);
            if (examResults == null)
            {
                return BadRequest("ExamResults cannot be created");
            }
            return Ok(examResults);
        }

        [HttpPut("{examId}")]
        public async Task<ActionResult<ExamResults>> UpdateExamResults(int examId, int medicalRecordId, string? examType = null, string? results = null, string? observations = null)
        {
            {
                var examResults = await _examResultsServices.UpdateExamResults(examId, medicalRecordId, examType, results, observations);
                if (examResults == null)
                {
                    return BadRequest("The ExamResults does not exist");
                }
                return Ok(examResults);
            }
        }
            [HttpDelete("{examId}")]

        public async Task<ActionResult<ExamResults>> DeleteExamResults(int examId)
            {
                var examResults = await _examResultsServices.DeleteExamResults(examId);
                if (examResults == null)
                {
                    return BadRequest("The ExamResults does not exist");
                }
                return Ok("ExamResults Deleted");
            }
        
    }
}
