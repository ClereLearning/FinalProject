namespace ISAT.Client.Services.UsersTypeService
{
    public interface IUsersTypeService
    {
        public List<UsersType> UsersTypes { get; set; }
        public Task<List<UsersType>> GetUsersTypes();
        public Task<UsersType> GetUsersType(Guid id);
        public Task PutUsersType(Guid id, UsersType UsersType);
        public Task<UsersType> PostUsersType(UsersType UsersType);
        public Task DeleteUsersType(Guid id);
    }
}
