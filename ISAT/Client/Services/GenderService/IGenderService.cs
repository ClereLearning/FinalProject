namespace ISAT.Client.Services.GenderService
{
    public interface IGenderService
    {
        public List<Gender> Genders { get; set; }
        public Task<List<Gender>> GetGenders();
        public Task<Gender> GetGender(Guid id);
        public Task PutGender(Guid id, Gender gender);
        public Task<Gender> PostGender(Gender gender);
        public Task DeleteGender(Guid id);
    }

}
