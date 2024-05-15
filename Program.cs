    using Microsoft.EntityFrameworkCore;
    using HospitalGests.Model;
    using HospitalGests.Context;
using HospitalGests.Services;
using HospitalGests.Repositories;
using static HospitalGests.Repositories.IPersonRepository;
using static HospitalGests.Services.ISpecialitiesService;
// using HospitalGests.Repositories;
// using HospitalGests.Services;
//using static HospitalGests.Repositories.IPersonRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
var ConnectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(ConnectionString));                     

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region AppRepository
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAvailabityRepository, AviabilityRepository> ();
builder.Services.AddScoped<IBedsRepository, BedsRepository> ();
builder.Services.AddScoped<IConsultingRoomsRepository, ConsultingRoomsRepository>();
builder.Services.AddScoped<IDepartmentsRepository, DepartmentsRepository> ();
builder.Services.AddScoped<IDiagnosisSecondaryRepository, DiagnosisSecondaryRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IExamResultsRepository, ExamResultsRepository>();
builder.Services.AddScoped<ILocationsRepository, LocationsRepository>();
builder.Services.AddScoped<IMedicalEquipmentsRepository, MedicalEquipmentsRepository>();
builder.Services.AddScoped<IMedicalNotesRepository, MedicalNotesRepository>();
builder.Services.AddScoped<IMedicalRecordsRepository, MedicalRecordsRespository>();
builder.Services.AddScoped<IMedicationdeliveryRepository, MedicationdeliveryRepository>();
builder.Services.AddScoped<IMedicinesRepository, MedicinesRepository>();
builder.Services.AddScoped<IOccupationsRepository, OccupationsRepository>();
builder.Services.AddScoped<IOperatingRoomsRepository, OperatingRoomsRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPharmacyRepository, PharmacyRepository>();
builder.Services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
builder.Services.AddScoped<IReminderRepository, ReminderRepository>();
builder.Services.AddScoped<IRFamilyMemberRepository, RFamilyMemberRepository>();
builder.Services.AddScoped<IRoomsRepository, RoomsRepository>();
builder.Services.AddScoped<ISpecialityRepository, SpecialityRepository>();
builder.Services.AddScoped<IStockmedicinesRepository, StockmedicinesRepository>();
builder.Services.AddScoped<ITreatmentRepository, TreatmentsRepository>();

#endregion

#region AppServices
builder.Services.AddScoped<IAppointmentServicie, AppointmentServices>();
builder.Services.AddScoped<IAvailabityServices, AvailabityServices>();
builder.Services.AddScoped<IBedService, BedsService>();
builder.Services.AddScoped<IConsultingRoomService, ConsultingRoomsService>();
builder.Services.AddScoped<IDepartmentService, DepartmentsService>();
builder.Services.AddScoped<IDiagnosisSecondaryService, DiagnosisSecondaryService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IExamResultsServices, ExamResultsServices>();
builder.Services.AddScoped<ILocationService, LocationsService>();
builder.Services.AddScoped<IMedicalEquipmentService, MedicalEquipmentsService>();
builder.Services.AddScoped<IMedicalNotesService, MedicalNotesService>();
builder.Services.AddScoped<IMedicalRecordsServices, MedicalRecordsServices>();
builder.Services.AddScoped<IMedicationdeliveryService, MedicationdeliveryService>();
builder.Services.AddScoped<IMedicineService, MedicinesService>();
builder.Services.AddScoped<IOccupationService, OccupationService>();
builder.Services.AddScoped<IOperatingService, OperatingRoomsService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IPharmacyService, PharmacyService>();
builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();
builder.Services.AddScoped<IReminderService, ReminderService>();
builder.Services.AddScoped<IRFamilyMemberService, RFamilyMemberService>();
builder.Services.AddScoped<IRoomsService, RoomsService>();
builder.Services.AddScoped<ISpecialitiesService, SpecialitiesService>();
builder.Services.AddScoped<IStockmedicinesService, StockmedicinesService>();
builder.Services.AddScoped<ITreatmentsService, TreatmentsService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
