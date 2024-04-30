using HospitalGests.Model;
using HospitalGests.Repositories;

namespace HospitalGests.Services
{
    public interface IExamResultsServices
    {
        Task<List<ExamResults>> GetAll();
        Task<ExamResults> GetExamResults(int examId);
        Task<ExamResults> CreateExamResults(int medicalRecordId, string examType, string results, string observations);
        Task<ExamResults> UpdateExamResults(int examId, int medicalRecordId, string? examType = null, string? results = null, string? observations = null);
        Task<ExamResults> DeleteExamResults(int examId);
    }
    public class ExamResultsServices : IExamResultsServices
    {
        public readonly IExamResultsRepository _examResultsRepository;

        public ExamResultsServices(IExamResultsRepository examResultsRepository)
        {
            _examResultsRepository = examResultsRepository;
        }
        public async Task<ExamResults> CreateExamResults(int medicalRecordId, string examType, string results, string observations)
        {
           return await _examResultsRepository.CreateExamResults(medicalRecordId, examType, results, observations);
        }

        public async Task<ExamResults> DeleteExamResults(int examId)
        {
            return await (_examResultsRepository.DeleteExamResults(examId));
        }

        public Task<List<ExamResults>> GetAll()
        {
           return _examResultsRepository.GetAll();
        }

        public Task<ExamResults> GetExamResults(int examId)
        {
            return _examResultsRepository.GetExamResults(examId);
        }

        public async Task<ExamResults> UpdateExamResults(int examId, int medicalRecordId, string? examType = null, string? results = null, string? observations = null)
        {
            ExamResults newExamResults = await _examResultsRepository.GetExamResults(examId);
            if (newExamResults == null)
            {
                return null;
            }
            else
            {
                if (examType == null) 
                {
                    newExamResults.ExamType = examType;
                }
                if (results == null)
                {
                    newExamResults.Results = results;
                }
                if(observations == null)
                {
                    newExamResults.Observations = observations;
                }
            }
            return await _examResultsRepository.UpdateExamResults(newExamResults);
        }
    }
}
