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
          {
            Console.WriteLine("===== SISTEMA BIBLIOTECA =====");
          }
        }
    }
}