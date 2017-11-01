using System;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using MetalWorker.Cryptography;

namespace Primality_tests
{
    /// <summary>
    /// Лабораторка по алгоритмам проверки на простоту
    /// </summary>
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            Dictionary<string, IPrimalityTester> primalityTesters = new Dictionary<string, IPrimalityTester> {
                { "Тест Ферма", new FermatPT() },
                { "Тест Миллера-Рабина", new MillerRabinPT() },
                { "Простой перебор", new BrutePT()}
            };

            Console.WriteLine("Введите число, которое хотите проверить на простоту:");
            string stringInput = Console.ReadLine();
            BigInteger input = BigInteger.Parse(stringInput);

            Stopwatch sw = new Stopwatch();

            foreach (var tester in primalityTesters){
                Console.Write(tester.Key + ": ");

                //Слишком большие числа простой перебор будет считать вечно:
                if (tester.Key == "Простой перебор" && BigInteger.Log10(input) > 10)
                {
                    Console.WriteLine("число слишком большое");
                    continue;
                }
                sw.Start();
                bool isPrime = tester.Value.IsPrime(input, 5);
                sw.Stop();
                Console.WriteLine((isPrime ? "простое" : "составное") + ", время: " + sw.Elapsed);
            }

            //Дробная часть числа e строкой:
            string eulerFractionString = "718281828459045235360287471352662497757247093699959574966967627724076630353547594" +
                "5713821785251664274274663919320030599218174135966290435729003342952605956307381323286279434907632338298807" +
                "5319525101901157383418793070215408914993488416750924476146066808226480016847741185374234544243710753907774" +
                "4992069551702761838606261331384583000752044933826560297606737113200709328709127443747047230696977209310141" +
                "6928368190255151086574637721112523897844250569536967707854499699679468644549059879316368892300987931277361" +
                "7821542499922957635148220826989519366803318252886939849646510582093923982948879332036250944311730123819706" +
                "841614039701983767932068328237646480429531180232878250981945581530175671736133206981125099";
            for(int i = 0; i < eulerFractionString.Length - 10; ++i)
            {
                string currentTenDigits = eulerFractionString.Substring(i, 10);
                BigInteger a = BigInteger.Parse(currentTenDigits);
                if (primalityTesters["Тест Миллера-Рабина"].IsPrime(a, 5))
                {
                    Console.WriteLine("Первое десятизначное простое число в дробной части числа e: {0}", currentTenDigits);
                    break;
                }
            }
            Console.Write("\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}