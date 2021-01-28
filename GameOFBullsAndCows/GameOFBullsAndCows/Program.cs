﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Цель задачи: Пользователь, в свою очередь, пытается его отгадать. 

1)Компьютер загадывает четырехзначное число (без повторений цифр). +

1.2)Выбор сложности связанный с попытками и количеством символов загадываемых+

2)Пользователь вводит число:+
2.1)если совпадает какая-то цифра и ее позиция, программа выводит слово БЫК и цифру. +
2.2)Если цифра есть, но позиция ее не верная, то пишет слово КОРОВА и цифру. +

3)Параллельно с каждым вводом пользователя числа, программа уменьшает счетчик попыток на 1.+
*/


namespace GameOFBullsAndCows
{
    class Program
    {
        static void Main(string[] args)
        {
            string UserInput;
            int[] DataForDifficult = new int[2];
            // data[0] = количеству символов в рандомном массиве
            // data[1] = количеству попыток

            DataForDifficult = ChoiceOfDifficulty();
            int[] RandomArray = new int[DataForDifficult[0]];
            int Attempt = DataForDifficult[1];

            RandomArray = GetRandomArray(RandomArray);
            while(Attempt != 0)
            {
                UserInput = GetUserInput(DataForDifficult[0]);

                if (CurrentUserInput(UserInput))
                {
                    CheckBulls(RandomArray, UserInput);
                    CheckCows(RandomArray, UserInput);

                    if (ArrayEqualsInput(RandomArray, UserInput))
                    {
                        Console.WriteLine("Ебать красава, уважуха!");
                        Attempt = 0;
                    }
                    else
                    {
                        Console.WriteLine("Поднатужься челик, осталось немного!");
                        Attempt -= 1;
                    }
                }
                else
                    Console.WriteLine("Всведено не корректное n-значное чило");
            }


            Console.ReadKey();
        }

        private static bool ArrayEqualsInput(int[] randArr, string input)
        {
            for (int index = 0; index < input.Length; index += 1)
            {
                if (randArr[index] != (Convert.ToInt32(input[index]) - 48))
                    return false;
            }

            return true;
        }

        static bool CurrentUserInput(string input)
        {
            // проверка на числа
            for (int index = 0; index < input.Length; index += 1)
                if (!char.IsDigit(input[index]))
                    return false;

            // проверка повторимость
            for(int index = 0; index < input.Length - 1; index += 1)
                for(int next = index + 1; next < input.Length; next += 1)
                    if (input[index].Equals(input[next]))
                        return false;

            return true;
        }

        static int[] ChoiceOfDifficulty()
        {
            int[] data = new int[2];
            int answer = 0;

            Console.WriteLine("Игра БЫКИ и КОРОВЫ\nВыберите уровень сложности:");
            Console.WriteLine("1)Легкий[двухзначное число, 15]\n2)Нормальный[четырехзначное число, 10]\n3)Сложный[шестизначное число, 5]\n4)Конченый[восьмизначное число, 3]\n\n");
            answer = int.Parse(Console.ReadLine());

            switch(answer)
            {
                case 1:
                    data[0] = 2;
                    data[1] = 15;
                    break;
                case 2:
                    data[0] = 4;
                    data[1] = 10;
                    break;
                case 3:
                    data[0] = 6;
                    data[1] = 5;
                    break;
                case 4:
                    data[0] = 8;
                    data[1] = 3;
                    break;
            }

            return data;
        }

        static int[] GetRandomArray(int[] array)
        {
            Random rand = new Random();
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

        static string GetUserInput(int size)
        {
            Console.WriteLine("\nВведите n-значное число");
            string input = Console.ReadLine();

            while(input.Length != size)
            {
                Console.WriteLine("Число должно быть n-значным!!!\nВведите снова n-значное число");
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
