using HospitalGests.Context;
using HospitalGests.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalGests.Repositories
{
  
    public interface IReminderRepository

    {
        Task<List<Reminder>> GetAll();
        Task<Reminder> GetReminder(int reminderId);
        Task<Reminder> CreatReminder(int appointmentId, DateTime reminderDateTime, string? reminderType, string? reminderStatus);
        Task<Reminder> DeleteReminder(int reminderId);
        Task<Reminder> UpdateReminder(Reminder reminder);

    }

    public class ReminderRepository : IReminderRepository
    {
        private readonly BaseDbContext _db;
        public ReminderRepository(BaseDbContext db)
        {
            _db = db;
        }
        public async Task<Reminder> CreatReminder(int appointmentId, DateTime reminderDateTime, string? reminderType, string? reminderStatus)
        {
            Reminder reminder = new Reminder
            {
                AppointmentId = appointmentId,
                ReminderDateTime = reminderDateTime,
                ReminderType = reminderType,
                ReminderStatus = reminderStatus
            };
            await _db.Reminders.AddAsync(reminder);
            _db.SaveChanges();
            return reminder;
        }

        public async Task<Reminder> DeleteReminder(int reminderId)
        {
           
            Reminder reminder = await GetReminder(reminderId);

            _db.Reminders.Remove(reminder);
            await _db.SaveChangesAsync();
            return reminder;
        }

        public async Task<List<Reminder>> GetAll()
        {
           return await _db.Reminders.ToListAsync();
        }

        public async Task<Reminder> GetReminder(int reminderId)
        {
            return await _db.Reminders.FirstOrDefaultAsync(z => z.ReminderId == reminderId);
        }

        public async Task<Reminder> UpdateReminder(Reminder reminder)
        {

            _db.Reminders.Update(reminder);
            await _db.SaveChangesAsync();
            return reminder;

        }
    }
}
