using ISAT.Shared.Models;

namespace ISAT.Client.Services.UsersTypeService
{
    public interface IUsersTypeService
    {
        public List<UsersType> UsersTypes { get; set; }
        public Task<List<UsersType>> GetUsersTypes();
        public Task<UsersType> GetUsersType(int id);
        public Task PutUsersType(int id, UsersType UsersType);
        public Task<UsersType> PostUsersType(UsersType UsersType);
        public Task DeleteUsersType(int id);
    }
}
