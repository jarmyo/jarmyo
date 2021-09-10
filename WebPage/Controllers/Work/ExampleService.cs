using System;
namespace Personal
{
    public class ExampleService : IScopedService, ISingletonService
    {
        Guid id;
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