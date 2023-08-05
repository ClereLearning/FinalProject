using System.Net.Http.Json;

namespace ISAT.Client.Services.SexualOrientationService
{
    public class SexualOrientationService : ISexualOrientationService
    {
        private readonly HttpClient _httpClient;


        public SexualOrientationService(HttpClient http)
        {
            this._httpClient = http;
        }

        public List<SexualOrientation> SexualOrientations { get; set; } = new List<SexualOrientation>();


        public async Task<SexualOrientation> GetSexualOrientation(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<SexualOrientation>($"api/SexualOrientation/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Sexual Orientation not found!");
        }

        public async Task<List<SexualOrientation>> GetSexualOrientations()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SexualOrientation>>("api/SexualOrientation");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Sexual Orientation empty");
        }

        public async Task<SexualOrientation> PostSexualOrientation(SexualOrientation sexualOrientation)
        {
            var result = await _httpClient.PostAsJsonAsync("api/SexualOrientation", sexualOrientation);
            var response = await result.Content.ReadFromJsonAsync<SexualOrientation>();
            if (response != null)
            {
                return response;
            }
            throw new Exception("Error during Sexual Orientation creation");
        }

        public async Task PutSexualOrientation(Guid id, SexualOrientation sexualOrientation)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/SexualOrientation/{id}", sexualOrientation);
            if (result != null)
            {
                return;
            }
            //await setObjResponse(result);            
            throw new Exception("Error during Sexual Orientation Update");
        }

        private async Task setObjResponse(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<SexualOrientation>>();
            if ((result != null) && (response != null))
            {
                SexualOrientations = response;
            }
        }

        public async Task DeleteSexualOrientation(Guid id)
        {
            var result = await _httpClient.DeleteAsync($"api/SexualOrientation/{id}");
            if (result != null)
            {
                return;
            }
            throw new Exception("Error during Sexual Orientation Deleting");
        }
    }
}
