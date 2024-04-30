using HospitalGests.Model;
using HospitalGests.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalGests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalEquipmentsController : ControllerBase
    {
        private readonly IMedicalEquipmentService _medicalEquipmentService;

        public MedicalEquipmentsController(IMedicalEquipmentService medicalEquipmentService)
        {
            _medicalEquipmentService = medicalEquipmentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MedicalEquipments>>> GetMedicalEquipment()
        {
            return Ok(await _medicalEquipmentService.GetAll());
        }
        [HttpGet("{id_Equipment}")]
        public async Task<ActionResult<MedicalEquipments>> GetMedicalEquipment(int id_Equipment)
        {
            var medicalEquipments = await _medicalEquipmentService.GetMedicalEquipment(id_Equipment);
            if (medicalEquipments == null)
            {
                return BadRequest("MedicalEquipments not found");
            }
            return Ok(medicalEquipments);
        }

        [HttpPost]
        public async Task<ActionResult<MedicalEquipments>> CreateMedicalEquipment(int department_Id, int location_Id, string? equipmentName, int stockEquipment)
        {
            var medicalEquipments = await _medicalEquipmentService.CreateMedicalEquipment(department_Id, location_Id, equipmentName, stockEquipment);
            if (medicalEquipments == null)
            {
                return BadRequest("MedicalEquipments cannot be created");
            }
            return Ok(medicalEquipments);
        }

        [HttpPut("{id_Equipment}")]
        public async Task<ActionResult<MedicalEquipments>> UpdateMedicalEquipment(int iD_Equipment, int iD_Department, int iD_Location, string? equipmentName = null, int? stockEquipment = null)
        {
            var medicalEquipments = await _medicalEquipmentService.UpdateMedicalEquipment(iD_Equipment, iD_Department, iD_Location, equipmentName, stockEquipment);
            if (medicalEquipments == null)
            {
                return BadRequest("The MedicalEquipments does not exist");
            }
            return Ok(medicalEquipments);
        }

        [HttpDelete("{id_Equipment}")]
        public async Task<ActionResult<MedicalEquipments>> DeleteMedicalEquipment(int id_Equipment)
        {
            var medicalEquipments = await _medicalEquipmentService.DeleteMedicalEquipment(id_Equipment);
            if (medicalEquipments == null)
            {
                return BadRequest("The MedicalEquipments does not exist");
            }
            return Ok("MedicalEquipments Deleted");
        }
    }
}
