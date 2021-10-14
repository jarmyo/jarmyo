namespace Personal
{
    public class ExampleService : IScopedService, ISingletonService
    {
        readonly Guid id;
        public ExampleService()
        {
            id = Guid.NewGuid();
        }
        public Guid GetID()
        {
            return id;
        }
    }
}