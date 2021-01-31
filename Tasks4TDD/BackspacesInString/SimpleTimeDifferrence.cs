using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackspacesInString
{
 /* Постановка задачи
 * В этом задании вам будет дана серия времени, когда срабатывает будильник.
 * Ваша задача заключается в опредлении максимального временного интервала между сигналами срабатывания будильника.
 * Каждый будильник начианет звонить в начале соответсвующей минуты и звонит ровно одну минуту.
 * Время в массиве не в хронологическом порядке. Игнорируйте повторяющиеся будильники, если такие есть
 * 
 * Пример
 * solve(["14:51"]) = "23:59"
 * solve(["23:00","04:22","18:05","06:24"]) == "11:40"
 */
    public class SimpleTimeDifferrence
    {
        public static string MaximunTimeInterval(string[] TimesArray)
        {
            List<TimeSpan> SpanPoint = new List<TimeSpan>();

            foreach (string time in TimesArray)
                SpanPoint.Add(TimeSpan.Parse(time));

            SpanPoint.Sort();

            TimeSpan MaxInterval = SpanPoint[0].Add(TimeSpan.FromHours(24)) - SpanPoint[SpanPoint.Count - 1];

            for(int index = 1; index < SpanPoint.Count; index += 1)
            {
                TimeSpan tmp = SpanPoint[index] - SpanPoint[index - 1];
                if (tmp > MaxInterval)
                    MaxInterval = tmp;
            }

            return MaxInterval.Subtract(TimeSpan.FromMinutes(1)).ToString("hh\\:mm");
        }
    }
}
