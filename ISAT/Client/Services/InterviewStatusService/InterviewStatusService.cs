using System.Net.Http.Json;

namespace ISAT.Client.Services.InterviewStatusService
{
    public class InterviewStatusService : IInterviewStatusService
    {
        private readonly HttpClient _httpClient;

        public InterviewStatusService(HttpClient http)
        {
            this._httpClient = http;
        }
        public List<InterviewStatus> InterviewsStatus { get; set; } = new List<InterviewStatus>();

        public async Task<List<InterviewStatus>> GetInterviewsStatus()
        {
            var result = await _httpClient.GetFromJsonAsync<List<InterviewStatus>>("api/interviewstatus");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Interview Status empty");
        }

        public async Task<InterviewStatus> GetInterviewStatus(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<InterviewStatus>($"api/interviewstatus/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Interview Status not found!");
        }
    }
}
