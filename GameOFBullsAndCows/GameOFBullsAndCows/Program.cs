using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Цель задачи: Пользователь, в свою очередь, пытается его отгадать. 

1)Компьютер загадывает четырехзначное число (без повторений цифр). +

2)Пользователь вводит число: 
2.1)если совпадает какая-то цифра и ее позиция, программа выводит слово БЫК и цифру. 
2.2)Если цифра есть, но позиция ее не верная, то пишет слово КОРОВА и цифру. 

3)Параллельно с каждым вводом пользователя числа, программа уменьшает счетчик попыток на 1.
*/


namespace GameOFBullsAndCows
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] RandomArray = new int[4];
            RandomArray = GetRandomArray(RandomArray);


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
    }
}
