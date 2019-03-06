using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAlg
{
    static class Globals
    {
        public static int[] Randoming(int count)
        {
            var rnd = new Random((int)DateTime.Now.ToBinary());

            var m = new int[count];
            var mk = new double[count];

            for (int i = 0; i < count; i++)
            {
                m[i] = i;
                mk[i] = rnd.NextDouble();
            }

            Array.Sort(mk, m);

            return m;

        }
    }
}
