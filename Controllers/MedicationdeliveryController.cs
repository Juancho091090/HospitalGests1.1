using HospitalGests.Model;
using HospitalGests.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalGests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationdeliveryController : ControllerBase
    {
        private readonly IMedicationdeliveryService _medicationdeliveryService;

        public MedicationdeliveryController(IMedicationdeliveryService medicationdeliveryService)
        {
            _medicationdeliveryService = medicationdeliveryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Medicationdelivery>>> GetMedicationdelivery()
        {
            return Ok(await _medicationdeliveryService.GetAll());
        }
        [HttpGet("{IdDelivery}")]
        public async Task<ActionResult<Medicationdelivery>> GetMedicationdelivery(int IdDelivery)
        {
            var medicationdelivery = await _medicationdeliveryService.GetMedicationdelivery(IdDelivery);
            if (medicationdelivery == null)
            {
                return BadRequest("Medicationdelivery not found");
            }
            return Ok(medicationdelivery);
        }

        [HttpPost]
        public async Task<ActionResult<Medicationdelivery>> CreateMedicationdelivery(int idPrescription, int idPharmacy, DateTime deliDaTe, string deliveredQuantity, string state)
        {
            var medicationdelivery = await _medicationdeliveryService.CreateMedicationdelivery(idPrescription, idPharmacy, deliDaTe, deliveredQuantity, state);
            {
                return BadRequest("Medicationdelivery cannot be created");
            }
            return Ok(medicationdelivery);
        }

        [HttpPut("{IdDelivery}")]
        public async Task<ActionResult<Medicationdelivery>> UpdateMedicationdelivery(int iddelivery, int idPrescription, int idPharmacy, DateTime? deliDaTi = null, string? deliveredQuantity = null, string? state = null)
        {
            {
                var medicationdelivery = await _medicationdeliveryService.UpdateMedicationdelivery(iddelivery, idPrescription,idPharmacy,deliDaTi, deliveredQuantity, state);
                if (medicationdelivery == null)
                {
                    return BadRequest("The Medicationdelivery does not exist");
                }
                return Ok(medicationdelivery);
            }
        }
        [HttpDelete("{IdDelivery}")]

        public async Task<ActionResult<Medicationdelivery>> DeleteMedicationdelivery(int IdDelivery)
        {
            var medicationdelivery = await _medicationdeliveryService.DeleteMedicationdelivery(IdDelivery);
            if (medicationdelivery == null)
            {
                return BadRequest("The Medicationdelivery does not exist");
            }
            return Ok("Medicationdelivery Deleted");
        }
    }
}
