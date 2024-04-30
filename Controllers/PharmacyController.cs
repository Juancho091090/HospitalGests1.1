using HospitalGests.Model;
using HospitalGests.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace HospitalGests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly IPharmacyService _pharmacyService;

        public PharmacyController(IPharmacyService pharmacyService)
        {
            _pharmacyService = pharmacyService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Pharmacy>>> GetAllPharmacy()
        {
            return Ok(await _pharmacyService.GetAll());
        }
        [HttpGet("{idPharmacy}")]
        public async Task<ActionResult<Pharmacy>> GetPharmacy(int idPharmacy)
        {
            var pharmacy = await _pharmacyService.GetPharmacy(idPharmacy);
            if (pharmacy == null)
            {
                return BadRequest("Pharmacy not found");
            }
            return Ok(pharmacy);
        }

        [HttpPost]
        public async Task<ActionResult<Pharmacy>> CreatePharmacy(string pharmacyname, string direcction, string email, string phone, string others)
        {
            var pharmacy = await _pharmacyService.CreatePharmacy(pharmacyname, direcction, email, phone, others);
            if (pharmacy == null)
            {
                return BadRequest("Pharmacy cannot be created");
            }
            return Ok(pharmacy );
        }

        [HttpPut("{idPharmacy}")]
        public async Task<ActionResult<Pharmacy>> UpdatePharmacy(int idPharmacy, string? pharmacyname = null, string? direcction = null, string? email = null, string? phone = null, string? others = null)
        {
            var pharmacy = await _pharmacyService.UpdatePharmacy(idPharmacy,pharmacyname, direcction, email, phone, others);
            if (pharmacy == null)
            {
                return BadRequest("The Pharmacy does not exist");
            }
            return Ok(pharmacy);
        }

        [HttpDelete("{idPharmacy}")]
        public async Task<ActionResult<Pharmacy>> DeletePharmacy(int idPharmacy)
        {
            var pharmacy = await _pharmacyService.DeletePharmacy(idPharmacy);
            if (pharmacy == null)
            {
                return BadRequest("The Pharmacy does not exist");
            }
            return Ok("Pharmacy Deleted");
        }
    }
}
