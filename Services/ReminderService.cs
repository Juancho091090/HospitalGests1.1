using HospitalGests.Model;
using HospitalGests.Repositories;

namespace HospitalGests.Services
{

    public interface IReminderService
    {
        Task<List<Reminder>> GetAll();
        Task<Reminder> GetReminder(int reminderId);
        Task<Reminder> CreatReminder(int appointmentId, DateTime reminderDateTime, string? reminderType, string? reminderStatus);
        Task<Reminder> DeleteReminder(int reminderId);
        Task<Reminder> UpdateReminder(int reminderId, int appointmentId, DateTime? reminderDateTime = null, string? reminderType = null, string? reminderStatus = null);

    }
    public class ReminderService : IReminderService

    {
        public readonly IReminderRepository _ReminderRepository;

        public ReminderService(IReminderRepository repository)
        {
            _ReminderRepository = repository;
        }
        public async Task<Reminder> CreatReminder(int appointmentId, DateTime reminderDateTime, string? reminderType, string? reminderStatus)
        {
            return await _ReminderRepository.CreatReminder(appointmentId, reminderDateTime, reminderType, reminderStatus);
        }

        public async Task<Reminder> DeleteReminder(int reminderId)
        {
            return await (_ReminderRepository.DeleteReminder(reminderId));
        }

        public async Task<List<Reminder>> GetAll()
        {
            return await _ReminderRepository.GetAll();
        }

        public async Task<Reminder> GetReminder(int reminderId)
        {
           return await _ReminderRepository.GetReminder(reminderId);
        }

        public async Task<Reminder> UpdateReminder(int reminderId, int appointmentId, DateTime? reminderDateTime = null, string? reminderType = null, string? reminderStatus = null)
        {
            Reminder newreminder = await _ReminderRepository.GetReminder(reminderId);
            if (newreminder == null)
            {
                return null;
            }else 
            { 
                if (reminderDateTime != null)
                {
                    newreminder.ReminderDateTime = (DateTime)reminderDateTime;
                }
                if (reminderType != null)
                {
                    newreminder.ReminderType = reminderType;
                }
                if(reminderStatus != null)
                {
                    newreminder.ReminderStatus = reminderStatus;
                }
            }
            return await _ReminderRepository.UpdateReminder(newreminder);
        }
    }
}
