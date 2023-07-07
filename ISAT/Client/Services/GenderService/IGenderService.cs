using ISAT.Shared.Models;

namespace ISAT.Client.Services.GenderService
{
    public interface IGenderService
    {
        public List<Gender> Genders { get; set; }
        public Task<List<Gender>> GetGenders();
        public Task<Gender> GetGender(int id);
        public Task PutGender(int id, Gender gender);
        public Task<Gender> PostGender(Gender gender);
        public Task DeleteGender(int id);
    }
        
}
