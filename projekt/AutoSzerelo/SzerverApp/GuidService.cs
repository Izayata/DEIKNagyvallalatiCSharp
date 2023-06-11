namespace SzerverApp
{
    public class GuidService : IGuidService
    {
        public Guid Guid { get; }

        public GuidService() 
        { 
            Guid = Guid.NewGuid();
        }
    }
}
