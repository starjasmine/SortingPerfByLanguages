using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpHeapsort
{
    class Program
    {

        public int[] MaxHeapify(int[] _arrnArr, int _nSizeArr, int _nIndex)
        {
            int iLeft = (_nIndex << 1) + 1;
            int iRight = iLeft + 1;
            int iLargest = 0;

            if (iLeft < _nSizeArr && _arrnArr[iLeft] > _arrnArr[_nIndex])
            {
                iLargest = iLeft;
            }
            else
            {
                iLargest = _nIndex;
            }

            if (iRight < _nSizeArr && _arrnArr[iRight] > _arrnArr[iLargest])
            {
                iLargest = iRight;
            }

            if (iLargest != _nIndex)
            {
                int t = _arrnArr[iLargest];
                _arrnArr[iLargest] = _arrnArr[_nIndex];
                _arrnArr[_nIndex] = t;

                _arrnArr = this.MaxHeapify(_arrnArr, _nSizeArr, iLargest);
            }

            return _arrnArr;
        }

        public int[] Heapsort(int[] _arrnArr)
        {
            int nSizeArr = _arrnArr.Length;

            for (int i = nSizeArr/2; i >= 0; i--)
            {
                _arrnArr = this.MaxHeapify(_arrnArr, nSizeArr, i);
            }

            return _arrnArr;
        }

        static void Main(string[] args)
        {
            var seq = Enumerable.Range(0, 100000000);
            Program instance = new Program();
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            var result = instance.Heapsort(seq.ToArray<int>());
            stopwatch.Stop();

            //foreach (var item in result)
            //{
            //    Console.Write(item.ToString() + " ");
            //}

            Console.WriteLine("\nElapsed (ns): {0}", stopwatch.Elapsed.TotalMilliseconds * 1000000);
        }
    }
}
