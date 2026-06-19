namespace mi_proyecto.Domain.Entities
{
    public class Formulario
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; }
        public string Email { get; private set; }
        public DateTime FechaEnvio { get; private set; }

        // Constructor privado — la entidad se crea con factory method
        private Formulario() { }

        public static Formulario Crear(string nombre, string email)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre es obligatorio");

            if (!email.Contains('@'))
                throw new ArgumentException("Email inválido");

            return new Formulario
            {
                Id = Guid.NewGuid(),
                Nombre = nombre,
                Email = email,
                FechaEnvio = DateTime.UtcNow
            };
        }
    }
}
