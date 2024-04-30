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
    public class StockmedicinesController : ControllerBase
    {
        private readonly IStockmedicinesService _stockmedicinesService;

        public StockmedicinesController(IStockmedicinesService stockmedicinesService)
        {
            _stockmedicinesService = stockmedicinesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Beds>>> GetAllStockmedicines()
        {
            return Ok(await _stockmedicinesService.GetAll());
        }

        [HttpGet("{Idstock}")]
        public async Task<ActionResult<Beds>> GetStockmedicines(int idstock)
        {
            var stockmedicine = await _stockmedicinesService.GetStockmedicines(idstock);
            if (stockmedicine == null)
            {
                return BadRequest("Stockmedicine not found");
            }
            return Ok(stockmedicine);
        }

        [HttpPost]
        public async Task<ActionResult<Beds>> CreateStockmedicines(int medicineId, int idPharmacy, int stockquantity, DateOnly lastupdate)
        {
            var stockmedicine = await _stockmedicinesService.CreateStockmedicines(medicineId, idPharmacy, stockquantity, lastupdate);   
            if (stockmedicine == null)
            {
                return BadRequest("Stockmedicine cannot be created");
            }
            return Ok(stockmedicine);
        }

        [HttpPut("{Idstock}")]
        public async Task<ActionResult<Appointment>> UpdateStockmedicines(int idstock, int medicineId, int idPharmacy, int? stockquantity = null, DateOnly? lastupdate = null)
        {
            var stockmedicine = await _stockmedicinesService.UpdateStockmedicines(idstock, medicineId, idPharmacy, stockquantity, lastupdate);
            if (stockmedicine == null)
            {
                return BadRequest("The Stockmedicine does not exist");
            }
            return Ok(stockmedicine);
        }

        [HttpDelete("{Idstock}")]
        public async Task<ActionResult<Beds>> DeleteStockmedicines(int idstock)
        {
            var stockmedicine = await _stockmedicinesService.DeleteStockmedicines(idstock);
            if (stockmedicine == null)
            {
                return BadRequest("The Stockmedicine does not exist");
            }
            return Ok("Stockmedicine Deleted");
        }
    }
}
