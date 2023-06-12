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
            return _people.TryGetValue(id, out var person) ? person : null;
        }

        public IEnumerable<Person> GetAll()
        {
            return _people.Values;
        }

        public void Upsert(Person person)
        {
            _people[person.Id] = person;
        }
    }
}
