using System;

class Program
{
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
    
    // ===== LIBROS =====
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
    static void RegisterBook() => ActionMsg("Registrar libro");
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

    static void ListBooksAll() => ActionMsg("Listar todos");
    static void ListBooksAvailable() => ActionMsg("Listar disponibles");
    static void ListBooksBorrowed() => ActionMsg("Listar prestados");
    static void ViewBookDetail() => ActionMsg("Ver detalle por ID");

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

// ===== USUARIOS =====
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

    static void RegisterUser() => ActionMsg("Registrar usuario");
    static void ListUsers() => ActionMsg("Listar usuarios");
    static void ViewUserDetail() => ActionMsg("Detalle usuario");
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


}