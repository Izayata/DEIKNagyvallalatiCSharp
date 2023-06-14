using SzerverApp.Contract;

namespace IrodaiKliensApp.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetAllPeopleAsync();

        Task<Person?> GetPersonByIdAsync(int id);
    }
}
