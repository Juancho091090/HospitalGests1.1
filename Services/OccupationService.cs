using HospitalGests.Model;
using HospitalGests.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalGests.Services
{
    public interface IOccupationService
    {
        Task<List<Occupation>> GetAll();
        Task<Occupation> GetOccupation(int occupation_Id);
        Task<Occupation> CreateOccupation(int roomID, int patientId, int doctorId, int locationId, string type, DateTime startDateTime, DateTime endDateTime);
        Task<Occupation> UpdateOccupation(int occupationId, int roomID, int patientId, int doctorId, int locationId, string? type = null, DateTime? startDateTime = null, DateTime? endDateTime = null);
        Task<Occupation> DeleteOccupation(int occupation_Id);
    }
    public class OccupationService : IOccupationService

    {
        public readonly IOccupationsRepository _occupationsRepository;
        public OccupationService(IOccupationsRepository occupationsRepository)
        {
            _occupationsRepository = occupationsRepository;
        }

        public async Task<Occupation> CreateOccupation(int roomID, int patientId, int doctorId, int locationId, string type, DateTime startDateTime, DateTime endDateTime)
        {
            return await _occupationsRepository.CreateOccupation(roomID, patientId, doctorId, locationId, type, startDateTime, endDateTime);
        }

        public async Task<Occupation> DeleteOccupation(int occupation_Id)
        {
            return await (_occupationsRepository.DeleteOccupation(occupation_Id));
        }

        public async Task<List<Occupation>> GetAll()
        {
            return await _occupationsRepository.GetAll();
        }

        public async Task<Occupation> GetOccupation(int occupation_Id)
        {
            return await _occupationsRepository.GetOccupation(occupation_Id);
        }

        public async Task<Occupation> UpdateOccupation(int occupation_Id, int resourceId, int patientId, int doctorId, int locationId, string? type = null, DateTime? startDateTime = null, DateTime? endDateTime = null)
        {
            Occupation newOccupation = await _occupationsRepository.GetOccupation(occupation_Id);
            if (newOccupation == null)
            {
                return null;
            }
            else
            {
                if (type != null)
                {
                    newOccupation.Type = type;
                }
                if (startDateTime != null)
                {
                    newOccupation.StartDateTime = (DateTime)startDateTime;
                }
                if (endDateTime != null)
                {
                    newOccupation.EndDateTime = (DateTime)endDateTime;
                }

            }
            return await _occupationsRepository.UpdateOccupation(newOccupation);
        }
    }
}
