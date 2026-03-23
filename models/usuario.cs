namespace system_books.Models
{
    public class Usuario
    {
        public int Id;
        public string Nombre;
        public string Contacto;
        public bool Activo = true;

        public Usuario(int id, string n, string c)
        {
            Id = id; Nombre = n; Contacto = c;
        }

        public string ResumenCorto() => $"[{Id}] {Nombre}";
    }
}
