using HospitalGests.Model;
using HospitalGests.Repositories;

namespace HospitalGests.Services
{
    public interface IAppointmentServicie
    {
        Task<List<Appointment>> GetAll();
        Task<Appointment> Getappointment(int appointmentId);
        Task<Appointment> Createappointment(int patientId, int doctorId, DateTime appointmentDateTime, string status, string observations);
        Task<Appointment> Updateappointment(int appointmentId , int patientId, int doctorId, DateTime? appointmentDateTime = null, string? status = null, string? observations = null);
        Task<Appointment> Deleteappointment(int appointmentId);
    }
    public class AppointmentServices : IAppointmentServicie

    {
        public readonly IAppointmentRepository _appointmentRepository;

        public AppointmentServices(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<Appointment> Createappointment( int patientId, int doctorId, DateTime appointmentDateTime, string status, string observations)
        {
            return await _appointmentRepository.Createappointment(patientId, doctorId, appointmentDateTime, status, observations);
        }

        public async Task<Appointment> Deleteappointment(int appointmentId)
        {
            return await (_appointmentRepository.Deleteappointment(appointmentId));
        }

        public async Task<List<Appointment>> GetAll()
        {
            return await _appointmentRepository.GetAll();
        }

        public async Task<Appointment> Getappointment(int appointmentId)
        {
            return await _appointmentRepository.Getappointment(appointmentId);
        }

        public async Task<Appointment> Updateappointment(int appointmentId, int patientId, int doctorId, DateTime? appointmentDateTime = null, string? status = null, string? observations = null)
        {
            Appointment newappointment = await _appointmentRepository.Getappointment(appointmentId);
            if (newappointment == null)
            {
                return null;
            }
            else
            {
                if (appointmentDateTime != null)
                {
                    newappointment.AppointmentDateTime = (DateTime)appointmentDateTime;
                }
                if (status != null)
                {
                    newappointment.Status = status;
                }
            }
           return await _appointmentRepository.Updateappointment(newappointment); 
        }
    }
}
