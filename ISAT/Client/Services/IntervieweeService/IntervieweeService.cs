using ISAT.Shared.Models;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json;

namespace ISAT.Client.Services.IntervieweeService
{
    public class IntervieweeService : IIntervieweeService
    {
        private readonly HttpClient _httpClient;

        public IntervieweeService(HttpClient http)
        {
            this._httpClient = http;
        }

        public List<Interviewee> Interviewees { get; set; } = new List<Interviewee>();



        public async Task<Interviewee> GetInterviewee(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Interviewee>($"api/interviewee/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Interviewee not found!");
        }

        public async Task<List<Interviewee>> GetInterviewees()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Interviewee>>("api/interviewee");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Interviewee empty");
        }

        public async Task<Interviewee> PostInterviewee(Interviewee interviewee)
        {
            var result = await _httpClient.PostAsJsonAsync("api/interviewee", interviewee);
            var response = await result.Content.ReadFromJsonAsync<Interviewee>();
            if (response != null)
            {
                return response;
            }
            throw new Exception("Error during Interviewee creation");
        }

        public async Task PutInterviewee(int id, Interviewee interviewee)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/interviewee/{id}", interviewee);
            if (result != null)
            {
                return;
            }
            //await setObjResponse(result);            
            throw new Exception("Error during Interviewee Update");
        }

        private async Task setObjResponse(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Interviewee>>();
            if ((result != null) && (response != null))
            {
                Interviewees = response;
            }
        }

        public async Task DeleteInterviewee(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/interviewee/{id}");
            if (result != null)
            {
                return;
            }
            throw new Exception("Error during Interviewee Deleting");
        }
    }
}
