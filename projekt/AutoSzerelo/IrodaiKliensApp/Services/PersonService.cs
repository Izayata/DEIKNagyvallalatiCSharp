using System.Net.Http.Json;
using SzerverApp.Contract;

namespace IrodaiKliensApp.Services
{
    public class PersonService : IPersonService
    {
        //Dependency injection által megkapott HttpClient
        private readonly HttpClient _httpClient;

        public PersonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IEnumerable<PersonCar>> GetAllPeopleAsync()
        {
            return _httpClient.GetFromJsonAsync<IEnumerable<PersonCar>>("People");
        }

        public Task<PersonCar?> GetPersonByIdAsync(int id)
        {
            return _httpClient.GetFromJsonAsync<PersonCar?>($"People/{id}");
        }

        public async Task UpdatePersonAsync(int id, PersonCar person)
        {
            await _httpClient.PutAsJsonAsync($"People/{id}", person);
        }

        public async Task DeletePersonAsync(int id)
        {
            await _httpClient.DeleteAsync($"People/{id}");
        }

        public async Task AddPersonAsync(PersonCar person)
        {
            await _httpClient.PostAsJsonAsync("People", person);
        }
    }
}
