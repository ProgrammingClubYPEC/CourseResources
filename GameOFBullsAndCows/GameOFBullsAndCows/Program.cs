using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Цель задачи: Пользователь, в свою очередь, пытается его отгадать. 

1)Компьютер загадывает четырехзначное число (без повторений цифр). +

2)Пользователь вводит число:+
2.1)если совпадает какая-то цифра и ее позиция, программа выводит слово БЫК и цифру. +
2.2)Если цифра есть, но позиция ее не верная, то пишет слово КОРОВА и цифру. +

3)Параллельно с каждым вводом пользователя числа, программа уменьшает счетчик попыток на 1.
*/


namespace GameOFBullsAndCows
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] RandomArray = new int[4];
            string UserInput;

            RandomArray = GetRandomArray(RandomArray);
            UserInput = GetUserInput();
            
            if(CurrentUserInput(UserInput))
            {
                CheckBulls(RandomArray, UserInput);
                CheckCows(RandomArray, UserInput);
            }

            Console.ReadKey();
        }

        static bool CurrentUserInput(string input)
        {
            char[] numbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            // проверка на числа
            foreach(char item in input)
                foreach(char numb in numbers)
                    if (item != numb)
                        return false;

            // проверка повторимость
            for(int index = 0; index < input.Length - 1; index += 1)
                for(int next = index + 1; next < input.Length; next += 1)
                    if (input[index] != input[next])
                        return false;

            return true;
        }

        static int[] GetRandomArray(int[] array)
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            array[0] = rand.Next(0, 10);

            for (int index = 1, next = rand.Next(0, 10); index < array.Length; next = rand.Next(0, 10))
            {
                if(array[index - 1] != next)
                {
                    array[index] = next;
                    index += 1;
                }
            }

            return array;
        }

        static string GetUserInput()
        {
            Console.WriteLine("Игра БЫКИ и КОРОВЫ\nВведите четырехзначное число");
            string input = Console.ReadLine();

            while(input.Length != 4)
            {
                Console.WriteLine("Число должно быть четырехзначным!!!\nВведите снова четырехзначное число");
                input = Console.ReadLine();
            }

            return input;
        }

        static void CheckBulls(int[] randArr, string input)
        {
            for(int index = 0; index < input.Length; index += 1)
            {
                if(randArr[index] == (Convert.ToInt32(input[index]) - 48))
                    Console.WriteLine($"БЫК {randArr[index]}");
            }
        }

        static void CheckCows(int[] randArr, string input)
        {
            for (int indexB = 0; indexB < input.Length; indexB += 1)
                for (int indexA = 0; indexA < randArr.Length; indexA += 1)
                {
                    if (randArr[indexA] == (Convert.ToInt32(input[indexB]) - 48))
                        Console.WriteLine($"КОРОВА {randArr[indexA]}");
                }
        }
    }
}
