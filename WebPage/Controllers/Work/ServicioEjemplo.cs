using System;
namespace Personal
{
    public class ServicioEjemplo : ITransientService, IScopedService, ISingletonService
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