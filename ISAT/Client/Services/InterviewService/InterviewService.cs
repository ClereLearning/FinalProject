using ISAT.Shared.Models;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json;

namespace ISAT.Client.Services.InterviewService
{
    public class InterviewService : IInterviewService
    {
        private readonly HttpClient _httpClient;


        public InterviewService(HttpClient http)
        {
            this._httpClient = http;
        }

        public List<Interview> Interviews { get; set; } = new List<Interview>();
        public List<Interviewee> Interviewees { get ; set ; }

        public async Task<Interview> GetInterview(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Interview>($"api/interview/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Interview not found!");
        }

        public async Task<List<Interview>> GetInterviews()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Interview>>("api/interview");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Interview empty");
        }

        public async Task<Interview> PostInterview(Interview interview)
        {
            var result = await _httpClient.PostAsJsonAsync("api/interview", interview);
            var response = await result.Content.ReadFromJsonAsync<Interview>();
            if (response != null)
            {
                return response;
            }
            throw new Exception("Error during Interview creation");
        }

        public async Task PutInterview(int id, Interview interview)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/interview/{id}", interview);
            if (result != null)
            {
                return;
            }
            //await setObjResponse(result);            
            throw new Exception("Error during Interview Update");
        }

        private async Task setObjResponse(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Interview>>();
            if ((result != null) && (response != null))
            {
                Interviews = response;
            }
        }

        public async Task DeleteInterview(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/interview/{id}");
            if (result != null)
            {
                return;
            }
            throw new Exception("Error during Interview Deleting");
        }

        public async Task<List<Interviewee>> GetInterviewees()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Interviewee>>("api/interview/interviewees");
            if (result != null)
            {
                return result;
            }
            throw new Exception("interviewees empty");
        }
    }
}
