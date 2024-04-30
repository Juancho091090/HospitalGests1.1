
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
    public class ReminderController : ControllerBase
    {
        private readonly IReminderService _reminderService;

        public ReminderController(IReminderService reminderService)
        {
            _reminderService = reminderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Reminder>>> GetAllReminders()
        {
            return Ok(await _reminderService.GetAll());
        }

        [HttpGet("{ReminderId}")]
        public async Task<ActionResult<Reminder>> GetReminder(int ReminderId)
        {
            var reminder = await _reminderService.GetReminder(ReminderId);
            if (reminder == null)
            {
                return BadRequest("Reminder not found");
            }
            return Ok(reminder);
        }

        [HttpPost]
        public async Task<ActionResult<Reminder>> CreateReminder(int AppointmentId, DateTime ReminderDateTime, string? ReminderType, string? ReminderStatus)
        {
            var reminder = await _reminderService.CreatReminder(AppointmentId, ReminderDateTime, ReminderType, ReminderStatus);   
            if (reminder == null)
            {
                return BadRequest("Reminder cannot be created");
            }
            return Ok(reminder);
        }

        [HttpPut("{ReminderId}")]
        public async Task<ActionResult<Reminder>> UpdateReminder(int ReminderId, int AppointmentId, DateTime ReminderDateTime, string? ReminderType, string? ReminderStatus)
        {
            var reminder = await _reminderService.UpdateReminder(ReminderId, AppointmentId, ReminderDateTime, ReminderType, ReminderStatus);
            if (reminder == null)
            {
                return BadRequest("The Reminder does not exist");
            }
            return Ok(reminder);
        }

        [HttpDelete("{ReminderId}")]
        public async Task<ActionResult<Reminder>> DeleteReminder(int ReminderId)
        {
            var reminder = await _reminderService.DeleteReminder(ReminderId);
            if (reminder == null)
            {
                return BadRequest("The Reminder does not exist");
            }
            return Ok("Reminder Deleted");
        }
    }
}
