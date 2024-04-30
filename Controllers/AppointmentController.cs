using HospitalGests.Model;
using HospitalGests.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using HospitalGests.Services;

namespace HospitalGests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentServicie _appointmentService;

        public AppointmentController(IAppointmentServicie appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Appointment>>> GetAllAppointment()
        {
            return Ok(await _appointmentService.GetAll());
        }
        [HttpGet("{appointmentId}")]
        public async Task<ActionResult<Appointment>> GetAppointment(int appointmentId)
        {
            var appointment = await _appointmentService.Getappointment(appointmentId);
            if (appointment == null)
            {
                return BadRequest("Appointment not found");
            }
            return Ok(appointment);
        }

        [HttpPost]
        public async Task<ActionResult<Appointment>> Createappointment(int patientId, int doctorId, DateTime appointmentDateTime, string status, string observations)
        {
            var appointment = await _appointmentService.Createappointment(patientId, doctorId, appointmentDateTime, status, observations);
            if (appointment == null )
            {
                return BadRequest("Appointment cannot be created");
            }
            return Ok(appointment);
        }

        [HttpPut("{appointmentId}")]
        public async Task<ActionResult<Appointment>> UpdateAppointment(int appointmentId, int patientId, int doctorId, DateTime? appointmentDateTime = null, string? status = null, string? observations = null)
        {
            var appointment = await _appointmentService.Updateappointment(appointmentId, patientId, doctorId, appointmentDateTime, status, observations);
            if (appointment == null)
            {
                return BadRequest("The Appointment does not exist");
            }
            return Ok(appointment);
        }

        [HttpDelete("{appointmentId}")]
        public async Task<ActionResult<Appointment>> DeleteAppointment(int appointmentId)
        {
            var appointment = await _appointmentService.Deleteappointment(appointmentId);
            if (appointment == null)
            {
                return BadRequest("The Appointment does not exist");
            }
            return Ok("Appointment Deleted");
        }
    }
}