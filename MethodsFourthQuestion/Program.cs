using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsFourthQuestion
{
    class Program
    {
        // Задача №4.
        // Создать метод, принимающий некоторое количество чисел, выяснить
        // является ли заданная последовательность элементами арифметической или геометрической прогрессии.

        static void Main(string[] args)
        {
            Console.WriteLine("Введите последовательность чисел для определения прогрессии.");

            var progressive = new int[5];

            for (int i = 0; i < progressive.Length; i++)
            {
                Console.Write($"\nВведите {i + 1}-ое число: ");
                int numb = int.Parse(Console.ReadLine());
                progressive[i] = numb;
            }

            int result = Progression(progressive);

            switch (result)
            {
                case 1:
                    Console.WriteLine("Данная последовательность явлется геометрической прогрессией");
                    break;
                case 2:
                    Console.WriteLine("Данная последовательность явлется арифметической прогрессией");
                    break;
                case 3:
                    Console.WriteLine("Данная последовательность явлется одновременно арифметической и геометрической прогрессией");
                    break;
                case 4:
                    Console.WriteLine("Данная последовательность не явлется прогрессией");
                    break;
                case 5:
                    Console.WriteLine("Недостаточно данных для определения принадлежности к прогрессии");
                    break;
            }

            Console.ReadKey();

        }

        /// <summary>
        /// Метод, принимающий некоторое количество целых чисел в качестве параметров или массив целых чисел, определяет является
        /// ли данная последовательность арифметической или геометрической прогрессией. Возвращает целое число со значение 
        /// int res = 1 (Геометрическая прогрессия), int res = 2 (Арифметическая прогрессия), int res = 3 (Арифметическая и геометрическая одновременно),
        /// int res = 4 (Не является прогрессией), int res = 5 (Недостаточно аргументов для определения принадлежности).
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static int Progression(params int[] args)
        {

            int result = 0;
            
            int step = args[1] - args[0]; // коэфициент шага арифметической прогрессии

            var row = args.Length - 1;

            if (args.Length < 2)
            {
                result = 5;
                return result;
            }

            for (int i = 1; i < row; i++)
            {

                if (Math.Abs(args[i]) == Math.Sqrt(args[i - 1] * args[i + 1]) && args[i - 1] != 0) // проверка на принадлежность к геом. прогр.
                {
                    result = 1;

                    if (args[0] == 0 && args[row] != 0)
                    {
                        result = 4;
                    }
                }

                else if (args[i] == (args[i - 1] + args[i + 1]) / 2) // проверка на принадлежность к ариф. прогр.
                {
                    result = 2;

                    if (args[i + 1] - args[i] != step)
                    {
                        result = 4;
                        break;
                    }
                }

                if (Math.Abs(args[i]) == Math.Sqrt(args[i - 1] * args[i + 1]) && args[i] == (args[i - 1] + args[i + 1]) / 2 && args[i - 1] != 0) // проверка на принадлежность к геом. и арифм. прогр.
                {
                    result = 3;

                    if (args[i + 1] - args[i] != step)
                    {
                        result = 4;
                        break;
                    }
                }

                else if (Math.Abs(args[i]) != Math.Sqrt(args[i - 1] * args[i + 1]) && args[i] != (args[i - 1] + args[i + 1]) / 2) // проверка на не принадлежность к прогресиии
                {
                    result = 4;
                    break;
                }

            }

            return result;
        }
    }
}
