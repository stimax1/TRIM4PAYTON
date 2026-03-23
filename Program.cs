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
}