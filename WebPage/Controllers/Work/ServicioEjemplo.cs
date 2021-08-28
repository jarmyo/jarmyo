using System;
namespace Personal
{
    public class ServicioEjemplo : IScopedService, ISingletonService
    {
        Guid id;
        public ServicioEjemplo()
        {
            id = Guid.NewGuid();
        }
        public Guid GetID()
        {
            return id;
        }
    }
}