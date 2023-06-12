namespace SzerverApp
{
    public interface IPersonRepository
    {
        void Upsert(Person person);

        void Delete(int id);

        Person Get(int id);

        IEnumerable<Person> GetAll();
    }
}
