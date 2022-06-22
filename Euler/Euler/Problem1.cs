using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    /**
     * If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
     * Find the sum of all the multiples of 3 or 5 below 1000.
    */
    public class Problem1
    {
        public int solve()
        {
            var multiples = new List<int>();
            for(int i = 0; i < 1000; i++)
            {
                if (i % 3 == 0)
                    multiples.Add(i);
                else if (i % 5 == 0)
                    multiples.Add(i);
            }


            return multiples.Sum();
        }
    }
}
