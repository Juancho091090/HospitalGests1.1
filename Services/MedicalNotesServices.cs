using HospitalGests.Model;
using HospitalGests.Repositories;

namespace HospitalGests.Services
{
    public interface IMedicalNotesService
    {
        Task<List<MedicalNotes>> GetAll();
        Task<MedicalNotes> GetMedicalNotes(int noteId);
        Task<MedicalNotes> CreateMedicalNotes(int medicalRecordID, string noteType, string noteName, DateTime dateNote);
        Task<MedicalNotes> UpdateMedicalNotes(int noteId, int medicalRecordID, string? noteType = null, string? noteName = null, DateTime? dateNote = null);
        Task<MedicalNotes> DeleteMedicalNotes(int noteId);
    }
    public class MedicalNotesService : IMedicalNotesService

    {
        public readonly IMedicalNotesRepository _medicineNotesRepository;

        public MedicalNotesService(IMedicalNotesRepository medicineNotesRepository)
        {
            _medicineNotesRepository = medicineNotesRepository;
        }

        public async Task<MedicalNotes> CreateMedicalNotes(int medicalRecordID, string noteType, string noteName, DateTime dateNote)
        {
            return await _medicineNotesRepository.CreateMedicalNotes(medicalRecordID, noteType, noteName, dateNote);
        }

        public async Task<MedicalNotes> DeleteMedicalNotes(int noteId)
        {
            return await(_medicineNotesRepository.DeleteMedicalNotes(noteId));
        }

        public async Task<List<MedicalNotes>> GetAll()
        {
            return await _medicineNotesRepository.GetAll();
        }

        public async Task<MedicalNotes> GetMedicalNotes(int noteId)
        {
            return await _medicineNotesRepository.GetMedicalNotes(noteId);
        }

        public async Task<MedicalNotes> UpdateMedicalNotes(int noteId, int medicalRecordID, string? noteType = null, string? noteName = null, DateTime? dateNote = null)
        {
            MedicalNotes newMedicalNotes = await _medicineNotesRepository.GetMedicalNotes(noteId);
            if (newMedicalNotes == null)
            {
                return null;
            }
            else
            {
                if (noteType != null)
                {
                    newMedicalNotes.NoteType = noteType;
                }
                if (noteName != null)
                {
                    newMedicalNotes.NoteName = noteName;
                }
                if (dateNote != null)
                {
                    newMedicalNotes.DateNote = dateNote;
                }

            }

            return await _medicineNotesRepository.UpdateMedicalNotes(newMedicalNotes);
        }

    }
}