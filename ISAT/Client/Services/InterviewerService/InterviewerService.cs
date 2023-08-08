using System.Net.Http.Json;


namespace ISAT.Client.Services.InterviewerService
{
    public class InterviewerService : IInterviewerService
    {
        public List<Interviewer> Interviewers { get; set; }

        private readonly HttpClient _httpClient;

        public InterviewerService(HttpClient http)
        {
            this._httpClient = http;
        }

        public async Task<Interviewer> GetInterviewer(string email)
        {
            var result = await _httpClient.GetFromJsonAsync<Interviewer>($"api/interviewer/{email}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Interviewer not found!");
        }

        public async Task<List<Interviewer>> GetInterviewers()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Interviewer>>("api/interviewer");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Interviewee empty");
        }
    }
}
