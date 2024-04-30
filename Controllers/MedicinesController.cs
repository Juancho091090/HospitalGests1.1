using HospitalGests.Model;
using HospitalGests.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalGests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        private readonly IMedicineService _medicineService;

        public MedicinesController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Medicines>>> GetAllMedicines()
        {
            return Ok(await _medicineService.GetAll());
        }
        [HttpGet("{medicineId}")]
        public async Task<ActionResult<Medicines>> GetMedicines(int medicineId)
        {
            var medicines = await _medicineService.GetMedicines(medicineId);
            if (medicines == null)
            {
                return BadRequest("Medicines not found");
            }
            return Ok(medicines);
        }

        [HttpPost]
        public async Task<ActionResult<Medicines>> CreateMedicines(int treatmentId, string medicineName, float quantityAviable, DateTime dueDate, int idPrescription)
        {
            var medicine = await _medicineService.CreateMedicines(treatmentId, medicineName, quantityAviable, dueDate, idPrescription);
            if (medicine == null)
            {
                return BadRequest("Medicine cannot be created");
            }
            return Ok(medicine);
        }

        [HttpPut("{medicineId}")]
        public async Task<ActionResult<Medicines>> UpdateMedicines(int medicineId, int treatmentId, string? medicineName = null, float? quantityAviable = null, DateTime? dueDate = null, int? idPrescription = null)
        {
            var medicine = await _medicineService.UpdateMedicines(medicineId, treatmentId, medicineName, quantityAviable, dueDate, idPrescription);
            if (medicine == null)
            {
                return BadRequest("The Medicine does not exist");
            }
            return Ok(medicine);
        }
    
        [HttpDelete("{medicineId}")]
        public async Task<ActionResult<Medicines>> DeleteMedicines(int medicineId)
        {
            var medicine = await _medicineService.DeleteMedicines(medicineId);
            if (medicine == null)
            {
                return BadRequest("The Medicine does not exist");
            }
            return Ok("Medicine Deleted");
        }
    
}
}
