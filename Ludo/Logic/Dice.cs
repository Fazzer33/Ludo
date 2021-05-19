using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludo.Model;

namespace Ludo.Logic
{
    public class Dice : IDice
    {
        private int _min;
        private int _max;
        public Dice(int min, int max)
        {
            _min = min;
            _max = max;

        }

        public int Role()
        {
            return new Random().Next(_min, _max + 1);
        }
    }
}
