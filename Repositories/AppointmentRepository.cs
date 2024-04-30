using HospitalGests.Context;
using HospitalGests.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalGests.Repositories
{
    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetAll();
        Task<Appointment> Getappointment(int AppointmentId);
        Task<Appointment> Createappointment(int patientId, int doctorId, DateTime appointmentDateTime, string status, string observations);
        Task<Appointment> Updateappointment(Appointment appointment);
        Task<Appointment> Deleteappointment(int AppointmentId);
    }

    public class AppointmentRepository : IAppointmentRepository

    {
        private readonly BaseDbContext _db;
        public AppointmentRepository(BaseDbContext db)
        {
            _db = db;
        }

        public async Task<Appointment> Createappointment(int patientId, int doctorId, DateTime appointmentDateTime, string status, string observations)
        {
            Appointment appointment = new Appointment
            {
                PatientId = patientId,
                DoctorId = doctorId,
                AppointmentDateTime = appointmentDateTime,
                Status = status,
                Observations = observations
            };
            await _db.Appointments.AddAsync(appointment);
            _db.SaveChanges();
            return appointment;
        }

        public async Task<Appointment> Deleteappointment(int AppointmentId)
        {
           
            Appointment  appointment = await Getappointment(AppointmentId);
            if (appointment == null)
            {
                //appointment.IsDelete = true;
            }
            _db.Appointments.Remove(appointment);
            _db.SaveChanges();
            return appointment;
        }

        public async Task<List<Appointment>> GetAll()
        {
            return await _db.Appointments.ToListAsync();
        }

        public async Task<Appointment> Getappointment(int AppointmentId)
        {
            return await _db.Appointments.FirstOrDefaultAsync(a => a.AppointmentId == AppointmentId);
        }

        public async Task<Appointment> Updateappointment(Appointment appointment)
        {
           _db.Appointments.Update(appointment);
            await _db.SaveChangesAsync();
            return appointment;
        }
    }
}