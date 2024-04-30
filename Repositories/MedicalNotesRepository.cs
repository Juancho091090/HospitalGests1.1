using HospitalGests.Context;
using HospitalGests.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalGests.Repositories
{
    public interface IMedicalNotesRepository
    {
        Task<List<MedicalNotes>> GetAll();
        Task<MedicalNotes> GetMedicalNotes(int noteId);
        Task<MedicalNotes> CreateMedicalNotes(int medicalRecordID, string noteType, string noteName, DateTime DateNote);
        Task<MedicalNotes> UpdateMedicalNotes(MedicalNotes medicalNotes);
        Task<MedicalNotes> DeleteMedicalNotes(int noteId);
    }
    public class MedicalNotesRepository : IMedicalNotesRepository
    {
        private readonly BaseDbContext _db;
        public MedicalNotesRepository(BaseDbContext db)
        {
            _db = db;
        }
        public async Task<List<MedicalNotes>> GetAll()
        {
            return await _db.MedicalNotes.ToListAsync();
        }
        public async Task<MedicalNotes> GetMedicalNotes(int noteId)
        {
            return await _db.MedicalNotes.FirstOrDefaultAsync(u => u.NoteId == noteId);
        }
        public async Task<MedicalNotes> CreateMedicalNotes(int medicalRecordID, string noteType, string noteName, DateTime DateNote)
        {
            MedicalNotes newMedicalNotes = new MedicalNotes
            {
                MedicalRecordId = medicalRecordID,
                NoteType = noteType,
                NoteName = noteName,
                DateNote = DateNote
            };
            await _db.MedicalNotes.AddAsync(newMedicalNotes);
            await _db.SaveChangesAsync();

            return newMedicalNotes;
        }
        public async Task<MedicalNotes> UpdateMedicalNotes(MedicalNotes medicalNotes)
        {
            _db.MedicalNotes.Update(medicalNotes);
            await _db.SaveChangesAsync();
            return medicalNotes;
        }
        public async Task<MedicalNotes> DeleteMedicalNotes(int noteId)
        {
            MedicalNotes medicalNotes = await GetMedicalNotes(noteId);

            _db.MedicalNotes.Update(medicalNotes);
            await _db.SaveChangesAsync();
            return medicalNotes;
        }
    }
}