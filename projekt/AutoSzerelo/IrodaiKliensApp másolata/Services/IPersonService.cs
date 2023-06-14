using SzerverApp.Contract;

namespace IrodaiKliensApp.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonCar>> GetAllPeopleAsync();

        Task<PersonCar?> GetPersonByIdAsync(int id);

        Task UpdatePersonAsync(int id, PersonCar person);

        Task DeletePersonAsync(int id);

        Task AddPersonAsync(PersonCar person);
    }
}
