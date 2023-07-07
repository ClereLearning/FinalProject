using ISAT.Shared.Models;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json;

namespace ISAT.Client.Services.GenderService
{
    public class GenderService : IGenderService
    {
        private readonly HttpClient _httpClient;

       
        public GenderService(HttpClient http)
        {
            this._httpClient = http;
        }
       
        public List<Gender> Genders { get; set; } = new List<Gender>();

       

        public async Task<Gender> GetGender(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Gender>($"api/gender/{id}");            
            if (result != null)
            {                
                return result;
            }
            throw new Exception("Gender not found!");
        }

        public async Task<List<Gender>> GetGenders()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Gender>>("api/gender");       
            if (result != null) 
            {
                return result;
            }            
            throw new Exception("Gender empty");
        }

        public async Task<Gender> PostGender(Gender gender)
        {
            var result = await _httpClient.PostAsJsonAsync ("api/gender", gender);
            var response = await result.Content.ReadFromJsonAsync<Gender>();            
            if (response != null)
            {
                return response;
            }
            throw new Exception("Error during Gender creation");
        }

        public async Task PutGender(int id, Gender gender)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/gender/{id}", gender);
            if (result != null)
            {
                return;
            }
            //await setObjResponse(result);            
            throw new Exception("Error during Gender Update");
        }

        private async Task setObjResponse(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Gender>>();
            if ((result != null) && (response != null))
            {
                Genders = response;
            }
        }

        public async Task DeleteGender(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/gender/{id}");            
            if (result != null)
            {
                return;
            }
            throw new Exception("Error during Gender Deleting");
        }

    }
}
