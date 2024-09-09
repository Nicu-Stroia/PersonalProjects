using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercitii2
{
    internal class List
    {
       public int sum;
       public float avg;
       public int max;
       public int min;
        List<int> list = new List<int>();
        public List() 
       {
           sum = 0;
           avg = 0;
       }
        public void GenerateList ()
        {
            int nr;
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Eneter in the list: ");
                nr = int.Parse(Console.ReadLine());
                list.Add(nr);
            }
        }
        public void SumList()
        {
            sum = 0;
            foreach(int nr in list)
            {
                sum = sum + nr;
            }
            Console.WriteLine(sum);
        }

        public void AverageList()
        {
            avg = 0;
            int ct = 0;
            foreach (int nr in list)
            {
                avg = avg + nr;
                ct++;
            }
            float rez = avg / ct;
            Console.WriteLine(rez);
        }

        public void MaxList()
        {
            max = list.Max();
            Console.WriteLine(max);
        }
        public void MinList()
        {
            min = list.Min();
            Console.WriteLine(min);
        }
    }
}
