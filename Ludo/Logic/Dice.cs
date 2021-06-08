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
        private int _result;

        public int Result
        {
            get { return _result; }
            set { _result = value;  }
        }
        public Dice(int min, int max)
        {
            _min = min;
            _max = max;
            _result = 0;
        }

        public int Role()
        {
            var result = new Random().Next(_min, _max + 1);
            Result = result;
            return result;
        }
    }
}
