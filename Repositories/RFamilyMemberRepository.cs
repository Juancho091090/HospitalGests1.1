using HospitalGests.Context;
using HospitalGests.Model;
using Microsoft.EntityFrameworkCore;
namespace HospitalGests.Repositories
{


    public interface IRFamilyMemberRepository
    {
        Task<List<ResponsibleFamilyMember>> GetAll();
        Task<ResponsibleFamilyMember> GetResponsibleFamilyMember(int responsibleFamilyMemberId);
        Task<ResponsibleFamilyMember> CreateResponsibleFamilyMember(int idPerson, string relationship, bool isPatient);
        Task<ResponsibleFamilyMember> DeleteResponsibleFamilyMember(int responsibleFamilyMemberId);
        Task<ResponsibleFamilyMember> UpdateResponsibleFamilyMember(ResponsibleFamilyMember responsibleFamilyMember);
    }
    public class RFamilyMemberRepository : IRFamilyMemberRepository
    {

        private readonly BaseDbContext _db;
        public RFamilyMemberRepository(BaseDbContext db)
        {
            _db = db;
        }
        public async Task<ResponsibleFamilyMember> CreateResponsibleFamilyMember(int idPerson, string relationship, bool isPatient)
        {
            ResponsibleFamilyMember responsibleFamilyMember = new ResponsibleFamilyMember
            {
                IdPerson = idPerson,
                Relationship = relationship,
                IsPatient = isPatient,
            };
            await _db.ResponsibleFamilyMembers.AddAsync(responsibleFamilyMember);
            _db.SaveChanges();
            return responsibleFamilyMember;

        }

        public async Task<ResponsibleFamilyMember> DeleteResponsibleFamilyMember(int responsibleFamilyMemberId)
        {
         
            ResponsibleFamilyMember responsibleFamilyMember = await GetResponsibleFamilyMember(responsibleFamilyMemberId);

            _db.ResponsibleFamilyMembers.Remove(responsibleFamilyMember);
            await _db.SaveChangesAsync();
            return responsibleFamilyMember;
        }

        public async Task<List<ResponsibleFamilyMember>> GetAll()
        {
            return await _db.ResponsibleFamilyMembers.ToListAsync();
        }

        public Task<ResponsibleFamilyMember> GetResponsibleFamilyMember(int responsibleFamilyMemberId)
        {
            return _db.ResponsibleFamilyMembers.FirstOrDefaultAsync(l => l.ResponsibleFamilyMemberId == responsibleFamilyMemberId);
        }

        public async Task<ResponsibleFamilyMember> UpdateResponsibleFamilyMember(ResponsibleFamilyMember responsibleFamilyMember)
        {
           
            _db.ResponsibleFamilyMembers.Update(responsibleFamilyMember);
            await _db.SaveChangesAsync();
            return responsibleFamilyMember;
        }
    }
}
