using System;
using System.Collections.Generic;

class Program
{
    static int currentOctave = 0;
    static List<int[]> octaves = new List<int[]>
    {
        new int[] { 261, 293, 329, 349, 392, 440, 493 }, // Октава 1
        new int[] { 523, 587, 659, 698, 784, 880, 988 }, // Октава 2
        new int[] { 1047, 1175, 1319, 1397, 1568, 1760, 1976 } // Октава 3
    };

    static void Main(string[] args)
    {
        Console.WriteLine("Добро пожаловать в пианино!");

        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1 - Играть на пианино");
            Console.WriteLine("2 - Изменить октаву");
            Console.WriteLine("3 - Выход");
            Console.Write("Введите число: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PlayPiano();
                    break;
                case "2":
                    ChangeOctave();
                    break;
                case "3":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Неверный ввод. Попробуйте снова.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void PlayPiano()
    {
        Console.WriteLine("Нажмите клавиши для воспроизведения звуков пианино.");

        while (true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    break;
                }

                int noteIndex = -1;
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Q:
                        noteIndex = 0;
                        break;
                    case ConsoleKey.W:
                        noteIndex = 1;
                        break;
                    case ConsoleKey.E:
                        noteIndex = 2;
                        break;
                    case ConsoleKey.R:
                        noteIndex = 3;
                        break;
                    case ConsoleKey.T:
                        noteIndex = 4;
                        break;
                    case ConsoleKey.Y:
                        noteIndex = 5;
                        break;
                    case ConsoleKey.U:
                        noteIndex = 6;
                        break;
                    default:
                        break;
                }

                if (noteIndex != -1)
                {
                    int[] octave = octaves[currentOctave];
                    int frequency = octave[noteIndex];

                    Console.WriteLine("Воспроизведение звука с частотой {0} Гц.", frequency);
                    // Воспроизведение звука
                }
            }
        }
    }

    static void ChangeOctave()
    {
        Console.WriteLine("Выберите октаву:");
        Console.WriteLine("1 - Октава 1");
        Console.WriteLine("2 - Октава 2");
        Console.WriteLine("3 - Октава 3");

        while (true)
        {
            Console.Write("Введите число: ");
            string choice = Console.ReadLine();
            if (choice == "1" || choice == "2" || choice == "3")
            {
                currentOctave = int.Parse(choice) - 1;
                Console.WriteLine("Выбрана октава {0}.", currentOctave + 1);
                break;
            }
            else
            {
                Console.WriteLine("Неверный ввод. Попробуйте снова.");
            }
        }
    }
}
