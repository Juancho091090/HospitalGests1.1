using HospitalGests.Model;
using HospitalGests.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalGests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalNotesController : ControllerBase
    {
        private readonly IMedicalNotesService _medicalNotesService;

        public MedicalNotesController(IMedicalNotesService medicalNotesService )
        {
            _medicalNotesService = medicalNotesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MedicalNotes>>> GetMedicalNotes()
        {
            return Ok(await _medicalNotesService.GetAll());
        }
        [HttpGet("{noteId}")]
        public async Task<ActionResult<MedicalNotes>> GetMedicalNotes(int noteId)
        {
            var medicalNotes = await _medicalNotesService.GetMedicalNotes(noteId);
            if (medicalNotes == null)
            {
                return BadRequest("MedicalNotes not found");
            }
            return Ok(medicalNotes);
        }

        [HttpPost]
        public async Task<ActionResult<MedicalNotes>> CreateMedicalNotes(int medicalRecordID, string noteType, string noteName, DateTime dateNote)
        {
            var medicalNotes = await _medicalNotesService.CreateMedicalNotes(medicalRecordID, noteType, noteName, dateNote);
            {
                return BadRequest("MedicalNotes cannot be created");
            }
            return Ok(medicalNotes);
        }

        [HttpPut("{noteId}")]
        public async Task<ActionResult<MedicalNotes>> UpdateMedicalNotes(int noteId, int medicalRecordID, string? noteType = null, string? noteName = null, DateTime? dateNote = null)
        {
            {
                var medicalNotes = await _medicalNotesService.UpdateMedicalNotes(noteId,medicalRecordID,noteType, noteName, dateNote);
                if (medicalNotes == null)
                {
                    return BadRequest("The MedicalNotes does not exist");
                }
                return Ok(medicalNotes);
            }
        }
        [HttpDelete("{noteId}")]

        public async Task<ActionResult<MedicalNotes>> DeleteMedicalNotes(int noteId)
        {
            var medicalNotes = await _medicalNotesService.DeleteMedicalNotes(noteId);
            if (medicalNotes == null)
            {
                return BadRequest("The MedicalNotes does not exist");
            }
            return Ok("MedicalNotes Deleted");
        }
    }
}
