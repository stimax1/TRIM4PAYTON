namespace system_books.Models
{
    public class Libro
    {
        public int Id;
        public string Titulo;
        public string Autor;
        public int Año;
        public string Categoria;
        public bool Disponible = true;

        public Libro(int id, string t, string a, int an, string c)
        {
            Id = id; Titulo = t; Autor = a; Año = an; Categoria = c;
        }

        public string ResumenCorto() => $"[{Id}] {Titulo} - {(Disponible ? "Disponible" : "Prestado")}";
        public string DetalleCompleto() => $"{Titulo} | {Autor} | {Año} | {Categoria}";
    }
}
