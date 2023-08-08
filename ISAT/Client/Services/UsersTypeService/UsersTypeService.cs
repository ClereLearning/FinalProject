using System.Net.Http.Json;

namespace ISAT.Client.Services.UsersTypeService
{
    public class UsersTypeService : IUsersTypeService
    {
        private readonly HttpClient _httpClient;

        public UsersTypeService(HttpClient http)
        {
            this._httpClient = http;
        }
        public List<UsersType> UsersTypes { get; set; } = new List<UsersType>();

        public async Task DeleteUsersType(Guid id)
        {
            var result = await _httpClient.DeleteAsync($"api/userstype/{id}");
            if (result != null)
            {
                return;
            }
            throw new Exception("Error during Users Type Deleting");
        }

        public async Task<UsersType> GetUsersType(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<UsersType>($"api/userstype/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Users Type not found!");
        }

        public async Task<List<UsersType>> GetUsersTypes()
        {
            var result = await _httpClient.GetFromJsonAsync<List<UsersType>>("api/userstype");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Users Type empty");
        }

        public async Task<UsersType> PostUsersType(UsersType usersType)
        {
            var result = await _httpClient.PostAsJsonAsync("api/userstype", usersType);
            var response = await result.Content.ReadFromJsonAsync<UsersType>();
            if (response != null)
            {
                return response;
            }
            throw new Exception("Error during Users Type creation");
        }

        public async Task PutUsersType(Guid id, UsersType usersType)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/userstype/{id}", usersType);
            if (result != null)
            {
                return;
            }
            throw new Exception("Error during Users Type Update");
        }
    }
}
