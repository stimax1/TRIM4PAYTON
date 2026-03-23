namespace system_books.Models
{
    public class Prestamo
    {
        public int Id;
        public int LibroId;
        public int UsuarioId;
        public DateTime FechaPrestamo = DateTime.Now;
        public DateTime? FechaDevolucion;
        public EstadoPrestamo Estado = EstadoPrestamo.Activo;

        public Prestamo(int id, int l, int u)
        {
            Id = id; LibroId = l; UsuarioId = u;
        }

        public bool EstaVencido() => (DateTime.Now - FechaPrestamo).Days > 7;
        public int DiasTranscurridos() => (DateTime.Now - FechaPrestamo).Days;

        public string ResumenCorto() => $"Prestamo {Id} - {Estado}";
    }
}
