namespace SzerverApp
{
    public class PersonRepository : IPersonRepository
    {

        private Dictionary<int, Person> _people = new Dictionary<int, Person>();

        public void Delete(int id)
        {
            _people.Remove(id);
        }

        public Person Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Upsert(Person person)
        {
            _people[person.Id] = person;
        }
    }
}
