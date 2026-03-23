using System;
using System.Collections.Generic;
using system_books.Models;

class Program
{
    static List<Libro> libros = new List<Libro>();
static List<Usuario> usuarios = new List<Usuario>();
static List<Prestamo> prestamos = new List<Prestamo>();

static int libroId = 1;
static int usuarioId = 1;
static int prestamoId = 1;
    static void Main()
    {
        ShowMainMenu();
    }

    static void Pause()
    {
        Console.WriteLine("\nPresione una tecla...");
        Console.ReadKey();
    }

    static void ActionMsg(string msg)
    {
        Console.WriteLine("\n[INFO] " + msg);
        Pause();
    }

    static string GetOption()
    {
        Console.Write("\nSeleccione una opción: ");
        return Console.ReadLine();
    }

    static void ShowMainMenu()
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear();

           
            Console.WriteLine("===== SISTEMA BIBLIOTECA =====");
            Console.WriteLine("1. Libros");
            Console.WriteLine("2. Usuarios");
            Console.WriteLine("3. Préstamos");
            Console.WriteLine("4. Búsquedas y reportes");
            Console.WriteLine("5. Guardar / Cargar");
            Console.WriteLine("6. Salir");

            switch (GetOption())
            {
                case "1": ShowBooksMenu(); break;
                case "2": ShowUsersMenu(); break;
                case "3": ShowLoansMenu(); break;
                case "4": ShowSearchReportsMenu(); break;
                case "5": ShowPersistenceMenu(); break;
                case "6": exit = ConfirmExit(); break;
                default: ActionMsg("Opción inválida"); break;
           }
        }
    }

    static void ShowBooksMenu()
    {
        bool back = false;

        while (!back)
        {
            Console.Clear();
            Console.WriteLine("=== LIBROS ===");
            Console.WriteLine("1. Registrar");
            Console.WriteLine("2. Listar");
            Console.WriteLine("3. Ver detalle");
            Console.WriteLine("4. Actualizar");
            Console.WriteLine("5. Eliminar");
            Console.WriteLine("0. Volver");

            switch (GetOption())
            {
                case "1": RegisterBook(); break;
                case "2": ListBooksMenu(); break;
                case "3": ViewBookDetail(); break;
                case "4": UpdateBookMenu(); break;
                case "5": DeleteBook(); break;
                case "0": back = true; break;
            }
        }
    }

    static void RegisterBook()
{
    Console.Write("Título: ");
    string titulo = Console.ReadLine();

    Console.Write("Autor: ");
    string autor = Console.ReadLine();

    Console.Write("Año: ");
    int año;
    while (!int.TryParse(Console.ReadLine(), out año))
    {
        Console.Write("Ingrese un año válido: ");
    }

    Console.Write("Categoría: ");
    string categoria = Console.ReadLine();

    Libro libro = new Libro(libroId++, titulo, autor, año, categoria);

    libros.Add(libro);

    ActionMsg("Libro registrado correctamente");
}

    static void DeleteBook() => ActionMsg("No eliminar si está prestado");

    static void ListBooksMenu()
    {
        Console.WriteLine("\n1. Todos\n2. Disponibles\n3. Prestados\n0. Volver");
        switch (GetOption())
        {
            case "1": ListBooksAll(); break;
            case "2": ListBooksAvailable(); break;
            case "3": ListBooksBorrowed(); break;
        }
    }

    static void ListBooksAll()
{
    Console.WriteLine("\n=== LISTA DE LIBROS ===");

    if (libros.Count == 0)
    {
        Console.WriteLine("No hay libros registrados");
    }
    else
    {
        foreach (var libro in libros)
        {
            Console.WriteLine(libro.ResumenCorto());
        }
    }

    Pause();
}

    static void ListBooksAvailable() => ActionMsg("Listar disponibles");
    static void ListBooksBorrowed() => ActionMsg("Listar prestados");
    static void ViewBookDetail()
{
    Console.Write("Ingrese ID del libro: ");
    int id;

    while (!int.TryParse(Console.ReadLine(), out id))
    {
        Console.Write("Ingrese un ID válido: ");
    }

    var libro = libros.Find(l => l.Id == id);

    if (libro != null)
        Console.WriteLine(libro.DetalleCompleto());
    else
        Console.WriteLine("Libro no encontrado");

    Pause();
}

    static void UpdateBookMenu()
    {
        Console.WriteLine("\n1. Editar título\n2. Editar autor\n3. Editar año/categoría\n0. Volver");
        switch (GetOption())
        {
            case "1": ActionMsg("Editar título"); break;
            case "2": ActionMsg("Editar autor"); break;
            case "3": ActionMsg("Editar año/categoría"); break;
        }
    }
    static void ShowUsersMenu()
    {
        bool back = false;

        while (!back)
        {
            Console.Clear();
            Console.WriteLine("=== USUARIOS ===");
            Console.WriteLine("1. Registrar\n2. Listar\n3. Detalle\n4. Actualizar\n5. Eliminar\n0. Volver");

            switch (GetOption())
            {
                case "1": RegisterUser(); break;
                case "2": ListUsers(); break;
                case "3": ViewUserDetail(); break;
                case "4": UpdateUserMenu(); break;
                case "5": DeleteUser(); break;
                case "0": back = true; break;
            }
        }
    }

    static void RegisterUser()
{
    Console.Write("Nombre: ");
    string nombre = Console.ReadLine();

    Console.Write("Contacto: ");
    string contacto = Console.ReadLine();

    Usuario usuario = new Usuario(usuarioId++, nombre, contacto);

    usuarios.Add(usuario);

    ActionMsg("Usuario registrado correctamente");
}

    static void ListUsers()
{
    Console.WriteLine("\n=== LISTA DE USUARIOS ===");

    if (usuarios.Count == 0)
    {
        Console.WriteLine("No hay usuarios registrados");
    }
    else
    {
        foreach (var u in usuarios)
        {
            Console.WriteLine(u.ResumenCorto());
        }
    }

    Pause();
}

    static void ViewUserDetail()
{
    Console.Write("Ingrese ID del usuario: ");
    int id;

    while (!int.TryParse(Console.ReadLine(), out id))
    {
        Console.Write("Ingrese un ID válido: ");
    }

    var usuario = usuarios.Find(u => u.Id == id);

    if (usuario != null)
        Console.WriteLine(usuario.ResumenCorto());
    else
        Console.WriteLine("Usuario no encontrado");

    Pause();
}

    static void DeleteUser() => ActionMsg("No eliminar si tiene préstamos");

    static void UpdateUserMenu()
    {
        Console.WriteLine("\n1. Editar nombre\n2. Editar contacto\n3. Activar/Desactivar\n0. Volver");
        switch (GetOption())
        {
            case "1": ActionMsg("Editar nombre"); break;
            case "2": ActionMsg("Editar contacto"); break;
            case "3": ActionMsg("Cambiar estado"); break;
        }
    }
