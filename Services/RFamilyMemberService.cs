using HospitalGests.Model;
using HospitalGests.Repositories;

public interface IRFamilyMemberService
{
    Task<List<ResponsibleFamilyMember>> GetAll();
    Task<ResponsibleFamilyMember> GetResponsibleFamilyMember(int responsibleFamilyMemberId);
    Task<ResponsibleFamilyMember> CreateResponsibleFamilyMember(int idPerson, string relationship, bool isPatient);
    Task<ResponsibleFamilyMember> DeleteResponsibleFamilyMember(int responsibleFamilyMemberId);
    Task<ResponsibleFamilyMember> UpdateResponsibleFamilyMember(int responsibleFamilyMemberId, int idPerson, string? relationship = null, bool? isPatient = null);
}
namespace HospitalGests.Services
{
    public class RFamilyMemberService : IRFamilyMemberService
    {
        public readonly IRFamilyMemberRepository _rFamilyMemberRepository;

        public RFamilyMemberService(IRFamilyMemberRepository rFamilyMemberRepository)
        {
            _rFamilyMemberRepository = rFamilyMemberRepository;
        }
        public async Task<ResponsibleFamilyMember> CreateResponsibleFamilyMember(int idPerson, string relationship, bool isPatient)
        {
            return await _rFamilyMemberRepository.CreateResponsibleFamilyMember(idPerson, relationship, isPatient);
        }
        public async Task<ResponsibleFamilyMember> DeleteResponsibleFamilyMember(int responsibleFamilyMemberId)
        {
            return await (_rFamilyMemberRepository.DeleteResponsibleFamilyMember(responsibleFamilyMemberId));
        }
        public async Task<List<ResponsibleFamilyMember>> GetAll()
        {
           return await _rFamilyMemberRepository.GetAll();
        }
        public async Task<ResponsibleFamilyMember> GetResponsibleFamilyMember(int responsibleFamilyMemberId)
        {
            return await _rFamilyMemberRepository.GetResponsibleFamilyMember(responsibleFamilyMemberId);
        }
        public async Task<ResponsibleFamilyMember> UpdateResponsibleFamilyMember(int responsibleFamilyMemberId, int idPerson, string? relationship = null, bool? isPatient = null)
        {
            ResponsibleFamilyMember newresponsibleFamilyMember = await _rFamilyMemberRepository.GetResponsibleFamilyMember(responsibleFamilyMemberId);

            if (newresponsibleFamilyMember == null)
            {
                return null;
            }else
            {
                if(relationship != null)
                {
                    newresponsibleFamilyMember.Relationship = relationship;
                } 
                if(isPatient != null)
                {
                    newresponsibleFamilyMember.IsPatient = (bool)isPatient;
                }
            }
            return await _rFamilyMemberRepository.UpdateResponsibleFamilyMember(newresponsibleFamilyMember);
        }
    }

}
