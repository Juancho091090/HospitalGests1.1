using Microsoft.EntityFrameworkCore;
using HospitalGests.Model;
using System.Collections.Generic;

namespace HospitalGests.Context
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
        {

        }
        public DbSet<Appointment> Appointments {  get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<Beds> Beds { get; set; }
        public DbSet<ConsultingRooms> ConsultingRooms { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<DiagnosisSecondary> DiagnosisSecondaries { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<ExamResults> ExamResults { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<MedicalEquipments> MedicalEquipments { get; set; }
        public DbSet<MedicalNotes> MedicalNotes { get; set; }
        public DbSet<MedicalRecords> MedicalRecords { get; set; }
        public DbSet<Medicationdelivery> Medicationdelivery { get; set; }
        public DbSet<Medicines> Medicines { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<OperatingRooms> OperatingRooms { get; set; }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<Persons> Persons { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Prescriptions> Prescriptions { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<ResponsibleFamilyMember> ResponsibleFamilyMembers { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Specialties> Specialties { get; set; }
        public DbSet<Stockmedicines> Stockmedicines { get; set; }
        public DbSet<Treatments> Treatments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patients>()
                .HasOne(p => p.Person)
                .WithOne(p => p.Patient)
                .HasForeignKey<Persons>(p => p.IdPerson)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Persons>()
                .HasOne(p => p.Patient)
                .WithOne(p => p.Person)
                .HasForeignKey<Patients>(p => p.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ResponsibleFamilyMember>()
                .HasOne(p => p.Person)
                .WithOne(p => p.ResponsibleFamilyMember)
                .HasForeignKey<Persons>(p => p.IdPerson)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Persons>()
                .HasOne(p => p.ResponsibleFamilyMember)
                .WithOne(p => p.Person)
                .HasForeignKey<ResponsibleFamilyMember>(p => p.ResponsibleFamilyMemberId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Locations>()
                .HasOne(p => p.Rooms)
                .WithOne(p => p.Locations)
                .HasForeignKey<Rooms>(p => p.RoomID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Rooms>()
                .HasOne(p => p.Locations)
                .WithOne(p => p.Rooms)
                .HasForeignKey<Locations>(p => p.Location_Id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Beds>()
                .HasOne(p => p.Rooms)
                .WithOne(p => p.Beds)
                .HasForeignKey<Rooms>(p => p.RoomID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Rooms>()
                .HasOne(p => p.Beds)
                .WithOne(p => p.Rooms)
                .HasForeignKey<Beds>(p => p.Bed_ID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Prescriptions>()
                .HasOne(p => p.Medicines)
                .WithOne(p => p.Prescriptions)
                .HasForeignKey<Medicines>(p => p.MedicineId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Medicines>()
                .HasOne(p => p.Prescriptions)
                .WithOne(p => p.Medicines)
                .HasForeignKey<Prescriptions>(p => p.IdPrescription)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Persons>()
                .HasOne(p => p.Doctor)
                .WithOne(p => p.Persons)
                .HasForeignKey<Doctor>(p => p.DoctorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Doctor>()
                .HasOne(p => p.Persons)
                .WithOne(p => p.Doctor)
                .HasForeignKey<Persons>(p => p.IdPerson)
                .OnDelete(DeleteBehavior.NoAction);
        }

        private void OnDelete(DeleteBehavior noAction)
        {
            throw new NotImplementedException();
        }
    }
}