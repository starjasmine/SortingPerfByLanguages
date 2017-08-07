#include <chrono>
#include <cstdio>
#include <cstdlib>

void max_heapify(int * _arrnArr, int _nSizeArr, int _nIndex)
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
		int t = _arrnArr[_nIndex];
		_arrnArr[_nIndex] = _arrnArr[iLargest];
		_arrnArr[iLargest] = t;
		max_heapify(_arrnArr, _nSizeArr, iLargest);
	}
}

void heapsort(int * _arrnArr, int _nSizeArr)
{
	for (int i = _nSizeArr / 2; i >= 0; i--)
	{
		max_heapify(_arrnArr, _nSizeArr, i);
	}
}

int main(void)
{
	const int arrsize = 10;
	int * arrnArr = new int[arrsize];
	
	for (int i = 1; i <= arrsize; i++)
	{
		arrnArr[i - 1] = i;
	}

	auto start = std::chrono::high_resolution_clock::now();
	heapsort(arrnArr, arrsize);
	auto end = std::chrono::high_resolution_clock::now();
	long long llElapsedNanoSec = std::chrono::duration_cast<std::chrono::nanoseconds>(end - start).count();

	//for (int i = 0; i < arrsize; i++)
	//{
	//	printf(" %d", arrnArr[i]);
	//}
	//puts("\n");
	printf("Elapsed: %lld ns\n", llElapsedNanoSec);
	delete[] arrnArr;
	arrnArr = nullptr;

	return EXIT_SUCCESS;
}