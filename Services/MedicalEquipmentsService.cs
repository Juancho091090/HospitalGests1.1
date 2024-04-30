using HospitalGests.Model;
using HospitalGests.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalGests.Services
{
    public interface IMedicalEquipmentService
    {
        Task<List<MedicalEquipments>> GetAll();
        Task<MedicalEquipments> GetMedicalEquipment(int id_Equipment);
        Task<MedicalEquipments> CreateMedicalEquipment(int department_Id, int location_Id, string? equipmentName, int stockEquipment);
        Task<MedicalEquipments> UpdateMedicalEquipment(int iD_Equipment, int iD_Department, int iD_Location, string? equipmentName = null, int? stockEquipment = null);
        Task<MedicalEquipments> DeleteMedicalEquipment(int id_Equipment);
    }

    public class MedicalEquipmentsService : IMedicalEquipmentService
    {
        private readonly MedicalEquipmentsRepository _medicalEquipmentsRepository;

        public MedicalEquipmentsService(IMedicalEquipmentsRepository medicalEquipmentsRepository)
        {
            _medicalEquipmentsRepository = (MedicalEquipmentsRepository?)medicalEquipmentsRepository;
        }

        public async Task<List<MedicalEquipments>> GetAll()
        {
           return await _medicalEquipmentsRepository.GetAll();
        }

        public async Task<MedicalEquipments> GetMedicalEquipment (int id_Equipment)
        {
          return await _medicalEquipmentsRepository.GetMedicalEquipment(id_Equipment);
        }

        public async Task<MedicalEquipments> CreateMedicalEquipment(int department_Id, int location_Id, string? equipmentName, int stockEquipment)
        {
            return await _medicalEquipmentsRepository.CreateMedicalEquipment(department_Id, location_Id, equipmentName,stockEquipment);
        }

        public async Task<MedicalEquipments> UpdateMedicalEquipment(int iD_Equipment, int iD_Department, int iD_Location, string? equipmentName = null, int? stockEquipment = null)
        {
            MedicalEquipments newmedicalEquipments = await _medicalEquipmentsRepository.GetMedicalEquipment(iD_Equipment);
            if(newmedicalEquipments == null)
            {
                return null;
            }else
            {
                if(equipmentName == null)
                {
                    newmedicalEquipments.EquipmentName = equipmentName;
                }
                if(stockEquipment == null)
                {
                    newmedicalEquipments.StockEquipment = (int)stockEquipment;
                }
            }
            return await _medicalEquipmentsRepository.UpdateMedicalEquipment(newmedicalEquipments);
        }

        public async Task<MedicalEquipments> DeleteMedicalEquipment(int id_Equipment)
        {
            return await(_medicalEquipmentsRepository.DeleteMedicalEquipment(id_Equipment));
        }
    }
}