static void ShowLoansMenu()
    {
        bool back = false;

        while (!back)
        {
            Console.Clear();
            Console.WriteLine("=== PRÉSTAMOS ===");
            Console.WriteLine("1. Crear\n2. Listar\n3. Ver detalle\n4. Devolver\n5. Eliminar\n0. Volver");

            switch (GetOption())
            {
                case "1": CreateLoan(); break;
                case "2": ListLoansMenu(); break;
                case "3": ViewLoanDetail(); break;
                case "4": RegisterReturn(); break;
                case "5": DeleteLoan(); break;
                case "0": back = true; break;
            }
        }
    }

    static void CreateLoan()
{
    Console.Write("ID Usuario: ");
    int userId;
    while (!int.TryParse(Console.ReadLine(), out userId))
    {
        Console.Write("Ingrese un ID válido: ");
    }

    Console.Write("ID Libro: ");
    int bookId;
    while (!int.TryParse(Console.ReadLine(), out bookId))
    {
        Console.Write("Ingrese un ID válido: ");
    }

    var usuario = usuarios.Find(u => u.Id == userId);
    var libro = libros.Find(l => l.Id == bookId);

    if (usuario == null)
    {
        ActionMsg("Usuario no existe");
        return;
    }

    if (!usuario.Activo)
    {
        ActionMsg("Usuario inactivo");
        return;
    }

    if (libro == null)
    {
        ActionMsg("Libro no existe");
        return;
    }

    if (!libro.Disponible)
    {
        ActionMsg("Libro no disponible");
        return;
    }

    Prestamo prestamo = new Prestamo(prestamoId++, bookId, userId);

    prestamos.Add(prestamo);

    libro.Disponible = false;

    ActionMsg("Préstamo creado correctamente");
}
    static void ViewLoanDetail() => ActionMsg("Detalle préstamo");
    static void RegisterReturn()
{
    Console.Write("ID Préstamo: ");
    int id;

    while (!int.TryParse(Console.ReadLine(), out id))
    {
        Console.Write("Ingrese un ID válido: ");
    }

    var prestamo = prestamos.Find(p => p.Id == id);

    if (prestamo == null)
    {
        ActionMsg("Préstamo no encontrado");
        return;
    }

    prestamo.FechaDevolucion = DateTime.Now;
    prestamo.Estado = EstadoPrestamo.Devuelto;

    var libro = libros.Find(l => l.Id == prestamo.LibroId);

    if (libro != null)
        libro.Disponible = true;

    ActionMsg("Devolución realizada correctamente");
}

    static void DeleteLoan() => ActionMsg("Reglas de eliminación");

    static void ListLoansMenu()
    {
        Console.WriteLine("\n1. Todos\n2. Activos\n3. Cerrados\n0. Volver");
        switch (GetOption())
        {
            case "1": ListLoansAll(); break;
            case "2": ActionMsg("Listar activos"); break;
            case "3": ActionMsg("Listar cerrados"); break;
        }
    }

    static void ListLoansAll()
{
    Console.WriteLine("\n=== LISTA DE PRÉSTAMOS ===");

    if (prestamos.Count == 0)
    {
        Console.WriteLine("No hay préstamos");
    }
    else
    {
        foreach (var p in prestamos)
        {
            Console.WriteLine(p.ResumenCorto());
        }
    }

    Pause();
}

static void ShowSearchReportsMenu() => ActionMsg("Búsquedas y reportes");

static void ShowPersistenceMenu() => ActionMsg("Guardar / cargar datos");

    static bool ConfirmExit()
    {
        Console.Write("¿Guardar antes de salir? (S/N): ");
        string r = Console.ReadLine().ToUpper();

        if (r == "S")
            ActionMsg("Guardando datos...");

        return true;
    }

}

