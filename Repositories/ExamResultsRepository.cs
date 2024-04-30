using HospitalGests.Context;
using HospitalGests.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalGests.Repositories
{
    public interface IExamResultsRepository
    {
        Task<List<ExamResults>> GetAll();
        Task<ExamResults> GetExamResults(int examId);
        Task<ExamResults> CreateExamResults(int medicalRecordId, string examType, string results, string observations);
        Task<ExamResults> UpdateExamResults(ExamResults examResults);
        Task<ExamResults> DeleteExamResults(int examId);
    }
    public class ExamResultsRepository : IExamResultsRepository
    {
        private readonly BaseDbContext _db;
        public ExamResultsRepository(BaseDbContext db) 
        {
            _db = db; 
        }
        public async Task<List<ExamResults>> GetAll()
        {
            return await _db.ExamResults.ToListAsync();
        }

        public async Task<ExamResults> GetExamResults(int examId)
        {
            return await _db.ExamResults.FirstOrDefaultAsync(u => u.ExamId == examId);
        }
        public async Task<ExamResults> CreateExamResults(int medicalRecordId, string examType, string results, string observations)
        {
            ExamResults  newExamResults = new ExamResults
            {
                MedicalRecordId = medicalRecordId,
                ExamType = examType,
                Results = results,
                Observations = observations
            };

            await _db.ExamResults.AddAsync(newExamResults);
            await _db.SaveChangesAsync();

            return newExamResults;
        }
        public async Task<ExamResults> UpdateExamResults(ExamResults examResults)
        {
            _db.ExamResults.Update(examResults);
            await _db.SaveChangesAsync();
            return examResults;
        }

        public async Task<ExamResults> DeleteExamResults(int examId)
        {
            ExamResults examResults = await GetExamResults(examId);

            //Resource.IsDeleted = true;

            _db.ExamResults.Update(examResults);
            await _db.SaveChangesAsync();
            return examResults;
        }
    }
}
