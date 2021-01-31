using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackspacesInString
{
 /* Постановка задачи
 * Напишите функцию, которая принимает массив из 10 целых чисел (от 0 до 9), 
 * который возвращает строку этих чисел в форме номера телефона.
 * 
 * Пример
 * CreatePhoneNumber.ConvertToPhoneNumber(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 0}) // => returns "(123) 456-7890"
 * 
 */
    public class CreatePhoneNumber
    {
        public static string ConvertToPhoneNumber(int[] numbers)
        {
            return long.Parse(string.Concat(numbers)).ToString("(000) 000-0000");
        }
    }
}
